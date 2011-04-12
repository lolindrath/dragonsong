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
	/// Summary description for FrmMacroEditor.
	/// </summary>
	public class FrmMacroEditor : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtMacro;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		KeyMappings keyMap;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cboModifier;
		private System.Windows.Forms.ComboBox cboKey;
		private System.Windows.Forms.Button btnDelete;
		object editing = null;

		/// <summary>
		/// Creates a new <see cref="FrmMacroEditor"/> instance.
		/// </summary>
		/// <param name="k">K.</param>
		public FrmMacroEditor(KeyMappings k)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			keyMap = k;
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
			this.txtMacro = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.cboModifier = new System.Windows.Forms.ComboBox();
			this.cboKey = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMacro
			// 
			this.txtMacro.Location = new System.Drawing.Point(16, 64);
			this.txtMacro.Multiline = true;
			this.txtMacro.Name = "txtMacro";
			this.txtMacro.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMacro.Size = new System.Drawing.Size(568, 168);
			this.txtMacro.TabIndex = 2;
			this.txtMacro.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 40);
			this.label4.Name = "label4";
			this.label4.TabIndex = 2;
			this.label4.Text = "Macro:";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(168, 240);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cboModifier
			// 
			this.cboModifier.Location = new System.Drawing.Point(72, 8);
			this.cboModifier.Name = "cboModifier";
			this.cboModifier.Size = new System.Drawing.Size(121, 21);
			this.cboModifier.TabIndex = 0;
			this.cboModifier.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
			// 
			// cboKey
			// 
			this.cboKey.Location = new System.Drawing.Point(256, 8);
			this.cboKey.Name = "cboKey";
			this.cboKey.Size = new System.Drawing.Size(121, 21);
			this.cboKey.TabIndex = 1;
			this.cboKey.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(208, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Key:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Modifier:";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(256, 240);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// FrmMacroEditor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 269);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cboKey);
			this.Controls.Add(this.cboModifier);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtMacro);
			this.Name = "FrmMacroEditor";
			this.Text = "Macro Editor";
			this.Load += new System.EventHandler(this.FrmMacroEditor_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmMacroEditor_Load(object sender, System.EventArgs e)
		{
			cboModifier.Items.Add("None");
			cboModifier.Items.Add(Keys.Alt);
			cboModifier.Items.Add(Keys.Control);
			cboModifier.Items.Add(Keys.Shift);
			cboModifier.SelectedIndex = 0;

			cboKey.Items.Add("None");
			cboKey.Items.Add("F1");
			cboKey.Items.Add("F2");
			cboKey.Items.Add("F3");
			cboKey.Items.Add("F4");
			cboKey.Items.Add("F5");
			cboKey.Items.Add("F6");
			cboKey.Items.Add("F7");
			cboKey.Items.Add("F8");
			cboKey.Items.Add("F9");
			cboKey.Items.Add("F10");
			cboKey.Items.Add("F11");
			cboKey.Items.Add("F12");

			cboKey.SelectedIndex = 0;

			CheckEnabled();
		}

		private void CheckEnabled()
		{
			if(cboKey.SelectedIndex == 0)
			{
				this.txtMacro.Enabled = false;
			}
			else
			{
				this.txtMacro.Enabled = true;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtMacro.Text.Length > 0 && editing != null)
			{
				keyMap.Keys[editing] = txtMacro.Text;
			}
			keyMap.Save();
		}

		private void Combo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cboKey.SelectedItem != null && cboKey.SelectedText != "None")
			{
				if(keyMap.Keys[MakeKeyData()] != null)
				{
					txtMacro.Text = (string)keyMap.Keys[MakeKeyData()];
				}
				else
				{
					txtMacro.Text = "";
				}

				editing = MakeKeyData();
			}

			CheckEnabled();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(cboKey.SelectedItem != null && cboKey.SelectedText != "None")
			{
				keyMap.Keys.Remove(MakeKeyData());
			}

			keyMap.Save();

			CheckEnabled();
		}

		private Keys MakeKeyData()
		{
			Keys mod = (Keys)Enum.Parse(typeof(Keys), cboModifier.SelectedItem.ToString());
			Keys k = (Keys)Enum.Parse(typeof(Keys), cboKey.SelectedItem.ToString());

			return mod | k;
		}
	}
}
