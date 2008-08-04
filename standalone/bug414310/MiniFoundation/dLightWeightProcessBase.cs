// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	dLightWeightProcessBase.cs
// Created:	        26/05/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Simple abstract base class for light weight services to be derived from.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 26/05/2008		1.0         BMcD    First Implementation.
// 
// **********************************************************************************************************************

using System;
using System.Threading;

namespace dWorld.Foundation.Utility.Threading
{
	public abstract class dLightWeightProcessBase
	{
		private int m_PendingProcessFlags = 0;
		private int m_PreRegesterProcessCount = 0;
		private int m_RegisterRequestCount = 0;
		private dLightWeightProcessThread.IndicateProcessHasWorkCall m_ProcessEnqueue;

		public abstract string Name {
			get;
		}

		public bool IsRegistered {
			get { return m_RegisterRequestCount > 0; }
		}

		public int PendingProcessCount {
			get { return m_PendingProcessFlags; }
		}

		internal int RegestrationCount {
			get { return m_RegisterRequestCount; }
		}

		public virtual void Registered ()
		{
		}

		public virtual void UnRegistered ()
		{
		}

		public abstract void Update ();

		protected void IncrementProcessFlag ()
		{
			if (m_ProcessEnqueue != null) {
				m_ProcessEnqueue (this);
				Interlocked.Increment (ref m_PendingProcessFlags);
			} else {
				Interlocked.Increment (ref m_PreRegesterProcessCount);
			}
		}

		internal void internal_IncrementRegister ()
		{
			Interlocked.Increment (ref m_RegisterRequestCount);
		}

		internal void internal_DecrementRegister ()
		{
			Interlocked.Decrement (ref m_RegisterRequestCount);
		}

		internal virtual void internal_Register (dLightWeightProcessThread.IndicateProcessHasWorkCall _ProcessEnqueue)
		{
			m_ProcessEnqueue = _ProcessEnqueue;

			while (m_PreRegesterProcessCount > 0) {
				IncrementProcessFlag ();
				m_PreRegesterProcessCount--;
			}

			Registered ();
		}

		internal virtual void internal_UnRegister ()
		{
			m_ProcessEnqueue = null;
			UnRegistered ();
		}

		internal void internal_Update ()
		{
			Update ();
			Interlocked.Decrement (ref m_PendingProcessFlags);
		}
	}
}
