using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Server
{
	static void Main ()
	{
		TcpListener listener = new TcpListener (IPAddress.Loopback, 8001);
		listener.Start ();

		TcpClient client = listener.AcceptTcpClient ();

		NetworkStream s = client.GetStream ();
		byte [] buff = new byte [1024];
		do {
			s.Read (buff, 0, buff.Length);
		} while (s.DataAvailable);

		string payload = @"<?xml version=""1.0"" encoding=""UTF-8""?>
			<soapenv:Envelope xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
				<soapenv:Body>
					<RetrievePropertiesResponseResponse xmlns=""urn:internalvim25"">
						<RetrievePropertiesResponseResult>
							<RetrievePropertiesResponse xmlns='urn:internalvim25'>
								<returnval xmlns=""urn:internalvim25"">
									<obj type=""Folder"">group-d1</obj>
									<propSet>
										<name>childEntity</name>
										<val xsi:type=""ArrayOfManagedObjectReference"">
											<ManagedObjectReference type=""Folder"" xsi:type=""ManagedObjectReference"">group-d33</ManagedObjectReference>
											<ManagedObjectReference type=""Folder"" xsi:type=""ManagedObjectReference"">group-d36</ManagedObjectReference>
											<ManagedObjectReference type=""Folder"" xsi:type=""ManagedObjectReference"">group-d2</ManagedObjectReference>
											<ManagedObjectReference type=""Datacenter"" xsi:type=""ManagedObjectReference"">datacenter-3</ManagedObjectReference>
										</val>
									</propSet>
								</returnval>
							</RetrievePropertiesResponse>
						</RetrievePropertiesResponseResult>
					</RetrievePropertiesResponseResponse>
				</soapenv:Body>
			</soapenv:Envelope>";

		string response = string.Format (CultureInfo.InvariantCulture,
			"HTTP/1.1 200 OK{0}" +
			"Date: Wed, 21 May 2008 22:17:55 GMT{0}" +
			"Cache-Control: no-cache{0}" +
			"Content-Type: text/xml; charset=utf-8{0}" +
			"Content-Length: {1}{0}" +
			"{0}" +
			"{2}", "\r\n", payload.Length, payload);

		Byte [] bytes = Encoding.ASCII.GetBytes (response);
		s.Write (bytes, 0, bytes.Length);
		s.Flush ();
	}
}
