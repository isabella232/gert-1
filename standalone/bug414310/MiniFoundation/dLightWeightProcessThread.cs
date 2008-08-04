// **********************************************************************************************************************
// 
// Copyright (c)2007, Realtime Worlds Ltd. All Rights reserved.
// 
// File:	    	dLightWeightProcessThread.cs
// Created:	        26/05/2008
// Author:    		bert.mcdowell
// Project:		    dWorld
// Description:   	Service Thread System.
// 
// Date				Version		BY		Comment
// ----------------------------------------------------------------------------------------------------------------------
// 26/05/2008		1.0         BMcD    First Implementation.
// 
// **********************************************************************************************************************

using System;
using System.Threading;
using System.Collections.Generic;

namespace dWorld.Foundation.Utility.Threading
{
	public class dLightWeightProcessThread
	{
		private enum eCommandType
		{
			Register,
			UnRegister,
			process,
		}

		private class Command
		{
			private eCommandType m_Command;
			private dLightWeightProcessBase m_Service;
			private ManualResetEvent m_Event;

			public Command (eCommandType _Command, dLightWeightProcessBase _Service)
			{
				m_Command = _Command;
				m_Service = _Service;
				m_Event = new ManualResetEvent (false);
			}

			public eCommandType Type {
				get { return m_Command; }
			}

			public dLightWeightProcessBase Service {
				get { return m_Service; }
			}

			public ManualResetEvent Event {
				get { return m_Event; }
			}
		}

		private class ThreadProcess
		{
			private static readonly int m_nStandardServices = 3;
			public static ManualResetEvent m_Stop = null;
			public static Semaphore m_ExternalCommandQueueEvent = null;
			public static Semaphore m_InternalCommandQueueEvent = null;
			public static MPCQueue<Command> m_ExternalCommandQueue = null;
			public static MPCQueue<Command> m_InternalCommandQueue = null;

			public static void Init ()
			{
				m_Stop = new ManualResetEvent (false);
				m_ExternalCommandQueueEvent = new Semaphore (0, 100000000);
				m_InternalCommandQueueEvent = new Semaphore (0, 100000000);
				m_ExternalCommandQueue = new MPCQueue<Command> (1);
				m_InternalCommandQueue = new MPCQueue<Command> (100);
			}

			public static void Term ()
			{
				m_Stop = null;
				m_InternalCommandQueueEvent = null;
				m_ExternalCommandQueueEvent = null;
				m_InternalCommandQueue = null;
				m_ExternalCommandQueue = null;
			}

			public ThreadProcess ()
			{
			}

			public void MainLoop ()
			{
				bool bRun = true;
				WaitHandle [] ServiceEvents = new WaitHandle [m_nStandardServices];
				ServiceEvents [0] = m_Stop;
				ServiceEvents [1] = m_ExternalCommandQueueEvent;
				ServiceEvents [2] = m_InternalCommandQueueEvent;

				bool bSwitched = false;

				int index = -1;
				AddDebug ('s');
				while (bRun) {
					// Wait on any of the service events.
					AddDebug ('w');
					index = WaitHandle.WaitAny (ServiceEvents);

					switch (index) {
					case 0: {
							AddDebug ('q');
							// quit the system
							bRun = false;
							break;
						}
					default: {
							Command command = null;
							if (bSwitched) {
								if (index == 2) {
									command = m_ExternalCommandQueue.Dequeue ();
								} else {
									command = m_InternalCommandQueue.Dequeue ();

									// switch the events round
									bSwitched = false;
									ServiceEvents [1] = m_ExternalCommandQueueEvent;
									ServiceEvents [2] = m_InternalCommandQueueEvent;
								}
							} else {
								if (index == 1) {
									command = m_ExternalCommandQueue.Dequeue ();

									// switch the events round
									bSwitched = true;
									ServiceEvents [2] = m_ExternalCommandQueueEvent;
									ServiceEvents [1] = m_InternalCommandQueueEvent;
								} else {
									command = m_InternalCommandQueue.Dequeue ();
								}
							}
							AddDebug ('c');
							ProcessCommand (command);
							break;
						}
					}
				}
			}

			private void ProcessCommand (Command _command)
			{
				// Add / Remove services.
				if (_command.Service != null) {
					switch (_command.Type) {
					case eCommandType.Register: {
							AddDebug ('r');
							AddServiceToList (_command.Service);
							break;
						}
					case eCommandType.UnRegister: {
							AddDebug ('u');
							RemoveServiceFromList (_command.Service);
							break;
						}
					case eCommandType.process: {
							AddDebug ('p');
							UpdateAProcess (_command);
							break;
						}
					}
				}
				_command.Event.Set ();
			}

			public static void EnqueueCommand (Command _command)
			{
				if (Active) {
					m_ExternalCommandQueue.Enqueue (_command);
					m_ExternalCommandQueueEvent.Release ();
				} else {
					throw new Exception ("dLightWeightProcessThread is currently unavaliable, the process thread is nto running and needs to be initialised. To initialise the process thread please use the foundation initialisation system.");
				}
			}

