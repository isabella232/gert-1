// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	MPCQueue.cs
// Created:	        29/02/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Multiple Producer / Consumer Queue.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 29/02/2008		1.0         BMcD    First Pass
// 
// **********************************************************************************************************************

using System;
using System.Threading;

namespace dWorld.Foundation.Utility.Threading
{
	public class MPCQueue<T> : dThreadSafeQueue<T> where T : class
	{
		private ReaderWriterLock m_lockHead = new ReaderWriterLock ();
		private ReaderWriterLock m_lockTail = new ReaderWriterLock ();

		public MPCQueue () : base ()
		{
		}

		public MPCQueue (int _capacity) : base (_capacity)
		{
		}

		public override void Enqueue (T _value)
		{
			m_lockTail.AcquireWriterLock (Timeout.Infinite);
			try {
				Protected_Enqueue (_value);
			} finally {
				m_lockTail.ReleaseWriterLock ();
			}
		}

		public override T Dequeue ()
		{
			T value = null;
			m_lockHead.AcquireWriterLock (Timeout.Infinite);
			try {
				value = Protected_Dequeue ();
			} finally {
				m_lockHead.ReleaseWriterLock ();
			}
			return value;
		}

		public override T Peek ()
		{
			T value = null;
			m_lockHead.AcquireReaderLock (Timeout.Infinite);
			try {
				value = Protected_Peek ();
			} finally {
				m_lockHead.ReleaseReaderLock ();
			}
			return value;
		}
	}
}
