// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	dThreadSafeQueue.cs
// Created:	        23/05/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Abstract Base class for all thread safe queue implementations.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 23/05/2008		1.0         BMcD    First Implementation
// 
// **********************************************************************************************************************

using System;
using System.Threading;

namespace dWorld.Foundation.Utility.Threading
{
	public abstract class dThreadSafeQueue<T> where T : class
	{
		private TQueueNode<T> m_Head = null;
		private TQueueNode<T> m_Tail = null;
		private TQueueNode<T> m_CacheHead = null;
		private TQueueNode<T> m_CacheTail = null;
		private long m_nCapacity = 0;
		private long m_nCount = 0;

		public dThreadSafeQueue () : this (0)
		{
		}

		public dThreadSafeQueue (int _capacity)
		{
			// setup the primary queue.
			TQueueNode<T> node = new TQueueNode<T> ();
			m_Head = node;
			m_Tail = node;

			// setup the cache nodes.
			TQueueNode<T> cahcenode = new TQueueNode<T> ();
			m_CacheHead = cahcenode;
			m_CacheTail = cahcenode;
			m_nCapacity = _capacity;

			for (int i = 0; i < _capacity; i++)
				Cache_Enqueue (new TQueueNode<T> ());
		}

		public int Capacity {
			get { return (int) Interlocked.Read (ref m_nCapacity); }
		}

		public int Count {
			get { return (int) Interlocked.Read (ref m_nCount); }
		}

		public abstract void Enqueue (T _value);

		public abstract T Dequeue ();

		public abstract T Peek ();

		public void Protected_Enqueue (T _value)
		{
			TQueueNode<T> node = Cache_Dequeue ();
			node.value = _value;
			m_Tail.next = node;
			m_Tail = node;
			Interlocked.Increment (ref m_nCount);
		}

		public T Protected_Dequeue ()
		{
			T value = null;
			// get a refrence to the next node.
			TQueueNode<T> nextNode = m_Head.next;
			if (nextNode != null) {
				Interlocked.Decrement (ref m_nCount);
				value = nextNode.value;
				TQueueNode<T> oldHead = m_Head;
				m_Head = nextNode;
				m_Head.value = null;

				Cache_Enqueue (oldHead); // store off the old head
			}

			return value;
		}

		protected T Protected_Peek ()
		{
			T value = null;
			// get a refrence to the next node.
			TQueueNode<T> nextNode = m_Head.next;
			if (nextNode != null) {
				value = nextNode.value;
			}
			return value;
		}

		private TQueueNode<T> Cache_Dequeue ()
		{
			TQueueNode<T> retNode = null;

			// get a refrence to the next node.
			TQueueNode<T> nextNode = m_CacheHead.next;
			if (nextNode != null) {
				retNode = m_CacheHead;
				m_CacheHead = nextNode;
			} else {
				retNode = new TQueueNode<T> ();
				m_nCapacity++;
			}

			return retNode;
		}

		private void Cache_Enqueue (TQueueNode<T> _Node)
		{
			_Node.next = null;
			_Node.value = null;
			m_CacheTail.next = _Node;
			m_CacheTail = _Node;
		}
	}
}
