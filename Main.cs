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
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Genghis.Windows.Forms;
using TabControl = Crownwood.Magic.Controls.TabControl;
using TabPage = Crownwood.Magic.Controls.TabPage;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmMain : Form
	{
		private IContainer components;

		private Panel panel1;
		private StatusBarPanel statusBarPanel1;
		private MenuItem mnuFile;
		private MenuItem mnuConnect;
		private MenuItem mnuSep1;
		private MenuItem mnuExit;
		private MenuItem mnuDisconnect;
		private StatusBar staMain;
		private Button btnSend;
		private MainMenu mnuMain;
		private ComboBox cmbInput;
		private MenuItem mnuHelp;
		private MenuItem mnuAbout;
		private MenuItem mnuPreferences;
		private ImageList imageList1;
		private TabControl tcMUD;
		private Splitter splitter1;

		private WindowSerializer windowSerializer;
		private MenuItem mnuConnectionManager;
		private MudList mudList;
		private MenuItem mnuSettings;
		private MenuItem mnuMacroEditor;
		private KeyMappings keyMap;
		private MenuItem mnuAliasEditor;
		private MenuItem mnuSaveCurrentSession;
		private SaveFileDialog saveFileDialog1;
		private MenuItem mnuOpenLog;
		private OpenFileDialog openFileDialog1;
		private Aliases aliases;

        /// <summary>
        /// used to pass in a host and port that will be connected to at startup
        /// </summary>
        public string pendingHost;
        /// <summary>
        /// used to pass in a host and port that will be connected to at startup
        /// </summary>
        public int pendingPort = -1;

		/// <summary>
		/// Creates a new <see cref="FrmMain"/> instance.
		/// </summary>
		public FrmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			windowSerializer = new WindowSerializer(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuConnectionManager = new System.Windows.Forms.MenuItem();
            this.mnuConnect = new System.Windows.Forms.MenuItem();
            this.mnuDisconnect = new System.Windows.Forms.MenuItem();
            this.mnuSaveCurrentSession = new System.Windows.Forms.MenuItem();
            this.mnuOpenLog = new System.Windows.Forms.MenuItem();
            this.mnuSep1 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuSettings = new System.Windows.Forms.MenuItem();
            this.mnuPreferences = new System.Windows.Forms.MenuItem();
            this.mnuMacroEditor = new System.Windows.Forms.MenuItem();
            this.mnuAliasEditor = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.staMain = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tcMUD = new Crownwood.Magic.Controls.TabControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.Location = new System.Drawing.Point(656, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmbInput);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 28);
            this.panel1.TabIndex = 3;
            // 
            // cmbInput
            // 
            this.cmbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInput.Location = new System.Drawing.Point(3, 1);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(640, 24);
            this.cmbInput.TabIndex = 0;
            this.cmbInput.Resize += new System.EventHandler(this.cmbInput_Resize);
            this.cmbInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInput_KeyPress);
            this.cmbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInput_KeyDown);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 439);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(744, 3);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuSettings,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuConnectionManager,
            this.mnuConnect,
            this.mnuDisconnect,
            this.mnuSaveCurrentSession,
            this.mnuOpenLog,
            this.mnuSep1,
            this.mnuExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuConnectionManager
            // 
            this.mnuConnectionManager.Index = 0;
            this.mnuConnectionManager.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.mnuConnectionManager.Text = "&Connection Manager..";
            this.mnuConnectionManager.Click += new System.EventHandler(this.mnuConnectionManager_Click);
            // 
            // mnuConnect
            // 
            this.mnuConnect.Index = 1;
            this.mnuConnect.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mnuConnect.Text = "&Quick Connect...";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.Index = 2;
            this.mnuDisconnect.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.mnuDisconnect.Text = "&Disconnect";
            this.mnuDisconnect.Click += new System.EventHandler(this.mnuDisconnect_Click);
            // 
            // mnuSaveCurrentSession
            // 
            this.mnuSaveCurrentSession.Index = 3;
            this.mnuSaveCurrentSession.Text = "&Save Current Session...";
            this.mnuSaveCurrentSession.Click += new System.EventHandler(this.mnuSaveCurrentSession_Click);
            // 
            // mnuOpenLog
            // 
            this.mnuOpenLog.Index = 4;
            this.mnuOpenLog.Text = "&Open Log...";
            this.mnuOpenLog.Click += new System.EventHandler(this.mnuOpenLog_Click);
            // 
            // mnuSep1
            // 
            this.mnuSep1.Index = 5;
            this.mnuSep1.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 6;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Index = 1;
            this.mnuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPreferences,
            this.mnuMacroEditor,
            this.mnuAliasEditor});
            this.mnuSettings.Text = "&Settings";
            // 
            // mnuPreferences
            // 
            this.mnuPreferences.Index = 0;
            this.mnuPreferences.Text = "&Preferences...";
            this.mnuPreferences.Click += new System.EventHandler(this.mnuPreferences_Click);
            // 
            // mnuMacroEditor
            // 
            this.mnuMacroEditor.Index = 1;
            this.mnuMacroEditor.Text = "&Macro Editor...";
            this.mnuMacroEditor.Click += new System.EventHandler(this.mnuMacroEditor_Click);
            // 
            // mnuAliasEditor
            // 
            this.mnuAliasEditor.Index = 2;
            this.mnuAliasEditor.Text = "&Alias Editor...";
            this.mnuAliasEditor.Click += new System.EventHandler(this.mnuAliasEditor_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 2;
            this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAbout});
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 0;
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // staMain
            // 
            this.staMain.Location = new System.Drawing.Point(0, 417);
            this.staMain.Name = "staMain";
            this.staMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.staMain.ShowPanels = true;
            this.staMain.Size = new System.Drawing.Size(744, 22);
            this.staMain.TabIndex = 5;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Use File -> Connect to Connect to a MUD";
            this.statusBarPanel1.Width = 727;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tcMUD
            // 
            this.tcMUD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMUD.IDEPixelArea = true;
            this.tcMUD.ImageList = this.imageList1;
            this.tcMUD.Location = new System.Drawing.Point(0, 0);
            this.tcMUD.Name = "tcMUD";
            this.tcMUD.ShowArrows = true;
            this.tcMUD.ShowClose = true;
            this.tcMUD.Size = new System.Drawing.Size(744, 375);
            this.tcMUD.TabIndex = 6;
            this.tcMUD.SelectionChanged += new System.EventHandler(this.tcMUD_SelectionChanged);
            this.tcMUD.ClosePressed += new System.EventHandler(this.tcMUD_ClosePressed);
            this.tcMUD.Click += new System.EventHandler(this.tcMUD_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "rtf";
            this.saveFileDialog1.Filter = "Rich Text Files (*.rtf)|*.rtf|All files (*.*)|*.*";
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 442);
            this.Controls.Add(this.tcMUD);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FrmMain";
            this.Text = "Dragonsong";
            this.Deactivate += new System.EventHandler(this.FrmMain_Deactivate);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			SplashScreen ss = new SplashScreen(typeof (FrmSplash));

			//Long running Init stuff
			FrmMain frm = new FrmMain();

			ss.Close(frm, 300);

            if (args.Length == 2)
            {
                int port = -1;
                try
                {
                    port = int.Parse(args[1]);

                    if (port > 0 && port < 65535)
                    {
                        frm.pendingHost = args[0];
                        frm.pendingPort = port;
                    }
                }
                catch
                {

                }
            }

			Application.Run(frm);
		}

		private Icon appIcon = BuildIcon("D", new Font("Courier New", 24f, FontStyle.Bold), Color.Gold, Color.DarkBlue);
		private Icon dataIcon = BuildIcon("D", new Font("Courier New", 24f, FontStyle.Bold), Color.Gold, Color.DarkRed);

		private Config config;

		private Hashtable conns = new Hashtable();

		private void FrmMain_Load(object sender, EventArgs e)
		{
			config = Config.Load();
			config.ConfigChanged += new ConfigChangedEventHandler(config_ConfigChanged);
			DirectoryInfo d = Directory.GetParent(Application.UserAppDataPath);

			mudList = new MudList(d.FullName + @"\MudList.xml");
			mudList.Load();
			keyMap = new KeyMappings(d.FullName + @"\KeyMapping.xml");
			keyMap.Load();
			aliases = new Aliases(d.FullName + @"\Aliases.xml");
			aliases.Load();

			this.Icon = appIcon;

			this.Focus();

			FrmMain_Resize(null, null);
			this.imageList1.Images.Add(appIcon);
			this.imageList1.Images.Add(dataIcon);

			this.cmbInput.Font = config.InputFont;

            if (pendingHost != null && pendingPort > 0)
            {
                Connect(pendingHost, pendingPort);
            }
		}

		private static Icon BuildIcon(string text, Font f, Color fore, Color back)
		{
			Bitmap bitmap = new Bitmap(32, 32);

			Brush foreBrush = new SolidBrush(fore);

			Graphics g = Graphics.FromImage(bitmap);

			if (back != Color.Empty)
			{
				Brush backBrush = new SolidBrush(back);
				g.FillRectangle(backBrush, 0, 0, 32, 32);
			}

			g.DrawString(text, f, foreBrush, 0, 0);

			IntPtr hIcon = bitmap.GetHicon();
			Icon icon = Icon.FromHandle(hIcon);

			return icon;
		}

		private void FrmMain_Resize(object sender, EventArgs e)
		{
            //panel1.Location = new Point(panel1.Location.X, this.Height - panel1.Height - staMain.Height - 50);
            //panel1.Width = this.Width - 10;
            //tcMUD.Height = this.Height - panel1.Height - 50 - staMain.Height;
            //tcMUD.Width = this.Width - 10;
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			if (conns.Count != 0)
			{
				foreach (Connection c in conns.Values)
				{
					c.Disconnect();
				}
			}

			config.Save();
			this.Close();
		}


		private void mnuConnect_Click(object sender, EventArgs e)
		{
			QuickConnect frm = new QuickConnect(config);
			frm.ShowDialog(this);
		}

		private void mnuDisconnect_Click(object sender, EventArgs e)
		{
			Disconnect();
		}

		private void rchANSI_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		private bool Active = false;

		private void FrmMain_Activated(object sender, EventArgs e)
		{
			Active = true;
			this.Icon = appIcon;
		}

		private void FrmMain_Deactivate(object sender, EventArgs e)
		{
			Active = false;
		}

		private void mnuAbout_Click(object sender, EventArgs e)
		{
			FrmAbout frmAbout = new FrmAbout();
			frmAbout.ShowDialog();
			frmAbout.Close();
		}

		private bool echo = true;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="FrmMain"/> is echo.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if echo; otherwise, <c>false</c>.
		/// </value>
		public bool Echo
		{
			get { return echo; }
			set { echo = value; }
		}

		private void cmbInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter && tcMUD.SelectedTab != null)
			{
				Connection c = (Connection) conns[tcMUD.SelectedTab];

				if (c == null)
					return;

				string command = aliases.BuildAlias(cmbInput.Text);

				c.SendCommand(command);

				cmbInput.Items.Insert(0, cmbInput.Text);

				while (cmbInput.Items.Count > config.HistorySize)
				{
					//too many items in the history, chop it off
					cmbInput.Items.RemoveAt(cmbInput.Items.Count - 1);
				}

				cmbInput.SelectAll();
				e.Handled = true;
			}
			else if (e.KeyChar == (char) Keys.Escape)
			{
				int result = cmbInput.FindString(cmbInput.Text);

				if (result != -1)
				{
					int partial = cmbInput.Text.Length;

					//cmbInput.Focus();
					cmbInput.Text = cmbInput.Items[result].ToString();

					cmbInput.SelectionStart = partial;
					cmbInput.SelectionLength = cmbInput.Text.Length - partial;

					e.Handled = true;
				}
			}

			if (numPadPressed)
			{
				e.Handled = true;
				numPadPressed = false;
			}
		}

		private void mnuPreferences_Click(object sender, EventArgs e)
		{
			FrmPreferences frm = new FrmPreferences(config);
			frm.ShowDialog();
			config = frm.Config;
		}

		/// <summary>
		/// Connects to the specified host.
		/// </summary>
		/// <param name="host">Host.</param>
		/// <param name="port">Port.</param>
		public void Connect(string host, int port)
		{
			TabPage t = new TabPage(host + ":" + port.ToString(CultureInfo.InvariantCulture));
			t.StartFocus = cmbInput;
			t.ImageIndex = 0;
			tcMUD.SelectedTab = tcMUD.TabPages.Add(t);
			Connection c = new Connection(t);
			c.NewData += new NewDataEventHandler(c_NewData);
			c.Disconnected += new EventHandler(c_Disconnected);
			c.Ansi.LinkClicked += new LinkClickedEventHandler(rchANSI_LinkClicked);
			c.Ansi.ReadOnly = true;
			conns.Add(t, c);

			try
			{
				c.Connect(host, port);
			}
			catch (SocketException se)
			{
				c.Ansi.AppendText("Connection Error: " + se.Message, AnsiEdit.MessageType.Error);
			}
		}

		/// <summary>
		/// Connects using the Muds data
		/// </summary>
		/// <param name="m">M.</param>
		public void Connect(Mud m)
		{
			TabPage t = new TabPage(m.Name);
			t.StartFocus = cmbInput;
			t.ImageIndex = 0;
			tcMUD.SelectedTab = tcMUD.TabPages.Add(t);
			Connection c = new Connection(t);
			c.NewData += new NewDataEventHandler(c_NewData);
			c.Disconnected += new EventHandler(c_Disconnected);
			c.Ansi.LinkClicked += new LinkClickedEventHandler(rchANSI_LinkClicked);
			c.Ansi.ReadOnly = true;
			conns.Add(t, c);

			try
			{
				c.Connect(m);
			}
			catch (SocketException se)
			{
				c.Ansi.AppendText("Connection Error: " + se.Message, AnsiEdit.MessageType.Error);
			}
		}

		/// <summary>
		/// Disconnects the active tab's connection.
		/// </summary>
		public void Disconnect()
		{
			if (tcMUD.SelectedTab != null)
			{
				Disconnect(tcMUD.SelectedTab);
			}
		}

		/// <summary>
		/// Disconnects by using a tab.
		/// </summary>
		/// <param name="t">T.</param>
		public void Disconnect(TabPage t)
		{
			Connection c = (Connection) conns[t];

			if (c != null)
			{
				conns.Remove(t);
				tcMUD.TabPages.Remove(t);
				c.Disconnect();
				c = null;
			}
		}

		/// <summary>
		/// Disconnects the specified connection.
		/// </summary>
		/// <param name="connection">Connection.</param>
		public void Disconnect(Connection connection)
		{
			TabPage tab = null;
			foreach (TabPage t in conns.Keys)
			{
				if (conns[t] == connection)
				{
					tab = t;
				}
			}

			if (tab != null)
			{
				Disconnect(tab);
			}
		}

		/// <summary>
		/// Reconnects the specified connection.
		/// </summary>
		/// <param name="c">C.</param>
		public void Reconnect(Connection c)
		{
			try
			{
				c.Connect();
			}
			catch (SocketException se)
			{
				c.Ansi.AppendText("Connection Error: " + se.Message, AnsiEdit.MessageType.Error);
			}
		}

		private void ShowDisconnectDialog(Connection c)
		{
			FrmDisconnected frm = new FrmDisconnected();
			frm.Connection = c;
			frm.ShowDialog(this);
		}

		private void tcMUD_ClosePressed(object sender, EventArgs e)
		{
			Disconnect();
		}

		private void tcMUD_SelectionChanged(object sender, EventArgs e)
		{
			Debug.WriteLine("Yup");
			if (tcMUD.SelectedTab != null)
			{
				tcMUD.SelectedTab.ImageIndex = 0;
				this.Text = "Dragonsong " + tcMUD.SelectedTab.Title;
			}

			cmbInput.Focus();
		}

		private void tcMUD_Click(object sender, EventArgs e)
		{
			cmbInput.Focus();
		}

		private void c_NewData(object sender, NewDataEventArgs e)
		{
			if (Active)
			{
				this.Icon = appIcon;
			}
			else
			{
				this.Icon = dataIcon;
			}
		}

		private bool numPadPressed = false;

		private void cmbInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (tcMUD.SelectedTab != null)
			{
				Connection c = (Connection) conns[tcMUD.SelectedTab];

				switch (e.KeyCode)
				{
					case Keys.NumPad1:
						{
							c.SendCommand("northwest");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad2:
						{
							c.SendCommand("south");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad3:
						{
							c.SendCommand("southeast");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad4:
						{
							c.SendCommand("west");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad5:
						{
							c.SendCommand("look");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad6:
						{
							c.SendCommand("east");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad7:
						{
							c.SendCommand("northwest");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad8:
						{
							c.SendCommand("north");
							numPadPressed = true;
							break;
						}

					case Keys.NumPad9:
						{
							c.SendCommand("northeast");
							numPadPressed = true;
							break;
						}
				} //end switch
			} //end if
		}

		/// <summary>
		/// Gets or sets the config.
		/// </summary>
		/// <value></value>
		public Config Config
		{
			get { return config; }
			set { config = value; }
		}

		/// <summary>
		/// Gets or set the MudList
		/// </summary>
		public MudList MudList
		{
			get { return mudList; }
			set { mudList = value; }
		}

		private void c_Disconnected(object sender, EventArgs e)
		{
			ShowDisconnectDialog((Connection) sender);
		}

		private void mnuConnectionManager_Click(object sender, EventArgs e)
		{
			FrmConnectionManager frm = new FrmConnectionManager(mudList);
			frm.ShowDialog(this);
		}

		/// <summary>
		/// Processs the dialog key.
		/// </summary>
		/// <param name="keyData">Key data.</param>
		/// <returns></returns>
		protected override bool ProcessDialogKey(Keys keyData)
		{
			string macro = (string) keyMap.Keys[keyData];

			if (macro != null && tcMUD.SelectedTab != null)
			{
				((Connection) conns[tcMUD.SelectedTab]).SendCommand(macro);
				return true;
			}
			else
			{
				return base.ProcessDialogKey(keyData);
			}
		}

		private void mnuMacroEditor_Click(object sender, EventArgs e)
		{
			FrmMacroEditor frm = new FrmMacroEditor(keyMap);
			frm.ShowDialog(this);
		}

		private void mnuAliasEditor_Click(object sender, EventArgs e)
		{
			FrmAliases frm = new FrmAliases(aliases);
			frm.ShowDialog(this);
		}

		/// <summary>
		/// Saves the current session to a file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void mnuSaveCurrentSession_Click(object sender, EventArgs e)
		{
			if (tcMUD.SelectedTab != null && saveFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				Connection conn = (Connection) conns[tcMUD.SelectedTab];

				conn.Ansi.SaveFile(saveFileDialog1.FileName);

				MessageBox.Show("Session Saved!");
			}
		}

		private void mnuOpenLog_Click(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Directory.GetParent(Application.UserAppDataPath).FullName + @"\log\";
			openFileDialog1.Filter = "Log Files (*.log)|*.log|All Files (*.*)|*.*";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				FrmLogViewer frm = new FrmLogViewer(openFileDialog1.FileName);
				frm.Show();
			}
		}

		private void config_ConfigChanged(object sender, EventArgs e)
		{
			cmbInput.Font = config.InputFont;
		}

		private void cmbInput_Resize(object sender, EventArgs e)
		{
			panel1.Height = cmbInput.Height + cmbInput.Top;
			this.FrmMain_Resize(null, null);
		}
	}
}