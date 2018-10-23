using MSI.Afterburner;

namespace AfterburnerServer.Models
{
    public class GPU
    {
        #region PROPERTIES
        /// <summary>
        /// The GPU name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The GPU BIOS Version
        /// </summary>
        public string BiosVersion { get; set; }

        /// <summary>
        /// The current loaded driver version
        /// </summary>
        public string DriverVersion { get; set; }

        /// <summary>
        /// The GPU Family Name
        /// </summary>
        public string Family { get; set; }
        #endregion

        #region CONSTRUCTORS
        public GPU( HardwareMonitorGpuEntry hardwareMonitorGpuEntry )
        {
            Name = hardwareMonitorGpuEntry.Device;
            BiosVersion = hardwareMonitorGpuEntry.BIOS;
            DriverVersion = hardwareMonitorGpuEntry.Driver;
            Family = hardwareMonitorGpuEntry.Family;
        }
        #endregion
    }
}
