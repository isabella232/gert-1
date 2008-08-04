// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	dLightWeightScheduledProcessBase.cs
// Created:	        09/07/2008
// Author:    		Sam.Suliman
// Project:		    dWorld
// Description:   	Simple abstract base class for light weight services that need to be updated at particular rate.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 09/07/2008		1.0         Sam S    First Implementation.
// 
// **********************************************************************************************************************

using System;
using System.Timers;
using System.Runtime.InteropServices;
using System.Threading;

namespace dWorld.Foundation.Utility.Threading
{
	internal delegate void WaitOrTimerDelegate (IntPtr param, [MarshalAs (UnmanagedType.Bool)] bool timerOrWaitFired);

	internal static class NativeMethods
	{
		[Flags]
		public enum TimerQueueFlags : uint
		{
			WT_EXECUTEDEFAULT = 0x00000000,
			WT_EXECUTEINIOTHREAD = 0x00000001,
			WT_EXECUTEINUITHREAD = 0x00000002,
			WT_EXECUTEINWAITTHREAD = 0x00000004,
			WT_EXECUTEONLYONCE = 0x00000008,
			WT_EXECUTEINTIMERTHREAD = 0x00000020,
			WT_EXECUTELONGFUNCTION = 0x00000010,
			WT_EXECUTEINPERSISTENTIOTHREAD = 0x00000040,
			WT_EXECUTEINPERSISTENTTHREAD = 0x00000080,
		}

		[DllImport ("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CreateTimerQueue ();

		[DllImport ("kernel32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool CreateTimerQueueTimer (ref IntPtr phNewTimer, IntPtr TimerQueue, WaitOrTimerDelegate Callback, IntPtr Parameter, uint DueTime, uint Period, TimerQueueFlags Flags);

		[DllImport ("kernel32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool ChangeTimerQueueTimer (IntPtr TimerQueue, IntPtr Timer, uint DueTime, uint Period);

		[DllImport ("kernel32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool DeleteTimerQueueEx (IntPtr TimerQueue, IntPtr CompletionHandle);

		[DllImport ("kernel32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool DeleteTimerQueueTimer (IntPtr TimerQueue, IntPtr Timer, IntPtr CompletionEvent);
	}

	public abstract class dLightWeightScheduledProcessBase : dLightWeightProcessBase
	{
		private int m_updateRatems = int.MaxValue;
		static IntPtr ms_timerQ;
		static int ms_count;
		IntPtr m_timer;

		public dLightWeightScheduledProcessBase (int _fps)
		{
			m_updateRatems = (int) (1000f / (float) _fps);
		}

		public int UpdateRatems
		{
			get { return m_updateRatems; }
			set { m_updateRatems = value; }
		}

		private void MyDelegate (IntPtr _param, bool _timerOrWaitFired)
		{
			dLightWeightProcessThread.AddDebug ('i');
			base.IncrementProcessFlag ();
			dLightWeightProcessThread.AddDebug ('f');
		}

		internal override void internal_Register (dLightWeightProcessThread.IndicateProcessHasWorkCall _ProcessEnqueue)
		{
			base.internal_Register (_ProcessEnqueue);

			if (Interlocked.Increment (ref ms_count) == 1)
				ms_timerQ = NativeMethods.CreateTimerQueue ();
			NativeMethods.CreateTimerQueueTimer (
				ref m_timer,
				ms_timerQ,
				new WaitOrTimerDelegate (MyDelegate),
				IntPtr.Zero,
				0,
				(uint) m_updateRatems,
				NativeMethods.TimerQueueFlags.WT_EXECUTEINIOTHREAD);
		}

		internal override void internal_UnRegister ()
		{
			base.internal_UnRegister ();

			NativeMethods.DeleteTimerQueueTimer (ms_timerQ, m_timer, new IntPtr (-1));
			m_timer = IntPtr.Zero;
			if (Interlocked.Decrement (ref ms_count) == 0) {
				NativeMethods.DeleteTimerQueueEx (ms_timerQ, new IntPtr (-1));
				ms_timerQ = IntPtr.Zero;
			}
		}
	}
}
