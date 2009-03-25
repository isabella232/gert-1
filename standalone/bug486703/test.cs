using System;
using System.Net;
using System.IO;

class Program
{
	static int Main ()
	{
		if (Environment.GetEnvironmentVariable ("MONO_TESTS_FTP") == null)
			return 0;

		FtpWebRequest req;
		FtpWebResponse response = null;

		req = (FtpWebRequest) WebRequest.Create ("ftp://ftp.mozilla.org");
		req.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

		try {
			response = (FtpWebResponse) req.GetResponse ();
			Assert.AreEqual ("257 \"/\"\r\n", response.StatusDescription, "#A1");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string line = sr.ReadLine ();
				Assert.IsNull (line, "#A2");
			}
		} finally {
			if (response != null)
				response.Close ();
		}

		req = (FtpWebRequest) WebRequest.Create ("ftp://ftp.microsoft.com/deskapps/project");
		req.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

		try {
			response = (FtpWebResponse) req.GetResponse ();
			Assert.AreEqual ("257 \"/deskapps/project\" is current directory.\r\n", response.StatusDescription, "#B1");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string line = sr.ReadLine ();
				Assert.IsNull (line, "#B2");
			}
		} finally {
			if (response != null)
				response.Close ();
		}

		string uri = Environment.GetEnvironmentVariable ("MONO_TESTS_FTP_URI");
		if (uri == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_FTP_URI");

		req = (FtpWebRequest) WebRequest.Create (uri);
		req.Credentials = GetCredentials ();
		req.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;

		try {
			response = (FtpWebResponse) req.GetResponse ();
			Assert.AreEqual ("257 \"/mono\" is the current directory\r\n", response.StatusDescription, "#C1");
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string line = sr.ReadLine ();
				Assert.IsNull (line, "#C2");
			}
		} finally {
			if (response != null)
				response.Close ();
		}

		return 0;
	}

	static NetworkCredential GetCredentials ()
	{
		string userName = Environment.GetEnvironmentVariable ("MONO_TESTS_FTP_USER");
		if (userName == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_FTP_USER");

		string pwd = Environment.GetEnvironmentVariable ("MONO_TESTS_FTP_PWD");
		if (pwd == null)
			throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_FTP_PWD");
		return new NetworkCredential (userName, pwd);
	}

	static ArgumentException CreateEnvironmentVariableNotSetException (string name)
	{
		return new ArgumentException ("The " + name + " environment variable is not set");
	}
}
