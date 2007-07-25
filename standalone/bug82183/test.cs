using System;
using System.IO;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main ()
	{
		string xml = @"
			<webReferenceOptions xmlns='http://microsoft.com/webReference/'>
				<codeGenerationOptions>properties newAsync</codeGenerationOptions>
			</webReferenceOptions>";

#if NET_2_0
		Validate (xml, WebReferenceOptions.Schema);
#endif

		string dir = AppDomain.CurrentDomain.BaseDirectory;
		using (FileStream fs = File.OpenRead (Path.Combine (dir, "webReferenceOptions.xsd"))) {
			XmlSchema schema = XmlSchema.Read (fs, null);
			Validate (xml, schema);
		}
	}

	static void Validate (string xml, XmlSchema schema)
	{
#if NET_2_0
		XmlReaderSettings s = new XmlReaderSettings ();
		s.ValidationType = ValidationType.Schema;
		s.Schemas.Add (schema);
		XmlReader r = XmlReader.Create (new StringReader (xml), s);
#else
		XmlTextReader xtr = new XmlTextReader (new StringReader (xml));
		XmlValidatingReader r = new XmlValidatingReader (xtr);
		r.ValidationType = ValidationType.Schema;
#endif
		while (!r.EOF)
			r.Read ();
	}
}
