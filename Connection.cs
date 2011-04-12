#region "GPL License"

// Dragonsong Version 0.0 - General purpose MUD Client
// Copyright (C) 2004 Andy Williams (lolindrath (.a.t.) lolindrath.com)
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

#endregion

using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TabControl = Crownwood.Magic.Controls.TabControl;
using TabPage = Crownwood.Magic.Controls.TabPage;

namespace Dragonsong
{
	/// <summary>
	/// This represents a single connection to a MUD.
	/// </summary>
	public class Connection
	{
		private TcpClient client;
		private NetworkStream stream;
		private Socket socket;
		private AnsiEdit ansi;
		private Timer timer;
		private bool echo = false;
		private TelnetHelper telnet;
		private TabPage tabPage;
		private FrmMain frmMain;
		private Mud mud = null;
		private Log log = null;

		/// <summary>
		/// Creates a new <see cref="Connection"/> instance.
		/// </summary>
		/// <param name="t">T.</param>
		public Connection(TabPage t)
		{
			tabPage = t;
			ansi = new AnsiEdit();
			ansi.Dock = DockStyle.Fill;
			ansi.BackColor = Color.Black;
			tabPage.Controls.Add(ansi);
			frmMain = (FrmMain) t.Parent.Parent;
			ansi.CurrentFont = frmMain.Config.ClientFont;

			timer = new Timer();
			timer.Interval = 100;
			timer.Tick += new EventHandler(timer_Tick);

			frmMain.Config.ConfigChanged += new ConfigChangedEventHandler(Config_ConfigChanged);

			telnet = new TelnetHelper(frmMain);
		}

		/// <summary>
		/// Gets the client.
		/// </summary>
		/// <value></value>
		public TcpClient Client
		{
			get { return client; }
		}

		/// <summary>
		/// Gets the stream.
		/// </summary>
		/// <value></value>
		public NetworkStream Stream
		{
			get { return stream; }
		}

		/// <summary>
		/// Gets the socket.
		/// </summary>
		/// <value></value>
		public Socket Socket
		{
			get { return socket; }
		}

		/// <summary>
		/// Gets the ANSIEdit.
		/// </summary>
		/// <value></value>
		public AnsiEdit Ansi
		{
			get { return ansi; }
		}

