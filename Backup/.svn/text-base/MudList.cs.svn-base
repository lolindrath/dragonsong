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
	/// This wraps an ArrayList with Save()/Load()
	/// functionality to manage the users' MUDs
	/// </summary>
	public class MudList
	{
		ArrayList mudList = new ArrayList();
		string fileName = null;

		/// <summary>
		/// Creates a new <see cref="MudList"/> instance.
		/// </summary>
		/// <param name="f">F.</param>
		public MudList(string f)
		{
			fileName = f;
		}

		/// <summary>
		/// Gets the list of the muds the user has saved
		/// </summary>
		/// <value></value>
		public ArrayList List
		{
			get { return mudList; }
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			XmlTextWriter w = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
			
			w.WriteStartElement("MUDList");

			foreach(Mud m in mudList)
			{
				w.WriteStartElement("MUD");
				w.WriteElementString("Name", m.Name);
				w.WriteElementString("Host", m.Host);
				w.WriteElementString("Port", m.Port.ToString());
				w.WriteElementString("Description", m.Description);
				w.WriteElementString("LoginScript", m.LoginScript);
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

				Mud m = null;
				while(r.Read())
				{
					r.MoveToContent();
					if(r.NodeType == XmlNodeType.Element)
					{
						if(r.Name == "Name")
						{
							r.MoveToContent();
							m = new Mud(r.ReadString());
						}
						else if(r.Name == "Host")
						{
							r.MoveToContent();
							m.Host = r.ReadString();
						}
						else if(r.Name == "Port")
						{
							r.MoveToContent();
							m.Port = int.Parse(r.ReadString());
						}
						else if(r.Name == "Description")
						{
							r.MoveToContent();
							m.Description = r.ReadString();
						}
						else if(r.Name == "LoginScript")
						{
							r.MoveToContent();
							m.LoginScript = r.ReadString();

							mudList.Add(m);
							m = null;
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

			//if it's a new file give it
			//a default entry
			if(mudList.Count == 0)
			{
				Mud m = new Mud("Realms of Exploration");

				m.Host = "planetmud.net";
				m.Port = 5005;
				m.Description = @" Realms of Exploration is set in the Forgotten Realms world
just after the book trilogy - Return of the Archwizards. 

We are in the Beta pahse of the MUD. Fine tuning everything as well 
as adding in more zones. Though we are primarily a RolePlay MUD we 
offer zones to level in as well. Bsically we hope that if you come 
for the levels you stay for the RolePlay.

The race and class selection is based on AD&D basics with some
very minor variations. Drow and Minotaur are allowed races while the 
core Classes are completely available. I am always open to 
suggestions. I am also working on a useable/workable 'Prestige 
Class' system. The webpage is updated as often as I can.

The world of Realms of Exploration starts in Shadowdale. The world 
is open for Exploration. With just over 1000 rooms we are still 
small but at the same time we have a small but dedicated group of 
builders expanding it daily.

There have been many pieces of code added to the MUD and continue to 
be added and tweaked. One of the current projects is a Hometown 
Starting point. Though we have to add new towns to add hometowns. 

Stop in enjoy the mud talk with the Imms who are on and other 
players who show up at different times. Keep your eyes open for 
people and places that might be part of the roleplay.";

				mudList.Add(m);
			}
				
		}

		/// <summary>
		/// Finds a mud by name
		/// </summary>
		/// <param name="name">Name.</param>
		/// <returns></returns>
		public Mud FindMud(string name)
		{
			foreach(Mud m in mudList)
			{
				if(m.Name == name)
				{
					return m;
				}
			}
			return null;
		}
	}
}
