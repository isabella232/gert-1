using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
	static void Main ()
	{
		string url = "ftp://users.telenet.be/mono/" +
			Guid.NewGuid ().ToString ("N") + ".tmp";

		UploadFile (url);
		DownloadFile (url);
		DeleteFile (url);
		DeleteFile_NonExisting (url);
	}

	static void UploadFile (string url)
	{
		FtpWebRequest req = (FtpWebRequest) WebRequest.Create (url);
		req.Credentials = GetCredentials ();
		req.Method = WebRequestMethods.Ftp.UploadFile;

		Stream rs = req.GetRequestStream ();

		using (StreamWriter sw = new StreamWriter (rs, Encoding.UTF8)) {
			sw.WriteLine ("Standalone test for Mono's FtpWebRequest.");
			sw.WriteLine ("Working gréat!");
			sw.Flush ();
		}
		rs.Close ();
	}

	static void DownloadFile (string url)
	{
		string expected = "Standalone test for Mono's FtpWebRequest."
			+ Environment.NewLine + "Working gréat!"
			+ Environment.NewLine;

		FtpWebRequest req = (FtpWebRequest) WebRequest.Create (url);
		req.Credentials = GetCredentials ();
		req.Method = WebRequestMethods.Ftp.DownloadFile;

		FtpWebResponse resp = (FtpWebResponse) req.GetResponse ();
		Stream rs = resp.GetResponseStream ();
		using (StreamReader sr = new StreamReader (rs, Encoding.UTF8, true)) {
			string content = sr.ReadToEnd ();
			if (content != expected)
				throw new Exception ("#1:" + content);
		}
		rs.Close ();
	}

	static void DeleteFile (string url)
	{
		FtpWebRequest req = (FtpWebRequest) WebRequest.Create (url);
		req.Credentials = GetCredentials ();
		req.Method = WebRequestMethods.Ftp.DeleteFile;

		FtpWebResponse resp = (FtpWebResponse) req.GetResponse ();
		try {
			if (resp.StatusCode != FtpStatusCode.FileActionOK)
				throw new Exception ("#1:" +resp.StatusCode.ToString ());
		} finally {
			resp.Close ();
		}
	}

	static void DeleteFile_NonExisting (string url)
	{
		FtpWebRequest req = (FtpWebRequest) WebRequest.Create (url);
		req.Credentials = GetCredentials ();
		req.Method = WebRequestMethods.Ftp.DeleteFile;

		try {
			req.GetResponse ();
			throw new Exception ("#1");
		} catch (WebException ex) {
			FtpWebResponse resp = ex.Response as FtpWebResponse;
			if (resp == null)
				throw new Exception ("#2");
			if (resp.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
				throw new Exception ("#3:" + resp.StatusCode);
		}
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
