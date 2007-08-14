using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

class NotifyIconTooltipTest
{

	internal enum NotifyIconMessage
	{
		NIM_ADD = 0x00000000,
		NIM_MODIFY = 0x00000001,
		NIM_DELETE = 0x00000002,
	}

	[Flags]
	internal enum NotifyIconFlags
	{
		NIF_MESSAGE = 0x00000001,
		NIF_ICON = 0x00000002,
		NIF_TIP = 0x00000004,
	}

	[StructLayout (LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct NOTIFYICONDATA
	{
		internal uint cbSize;
		internal IntPtr hWnd;
		internal uint uID;
		internal NotifyIconFlags uFlags;
		internal uint uCallbackMessage;
		internal IntPtr hIcon;
		[MarshalAs (UnmanagedType.ByValTStr, SizeConst = 64)]
		internal string szTip;
	}

	static void Main (string [] args)
	{
		if (args.Length == 1) {
			Console.WriteLine ("Press enter to continue.");
			Console.ReadLine ();
			return;
		}

		Console.WriteLine ("Expected result:");
		Console.WriteLine ("\tszTip[0] = h");
		Console.WriteLine ("\tszTip[1] =");
		Console.WriteLine ("\tszTip[2] = e");
		Console.WriteLine ("\tszTip[3] =");
		Console.WriteLine ("\tszTip[4] = l");
		Console.WriteLine ("\tszTip[5] =");
		Console.WriteLine ("\tszTip[6] = l");
		Console.WriteLine ("\tszTip[7] =");
		Console.WriteLine ("\tszTip[8] = o");
		Console.WriteLine ("\tszTip[9] =");
		Console.WriteLine ();
		Console.WriteLine ("Actual result:");

		test ();
	}

	private static void test ()
	{
		Form form = new Form ();

		NOTIFYICONDATA nid = new NOTIFYICONDATA ();
		nid.cbSize = (uint) Marshal.SizeOf (nid);
		nid.hWnd = form.Handle;
		nid.uID = 1;
		nid.uCallbackMessage = (uint) 0x0400;
		nid.uFlags = NotifyIconFlags.NIF_MESSAGE;

		string tipText = "hello";
		nid.szTip = tipText;
		nid.uFlags |= NotifyIconFlags.NIF_TIP;

		Win32Shell_NotifyIcon (NotifyIconMessage.NIM_ADD, ref nid);
	}

	[DllImport ("libtest", EntryPoint = "Shell_NotifyIconW", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
	private extern static bool Win32Shell_NotifyIcon (NotifyIconMessage dwMessage, ref NOTIFYICONDATA lpData);
}
