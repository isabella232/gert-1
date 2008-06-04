using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
	static void Main ()
	{
		const string issuer = "E=test@test, CN=test, OU=SomeOUN, O=SomeON, S=Somewhere, C=PL";

		X509Certificate cert = X509Certificate.CreateFromCertFile ("cert.pem");
#if NET_2_0
		Assert.AreEqual (issuer, cert.Issuer, "#1");
#else
		Assert.AreEqual (issuer, cert.GetIssuerName (), "#1");
#endif
	}
}
