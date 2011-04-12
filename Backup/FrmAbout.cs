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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for FrmAbout.
	/// </summary>
	public class FrmAbout : Form
	{
		private Label label1;
		private Button btnOK;
		private LinkLabel linkLabel1;
		private Label label3;
		private TabControl tabControl1;
		private TabPage tbLicense;
		private TextBox txtLicense;
		private TabPage tbChangeLog;
		private TextBox txtChangeLog;
		private System.Windows.Forms.LinkLabel linkLabel2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmAbout"/> instance.
		/// </summary>
		public FrmAbout()
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbChangeLog = new System.Windows.Forms.TabPage();
			this.txtChangeLog = new System.Windows.Forms.TextBox();
			this.tbLicense = new System.Windows.Forms.TabPage();
			this.txtLicense = new System.Windows.Forms.TextBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.tabControl1.SuspendLayout();
			this.tbChangeLog.SuspendLayout();
			this.tbLicense.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.DarkGreen;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(456, 56);
			this.label1.TabIndex = 1;
			this.label1.Text = "Dragonsong";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(184, 296);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(272, 296);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(192, 23);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Dragonsong uses MagicLibrary 1.7.4";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 288);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 40);
			this.label3.TabIndex = 5;
			this.label3.Text = " Portions copyright 2002-2004 The Genghis Group (http://www.genghisgroup.com/).";
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabControl1.Controls.Add(this.tbChangeLog);
			this.tabControl1.Controls.Add(this.tbLicense);
			this.tabControl1.Location = new System.Drawing.Point(0, 80);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(472, 200);
			this.tabControl1.TabIndex = 0;
			// 
			// tbChangeLog
			// 
			this.tbChangeLog.Controls.Add(this.txtChangeLog);
			this.tbChangeLog.Location = new System.Drawing.Point(23, 4);
			this.tbChangeLog.Name = "tbChangeLog";
			this.tbChangeLog.Size = new System.Drawing.Size(445, 192);
			this.tbChangeLog.TabIndex = 1;
			this.tbChangeLog.Text = "ChangeLog";
			// 
			// txtChangeLog
			// 
			this.txtChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtChangeLog.Location = new System.Drawing.Point(0, 0);
			this.txtChangeLog.Multiline = true;
			this.txtChangeLog.Name = "txtChangeLog";
			this.txtChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtChangeLog.Size = new System.Drawing.Size(445, 192);
			this.txtChangeLog.TabIndex = 1;
			this.txtChangeLog.Text = "";
			// 
			// tbLicense
			// 
			this.tbLicense.Controls.Add(this.txtLicense);
			this.tbLicense.Location = new System.Drawing.Point(23, 4);
			this.tbLicense.Name = "tbLicense";
			this.tbLicense.Size = new System.Drawing.Size(445, 192);
			this.tbLicense.TabIndex = 0;
			this.tbLicense.Text = "GPL";
			// 
			// txtLicense
			// 
			this.txtLicense.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtLicense.Location = new System.Drawing.Point(-6, 0);
			this.txtLicense.Multiline = true;
			this.txtLicense.Name = "txtLicense";
			this.txtLicense.ReadOnly = true;
			this.txtLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLicense.Size = new System.Drawing.Size(456, 192);
			this.txtLicense.TabIndex = 2;
			this.txtLicense.Text = "";
			// 
			// linkLabel2
			// 
			this.linkLabel2.Location = new System.Drawing.Point(72, 64);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(304, 16);
			this.linkLabel2.TabIndex = 6;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Copyright (C) Lolindrath (www.lolindrath.com)";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// FrmAbout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(474, 333);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmAbout";
			this.Text = "Dragonsong by Lolindrath";
			this.Load += new System.EventHandler(this.FrmAbout_Load);
			this.tabControl1.ResumeLayout(false);
			this.tbChangeLog.ResumeLayout(false);
			this.tbLicense.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void FrmAbout_Load(object sender, EventArgs e)
		{
			txtLicense.Text = FileFromAssembly("Dragonsong.GPL.txt");
			txtLicense.SelectionStart = 0;
			txtChangeLog.Text = FileFromAssembly("Dragonsong.ChangeLog.txt");
			txtChangeLog.SelectionStart = 0;
		}

		private string FileFromAssembly(string resource)
		{
			StreamReader sr = new StreamReader(GetType().Assembly.GetManifestResourceStream(resource));

			string text = sr.ReadToEnd();

			sr.Close();

			return text;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.dotnetmagic.com");

			linkLabel1.LinkVisited = true;
		}

		private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.lolindrath.com");
			linkLabel2.LinkVisited = true;
		}
	}
}