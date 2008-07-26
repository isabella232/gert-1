using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
	static void Main ()
	{
		const string issuerName = "C=PL, S=Somewhere, O=SomeON, OU=SomeOUN, CN=test, E=test@test";
#if NET_2_0
		const string issuer = "E=test@test, CN=test, OU=SomeOUN, O=SomeON, S=Somewhere, C=PL";
#endif

		X509Certificate cert = X509Certificate.CreateFromCertFile ("cert.pem");
#if NET_2_0
		Assert.AreEqual (issuer, cert.Issuer, "#1");
		Assert.AreEqual (issuer, cert.Subject, "#2");
		Assert.AreEqual (issuerName, cert.GetIssuerName (), "#3");
		Assert.AreEqual (issuerName, cert.GetName (), "#4");
#else
		Assert.AreEqual (issuerName, cert.GetIssuerName (), "#1");
		Assert.AreEqual (issuerName, cert.GetName (), "#2");
#endif
	}
}
