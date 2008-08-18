using System;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

class Program
{
	static void Main ()
	{
		DataTable tbl = new DataTable ("LrtTable");
		tbl.Columns.Add ("Dummy", typeof (uint));
		tbl.Columns.Add ("FuncXml", typeof (LrtXml));

		DataSet ds = new DataSet ("LrtData");
		ds.Tables.Add (tbl);
		ds.ReadXml ("test.xml");

		Assert.AreEqual (1, ds.Tables ["LrtTable"].Rows.Count, "#1");
	}
}

[Serializable]
public class LrtXml : IXmlSerializable
{
	private XmlNode mFuncXmlNode;

	public LrtXml ()
	{
	}

	public LrtXml (string str)
	{
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (str);
		mFuncXmlNode = (XmlNode) (doc.DocumentElement);
	}

	public LrtXml (XmlNode xNode)
	{
		mFuncXmlNode = xNode;
	}

	public XmlNode Node
	{
		get
		{
			return mFuncXmlNode;
		}
		set
		{
			this.mFuncXmlNode = value;
		}
	}

	public override string ToString ()
	{
		return this.Node.OuterXml;
	}

	void IXmlSerializable.WriteXml (XmlWriter writer)
	{
		XmlDocument doc = new XmlDocument ();
		doc.LoadXml (mFuncXmlNode.OuterXml);

		// On function level
		if (doc.DocumentElement.Name == "Func") {
			try { doc.DocumentElement.Attributes.Remove (doc.DocumentElement.Attributes ["ReturnType"]); } catch { }
			try { doc.DocumentElement.Attributes.Remove (doc.DocumentElement.Attributes ["ReturnTId"]); } catch { }
			try { doc.DocumentElement.Attributes.Remove (doc.DocumentElement.Attributes ["CSharpType"]); } catch { }
		} else {
			UpgradeSchema (doc.DocumentElement);
		}

		// Make sure lrt is saved according to latest schema
		foreach (XmlNode n in doc.DocumentElement.ChildNodes) {
			UpgradeSchema (n);
		}

		doc.WriteTo (writer);
	}

	void IXmlSerializable.ReadXml (XmlReader reader)
	{
		XmlDocument doc = new XmlDocument ();
		string str = reader.ReadString ();
		try {
			doc.LoadXml (str);
		} catch {
			doc.LoadXml (reader.ReadOuterXml ());
		}
		mFuncXmlNode = (XmlNode) (doc.DocumentElement);
	}

	XmlSchema IXmlSerializable.GetSchema ()
	{
		return (null);
	}

	void UpgradeSchema (XmlNode xNode)
	{
		try { xNode.Attributes.Remove (xNode.Attributes ["TId"]); } catch { }
		try { xNode.Attributes.Remove (xNode.Attributes ["OnError"]); } catch { }
		try { xNode.Attributes.Remove (xNode.Attributes ["Check"]); } catch { }
		try { xNode.Attributes.Remove (xNode.Attributes ["ParamType"]); } catch { }
		try { xNode.Attributes.Remove (xNode.Attributes ["RealLen"]); } catch { }

		try {
			XmlAttribute attr = xNode.Attributes ["IsExpGetRef"];
			xNode.Attributes.Remove (xNode.Attributes ["IsExpGetRef"]);
			xNode.Attributes.InsertAfter (attr, xNode.Attributes ["ExpectedValue"]);
		} catch { }

		string tmp = xNode.Attributes ["HandleInput"].Value;
		tmp = tmp.Replace ("E_LRT_INPUT_HANDLE_", "");
		xNode.Attributes ["HandleInput"].Value = tmp;

		foreach (XmlNode n in xNode.ChildNodes) {
			UpgradeSchema (n);
		}
	}
}
