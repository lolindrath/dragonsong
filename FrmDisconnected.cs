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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for FrmDisconnected.
	/// </summary>
	public class FrmDisconnected : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnReconnect;
		private System.Windows.Forms.Button btnNewConnection;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnQuickConnect;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmDisconnected"/> instance.
		/// </summary>
		public FrmDisconnected()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.btnReconnect = new System.Windows.Forms.Button();
			this.btnNewConnection = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnQuickConnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(8, 15);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnReconnect
			// 
			this.btnReconnect.Location = new System.Drawing.Point(88, 15);
			this.btnReconnect.Name = "btnReconnect";
			this.btnReconnect.TabIndex = 1;
			this.btnReconnect.Text = "&Reconnect";
			this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
			// 
			// btnNewConnection
			// 
			this.btnNewConnection.Location = new System.Drawing.Point(265, 16);
			this.btnNewConnection.Name = "btnNewConnection";
			this.btnNewConnection.Size = new System.Drawing.Size(128, 23);
			this.btnNewConnection.TabIndex = 2;
			this.btnNewConnection.Text = "&Connection Manager";
			this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(398, 16);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnQuickConnect
			// 
			this.btnQuickConnect.Location = new System.Drawing.Point(168, 16);
			this.btnQuickConnect.Name = "btnQuickConnect";
			this.btnQuickConnect.Size = new System.Drawing.Size(92, 23);
			this.btnQuickConnect.TabIndex = 4;
			this.btnQuickConnect.Text = "&Quick Connect";
			this.btnQuickConnect.Click += new System.EventHandler(this.btnQuickConnect_Click);
			// 
			// FrmDisconnected
			// 
			this.AcceptButton = this.btnReconnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(482, 53);
			this.ControlBox = false;
			this.Controls.Add(this.btnQuickConnect);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnNewConnection);
			this.Controls.Add(this.btnReconnect);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmDisconnected";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Disconnected...";
			this.Load += new System.EventHandler(this.FrmDisconnected_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			((FrmMain)this.Owner).Disconnect(connection);
			this.Close();
		}

		private void btnNewConnection_Click(object sender, System.EventArgs e)
		{
			FrmConnectionManager frm = new FrmConnectionManager(((FrmMain)this.Owner).MudList);
			frm.ShowDialog(this.Owner);
			this.Close();
		}

		private void btnReconnect_Click(object sender, System.EventArgs e)
		{
			((FrmMain)this.Owner).Reconnect(connection);
			this.Close();
		}

		private void FrmDisconnected_Load(object sender, System.EventArgs e)
		{

		}

		private Connection connection;

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnQuickConnect_Click(object sender, System.EventArgs e)
		{
			QuickConnect frm = new QuickConnect(((FrmMain)this.Owner).Config);
			frm.ShowDialog(this.Owner);
			this.Close();
		}
	
		/// <summary>
		/// Gets or sets the connection.
		/// </summary>
		/// <value></value>
		public Connection Connection
		{
			get { return connection; }
			set { connection = value; }
		}
	}
}
