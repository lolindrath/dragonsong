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
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonsong
{
	/// <summary>
	/// AnsiEdit inherits from RichTextBox
	/// and handles standard ANSI color sequences,
	/// translating them into Rich Text Format.
	/// </summary>
	public class AnsiEdit : RichTextBox
	{
		private HybridDictionary rtfColor;
		private HybridDictionary rtfFontFamily;
		private const string FF_UNKNOWN = "UNKNOWN";

		private RtfColor foreColor = RtfColor.BrightWhite;
		private RtfColor backColor = RtfColor.Black;
		private bool boldFont = false;

		private Font currentFont = new Font("Courier New", 8f);

		private int updating = 0;
		private int oldEventMask = 0;

		private const char EscChar = '\x1B';
		private static State state = State.Normal;

		private const string RTF_HEADER = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033";
		private const string RTF_DOCUMENT_PRE = @"\viewkind4\uc1\pard\cf1 \f0\fs20 ";
		private const string RTF_DOCUMENT_POST = @"\cf0\fs17}";

		private const int ScrollBufferSize = 250*80; //500 lines of scroll back allowed
		private int maxScroll = int.MinValue;

		private bool echo = true;

		/// <summary>
		/// Describes how to interpret
		/// the data being added.
		/// </summary>
		public enum MessageType
		{
			/// <summary>
			/// This is input the user types and sends to the server
			/// </summary>
			KeyboardInput,
			/// <summary>
			/// Just normal text added to the control
			/// </summary>
			Normal,
			/// <summary>
			/// Outputs the text as an error in red on a white background
			/// </summary>
			Error,
			/// <summary>
			/// Interprets this text as ANSI.
			/// </summary>
			ANSI
		}

		private enum State
		{
			Normal,
			Esc,
			Bracket,
			Parms
		}

		// Definitions for colors in an RTF document
		private struct RtfColorDef
		{
			public const string Black = @"\red0\green0\blue0";
			public const string Red = @"\red128\green0\blue0";
			public const string Green = @"\red0\green128\blue0";
			public const string Yellow = @"\red128\green128\blue0";
			public const string Blue = @"\red0\green0\blue128";
			public const string Magenta = @"\red128\green0\blue128";
			public const string Cyan = @"\red0\green128\blue128";
			public const string White = @"\red192\green192\blue192";
			public const string BrightBlack = @"\red128\green128\blue128";
			public const string BrightRed = @"\red255\green0\blue0";
			public const string BrightGreen = @"\red0\green255\blue0";
			public const string BrightYellow = @"\red255\green255\blue0";
			public const string BrightBlue = @"\red0\green0\blue255";
			public const string BrightMagenta = @"\red255\green0\blue255";
			public const string BrightCyan = @"\red0\green255\blue255";
			public const string BrightWhite = @"\red255\green255\blue255";
		}

		// Control words for RTF font families
		private struct RtfFontFamilyDef
		{
			public const string Unknown = @"\fnil";
			public const string Roman = @"\froman";
			public const string Swiss = @"\fswiss";
			public const string Modern = @"\fmodern";
			public const string Script = @"\fscript";
			public const string Decor = @"\fdecor";
			public const string Technical = @"\ftech";
			public const string BiDirect = @"\fbidi";
		}

		/// <summary>
		/// Describes the allowed color set
		/// </summary>
		public enum RtfColor
		{
			/// <summary>
			/// ANSI Black
			/// </summary>
			Black = 0,
			/// <summary>
			/// ANSI Red
			/// </summary>
			Red,
			/// <summary>
			/// ANSI Green
			/// </summary>
			Green,
			/// <summary>
			/// ANSI Yellow
			/// </summary>
			Yellow,
			/// <summary>
			/// ANSI Blue
			/// </summary>
			Blue,
			/// <summary>
			/// ANSI Magenta
			/// </summary>
			Magenta,
			/// <summary>
			/// ANSI Cyan
			/// </summary>
			Cyan,
			/// <summary>
			/// ANSI White
			/// </summary>
			White,
			/// <summary>
			/// Bright Black
			/// </summary>
			//brights start @ 8
			BrightBlack,
			/// <summary>
			/// Bright Red
			/// </summary>
			BrightRed,
			/// <summary>
			/// Bright Green
			/// </summary>
			BrightGreen,
			/// <summary>
			/// Bright Yellow
			/// </summary>
			BrightYellow,
			/// <summary>
			/// Bright Blue
			/// </summary>
			BrightBlue,
			/// <summary>
			/// Bright Magenta
			/// </summary>
			BrightMagenta,
			/// <summary>
			/// Bright Cyan
			/// </summary>
			BrightCyan,
			/// <summary>
			/// Bright White
			/// </summary>
			BrightWhite
		}

		/// <summary>
		/// Creates a new <see cref="AnsiEdit"/> instance.
		/// </summary>
		public AnsiEdit() : base()
		{
			rtfColor = new HybridDictionary();
			rtfColor.Add(RtfColor.Black, RtfColorDef.Black);
			rtfColor.Add(RtfColor.Red, RtfColorDef.Red);
			rtfColor.Add(RtfColor.Green, RtfColorDef.Green);
			rtfColor.Add(RtfColor.Yellow, RtfColorDef.Yellow);
			rtfColor.Add(RtfColor.Blue, RtfColorDef.Blue);
			rtfColor.Add(RtfColor.Magenta, RtfColorDef.Magenta);
			rtfColor.Add(RtfColor.Cyan, RtfColorDef.Cyan);
			rtfColor.Add(RtfColor.White, RtfColorDef.White);
			rtfColor.Add(RtfColor.BrightBlack, RtfColorDef.BrightBlack);
			rtfColor.Add(RtfColor.BrightRed, RtfColorDef.BrightRed);
			rtfColor.Add(RtfColor.BrightGreen, RtfColorDef.BrightGreen);
			rtfColor.Add(RtfColor.BrightYellow, RtfColorDef.BrightYellow);
			rtfColor.Add(RtfColor.BrightBlue, RtfColorDef.BrightBlue);
			rtfColor.Add(RtfColor.BrightMagenta, RtfColorDef.BrightMagenta);
			rtfColor.Add(RtfColor.BrightCyan, RtfColorDef.BrightCyan);
			rtfColor.Add(RtfColor.BrightWhite, RtfColorDef.BrightWhite);

			rtfFontFamily = new HybridDictionary();
			rtfFontFamily.Add(FontFamily.GenericMonospace.Name, RtfFontFamilyDef.Modern);
			rtfFontFamily.Add(FontFamily.GenericSansSerif, RtfFontFamilyDef.Swiss);
			rtfFontFamily.Add(FontFamily.GenericSerif, RtfFontFamilyDef.Roman);
			rtfFontFamily.Add(FF_UNKNOWN, RtfFontFamilyDef.Unknown);

			this.SetStyle(ControlStyles.DoubleBuffer, true);
		}

		/// <summary>
		/// Maintains performance while updating.
		/// </summary>
		/// <remarks>
		/// <para>
		/// It is recommended to call this method before doing
		/// any major updates that you do not wish the user to
		/// see. Remember to call EndUpdate when you are finished
		/// with the update. Nested calls are supported.
		/// </para>
		/// <para>
		/// Calling this method will prevent redrawing. It will
		/// also setup the event mask of the underlying richedit
		/// control so that no events are sent.
		/// </para>
		/// </remarks>
		public void BeginUpdate()
		{
			// Deal with nested calls.
			++updating;

			if (updating > 1)
				return;

			// Prevent the control from raising any events.
			oldEventMask = Win32Helper.SendMessage(this.Handle.ToInt32(),
			                                       Win32Helper.EM_SETEVENTMASK, 0, 0);

			// Prevent the control from redrawing itself.
			Win32Helper.SendMessage(this.Handle.ToInt32(),
			                        Win32Helper.WM_SETREDRAW, 0, 0);

		}

		/// <summary>
		/// Resumes drawing and event handling.
		/// </summary>
		/// <remarks>
		/// This method should be called every time a call is made
		/// made to BeginUpdate. It resets the event mask to it's
		/// original value and enables redrawing of the control.
		/// </remarks>
		public void EndUpdate()
		{
			// Deal with nested calls.
			--updating;

			if (updating < 0)
				return;

			// Allow the control to redraw itself.
			Win32Helper.SendMessage(this.Handle.ToInt32(),
			                        Win32Helper.WM_SETREDRAW, 1, 0);

			// Allow the control to raise event messages.
			Win32Helper.SendMessage(this.Handle.ToInt32(),
			                        Win32Helper.EM_SETEVENTMASK, 0, oldEventMask);
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="AnsiEdit"/> is echo.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if echo; otherwise, <c>false</c>.
		/// </value>
		public bool Echo
		{
			get { return echo; }
			set { echo = value; }
		}

		/// <summary>
		/// gets or sets the current font
		/// </summary>
		public Font CurrentFont
		{
			get { return currentFont; }
			set { currentFont = value; }
		}

		/// <summary>
		/// Appends the text.
		/// </summary>
		/// <param name="s">S.</param>
		/// <param name="message">Message.</param>
		public void AppendText(string s, MessageType message)
		{
			switch (message)
			{
				case MessageType.KeyboardInput:
					{
						if (Echo)
						{
							InsertTextAsRtf(s, this.CurrentFont, RtfColor.BrightYellow, RtfColor.Black);
						}
						break;
					}
				case MessageType.Normal:
					{
						if (boldFont && ((int) foreColor) < 8)
						{
							foreColor = (RtfColor) ((int) foreColor + 8);
						}

						InsertTextAsRtf(s, this.CurrentFont, foreColor, backColor);
						break;
					}
				case MessageType.Error:
					{
						InsertTextAsRtf(s, this.CurrentFont, RtfColor.BrightRed, RtfColor.BrightWhite);
						break;
					}
				case MessageType.ANSI:
					{
						ProcessANSI(s);
						break;
					}
			}
		}

		private void ProcessANSI(string s)
		{
			ArrayList parms = new ArrayList();

			int i = 0;
			while (i < s.Length)
			{
				switch (state)
				{
					case State.Normal:
						{
							if (s[i] != EscChar)
							{
								int start = i;
								while (i < s.Length && s[i] != EscChar)
								{
									i++;
								}

								AppendText(s.Substring(start, i - start), MessageType.Normal);
							}
							else
							{
								state = State.Esc;
								++i;
							}

							break;
						}
					case State.Esc:
						{
							if (s[i] == '[' && ((i + 1) < s.Length && Char.IsNumber(s[i + 1])))
							{
								parms = new ArrayList();
								state = State.Bracket;
								++i;
								break;
							}
							else if (s[i] == '[' && ((i + 1) < s.Length) && !Char.IsNumber(s[i + 1]))
							{
								//we have ESC[A, considering this malformed and deleting it
								s = s.Remove(i - 1, 2);
								state = State.Normal;
								break;
							}
							else
							{
								state = State.Normal;
								break;
							}
						}
					case State.Bracket:
						{
							while (i < s.Length && (Char.IsNumber(s[i]) || s[i] == ';'))
							{
								if (Char.IsNumber(s[i]))
								{
									int param = int.Parse(s[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
									++i;

									while (Char.IsNumber(s[i]))
									{
										param *= 10;
										param += int.Parse(s[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
										++i;
									}

									parms.Add(param);

									if (s[i] == ';')
									{
										++i;
										break;
									}
								}
								else if (s[i] == ';')
								{
									++i;
									break;
								}

								state = State.Parms;
							}

							break;
						}
					case State.Parms:
						{
							switch (s[i])
							{
								case 'A': //Move cursor up N lines
									{
										++i;
										break;
									}
								case 'B': //Move cursor down N lines
									{
										++i;
										break;
									}
								case 'C': //Move cursor right N spaces
									{
										StringBuilder sb = new StringBuilder();
										sb.Append(' ', (int) parms[0]);
										s = s.Insert(i + 1, sb.ToString());
										++i;
										break;
									}
								case 'D': //Move cursor left N spaces
									{
										++i;
										break;
									}
								case 'H':
								case 'f': //Move cursor to C column and N line
									{
										++i;
										break;
									}
								case 'J': //Clear the screen, return to 0,0
									{
										if (parms[0].Equals(2))
										{
											/*int chars,lines;
									string newlines = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
									Graphics g = rich.CreateGraphics();
									g.MeasureString(newlines, new Font("Courier New", 8f), rich.DisplayRectangle.Size, StringFormat.GenericDefault, out chars, out lines);

									this.AppendText(newlines.Substring(0, lines), MessageType.ANSI);
									*/
										}
										++i;
										break;
									}
								case 'K': //erase to EOL
									{
										++i;
										break;
									}
								case 's': //save cursor position: non-standard
									{
										++i;
										break;
									}
								case 'u': //restore cursor position - non-standard
									{
										++i;
										break;
									}
								case 'm':
									{
										ProcessParms(parms);
										++i;
										break;
									}
								default:
									{
										++i;
										break;
									}
							}

							state = State.Normal;
							break;
						}
				}
			}
		}

		private void ProcessParms(ArrayList parms)
		{
			int nowcol = 0;
			foreach (int i in parms)
			{
				switch (i)
				{
					case 0: //Reset/None
						{
							boldFont = false;
							foreColor = RtfColor.BrightWhite;
							backColor = RtfColor.Black;
							break;
						}
					case 1: //Bold
						{
							boldFont = true;
							break;
						}
					case 4: //Underscore
						{
							break;
						}
					case 5: //Blink
						{
							break;
						}
					case 7: //Reverse
						{
							break;
						}
					case 8: //Concealed
						{
							break;
						}
					case 30:
					case 31:
					case 32:
					case 33:
					case 34:
					case 35:
					case 36:
					case 37:
						{
							nowcol = i;
							break;
						}
					case 40:
						{
							backColor = RtfColor.Black;
							break;
						}
					case 41:
						{
							backColor = RtfColor.Red;
							break;
						}
					case 42:
						{
							backColor = RtfColor.Green;
							break;
						}
					case 43:
						{
							backColor = RtfColor.Yellow;
							break;
						}
					case 44:
						{
							backColor = RtfColor.Blue;
							break;
						}
					case 45:
						{
							backColor = RtfColor.Cyan;
							break;
						}
					case 46:
						{
							backColor = RtfColor.Magenta;
							break;
						}
					case 47:
						{
							backColor = RtfColor.White;
							break;
						}
					default:
						{
							break;
						}
				}

				//If it's a foreground color
				if (nowcol >= 30 && nowcol <= 37)
				{
					if (boldFont)
					{
						foreColor = (RtfColor) nowcol - 22;
					}
					else
					{
						foreColor = (RtfColor) nowcol - 30;
					}
				}
			}
		}

		/// <summary>
		/// Inserts the text as RTF.
		/// </summary>
		/// <param name="s">S.</param>
		/// <param name="font">Font.</param>
		/// <param name="textColor">Color of the text.</param>
		/// <param name="backColor">Color of the back.</param>
		public void InsertTextAsRtf(string s, Font font, RtfColor textColor, RtfColor backColor)
		{
			StringBuilder rtf = new StringBuilder();

		    rtf.Append(RTF_HEADER);
			rtf.Append(GetFontTable(font));
			rtf.Append(GetColorTable(textColor, backColor));
			rtf.Append(GetDocumentArea(s, font));

			this.SelectionStart = int.MaxValue;
			this.SelectedRtf = rtf.ToString();
         
			if (ScrollPos >= maxScroll)
			{
				//check to see if the buffer is too big
				//we have to do this while the user is scrolled
				//down incase the's looking at the line we're cutting out
				if (this.Text.Length > ScrollBufferSize && (this.Text.Length - ScrollBufferSize) > ScrollBufferSize/3)
				{
					this.SelectionStart = 0;

					string str = this.Text.Substring(0, this.Text.Length - ScrollBufferSize);

					int pos = this.Text.Length - ScrollBufferSize;

					//find the closest line to chop off at, otherwise default to 
					//the ScrollBufferSize
					for (int i = str.Length - 1; i >= 0; i--)
					{
						if (str[i] == '\n')
						{
							pos = i;
							break;
						}
					}

					this.SelectionLength = pos;


					Win32Helper.SendMessage(this.Handle.ToInt32(), Win32Helper.EM_REPLACESEL, -1, "");
					maxScroll = int.MinValue;
					ScrollToBottom();
					maxScroll = ScrollPos;
				}
				else
				{
					maxScroll = Math.Max(ScrollPos, maxScroll);
					ScrollToBottom();
				}
			}
		}

		/// <summary>
		/// Gets or sets the max scroll.
		/// </summary>
		/// <value></value>
		public int MaxScroll
		{
			get { return maxScroll; }
			set { maxScroll = value; }
		}

		/// <summary>
		/// Gets the scroll position.
		/// </summary>
		/// <value></value>
		public int ScrollPos
		{
			get
			{
				Win32Helper.SCROLLINFO sc = new Win32Helper.SCROLLINFO();
				sc.fMask = Win32Helper.SIF_ALL;
				sc.cbSize = Marshal.SizeOf(sc);
				Win32Helper.GetScrollInfo(this.Handle.ToInt32(), Win32Helper.SB_VERT, ref sc);

				return sc.nPos;
			}
		}

		/// <summary>
		/// Scrolls to the bottom.
		/// </summary>
        private void ScrollToBottom()
        {
            int iMin, iMax, iPos = Win32Helper.GetScrollPos(this.Handle.ToInt32(), Win32Helper.SB_VERT);

            Win32Helper.GetScrollRange(this.Handle, Win32Helper.SB_VERT, out iMin, out iMax);

            Win32Helper.SendMessage(this.Handle, Win32Helper.EM_SETSCROLLPOS, 0, 
                new Win32Helper.POINT(0, Math.Max(0, (iMax - (this.ClientSize.Height - 1)))));
        }

		/*public void ScrollToBottom()
		{
			Win32Helper.SendMessage(this.Handle.ToInt32(), Win32Helper.WM_VSCROLL, Win32Helper.SB_BOTTOM, 1);
		}*/

		private string GetDocumentArea(string s, Font font)
		{
			StringBuilder doc = new StringBuilder();

			doc.Append(RTF_DOCUMENT_PRE);
			doc.Append(@"\highlight2");


			if (font.Bold)
				doc.Append(@"\b");


			if (font.Italic)
				doc.Append(@"\i");


			if (font.Strikeout)
				doc.Append(@"\strike");

			if (font.Underline)
				doc.Append(@"\ul");

			doc.Append(@"\f0 ");

			doc.Append(@"\fs"); //font size
			doc.Append((int) Math.Round((2*font.SizeInPoints)));

			// Apppend a space before starting actual text (for clarity)
			doc.Append(@" ");

			//escape special characters
			s = s.Replace(@"\", @"\\");
			s = s.Replace("{", "\\{");
			s = s.Replace("}", "\\}");

			doc.Append(s.Replace("\n", @"\par ")); //new lines to \par

			doc.Append(@"\highlight0 ");

			if (font.Bold)
				doc.Append(@"\b0");

			if (font.Italic)
				doc.Append(@"\i0");

			if (font.Strikeout)
				doc.Append(@"\strike0");

			if (font.Underline)
				doc.Append(@"\ulnone");

			doc.Append(@"\f0");
			doc.Append(@"\fs20");

			doc.Append(RTF_DOCUMENT_POST);

			return doc.ToString();
		}

		private string GetFontTable(Font font)
		{
			StringBuilder fontTable = new StringBuilder();

			// Append table control string
			fontTable.Append(@"{\fonttbl{\f0");

			// If the font's family corresponds to an RTF family, append the
			// RTF family name, else, append the RTF for unknown font family.
			if (rtfFontFamily.Contains(font.FontFamily.Name))
				fontTable.Append(rtfFontFamily[font.FontFamily.Name]);
			else
				fontTable.Append(rtfFontFamily[FF_UNKNOWN]);

			// \fcharset specifies the character set of a font in the font table.
			// 0 is for ANSI.
			fontTable.Append(@"\fcharset0 ");

			// Append the name of the font
			fontTable.Append(font.Name);

			// Close control string
			fontTable.Append(@";}}");

			return fontTable.ToString();
		}

		/// <summary>
		/// Initializes the component.
		/// </summary>
		protected void InitializeComponent()
		{
			// 
			// AnsiEdit
			// 
			this.Cursor = Cursors.Default;

		}

		private string GetColorTable(RtfColor textColor, RtfColor backColor)
		{
			StringBuilder colorTable = new StringBuilder();

			colorTable.Append(@"{\colortbl ;");

			colorTable.Append(rtfColor[textColor]);
			colorTable.Append(@";");

			colorTable.Append(rtfColor[backColor]);
			colorTable.Append(@";}\n");

			return colorTable.ToString();
		}
	} //end class
} //end namespace