		/// <summary>
		/// Gets the socket timer.
		/// </summary>
		/// <value></value>
		public Timer SocketTimer
		{
			get { return timer; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Connection"/> is echo.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if echo; otherwise, <c>false</c>.
		/// </value>
		public bool Echo
		{
			get { return echo; }
			set { echo = value; }
		}

		private string host;

		/// <summary>
		/// Gets or sets the host.
		/// </summary>
		/// <value></value>
		public string Host
		{
			get { return host; }
			set { host = value; }
		}

		private int port = -1;

		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value></value>
		public int Port
		{
			get { return port; }
			set { port = value; }
		}

		private Socket getSocket(TcpClient c)
		{
            return c.Client;
		}

		/// <summary>
		/// Connects the specified h.
		/// </summary>
		/// <param name="h">H.</param>
		/// <param name="p">P.</param>
		public void Connect(string h, int p)
		{
			Disconnect();
			host = h;
			port = p;
			client = new TcpClient(host, port);
			stream = client.GetStream();
			socket = getSocket(client);
			log = new Log(host, port);
			timer.Start();
		}

		/// <summary>
		/// Connects the specified m.
		/// </summary>
		/// <param name="m">M.</param>
		public void Connect(Mud m)
		{
			mud = m;
			this.Connect(m.Host, m.Port);

			if (m.LoginScript.Length != 0)
			{
				this.SendCommand(m.LoginScript);
			}
		}

		/// <summary>
		/// Connects this instance.
		/// </summary>
		public void Connect()
		{
			if (mud != null)
			{
				Connect(mud);
			}
			else
			{
				Connect(host, port);
			}
		}

		/// <summary>
		/// Disconnects this instance.
		/// </summary>
		public void Disconnect()
		{
			if (socket != null && socket.Connected)
			{
				client.Close();
				timer.Stop();
				log.Close();
				Echo = true;
			}
		}

		/// <summary>
		/// Sends the command.
		/// </summary>
		/// <param name="command">Command.</param>
		public void SendCommand(string command)
		{
			StringBuilder sb = new StringBuilder(command);
			sb.Replace(frmMain.Config.CommandSep.ToString(), "\n\r");
			sb.Append("\n\r");

			byte[] buffer = Encoding.ASCII.GetBytes(sb.ToString());

			try
			{
				log.Write(sb.ToString());
				stream.Write(buffer, 0, buffer.Length);
				ansi.AppendText(sb.ToString(), AnsiEdit.MessageType.KeyboardInput);
			}
			catch (IOException se)
			{
				Disconnect();
				ansi.AppendText("Send Error: " + se.Message, AnsiEdit.MessageType.Error);
				OnDisconnected(EventArgs.Empty);
			}
		}


		private void timer_Tick(object sender, EventArgs e)
		{
			if (socket.Connected && socket.Poll(1, SelectMode.SelectRead))
			{
				byte[] buffer = new byte[client.ReceiveBufferSize];

				int recieved = 0;

				try
				{
					recieved = stream.Read(buffer, 0, client.ReceiveBufferSize);

					if (recieved == 0)
					{
						Disconnect();
						OnDisconnected(EventArgs.Empty);
						return;
					}

					buffer = telnet.ProcessTelnet(buffer);
					string data = Encoding.UTF8.GetString(buffer);
					data = data.Trim(new char[1] {'\0'});

					log.Write(data);

					ansi.AppendText(data, AnsiEdit.MessageType.ANSI);

					//Tell everyone there's new data
					NewDataEventArgs dataEvent = new NewDataEventArgs(data);

					OnNewData(dataEvent);

					if (((TabControl) tabPage.Parent).SelectedTab != tabPage)
					{
						tabPage.ImageIndex = 1;
					}
				}
				catch (SocketException se)
				{
					this.Ansi.AppendText("\nRead Error: " + se.Message + "\n", AnsiEdit.MessageType.Error);
					Disconnect();
					OnDisconnected(EventArgs.Empty);
				}
				catch (IOException ioE)
				{
					this.Ansi.AppendText("\nRead Error: " + ioE.Message + "\n", AnsiEdit.MessageType.Error);
					Disconnect();
					OnDisconnected(EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// This event fires when new data
		/// has arrived at the Connection.
		/// </summary>
		public event NewDataEventHandler NewData;

		/// <summary>
		/// Used to fire the new data event.
		/// </summary>
		/// <param name="e">E.</param>
		protected virtual void OnNewData(NewDataEventArgs e)
		{
			if (NewData != null)
			{
				NewData(this, e);
			}
		}

		/// <summary>
		/// This event fires when the Connection
		/// disconnects.
		/// </summary>
		public event EventHandler Disconnected;

		/// <summary>
		/// Used to fire the disconnected event.
		/// </summary>
		/// <param name="e">E.</param>
		protected virtual void OnDisconnected(EventArgs e)
		{
			if (Disconnected != null)
			{
				Disconnected(this, e);
			}
		}

		private void Config_ConfigChanged(object sender, EventArgs e)
		{
			ansi.CurrentFont = frmMain.Config.ClientFont;
		}
	} //end Connection

	/// <summary>
	/// This event fires when new data
	/// has arrived at the Connection.
	/// </summary>
	public delegate void NewDataEventHandler(object sender, NewDataEventArgs e);

	/// <summary>
	/// This event fires when new data
	/// has arrived at the Connection.
	/// </summary>
	public class NewDataEventArgs : EventArgs
	{
		private string data;

		/// <summary>
		/// Creates a new <see cref="NewDataEventArgs"/> instance.
		/// </summary>
		/// <param name="d">D.</param>
		public NewDataEventArgs(string d)
		{
			data = d;
		}

		/// <summary>
		/// Gets the new incoming data.
		/// </summary>
		/// <value></value>
		public string Data
		{
			get { return data; }
		}
	}
} //end Dragonsong