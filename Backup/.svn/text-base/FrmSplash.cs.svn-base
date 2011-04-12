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

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for FrmSplash.
	/// </summary>
	public class FrmSplash : Form
	{
		private LinkLabel linkHomepage;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary>
		/// Creates a new <see cref="FrmSplash"/> instance.
		/// </summary>
		public FrmSplash()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmSplash));
			this.linkHomepage = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// linkHomepage
			// 
			this.linkHomepage.BackColor = System.Drawing.Color.Transparent;
			this.linkHomepage.LinkColor = System.Drawing.Color.Transparent;
			this.linkHomepage.Location = new System.Drawing.Point(32, 576);
			this.linkHomepage.Name = "linkHomepage";
			this.linkHomepage.Size = new System.Drawing.Size(352, 23);
			this.linkHomepage.TabIndex = 0;
			this.linkHomepage.TabStop = true;
			this.linkHomepage.Text = "000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
				"000000000000000000000";
			this.linkHomepage.Click += new System.EventHandler(this.linkHomepage_Click);
			this.linkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHomepage_LinkClicked);
			// 
			// FrmSplash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(424, 597);
			this.Controls.Add(this.linkHomepage);
			this.Name = "FrmSplash";
			this.Text = "FrmSplash";
			this.ResumeLayout(false);

		}

		#endregion

		private void linkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//Process.Start("http://www.lolindrath.com/");
		}

		private void linkHomepage_Click(object sender, System.EventArgs e)
		{
			Process.Start("http://www.lolindrath.com/");
		}
	}
}