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
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for Log.
	/// </summary>
	public class Log : IDisposable
	{
		private TextWriter tw;

		/// <summary>
		/// Creates a new <see cref="Log"/> instance.
		/// </summary>
		/// <param name="host">Host.</param>
		/// <param name="port">Port.</param>
		public Log(string host, int port)
		{
			DirectoryInfo d = Directory.GetParent(Application.UserAppDataPath);
			string logDir = d.FullName + @"\log\" + host + "." + port.ToString() + @"\";
			string logFile = logDir + @"\" + DateTime.Now.ToString("U").Replace(":", ".") + ".log";

			if(!Directory.Exists(logDir))
			{
				Directory.CreateDirectory(logDir);
			}

			while(File.Exists(logFile))
			{
				Thread.Sleep(1000);
				logFile = logDir + @"\" + DateTime.Now.ToString("U").Replace(":", ".") + ".log";
			}
			tw = File.CreateText(logFile);
			WriteLine("--Connected on " + DateTime.Now.ToString("U"));
		}

		/// <summary>
		/// Writes the specified data.
		/// </summary>
		/// <param name="data">Data.</param>
		public void Write(string data)
		{
			tw.Write(data);
		}

		/// <summary>
		/// Writes the line.
		/// </summary>
		/// <param name="data">Data.</param>
		public void WriteLine(string data)
		{
			tw.WriteLine(data);
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		public void Close()
		{
			try
			{
				tw.Write("--Closed on " + DateTime.Now.ToString("U") + "\n\r");
				tw.Flush();
				tw.Close();
			}
			catch
			{
			}
		}

		#region IDisposable Members

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public void Dispose()
		{
			try
			{
				tw.Write("--Closed on " + DateTime.Now.ToString("U") + "\n\r");
				tw.Flush();
				tw.Close();
			}
			catch
			{
			}
		}

		#endregion
	}
}
