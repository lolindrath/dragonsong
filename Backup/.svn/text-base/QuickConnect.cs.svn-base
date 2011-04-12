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
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for QuickConnect.
	/// </summary>
	public class QuickConnect : Form
	{
		private Label label1;
		private Label label2;
		private Button btnConnect;
		private Button btnCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private TextBox txtHost;
		private TextBox txtPort;
		private ErrorProvider errorProvider1;

		private Config config = null;

		/// <summary>
		/// Creates a new <see cref="QuickConnect"/> instance.
		/// </summary>
		public QuickConnect(Config c)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			config = c;
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
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(64, 8);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(184, 20);
			this.txtHost.TabIndex = 0;
			this.txtHost.Text = "planetmud.net";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(64, 40);
			this.txtPort.Name = "txtPort";
			this.txtPort.TabIndex = 1;
			this.txtPort.Text = "5005";
			this.txtPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtPort_Validating);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(48, 80);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "&Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "C&ancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Host:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Port:";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// QuickConnect
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(256, 117);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtHost);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "QuickConnect";
			this.Text = "Quick Connect";
			this.Load += new System.EventHandler(this.QuickConnect_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			if(errorProvider1.GetError(txtPort) != "")
				return;

			FrmMain frm = (FrmMain) this.Owner;

			config.QuickConnectHost = txtHost.Text;
			config.QuickConnectPort = int.Parse(txtPort.Text, CultureInfo.InvariantCulture);
			config.Save();

			frm.Connect(txtHost.Text, int.Parse(txtPort.Text, CultureInfo.InvariantCulture));

			this.Close();
		}

		private void QuickConnect_Load(object sender, EventArgs e)
		{
			txtHost.Text = config.QuickConnectHost;
			txtPort.Text = config.QuickConnectPort.ToString();
		}

		private void txtPort_Validating(object sender, CancelEventArgs e)
		{
			//bad integer check
			int port = -1;
			try
			{
				port = int.Parse(txtPort.Text);
			}
			catch
			{
				errorProvider1.SetError(txtPort, "Ports must be a number between 1 and 65,535");
				//e.Cancel = true;
			}

			//range check
			if(port < 1 || port > 65535)
			{
				errorProvider1.SetError(txtPort, "Ports must be a number between 1 and 65,535");
				//e.Cancel = true;
			}
		}
	}
}