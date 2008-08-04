// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	SPCList.cs
// Created:	        11/03/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Thread Safe Single Producer / Consumer List.
//
//                  TODO :: Improve this to try and minmise or remove locks. 
//
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 11/03/2008		1.0         BMcD    First Pass
// 
// **********************************************************************************************************************

using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace dWorld.Foundation.Utility.Threading
{
	public class SPCList<T> : IEnumerable where T : class
	{
		public class Node
		{
			private T m_Object;

			internal Node (T _Object)
			{
				m_Object = _Object;
			}

			public T Data {
				get { return m_Object; }
			}
		}

		private class Enumerator : IEnumerator, IDisposable
		{
			private Mutex m_mut;
			private List<Node>.Enumerator m_Enumerator;
			private bool m_bDisposed = false;

			public Enumerator (List<Node> _DList, Mutex _mut)
			{
				_mut.WaitOne ();
				m_mut = _mut;
				m_Enumerator = _DList.GetEnumerator ();
			}

			public void Dispose ()
			{
				if (!m_bDisposed) {
					m_bDisposed = true;
					m_mut.ReleaseMutex ();
				}
			}

			~Enumerator ()
			{
				Dispose ();
			}

			public object Current {
				get { return m_Enumerator.Current; }
			}

			public bool MoveNext ()
			{
				return m_Enumerator.MoveNext ();
			}

			public void Reset ()
			{
			}
		}

		private List<Node> m_List = null;
		private Mutex m_mut = new Mutex ();
		private long m_nCount = 0;

		public SPCList () : this (1000)
		{
		}

		public SPCList (int _capacity)
		{
			m_List = new List<Node> (_capacity);
		}

		public int Count {
			get { return (int) Interlocked.Read (ref m_nCount); }
		}

		public Node this [int _nIndex] {
			get {
				Node node = null;
				m_mut.WaitOne ();
				node = m_List [_nIndex];
				m_mut.ReleaseMutex ();
				return node;
			}
		}

		public IEnumerator GetEnumerator ()
		{
			return new Enumerator (m_List, m_mut);
		}

		public bool Contains (T _item) {
			bool bRet = false;

			try {
				m_mut.WaitOne ();

				foreach (Node node in m_List) {
					if (node.Data.Equals (_item)) {
						bRet = true;
						break;
					}
				}
			} finally {
				m_mut.ReleaseMutex ();
			}

			return bRet;
		}

		public void Add (T _value)
		{
			try {
				m_mut.WaitOne ();
				m_List.Add (new Node (_value));
				Interlocked.Increment (ref m_nCount);
			} finally {
				m_mut.ReleaseMutex ();
			}
		}

		public T Remove ()
		{
			T value = null;

			try {
				m_mut.WaitOne ();

				if (m_List.Count > 0) {
					Node head = m_List [0];
					m_List.Remove (head);
					value = head.Data;
					Interlocked.Decrement (ref m_nCount);
				}
			} finally {
				m_mut.ReleaseMutex ();
			}

			return value;
		}

		public T Remove (Node _node)
		{
			T value = null;

			try {
				m_mut.WaitOne ();

				if (m_List.Remove (_node)) {
					value = _node.Data;
					Interlocked.Decrement (ref m_nCount);
				}
			} finally {
				m_mut.ReleaseMutex ();
			}

			return value;
		}

		public bool Remove (T _obj)
		{
			bool bRet = false;

			try {
				m_mut.WaitOne ();

				Node remNode = null;
				foreach (Node node in m_List) {
					if (node.Data.Equals (_obj)) {
						remNode = node;
						break;
					}
				}

				if (remNode != null) {
					bRet = m_List.Remove (remNode);
					Interlocked.Decrement (ref m_nCount);
				}
			} finally {
				m_mut.ReleaseMutex ();
			}

			return bRet;
		}
	}
}
