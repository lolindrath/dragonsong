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
using System.Runtime.InteropServices;
using System.IO;

namespace Dragonsong
{
	/// <summary>
	/// Summary description for Win32Helper.
	/// </summary>
	public sealed class Win32Helper
	{
		public const int SB_CTL = 2;
		public const int SB_VERT = 1;
		public const int SB_BOTTOM = 7;
		public const int WM_VSCROLL = 0x115;
		public const int SB_THUMBTRACK = 5;
		public const int SB_THUMBPOSITION = 4;

		public const int EM_SETEVENTMASK = 1073;
		public const int EM_REPLACESEL = 0xC2;
		public const int WM_SETREDRAW = 11;
        public const int EM_SETSCROLLPOS = 0x0400 + 222; 

		public const int SIF_RANGE   = 0x0001;  
		public const int SIF_PAGE    = 0x0002;  
		public const int SIF_POS     = 0x0004; 
		public const int SIF_TRACKPOS  = 0x0010;  
		public const int SIF_ALL = SIF_TRACKPOS | SIF_POS | SIF_RANGE | SIF_PAGE;

		private Win32Helper()
		{
		}

		/// <summary>
		/// Sends the message.
		/// </summary>
		/// <param name="hWnd">H WND.</param>
		/// <param name="Msg">MSG.</param>
		/// <param name="wParam">W param.</param>
		/// <param name="lParam">L param.</param>
		/// <returns></returns>
		[DllImport("user32.dll")] 
		public static extern int SendMessage( 
			int hWnd, // handle to destination window 
			uint Msg, // message 
			int wParam, // first message parameter 
			int lParam // second message parameter 
			);

		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(int hWnd, Int32 msg,
			Int32 wParam, string lParam);

        [DllImport("user32", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, POINT lParam);

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
            this.y = y;
            }
        } 

		[DllImport("user32")] public static extern int SetWindowText(int hwnd, string lpString);

		/// <summary>
		/// Gets the scroll info.
		/// </summary>
		/// <param name="hwnd">HWND.</param>
		/// <param name="n">N.</param>
		/// <param name="lpScrollInfo">Lp scroll info.</param>
		/// <returns></returns>
		[DllImport("user32")] 
		public static extern int GetScrollInfo(int hwnd, int n, ref SCROLLINFO lpScrollInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(int hWnd, int nBar);

        [DllImport("user32.dll")]
        public static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos,
           out int lpMaxPos);

		public enum SND
		{
			SND_SYNC         = 0x0000  ,/* play synchronously (default) */
			SND_ASYNC        = 0x0001 , /* play asynchronously */
			SND_NODEFAULT    = 0x0002 , /* silence (!default) if sound not found */
			SND_MEMORY       = 0x0004 , /* pszSound points to a memory file */
			SND_LOOP         = 0x0008 , /* loop the sound until next sndPlaySound */
			SND_NOSTOP       = 0x0010 , /* don't stop any currently playing sound */
			SND_NOWAIT       = 0x00002000, /* don't wait if the driver is busy */
			SND_ALIAS        = 0x00010000 ,/* name is a registry alias */
			SND_ALIAS_ID     = 0x00110000, /* alias is a pre d ID */
			SND_FILENAME     = 0x00020000, /* name is file name */
			SND_RESOURCE     = 0x00040004, /* name is resource name or atom */
			SND_PURGE        = 0x0040,  /* purge non-static events for task */
			SND_APPLICATION  = 0x0080 /* look for application specific association */
		}

		/// <summary>
		/// Describes the current state of the scroll bar
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SCROLLINFO 
		{
			public int cbSize;
			public int fMask;
			public int nMin;
			public int nMax;
			public int nPage;
			public int nPos;
			public int nTrackPos;
		}

		[DllImport("winmm.dll", EntryPoint="PlaySound",CharSet=CharSet.Auto)]
		private static extern int PlaySound(String pszSound, int hmod, int falgs);

		/// <summary>
		/// Plays an OS event sound
		/// </summary>
		/// <param name="file">The sound file to play</param>
		public static void PlaySoundEvent(String file)
		{
			PlaySound(file,0,
				(int) (SND.SND_ASYNC | SND.SND_ALIAS | SND.SND_NOWAIT));
		}

		/// <summary>
		/// Plays the sound file
		/// </summary>
		/// <param name="file">PSZ sound.</param>
		public static void PlaySound(String file)
		{
			if(File.Exists(file))
			{
				PlaySound(file,0,
					(int) (SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT));
			}
		}
	}
}
