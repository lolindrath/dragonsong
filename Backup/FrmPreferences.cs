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
	/// Summary description for FrmPreferences.
	/// </summary>
	public class FrmPreferences : Form
	{
		private FontDialog fontDialog1;
		private Label label1;
		private TextBox txtFontDisplay;
		private Button btnFontPick;
		private Button btnCancel;
		private Button btnOK;
		private TabControl tabControl1;
		private TabPage tpGeneral;
		private Label label2;
		private TextBox txtCommandSep;
		private TextBox txtHistSize;
		private Label label3;
		private TextBox txtBellSound;
		private Label label4;
		private Button btnBellSound;
		private OpenFileDialog openFileDialog1;
		private Button btnPlay;
		private ErrorProvider errorProvider1;
		private TextBox txtInputFont;
		private Button btnInputFont;
		private Label label5;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmPreferences"/> instance.
		/// </summary>
		public FrmPreferences()
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
		/// Creates a new <see cref="FrmPreferences"/> instance.
		/// </summary>
		/// <param name="c">C.</param>
		public FrmPreferences(Config c) : this()
		{
			config = c;
		}

		private Config config;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmPreferences));
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFontDisplay = new System.Windows.Forms.TextBox();
			this.btnFontPick = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.btnInputFont = new System.Windows.Forms.Button();
			this.txtInputFont = new System.Windows.Forms.TextBox();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnBellSound = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBellSound = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtHistSize = new System.Windows.Forms.TextBox();
			this.txtCommandSep = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.tabControl1.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(384, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Window Font: (Make sure it\'s a monospaced font like Courier New)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFontDisplay
			// 
			this.txtFontDisplay.Location = new System.Drawing.Point(48, 40);
			this.txtFontDisplay.Name = "txtFontDisplay";
			this.txtFontDisplay.ReadOnly = true;
			this.txtFontDisplay.Size = new System.Drawing.Size(440, 20);
			this.txtFontDisplay.TabIndex = 0;
			this.txtFontDisplay.TabStop = false;
			this.txtFontDisplay.Text = "";
			// 
			// btnFontPick
			// 
			this.btnFontPick.Location = new System.Drawing.Point(496, 40);
			this.btnFontPick.Name = "btnFontPick";
			this.btnFontPick.Size = new System.Drawing.Size(32, 23);
			this.btnFontPick.TabIndex = 0;
			this.btnFontPick.Text = "...";
			this.btnFontPick.Click += new System.EventHandler(this.btnFontPick_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(416, 288);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(88, 288);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpGeneral);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(544, 272);
			this.tabControl1.TabIndex = 5;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.label5);
			this.tpGeneral.Controls.Add(this.btnInputFont);
			this.tpGeneral.Controls.Add(this.txtInputFont);
			this.tpGeneral.Controls.Add(this.btnPlay);
			this.tpGeneral.Controls.Add(this.btnBellSound);
			this.tpGeneral.Controls.Add(this.label4);
			this.tpGeneral.Controls.Add(this.txtBellSound);
			this.tpGeneral.Controls.Add(this.label3);
			this.tpGeneral.Controls.Add(this.txtHistSize);
			this.tpGeneral.Controls.Add(this.txtCommandSep);
			this.tpGeneral.Controls.Add(this.label2);
			this.tpGeneral.Controls.Add(this.label1);
			this.tpGeneral.Controls.Add(this.txtFontDisplay);
			this.tpGeneral.Controls.Add(this.btnFontPick);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Size = new System.Drawing.Size(536, 246);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "General";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 72);
			this.label5.Name = "label5";
			this.label5.TabIndex = 12;
			this.label5.Text = "Input Area Font:";
			// 
			// btnInputFont
			// 
			this.btnInputFont.Location = new System.Drawing.Point(496, 96);
			this.btnInputFont.Name = "btnInputFont";
			this.btnInputFont.Size = new System.Drawing.Size(32, 23);
			this.btnInputFont.TabIndex = 1;
			this.btnInputFont.Text = "...";
			this.btnInputFont.Click += new System.EventHandler(this.btnInputFont_Click);
			// 
			// txtInputFont
			// 
			this.txtInputFont.Location = new System.Drawing.Point(48, 96);
			this.txtInputFont.Name = "txtInputFont";
			this.txtInputFont.ReadOnly = true;
			this.txtInputFont.Size = new System.Drawing.Size(440, 20);
			this.txtInputFont.TabIndex = 0;
			this.txtInputFont.TabStop = false;
			this.txtInputFont.Text = "";
			// 
			// btnPlay
			// 
			this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
			this.btnPlay.Location = new System.Drawing.Point(496, 208);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(32, 23);
			this.btnPlay.TabIndex = 6;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnBellSound
			// 
			this.btnBellSound.Location = new System.Drawing.Point(464, 208);
			this.btnBellSound.Name = "btnBellSound";
			this.btnBellSound.Size = new System.Drawing.Size(32, 23);
			this.btnBellSound.TabIndex = 5;
			this.btnBellSound.Text = "...";
			this.btnBellSound.Click += new System.EventHandler(this.btnBellSound_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(72, 208);
			this.label4.Name = "label4";
			this.label4.TabIndex = 8;
			this.label4.Text = "Bell Sound:";
			// 
			// txtBellSound
			// 
			this.txtBellSound.Location = new System.Drawing.Point(184, 208);
			this.txtBellSound.Name = "txtBellSound";
			this.txtBellSound.Size = new System.Drawing.Size(272, 20);
			this.txtBellSound.TabIndex = 4;
			this.txtBellSound.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Command History Size:";
			// 
			// txtHistSize
			// 
			this.txtHistSize.Location = new System.Drawing.Point(184, 176);
			this.txtHistSize.Name = "txtHistSize";
			this.txtHistSize.Size = new System.Drawing.Size(48, 20);
			this.txtHistSize.TabIndex = 3;
			this.txtHistSize.Text = "";
			this.txtHistSize.Validating += new System.ComponentModel.CancelEventHandler(this.txtHistSize_Validating);
			// 
			// txtCommandSep
			// 
			this.txtCommandSep.Location = new System.Drawing.Point(184, 128);
			this.txtCommandSep.MaxLength = 1;
			this.txtCommandSep.Name = "txtCommandSep";
			this.txtCommandSep.Size = new System.Drawing.Size(24, 20);
			this.txtCommandSep.TabIndex = 2;
			this.txtCommandSep.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Command Seperator Character:";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Wav files (*.wav)|*.wav|All files (*.*) | *.*";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// FrmPreferences
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 317);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Name = "FrmPreferences";
			this.Text = "Preferences";
			this.Load += new System.EventHandler(this.FrmPreferences_Load);
			this.tabControl1.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void btnFontPick_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = config.ClientFont;

			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				txtFontDisplay.Text = fontDialog1.Font.ToString();
				config.ClientFont = fontDialog1.Font;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if(errorProvider1.GetError(txtHistSize) != "")
				return;

			config.HistorySize = int.Parse(txtHistSize.Text, CultureInfo.InvariantCulture);

			if (txtCommandSep.Text == "")
			{
				config.CommandSep = ';';
			}
			else
			{
				config.CommandSep = txtCommandSep.Text[0];
			}
			config.Save();
			this.Close();
		}

		private void FrmPreferences_Load(object sender, EventArgs e)
		{
			txtFontDisplay.Text = config.ClientFont.ToString();
			txtInputFont.Text = config.InputFont.ToString();
			txtCommandSep.Text = config.CommandSep.ToString(CultureInfo.InvariantCulture);
			txtHistSize.Text = config.HistorySize.ToString(CultureInfo.InvariantCulture);
			txtBellSound.Text = config.BellSound;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnBellSound_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				config.BellSound = openFileDialog1.FileName;
				txtBellSound.Text = config.BellSound;
			}
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			Win32Helper.PlaySound(txtBellSound.Text);
		}

		private void txtHistSize_Validating(object sender, CancelEventArgs e)
		{
			int hist = -1;
			try
			{
				hist = int.Parse(txtHistSize.Text);
			}
			catch
			{
				errorProvider1.SetError(txtHistSize, "History Size must be a whole number");
				return;
			}

			if(hist < 0)
			{
				errorProvider1.SetError(txtHistSize, "History Size must be greater than zero");
			}
		}

		private void btnInputFont_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = config.InputFont;

			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				txtInputFont.Text = fontDialog1.Font.ToString();
				config.InputFont = fontDialog1.Font;
			}
		}
	}
}