using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AfterburnerServer.Networking;
using MSI.Afterburner;
using MSI.Afterburner.Exceptions;
using System.Runtime.InteropServices;

namespace AfterburnerServer
{
	public partial class MainForm : Form
	{
		#region FIX-ENABLE FORM MOVEMENT WITH NO BORDERS

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{     
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		#endregion

		private Server _server;

		public MainForm( )
		{
			InitializeComponent( );
			
		}

		private void StartServer()
		{
			try
			{
				// Connect to HardwareMonitor shared memory
				var hardwareMonitor = new HardwareMonitor();

				// Start the server
				_server = new Server(hardwareMonitor);
				_server.StartServer();

				Program.ServerIsAlive = true;
				lbServerStatus.Text = "Server broadcasting at " + _server.IPAddress;
			}
			catch (SharedMemoryNotFound)
			{
				lbServerStatus.Text = "Could not find MSI Afterburner";
			}
			catch
			{
				lbServerStatus.Text = "Server initialization failed";
			}
		}

		private void StopServer()
		{
			Program.ServerIsAlive = false;
			lbServerStatus.Text = "";
			_server.StopServer();
			_server = null;
		}

		private void BT_ToggleServer_Click( object sender, EventArgs e )
		{
			if (!Program.ServerIsAlive)
			{
				StartServer();
				btToggleServer.Text = "STOP";
			}
			else
			{
				StopServer();
				btToggleServer.Text = "START";
			}
		}
	}
}
