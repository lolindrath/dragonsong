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
	/// Summary description for FrmMudName.
	/// </summary>
	public class FrmMudName : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtMudName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmMudName"/> instance.
		/// </summary>
		public FrmMudName()
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtMudName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAdd.Location = new System.Drawing.Point(96, 56);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtMudName
			// 
			this.txtMudName.Location = new System.Drawing.Point(8, 24);
			this.txtMudName.Name = "txtMudName";
			this.txtMudName.Size = new System.Drawing.Size(336, 20);
			this.txtMudName.TabIndex = 0;
			this.txtMudName.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(176, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter the MUDs name below:";
			// 
			// FrmMudName
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(360, 82);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtMudName);
			this.Controls.Add(this.btnAdd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmMudName";
			this.Text = "Enter MUD Name";
			this.Load += new System.EventHandler(this.FrmMudName_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmMudName_Load(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <returns></returns>
		public static string ShowForm()
		{
			FrmMudName frm = new FrmMudName();

			frm.ShowDialog();
			string name = frm.txtMudName.Text;
			frm.Dispose();

			return name;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			txtMudName.Text = null;
			//this.Close();
		}
	}
}
