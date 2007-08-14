using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

class Program
{
	[STAThread]
	static void Main ()
	{
		Tester t = new Tester ();
		t.RunTests ();
	}
}

class Tester
{
	public void Reset ()
	{
		_entriesWritten = new ArrayList ();

		if (EventLog.Exists ("monologtemp", "."))
			EventLog.Delete ("monologtemp", ".");
		if (EventLog.Exists ("monologother", "."))
			EventLog.Delete ("monologother", ".");
	}

	public void RunTests ()
	{
		Reset ();

		try {
			TestA ();
		} finally {
			Reset ();
		}

		// https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=293034
#if MONO
		try {
			TestB ();
		} finally {
			Reset ();
		}
#endif

		try {
			TestC ();
		} finally {
			Reset ();
		}
	}

	void TestA ()
	{
		if (!EventLog.Exists ("monologtemp", "."))
			EventLog.CreateEventSource ("monotempsource", "monologtemp");
		if (!EventLog.Exists ("monologother", "."))
			EventLog.CreateEventSource ("monoothersource", "monologother");

		EventLog otherEventLogA = new EventLog ("monologother", ".", "monoothersource");

		EventLog otherEventLogB = new EventLog ("monologother", ".", "monoothersource");
		otherEventLogB.EntryWritten += new EntryWrittenEventHandler (EventLog_EntryWritten);

		EventLog tempEventLog = new EventLog ("monologtemp", ".", "monotempsource");
		tempEventLog.EnableRaisingEvents = true;
		tempEventLog.EntryWritten += new EntryWrittenEventHandler (EventLog_EntryWritten);

		otherEventLogA.WriteEntry ("message1", EventLogEntryType.Warning,
			111, 1, new byte [] { 1, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (0, _entriesWritten.Count, "#A1");

		otherEventLogB.EnableRaisingEvents = true;
		otherEventLogA.WriteEntry ("message2", EventLogEntryType.Warning,
			222, 2, new byte [] { 2, 8 });
		otherEventLogA.WriteEntry ("message3", EventLogEntryType.Warning,
			333, 3, new byte [] { 3, 8 });
		otherEventLogA.WriteEntry ("message4", EventLogEntryType.Warning,
			444, 4, new byte [] { 4, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (3, _entriesWritten.Count, "#A2");

		EventLogEntry entry = (EventLogEntry) _entriesWritten [0];
		Assert.AreEqual ((short) 2, entry.CategoryNumber, "#A3");
		Assert.AreEqual (222, entry.EventID, "#A4");
		Assert.AreEqual ("message2", entry.Message, "#A5");
		Assert.AreEqual ("monoothersource", entry.Source, "#A6");

		entry = (EventLogEntry) _entriesWritten [1];
		Assert.AreEqual ((short) 3, entry.CategoryNumber, "#A7");
		Assert.AreEqual (333, entry.EventID, "#A8");
		Assert.AreEqual ("message3", entry.Message, "#A9");
		Assert.AreEqual ("monoothersource", entry.Source, "#A10");

		entry = (EventLogEntry) _entriesWritten [2];
		Assert.AreEqual ((short) 4, entry.CategoryNumber, "#A11");
		Assert.AreEqual (444, entry.EventID, "#A12");
		Assert.AreEqual ("message4", entry.Message, "#A13");
		Assert.AreEqual ("monoothersource", entry.Source, "#A14");

		otherEventLogB.Dispose ();

		Thread.Sleep (2000);

		otherEventLogB = new EventLog ("monologother", ".", "monoothersource");
		otherEventLogB.EntryWritten += new EntryWrittenEventHandler (EventLog_EntryWritten);
		otherEventLogB.EnableRaisingEvents = true;

		otherEventLogA.WriteEntry ("message5", EventLogEntryType.Warning,
			555, 5, new byte [] { 5, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (4, _entriesWritten.Count, "#A15");

		entry = (EventLogEntry) _entriesWritten [3];
		Assert.AreEqual ((short) 5, entry.CategoryNumber, "#A16");
		Assert.AreEqual (555, entry.EventID, "#A17");
		Assert.AreEqual ("message5", entry.Message, "#A18");
		Assert.AreEqual ("monoothersource", entry.Source, "#A19");

		tempEventLog.Dispose ();
		otherEventLogA.Dispose ();
		otherEventLogB.Dispose ();

		Thread.Sleep (2000);
	}

	void TestB ()
	{
		if (!EventLog.Exists ("monologtemp", "."))
			EventLog.CreateEventSource ("monotempsource", "monologtemp");
		if (!EventLog.Exists ("monologother", "."))
			EventLog.CreateEventSource ("monoothersource", "monologother");

		EventLog otherEventLogA = new EventLog ("monologother", ".", "monoothersource");

		EventLog otherEventLogB = new EventLog ("monologtemp", ".", "monotempsource");
		otherEventLogB.EntryWritten += new EntryWrittenEventHandler (EventLog_EntryWritten);
		otherEventLogB.EnableRaisingEvents = true;

		otherEventLogA.WriteEntry ("message1", EventLogEntryType.Warning,
			111, 1, new byte [] { 1, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (0, _entriesWritten.Count, "#B1");

		otherEventLogB.Log = "monologother";

		otherEventLogA.WriteEntry ("message2", EventLogEntryType.Warning,
			222, 2, new byte [] { 2, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (1, _entriesWritten.Count, "#B2");

		EventLogEntry entry = (EventLogEntry) _entriesWritten [0];
		Assert.AreEqual ((short) 2, entry.CategoryNumber, "#B3");
		Assert.AreEqual (222, entry.EventID, "#B4");
		Assert.AreEqual ("message2", entry.Message, "#B5");
		Assert.AreEqual ("monoothersource", entry.Source, "#B6");

		otherEventLogA.Dispose ();
		otherEventLogB.Dispose ();

		Thread.Sleep (2000);
	}

	void TestC ()
	{
		if (!EventLog.Exists ("monologtemp", ".")) {
			EventLog.CreateEventSource ("monotempsourceA", "monologtemp");
			EventLog.CreateEventSource ("monotempsourceB", "monologtemp");
		}

		EventLog otherEventLogA = new EventLog ("monologtemp", ".", "monotempsourceA");

		EventLog otherEventLogB = new EventLog ("monologtemp", ".", "monotempsourceB");
		otherEventLogB.EntryWritten += new EntryWrittenEventHandler (EventLog_EntryWritten);
		otherEventLogB.EnableRaisingEvents = true;

		otherEventLogA.WriteEntry ("message1", EventLogEntryType.Warning,
			111, 1, new byte [] { 1, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (1, _entriesWritten.Count, "#C1");

		EventLogEntry entry = (EventLogEntry) _entriesWritten [0];
		Assert.AreEqual ((short) 1, entry.CategoryNumber, "#C2");
		Assert.AreEqual (111, entry.EventID, "#C3");
		Assert.AreEqual ("message1", entry.Message, "#C4");
		Assert.AreEqual ("monotempsourceA", entry.Source, "#C5");

		otherEventLogA.Clear ();

		otherEventLogA.WriteEntry ("message2", EventLogEntryType.Warning,
			222, 2, new byte [] { 2, 8 });
		otherEventLogA.WriteEntry ("message3", EventLogEntryType.Warning,
			333, 3, new byte [] { 3, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (2, _entriesWritten.Count, "#C6");

		entry = (EventLogEntry) _entriesWritten [1];
		Assert.AreEqual ((short) 3, entry.CategoryNumber, "#C7");
		Assert.AreEqual (333, entry.EventID, "#C8");
		Assert.AreEqual ("message3", entry.Message, "#C9");
		Assert.AreEqual ("monotempsourceA", entry.Source, "#C10");

		otherEventLogB.WriteEntry ("message4", EventLogEntryType.Warning,
			444, 4, new byte [] { 3, 8 });

		Thread.Sleep (10000);

		Assert.AreEqual (3, _entriesWritten.Count, "#C11");

		entry = (EventLogEntry) _entriesWritten [2];
		Assert.AreEqual ((short) 4, entry.CategoryNumber, "#C12");
		Assert.AreEqual (444, entry.EventID, "#C13");
		Assert.AreEqual ("message4", entry.Message, "#C14");
		Assert.AreEqual ("monotempsourceB", entry.Source, "#C15");

		otherEventLogA.Dispose ();
		otherEventLogB.Dispose ();

		Thread.Sleep (2000);
	}

	void EventLog_EntryWritten (object sender, EntryWrittenEventArgs e)
	{
		_entriesWritten.Add (e.Entry);
	}

	private ArrayList _entriesWritten;
}

class Assert
{
	public static void AreEqual (string a, string b, string msg)
	{
		if (a != b)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected {0} but was {1}: {2}", a, b, msg));
	}

	public static void AreEqual (int a, int b, string msg)
	{
		if (a != b)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected {0} but was {1}: {2}", a, b, msg));
	}

	public static void AreEqual (short a, short b, string msg)
	{
		if (a != b)
			throw new Exception (string.Format (CultureInfo.InvariantCulture,
				"Expected {0} but was {1}: {2}", a, b, msg));
	}
}
