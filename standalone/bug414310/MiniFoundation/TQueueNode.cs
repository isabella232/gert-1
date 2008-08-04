// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	TQueueNode.cs
// Created:	        29/02/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Internal Threading Queue Node.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 29/02/2008		1.0         BMcD    First Pass.
// 
// **********************************************************************************************************************

using System;

namespace dWorld.Foundation.Utility.Threading
{
	internal class TQueueNode<T> where T : class
	{
		private T m_Value;
		private TQueueNode<T> m_Next;

		public T value {
			get { return m_Value; }
			set { m_Value = value; }
		}

		public TQueueNode<T> next {
			get { return m_Next; }
			set { m_Next = value; }
		}

		internal TQueueNode ()
		{
			m_Value = null;
			m_Next = null;
		}

		internal TQueueNode (T value)
		{
			m_Value = value;
			m_Next = null;
		}
	}
}
