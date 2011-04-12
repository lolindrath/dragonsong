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
	/// Summary description for FrmConnectionManager.
	/// </summary>
	public class FrmConnectionManager : Form
	{
		private ListBox lstMudNames;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox txtPort;
		private TextBox txtHost;
		private TextBox txtDescription;
		private Label label4;
		private Label label5;
		private TextBox txtLoginScript;
		private Button btnConnect;
		private Button btnAdd;
		private Button btnDelete;
		private Button btnRename;
		private Button btnExit;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private Button btnSave;
		private ErrorProvider errorProvider1;

		private MudList mudList;

		/// <summary>
		/// Creates a new <see cref="FrmConnectionManager"/> instance.
		/// </summary>
		/// <param name="m">M.</param>
		public FrmConnectionManager(MudList m)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			mudList = m;
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
			this.lstMudNames = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLoginScript = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnRename = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// lstMudNames
			// 
			this.lstMudNames.Location = new System.Drawing.Point(16, 32);
			this.lstMudNames.Name = "lstMudNames";
			this.lstMudNames.Size = new System.Drawing.Size(160, 290);
			this.lstMudNames.TabIndex = 10;
			this.lstMudNames.DoubleClick += new System.EventHandler(this.lstMudNames_DoubleClick);
			this.lstMudNames.SelectedIndexChanged += new System.EventHandler(this.lstMudNames_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "MUD Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(192, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Host:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Port:";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(240, 56);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(64, 20);
			this.txtPort.TabIndex = 1;
			this.txtPort.Text = "";
			this.txtPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtPort_Validating);
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(240, 16);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(232, 20);
			this.txtHost.TabIndex = 0;
			this.txtHost.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.AcceptsReturn = true;
			this.txtDescription.Location = new System.Drawing.Point(184, 112);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(424, 96);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(184, 88);
			this.label4.Name = "label4";
			this.label4.TabIndex = 7;
			this.label4.Text = "Description:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(184, 216);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(368, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Output to send on connect: (i.e. the login script)";
			// 
			// txtLoginScript
			// 
			this.txtLoginScript.AcceptsReturn = true;
			this.txtLoginScript.Location = new System.Drawing.Point(184, 240);
			this.txtLoginScript.Multiline = true;
			this.txtLoginScript.Name = "txtLoginScript";
			this.txtLoginScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLoginScript.Size = new System.Drawing.Size(424, 80);
			this.txtLoginScript.TabIndex = 3;
			this.txtLoginScript.Text = "";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(16, 336);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.TabIndex = 4;
			this.btnConnect.Text = "&Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(120, 336);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(328, 336);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 7;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnRename
			// 
			this.btnRename.Location = new System.Drawing.Point(432, 336);
			this.btnRename.Name = "btnRename";
			this.btnRename.TabIndex = 8;
			this.btnRename.Text = "&Rename";
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(536, 336);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 9;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(224, 336);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// FrmConnectionManager
			// 
			this.AcceptButton = this.btnConnect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(616, 373);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnRename);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.txtLoginScript);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstMudNames);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmConnectionManager";
			this.Text = "Connection Manager";
			this.Load += new System.EventHandler(this.FrmConnectionManager_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private void FrmConnectionManager_Load(object sender, EventArgs e)
		{
			RefreshList();

			if (lstMudNames.Items.Count > 0)
			{
				lstMudNames.SelectedIndex = 0;
			}

			CheckEnabled();
		}

		private void CheckEnabled()
		{
			if (lstMudNames.Items.Count == 0)
			{
				txtHost.Enabled = false;
				txtPort.Enabled = false;
				txtDescription.Enabled = false;
				txtLoginScript.Enabled = false;
			}
			else
			{
				txtHost.Enabled = true;
				txtPort.Enabled = true;
				txtDescription.Enabled = true;
				txtLoginScript.Enabled = true;
			}
		}

		private void RefreshList()
		{
			lstMudNames.Items.Clear();
			foreach (Mud m in mudList.List)
			{
				lstMudNames.Items.Add(m.Name);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			string name = FrmMudName.ShowForm();

			if (name != null)
			{
				mudList.List.Add(new Mud(name));
				lstMudNames.SelectedIndex = lstMudNames.Items.Add(name);
				CheckEnabled();
				txtHost.Focus();
			}
		}

		private void lstMudNames_SelectedIndexChanged(object sender, EventArgs e)
		{
			Mud m = mudList.FindMud(lstMudNames.SelectedItem.ToString());

			if (m != null)
			{
				LoadMUD(m);
			}
		}

		private void LoadMUD(Mud m)
		{
			txtHost.Text = m.Host;
			txtPort.Text = m.Port.ToString(CultureInfo.InvariantCulture);
			txtDescription.Text = m.Description;
			txtLoginScript.Text = m.LoginScript;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (lstMudNames.SelectedItem != null)
			{
				Mud m = mudList.FindMud(lstMudNames.SelectedItem.ToString());

				if (m != null && txtPort.Text.Length != 0)
				{
					m.Host = txtHost.Text;
					m.Port = int.Parse(txtPort.Text, CultureInfo.InvariantCulture);
					m.Description = txtDescription.Text;
					m.LoginScript = txtLoginScript.Text;
					mudList.Save();
				}
			}
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			btnSave_Click(null, null);
			if (lstMudNames.SelectedItem != null)
			{
				Mud m = mudList.FindMud(lstMudNames.SelectedItem.ToString());

				if (m != null)
				{
					((FrmMain) this.Owner).Connect(m);
				}

				this.Close();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRename_Click(object sender, EventArgs e)
		{
			if (lstMudNames.SelectedItem != null)
			{
				Mud m = mudList.FindMud(lstMudNames.SelectedItem.ToString());

				if (m != null)
				{
					string name = FrmMudName.ShowForm();
					m.Name = name;
					mudList.Save();
					RefreshList();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (lstMudNames.SelectedItem != null)
			{
				Mud m = mudList.FindMud(lstMudNames.SelectedItem.ToString());

				if (m != null)
				{
					mudList.List.Remove(m);
					mudList.Save();
					RefreshList();
					LoadMUD(new Mud(""));
				}
			}

			CheckEnabled();
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
			if (port < 1 || port > 65535)
			{
				errorProvider1.SetError(txtPort, "Ports must be a number between 1 and 65,535");
				//e.Cancel = true;
			}
		}

		private void lstMudNames_DoubleClick(object sender, EventArgs e)
		{
			btnConnect_Click(null, null);
		}
	}
}