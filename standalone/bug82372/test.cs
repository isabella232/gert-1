using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

class Program
{
	static int Main ()
	{
		string input = @"
			<Config>
				<SavedSplitterDistances>
					<dictionary />
				</SavedSplitterDistances>
				<SavedWindowLocations>
					<dictionary>
						<item>
							<key>
								<string>MainWindow</string>
							</key>
							<value>
								<int>10</int>
							</value>
						</item>
						<item>
							<key>
								<string>Child</string>
							</key>
							<value>
								<int>5</int>
							</value>
						</item>
					</dictionary>
				</SavedWindowLocations>
			</Config>";

		XmlSerializer ser = new XmlSerializer (typeof (Settings));
		Settings settings = (Settings) ser.Deserialize (new StringReader (input));
		if (settings.SavedSplitterDistances.Count != 0)
			return 1;
		if (settings.SavedWindowLocations.Count != 2)
			return 2;
		if (settings.SavedWindowLocations ["MainWindow"] != 10)
			return 3;
		if (settings.SavedWindowLocations ["Child"] != 5)
			return 4;

		MemoryStream ms = new MemoryStream ();
		StreamWriter sw = new StreamWriter (ms, Encoding.UTF8);
		sw.Write (input);
		sw.Flush ();
		ms.Position = 0;

		settings = (Settings) ser.Deserialize (ms);

		if (settings.SavedSplitterDistances.Count != 0)
			return 5;
		if (settings.SavedWindowLocations.Count != 2)
			return 6;
		if (settings.SavedWindowLocations ["MainWindow"] != 10)
			return 7;
		if (settings.SavedWindowLocations ["Child"] != 5)
			return 8;

		return 0;
	}
}

[XmlRoot ("Config")]
public class Settings
{
	private SerializableDictionary<string, int> m_savedSplitterDistances = new SerializableDictionary<string, int> ();

	public SerializableDictionary<string, int> SavedSplitterDistances
	{
		get { return m_savedSplitterDistances; }
		set
		{
			m_savedSplitterDistances = value;
		}
	}

	private SerializableDictionary<string, int> m_savedWindowLocations = new SerializableDictionary<string, int> ();

	public SerializableDictionary<string, int> SavedWindowLocations
	{
		get { return m_savedWindowLocations; }
		set
		{
			m_savedWindowLocations = value;
		}
	}
}

[XmlRoot]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
	public XmlSchema GetSchema ()
	{
		return null;
	}

	public void ReadXml (XmlReader reader)
	{
		XmlTextReader xtr = (XmlTextReader) reader;
		if (xtr.WhitespaceHandling != WhitespaceHandling.Significant)
			throw new Exception ();

		XmlSerializer keySer = new XmlSerializer (typeof (TKey));
		XmlSerializer valueSer = new XmlSerializer (typeof (TValue));

		reader.Read ();
		reader.ReadStartElement ("dictionary");
		while (reader.NodeType != XmlNodeType.EndElement) {
			reader.ReadStartElement ("item");
			reader.ReadStartElement ("key");
			TKey key = (TKey) keySer.Deserialize (reader);
			reader.ReadEndElement ();

			reader.ReadStartElement ("value");
			TValue value = (TValue) valueSer.Deserialize (reader);
			reader.ReadEndElement ();

			this.Add (key, value);
			reader.ReadEndElement ();
			reader.MoveToContent ();
		}
		if (this.Count != 0) {
			reader.ReadEndElement ();
		}
		reader.ReadEndElement ();
	}

	public void WriteXml (XmlWriter writer)
	{
		XmlSerializer keySer = new XmlSerializer (typeof (TKey));
		XmlSerializer valueSer = new XmlSerializer (typeof (TValue));

		writer.WriteStartElement ("dictionary");
		foreach (TKey key in this.Keys) {
			writer.WriteStartElement ("item");

			writer.WriteStartElement ("key");
			keySer.Serialize (writer, key);
			writer.WriteEndElement ();

			writer.WriteStartElement ("value");
			valueSer.Serialize (writer, this [key]);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
		}
		writer.WriteEndElement ();
	}
}
