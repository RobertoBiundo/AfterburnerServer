using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AfterburnerServer.Models;
using MQTTnet;
using MQTTnet.Server;
using MSI.Afterburner;

namespace AfterburnerServer.Networking
{
    public class Server
    {
        #region CONSTANTS
        // EVENTS
        private const string TOPIC_GENERAL = "GENERAL";
        private const string TOPIC_REQUESTS = "REQUESTS";
        private const string TOPIC_GPU_LIST = "GPU_LIST";
        private const string TOPIC_STATS = "STATS";

        // MESSAGES
        private const string MESSAGE_GET_GPU_LIST = "GET_GPU_LIST";

        // OTHER
        private const string INFO_THREAD_NAME = "PeriodicInfoThread";
        private const int STAT_INTERVAL = 1000;
        #endregion


        #region VARIABLES
        private static HardwareMonitor _hardwareMonitor;
        private static IMqttServer _mqttServer;
        private static Thread _infoPublishThread;
        #endregion


        #region CONSTRUCTORS
        public Server( string url, HardwareMonitor hardwareMonitor )
        {
            _hardwareMonitor = hardwareMonitor;

            var options = new MqttServerOptions();
            _mqttServer = new MqttFactory().CreateMqttServer();
            _mqttServer.StartAsync(options);
            
            RegisterForRequests( );
            RegisterPeriodicInfoPublish();

        }

        public void StopServer()
        {
            _mqttServer.StopAsync();
        }
        #endregion


        #region SERVER EVENTS AND METHODS
        private static void SendMessage( string topicName, string message )
        {
            var package = new MqttApplicationMessageBuilder()
                .WithTopic(topicName)
                .WithPayload(message)
                .WithExactlyOnceQoS()
                .Build();

            _mqttServer.PublishAsync(package);
        }

        private static void SendGpuListMessage( )
        {
            var gpuList = new List<GPU>( );
            for ( var i = 0; i < _hardwareMonitor.Header.GpuEntryCount; i++ )
            {
                gpuList.Add( new GPU( _hardwareMonitor.GpuEntries[ i ] ) );
            }
            SendMessage( TOPIC_GPU_LIST, Newtonsoft.Json.JsonConvert.SerializeObject( gpuList ) );
        }

        private static void RegisterForRequests( )
        {
            _mqttServer.ApplicationMessageReceived += (s, e) =>
            {
                var topic = e.ApplicationMessage.Topic;
                var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                if (topic != TOPIC_REQUESTS) return;

                switch ( message )
                {
                    case MESSAGE_GET_GPU_LIST:
                        SendGpuListMessage( );
                        break;
                    default:
                        break;
                }
            };
        }
        
        private static void RegisterPeriodicInfoPublish( )
        {
            _infoPublishThread = new Thread( PublishInfo )
            {
                Priority = ThreadPriority.Normal,
                Name = INFO_THREAD_NAME
            };
            _infoPublishThread.Start( );
        }
        #endregion


        #region THREAD METHODS
        private static void PublishInfo()
        {
            while (Program.Alive)
            {
                try
                {
                    var statList = new List<Stat>();

                    foreach (var hardwareMonitorEntry in _hardwareMonitor.Entries)
                    {
                        statList.Add(new Stat(hardwareMonitorEntry));
                        _hardwareMonitor.ReloadEntry(hardwareMonitorEntry);
                    }

                    SendMessage( TOPIC_STATS, Newtonsoft.Json.JsonConvert.SerializeObject( statList ) );
                    
                    Thread.Sleep(STAT_INTERVAL);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    if (exception.InnerException != null)
                        Console.WriteLine(exception.InnerException.Message);
                }
            }
        }
        #endregion
    }
}
