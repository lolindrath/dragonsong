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
using System.Xml.Serialization;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;

namespace Dragonsong
{
	/// <summary>
	/// Holds a users custom UI preferences.
	/// </summary>
	public class Config
	{

		/// <summary>
		/// Creates a new <see cref="Config"/> instance.
		/// </summary>
		public Config()
		{
			clientFont = new Font("Courier New", 12f);
			inputFont = new Font("Arial", 10f);
		}
		
		private Font clientFont;
		private Font inputFont;
		private char commandSep;
		private int	historySize;
		private string bellSound;
		private string quickConnectHost;
		private int quickConnectPort;

		private bool configExists = false;

		/// <summary>
		/// Gets or sets the client font.
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		public Font ClientFont
		{
			get { return clientFont; }
			set { clientFont = value;}
		}

		/// <summary>
		/// Gets or sets the input font.
		/// </summary>
		/// <value></value>
		[XmlIgnore]
		public Font InputFont
		{
			get { return inputFont; }
			set { inputFont = value;}
		}

		/// <summary>
		/// Gets or sets the serialize font.
		/// </summary>
		/// <value></value>
		public string SerializeFont
		{
			get { return (string)TypeDescriptor.GetConverter(clientFont).ConvertToString(clientFont); }
			set 
			{ 
				clientFont = (Font)TypeDescriptor.GetConverter(clientFont).ConvertFromString(value);
			}
		}

		/// <summary>
		/// Gets or sets the serialize font.
		/// </summary>
		/// <value></value>
		public string SerializeInputFont
		{
			get { return (string)TypeDescriptor.GetConverter(inputFont).ConvertToString(inputFont); }
			set 
			{ 
				inputFont = (Font)TypeDescriptor.GetConverter(inputFont).ConvertFromString(value);
			}
		}

		/// <summary>
		/// Gets or sets the command sep.
		/// </summary>
		/// <value></value>
		public char CommandSep
		{
			get { return commandSep; }
			set { commandSep = value;}
		}

		/// <summary>
		/// Gets or sets the size of the history.
		/// </summary>
		/// <value></value>
		public int HistorySize
		{
			get { return historySize; }
			set { historySize = value;}
		}

		/// <summary>
		/// Gets or sets a value indicating whether [config exists].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [config exists]; otherwise, <c>false</c>.
		/// </value>
		[XmlIgnore]
		public bool ConfigExists
		{
			get { return configExists; }
			set { configExists = value; }
		}

		/// <summary>
		/// Gets or sets the bell sound.
		/// </summary>
		/// <value></value>
		public string BellSound
		{
			get { return bellSound;}
			set { bellSound = value; }
		}

		/// <summary>
		/// Gets or sets the Quick Connect Host
		/// </summary>
		public string QuickConnectHost
		{
			get { return quickConnectHost; }
			set { quickConnectHost = value; }
		}

		/// <summary>
		/// Gets or sets the Quick Connect Port
		/// </summary>
		public int QuickConnectPort
		{
			get { return quickConnectPort; }
			set { quickConnectPort = value; }
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			StreamWriter myWriter = null;
			XmlSerializer mySerializer = null;
			try
			{
				mySerializer = new XmlSerializer(typeof(Config));
				DirectoryInfo d = Directory.GetParent(Application.UserAppDataPath);
				myWriter = new StreamWriter(d.FullName + @"\DragonsongConfig.xml",false);
				mySerializer.Serialize(myWriter, this);
				OnConfigChanged(EventArgs.Empty);
			}
			catch(Exception ex)
			{
				ex = ex;
			}
			finally
			{
				// If the FileStream is open, close it.
				if(myWriter != null)
				{
					myWriter.Close();
				}
			}
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		/// <returns>The loaded configuration</returns>
		public static Config Load()
		{
			XmlSerializer mySerializer = null;
			FileStream myFileStream = null;
			Config c = new Config();

			try
			{
				mySerializer = new XmlSerializer(typeof(Config));
				DirectoryInfo d = Directory.GetParent(Application.UserAppDataPath);
				FileInfo fi = new FileInfo(d.FullName + @"\DragonsongConfig.xml");
				
				if(fi.Exists)
				{
					myFileStream = fi.OpenRead();
					c = (Config)mySerializer.Deserialize(myFileStream);
					c.ConfigExists = true;
				}
				else
				{
					c.LoadDefaults();
				}

				c.OnConfigChanged(EventArgs.Empty);
			}
			catch(Exception ex)
			{
				ex = ex;
			}
			finally
			{
				// If the FileStream is open, close it.
				if(myFileStream != null)
				{
					myFileStream.Close();
				}
			}

			return c;
		}

		/// <summary>
		/// Loads the defaults.
		/// </summary>
		public void LoadDefaults()
		{
			clientFont = new Font("Courier New", 12f);
			inputFont = new Font("Arial", 10f);
			commandSep = ';';
			historySize = 10;
			quickConnectHost = "planetmud.net";
			quickConnectPort = 5005;
		}

		/// <summary>
		/// Fires when the configuration changes.
		/// </summary>
		public event ConfigChangedEventHandler ConfigChanged;
		
		/// <summary>
		/// Fires the config changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected virtual void OnConfigChanged(EventArgs e)
		{
			if(ConfigChanged != null)
			{
				ConfigChanged(this, e);
			}
		}
	}//class Config

	/// <summary>
	/// Fires when the configuration changes.
	/// </summary>
	public delegate void ConfigChangedEventHandler(object sender, EventArgs e);

}//namespace Dragonsong
