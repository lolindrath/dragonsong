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
	/// Summary description for FrmAliases.
	/// </summary>
	public class FrmAliases : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAliasName;
		private System.Windows.Forms.Button btnAddAlias;
		private System.Windows.Forms.ListBox lstAliases;
		private System.Windows.Forms.TextBox txtAlias;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnDelete;

		private Aliases aliases;

		internal FrmAliases(Aliases a)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			aliases = a;
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
			this.lstAliases = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAddAlias = new System.Windows.Forms.Button();
			this.txtAliasName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAlias = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstAliases
			// 
			this.lstAliases.Location = new System.Drawing.Point(8, 24);
			this.lstAliases.Name = "lstAliases";
			this.lstAliases.Size = new System.Drawing.Size(160, 303);
			this.lstAliases.TabIndex = 0;
			this.lstAliases.SelectedIndexChanged += new System.EventHandler(this.lstAliases_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnAddAlias);
			this.groupBox1.Controls.Add(this.txtAliasName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(232, 336);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(344, 56);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Add New Alias";
			// 
			// btnAddAlias
			// 
			this.btnAddAlias.Location = new System.Drawing.Point(256, 24);
			this.btnAddAlias.Name = "btnAddAlias";
			this.btnAddAlias.TabIndex = 5;
			this.btnAddAlias.Text = "&Add Alias";
			this.btnAddAlias.Click += new System.EventHandler(this.btnAddAlias_Click);
			// 
			// txtAliasName
			// 
			this.txtAliasName.Location = new System.Drawing.Point(88, 24);
			this.txtAliasName.Name = "txtAliasName";
			this.txtAliasName.Size = new System.Drawing.Size(152, 20);
			this.txtAliasName.TabIndex = 4;
			this.txtAliasName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Alias Name:";
			// 
			// txtAlias
			// 
			this.txtAlias.AcceptsReturn = true;
			this.txtAlias.Location = new System.Drawing.Point(184, 24);
			this.txtAlias.Multiline = true;
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtAlias.Size = new System.Drawing.Size(392, 304);
			this.txtAlias.TabIndex = 1;
			this.txtAlias.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "Aliases:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 0);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Alias Script:";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(8, 360);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(88, 360);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// FrmAliases
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(586, 399);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAlias);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lstAliases);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAliases";
			this.Text = "FrmAliases";
			this.Load += new System.EventHandler(this.FrmAliases_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmAliases_Load(object sender, System.EventArgs e)
		{
			LoadAliases();

			if(lstAliases.Items.Count > 0)
			{
				lstAliases.SelectedIndex = 0;
			}
		}

		private void CheckEnabled()
		{
			if(lstAliases.Items.Count == 0)
			{
				this.txtAlias.Enabled = false;
			}
			else
			{
				this.txtAlias.Enabled = true;
			}
		}

		private void LoadAliases()
		{
			lstAliases.Items.Clear();

			foreach(string a in aliases.Alias.Keys)
			{
				lstAliases.Items.Add(a);
			}
		}

		private void lstAliases_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(aliases.Alias[lstAliases.SelectedItem] != null)
			{
				txtAlias.Text = (string)aliases.Alias[lstAliases.SelectedItem];
			}
			else
			{
				txtAlias.Text = "";
			}
		}

		private void btnAddAlias_Click(object sender, System.EventArgs e)
		{
			lstAliases.SelectedIndex = lstAliases.Items.Add(txtAliasName.Text);
			txtAliasName.Text = "";

			CheckEnabled();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtAlias.Text.Length > 0)
			{
				aliases.Alias[lstAliases.SelectedItem] = txtAlias.Text;
			}

			aliases.Save();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(lstAliases.SelectedItem != null)
			{
				aliases.Alias.Remove(lstAliases.SelectedItem);
			}
			aliases.Save();

			CheckEnabled();
		}
	}
}
