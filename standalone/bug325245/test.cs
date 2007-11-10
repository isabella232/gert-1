using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	[STAThread]
	static int Main ()
	{
		ValidationError ve = null;
		XmlSchema schema = XmlSchema.Read (new XmlTextReader ("schema.xsd"), null);

#if NET_2_0
		XmlReaderSettings settings = new XmlReaderSettings ();
		settings.ValidationType = ValidationType.Schema;
		settings.Schemas.Add (schema);
		settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

		_reader = XmlReader.Create (new XmlTextReader ("input.xml"), settings);
		while (_reader.Read ()) ;
		_reader.Close ();

		if (_validationErrors.Count != 1)
			return 1;

		ve = (ValidationError) _validationErrors [0];
		if (ve.LocalName != "myfield3")
			return 2;
		if (ve.NamespaceURI.Length != 0)
			return 3;
#endif

		_validationErrors.Clear ();

		XmlValidatingReader vr = new XmlValidatingReader (new XmlTextReader ("input.xml"));
		vr.ValidationType = ValidationType.Schema;
		vr.Schemas.Add (schema);
		vr.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

		_reader = vr;

		while (_reader.Read ()) ;

		if (_validationErrors.Count != 1)
			return 1;

		ve = (ValidationError) _validationErrors [0];
		if (ve.LocalName != "myfield3")
			return 2;
		if (ve.NamespaceURI.Length != 0)
			return 3;

		return 0;
	}

	static void ValidationCallBack (Object sender, ValidationEventArgs e)
	{
		_validationErrors.Add (new ValidationError (e, _reader.LocalName,
			_reader.NamespaceURI));
	}

	static ArrayList _validationErrors = new ArrayList ();
	static XmlReader _reader;
}

class ValidationError
{
	public ValidationError (ValidationEventArgs e, string localName, string namespaceURI)
	{
		_event = e;
		_localName = localName;
		_namespaceURI = namespaceURI;
	}

	public ValidationEventArgs Event
	{
		get { return _event; }
	}

	public string LocalName
	{
		get { return _localName; }
	}

	public string NamespaceURI
	{
		get { return _namespaceURI; }
	}

	private readonly ValidationEventArgs _event;
	private readonly string _localName;
	private readonly string _namespaceURI;
}
