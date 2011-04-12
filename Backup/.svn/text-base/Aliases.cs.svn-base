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
using System.Globalization;

namespace Dragonsong
{
	internal class Aliases
	{
		private Hashtable alias = new Hashtable();
		string fileName = null;

		internal Aliases(string f)
		{
			fileName = f;
		}

		internal Hashtable Alias
		{
			get { return alias; }
		}

		internal void Save()
		{
			XmlTextWriter w = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
			
			w.WriteStartElement("Aliases");

			foreach(string key in alias.Keys)
			{
				w.WriteStartElement("Alias");
				w.WriteElementString("Name", key);
				w.WriteElementString("Macro", alias[key].ToString());
				w.WriteEndElement();
			}

			w.WriteEndElement();

			w.Close();
		}

		internal void Load()
		{
			try
			{
				XmlTextReader r = new XmlTextReader(File.OpenRead(fileName));

				string key = "";
				while(r.Read())
				{
					r.MoveToContent();
					if(r.NodeType == XmlNodeType.Element)
					{
						if(r.Name == "Name")
						{
							r.MoveToContent();
							key = r.ReadString();
						}
						else if(r.Name == "Macro")
						{
							r.MoveToContent();
							alias[key] = r.ReadString();
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

		/// <summary>
		/// If the alias exists it does the replacement
		/// otherwise it returns the input string
		/// </summary>
		/// <param name="input">Input from user.</param>
		/// <returns>Alias if it exists or the original input</returns>
		internal string BuildAlias(string input)
		{
			string[] words = input.Split(new char[] { ' ' });

			if(words.Length > 0 && alias[words[0]] != null)
			{
				string command = (string)alias[words[0]];

				if(words.Length > 1)
				{
					//we have arguments for the
					//alias, try to do replacement
					for(int i = 1; i < words.Length; i++)
					{
						command = command.Replace("%" + i.ToString(CultureInfo.InvariantCulture), words[i]);
					}
				}

				return command;
			}
			else
			{
				return input;
			}
		}
	}


}
