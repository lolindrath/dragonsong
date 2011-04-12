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
using System.IO;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for FrmLogViewer.
	/// </summary>
	public class FrmLogViewer : System.Windows.Forms.Form
	{
		private Dragonsong.AnsiEdit ansiLog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmLogViewer"/> instance.
		/// </summary>
		/// <param name="path">Path.</param>
		public FrmLogViewer(string path)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			TextReader tr = File.OpenText(path);

			ansiLog.CurrentFont = new Font("Courier New", 10f);
			ansiLog.BackColor = Color.Black;
			ansiLog.AppendText(tr.ReadToEnd(), Dragonsong.AnsiEdit.MessageType.ANSI);

			tr.Close();

			FileInfo f = new FileInfo(path);
			this.Text = f.Name;
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
			this.ansiLog = new Dragonsong.AnsiEdit();
			this.SuspendLayout();
			// 
			// ansiLog
			// 
			this.ansiLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ansiLog.Echo = true;
			this.ansiLog.Location = new System.Drawing.Point(0, 0);
			this.ansiLog.MaxScroll = -2147483648;
			this.ansiLog.Name = "ansiLog";
			this.ansiLog.ReadOnly = true;
			this.ansiLog.Size = new System.Drawing.Size(592, 373);
			this.ansiLog.TabIndex = 0;
			this.ansiLog.Text = "";
			// 
			// FrmLogViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.ansiLog);
			this.Name = "FrmLogViewer";
			this.Text = "FrmLogViewer";
			this.Load += new System.EventHandler(this.FrmLogViewer_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FrmLogViewer_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
