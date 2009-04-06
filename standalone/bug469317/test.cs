using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;

class Program
{
	static void Main ()
	{
		string xsdFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"manifest.xsd");

		Test1 (xsdFile);
#if NET_2_0
		Test2 (xsdFile);
#endif
	}

	static void Test1 (string xsdFile)
	{
		byte [] data = Encoding.UTF8.GetBytes (xml);

		using (MemoryStream xmlStream = new MemoryStream (data)) {
			XmlReader xmlReader = new XmlTextReader (xmlStream);

			XmlValidatingReader vr = new XmlValidatingReader (xmlReader);
			vr.ValidationType = ValidationType.Schema;
			vr.Schemas.Add (null, new XmlTextReader (xsdFile));
			vr.Schemas.Add (null, new XmlTextReader ("http://www.w3.org/TR/xmldsig-core/xmldsig-core-schema.xsd"));

			while (vr.Read ()) {
			}
		}
	}

#if NET_2_0
	static void Test2 (string xsdFile)
	{
		byte [] data = Encoding.UTF8.GetBytes (xml);

		using (MemoryStream xmlStream = new MemoryStream (data)) {
			XmlReaderSettings settings = new XmlReaderSettings ();
			settings.ProhibitDtd = false;
			XmlReaderSettings xrs = new XmlReaderSettings ();
			xrs.ProhibitDtd = false;
			settings.Schemas.Add (null, new XmlTextReader (xsdFile));
			settings.Schemas.Add (null, XmlReader.Create ("http://www.w3.org/TR/xmldsig-core/xmldsig-core-schema.xsd", xrs));
			settings.ValidationType = ValidationType.Schema;

			XmlReader reader = XmlReader.Create (xmlStream, settings);
			while (reader.Read ()) {
			}
		}
	}
#endif

	static string xml = @"<?xml version='1.0' encoding='UTF-8'?>
		<!-- 
		* Copyright (c) 2008 Yamaha Corporation
		* All rights reserved.
		*
		* Redistribution and use in source and binary forms, with or without
		* modification, are permitted provided that the following conditions are met:
		*     * Redistributions of source code must retain the above copyright
		*       notice, this list of conditions and the following disclaimer.
		*     * Redistributions in binary form must reproduce the above copyright
		*       notice, this list of conditions and the following disclaimer in the
		*       documentation and/or other materials provided with the distribution.
		*     * Neither the name of the <organization> nor the
		*       names of its contributors may be used to endorse or promote products
		*       derived from this software without specific prior written permission.
		*
		* THIS SOFTWARE IS PROVIDED BY YAMAHA CORPORATION ''AS IS'' AND ANY
		* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
		* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
		* DISCLAIMED. IN NO EVENT SHALL YAMAHA CORPORATION BE LIABLE FOR ANY
		* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
		* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
		* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
		* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
		* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
		* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
		-->
		<osfm:manifest xmlns:osfm='http://www.yamaha.co.uk/osf/manifest/0.9' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
			<osfm:assets name='Abc'>
				<osfm:asset media-type='text/xml' name='Container.xml' />
				<osfm:asset media-type='text/xml' name='Manifest.xml' />
				<osfm:asset media-type='text/xml' name='Metadata.xml' />
				<osfm:asset media-type='application/osf-score-pvg-profile+xml' name='Score.xml' />
				<osfm:asset media-type='pdf' name='Alternate/Score.pdf' />
				<osfm:asset-group name='alternate'>
					<osfm:asset-reference ref='Alternate/Score.pdf'></osfm:asset-reference>
				</osfm:asset-group>
			</osfm:assets>
		</osfm:manifest>";
}
