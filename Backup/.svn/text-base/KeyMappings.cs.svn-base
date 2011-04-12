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
using System.Collections;
using System.IO;
using System.Xml;

namespace Dragonsong
{
	/// <summary>
	/// This class wraps a hashtable with Save()/Load()
	/// functionality for the keys a user has mapped to
	/// certain macros. Only F1-F12 plus the modifiers
	/// Alt, Shift and Ctrl are possible.
	/// </summary>
	[Serializable]
	public class KeyMappings
	{
		private Hashtable keys = new Hashtable();
		string fileName = null;

		/// <summary>
		/// Creates a new <see cref="KeyMappings"/> instance.
		/// </summary>
		/// <param name="f">F.</param>
		public KeyMappings(string f)
		{
			fileName = f;
		}

		/// <summary>
		/// Gets the keys and the macros they map to.
		/// </summary>
		/// <value></value>
		public Hashtable Keys
		{
			get { return keys; }
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			XmlTextWriter w = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
			
			w.WriteStartElement("KeyMappings");

			foreach(System.Windows.Forms.Keys key in keys.Keys)
			{
				w.WriteStartElement("Key");
				w.WriteElementString("Name", key.ToString());
				w.WriteElementString("Macro", keys[key].ToString());
				w.WriteEndElement();
			}

			w.WriteEndElement();

			w.Close();
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public void Load()
		{
			try
			{
				XmlTextReader r = new XmlTextReader(File.OpenRead(fileName));

				object key = null;
				while(r.Read())
				{
					r.MoveToContent();
					if(r.NodeType == XmlNodeType.Element)
					{
						if(r.Name == "Name")
						{
							r.MoveToContent();
							key = Enum.Parse(typeof(System.Windows.Forms.Keys), r.ReadString());
						}
						else if(r.Name == "Macro")
						{
							r.MoveToContent();
							keys[key] = r.ReadString();
						}
					}
				}
			}
			catch(XmlException e)
			{
				e = e;
			}
			catch(FileNotFoundException e)
			{
				//this just means this is the first time
				//the list has ever been loaded
				e = e;
			}
		}
	}
}
