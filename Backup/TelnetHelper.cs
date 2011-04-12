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
using System.Text;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// TelnetHelper does telnet negotation and sub negotiation
	/// </summary>
	internal class TelnetHelper
	{	
		private FrmMain main;

		private const byte BELL = (byte)0x07;
		private const byte IAC = (byte)255;
		private const byte DONT = (byte)254;
		private const byte WONT = (byte)252;
		private const byte WILL = (byte)251;
		private const byte TELOPT_ECHO = (byte)1;


		/// <summary>
		/// Creates a new <see cref="TelnetHelper"/> instance.
		/// </summary>
		/// <param name="m">The parent form</param>
		internal TelnetHelper(FrmMain m)
		{
			main = m;
		}

		/// <summary>
		/// Processs the telnet.
		/// </summary>
		/// <param name="bytes">Bytes yo process</param>
		internal byte[] ProcessTelnet(byte[] bytes)
		{
			byte[] to = new byte[bytes.Length];
			int i = 0;
			int pos = 0;
			
			while(i < bytes.Length)
			{
				byte b = bytes[i];
				
				switch(b)
				{
					case BELL:
					{
						if(main.Config.BellSound != null)
						{
							Win32Helper.PlaySound(main.Config.BellSound);
						}
						else
						{
							Win32Helper.PlaySoundEvent("SystemAsterisk");
						}
						++i;
						break;
					}
					case IAC:
					{
						//MessageBox.Show("In IAC");
						++i;

						if(i < bytes.Length)
						{
							b = bytes[i];

							switch(b)
							{
								case WILL:
								{
									++i;
									if(i < bytes.Length)
									{
										b = bytes[i];
										switch(b)
										{
											case TELOPT_ECHO:
											{
												//FIXME main.Echo = false;
												++i;
												break;
											}
										}
									}
									break;
								}
								case WONT:
								{
									++i;
									if(i < bytes.Length)
									{
										b = bytes[i];
										switch(b)
										{
											case TELOPT_ECHO:
											{
												//FIX ME main.Echo = true;
												++i;
												break;
											}
										}
									}
									break;
								}
							}
						}
						
						break;
					}//case IAC
					default:
					{
						to[pos++] = bytes[i++];
						break;
					}
				}//switch(b)
			}//while

			return to;
		}
	}
}