			public static void EnqueueProcessToBeUpdated (dLightWeightProcessBase _process)
			{
				if (Active) {
					if (_process.PendingProcessCount == 0 && _process.RegestrationCount > 0) {
						Command command = new Command (eCommandType.process, _process);
						m_InternalCommandQueue.Enqueue (command);
						m_InternalCommandQueueEvent.Release ();
					}
				}
			}

			private void AddServiceToList (dLightWeightProcessBase _process)
			{
				_process.internal_Register (EnqueueProcessToBeUpdated);
			}

			private void RemoveServiceFromList (dLightWeightProcessBase _process)
			{
				_process.internal_UnRegister ();
			}

			private void UpdateAProcess (Command _command)
			{
				// Update the requried service.
				try {
					_command.Service.internal_Update ();

					// Re queue the process to be executed
					if ((_command.Service.PendingProcessCount > 0) &&
					     (_command.Service.RegestrationCount > 0)) {
						m_InternalCommandQueue.Enqueue (_command);
						m_InternalCommandQueueEvent.Release ();
					}
				} catch (Exception e) {
					// TODO :: Add to the logging system rather than the console.
					Console.WriteLine ("Light weight process {0} threw exception : {1}", _command.Service.Name, e.Message);
				}
			}
		}

		internal delegate void IndicateProcessHasWorkCall (dLightWeightProcessBase _process);

		private static MPCList<dLightWeightProcessBase> m_Processes = null;
		private static List<Thread> m_Threads = null;
		private static object m_Lock = new object ();
		private static int m_nRefCount = 0;
		public static char [] ms_buffer = new char [1024 * 10];
		public static int count;

		public static void AddDebug (char _c)
		{
			int index = Interlocked.Increment (ref count);
			ms_buffer [index % ms_buffer.Length] = _c;
		}

		public static void AddDebug (string _s)
		{
			foreach (char c in _s) {
				AddDebug (c);
			}
		}

		public static bool Active {
			get { return m_Threads != null; }
		}

		public static int Count {
			get { return m_Processes.Count; }
		}

		internal static int RefCount {
			get { return m_nRefCount; }
		}

		public static void AsyncAddService (dLightWeightProcessBase _Process)
		{
			if (m_Processes != null) {
				if (_Process != null) {
					m_Processes.Add (_Process);
					_Process.internal_IncrementRegister ();
					ThreadProcess.EnqueueCommand (new Command (eCommandType.Register, _Process));
				}
			} else {
				throw new Exception ("dLightWeightProcessThread has not been initialised, please initialise it through the Foundation Initialisation System.");
			}
		}

		public static void AsyncRemoveService (dLightWeightProcessBase _Process)
		{
			if (m_Processes != null) {
				if (m_Processes.Remove (_Process)) {
					_Process.internal_DecrementRegister ();
					ThreadProcess.EnqueueCommand (new Command (eCommandType.UnRegister, _Process));
				}
			}
		}

		public static void AddService (dLightWeightProcessBase _Process)
		{
			if (m_Processes != null) {
				if (_Process != null) {
					m_Processes.Add (_Process);
					_Process.internal_IncrementRegister ();
					Command command = new Command (eCommandType.Register, _Process);
					ThreadProcess.EnqueueCommand (command);
					command.Event.WaitOne ();
				}
			} else {
				throw new Exception ("dLightWeightProcessThread has not been initialised, please initialise it through the Foundation Initialisation System.");
			}
		}

		public static void RemoveService (dLightWeightProcessBase _Process)
		{
			if (m_Processes != null) {
				if (m_Processes.Remove (_Process)) {
					_Process.internal_DecrementRegister ();
					Command command = new Command (eCommandType.UnRegister, _Process);
					ThreadProcess.EnqueueCommand (command);
					command.Event.WaitOne ();
				}
			}
		}

		public static void Init ()
		{
			Init (2);
		}

		internal static void Init (int _nThreadCount)
		{
			lock (m_Lock) {
				m_nRefCount++;
				if (m_nRefCount == 1) {
					m_Processes = new MPCList<dLightWeightProcessBase> ();

					ThreadProcess.Init ();

					m_Threads = new List<Thread> ();
					int nThreadCount = _nThreadCount;
					for (int i = 0; i < nThreadCount; i++) {
						Thread thread = new Thread (delegate () { ThreadProcess process = new ThreadProcess (); process.MainLoop (); });
						thread.Name = String.Format ("dLightWeightProcessThread_{0}", i);
						thread.Start ();

						m_Threads.Add (thread);
					}
				}
			}
		}

		public static void Quit ()
		{
			lock (m_Lock) {
				// if we only have one ref count 
				// destroy all the service threads
				// else just decrement the refrence
				// counter.
				if (m_nRefCount == 1) {
					if (m_Threads != null) {
						// Set the thread to drop through.
						ThreadProcess.m_Stop.Set ();
						foreach (Thread thread in m_Threads)
							thread.Join ();
						m_Threads = null;

						// Unregister all the nodes.
						foreach (MPCList<dLightWeightProcessBase>.Node node in m_Processes) {
							node.Data.internal_DecrementRegister ();
							node.Data.internal_UnRegister ();
						}
						m_Processes = null;

						ThreadProcess.Term ();
					}
				}
				// Prevent the count going below 0
				m_nRefCount = Math.Max (m_nRefCount - 1, 0);
			}
		}
	}
}
