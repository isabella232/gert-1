using System;
using System.Net;
using System.IO;
using System.Text;

namespace BasicFTPClientNamespace
{
	class BasicFTPClient
	{
		public string remoteUri;

		public BasicFTPClient ()
		{
			string uri = Environment.GetEnvironmentVariable ("MONO_TESTS_FTP_URI");
			if (uri == null)
				throw CreateEnvironmentVariableNotSetException ("MONO_TESTS_FTP_URI");
			remoteUri = uri;
		}

		public void DeleteFile (string remotePath)
		{
			FtpWebRequest req = (FtpWebRequest) WebRequest.Create (BuildServerUri (remotePath));
			req.Credentials = GetCredentials ();
			req.Method = WebRequestMethods.Ftp.DeleteFile;

			FtpWebResponse resp = (FtpWebResponse) req.GetResponse ();
			try {
				Assert.AreEqual (FtpStatusCode.FileActionOK,
					resp.StatusCode, "Failed to delete '" + remotePath + "'.");
			} finally {
				resp.Close ();
			}
		}

		public byte [] DownloadData (string remotePath)
		{
			WebClient request = CreateClient ();
			return request.DownloadData (BuildServerUri (remotePath));
		}

		public void DownloadFile (string remotePath, string fileName)
		{
			WebClient request = CreateClient ();
			request.DownloadFile (BuildServerUri (remotePath), fileName);
		}

		public byte [] UploadData (string remotePath, byte [] data)
		{
			WebClient request = CreateClient ();
			return request.UploadData (BuildServerUri (remotePath), data);
		}

		public byte [] UploadFile (string remotePath, string fileName)
		{
			WebClient request = CreateClient ();
			return request.UploadFile (BuildServerUri (remotePath), fileName);
		}

		Uri BuildServerUri (string path)
		{
			return new Uri (String.Format ("{0}/{1}", remoteUri, path));
		}

		static WebClient CreateClient ()
		{
			WebClient request = new WebClient ();
			request.Credentials = GetCredentials ();
			return request;
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

	class Program
	{
		static int Main ()
		{
			if (Environment.GetEnvironmentVariable ("MONO_TESTS_FTP") == null)
				return 0;

			FtpWebRequest req;
			WebResponse response = null;

			req = (FtpWebRequest) WebRequest.Create ("ftp://ftp.mozilla.org");
			req.Method = WebRequestMethods.Ftp.ListDirectory;

			try {
				response = req.GetResponse ();
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					string line = sr.ReadLine ();
					Assert.AreEqual ("README", line, "#A1");
					line = sr.ReadLine ();
					Assert.AreEqual ("index.html", line, "#A2");
					line = sr.ReadLine ();
					Assert.AreEqual ("pub", line, "#A3");
					line = sr.ReadLine ();
					Assert.IsNull (line, "#A4");
				}
			} finally {
				if (response != null)
					response.Close ();
			}

			req = (FtpWebRequest) WebRequest.Create ("ftp://ftp.microsoft.com/deskapps/project");
			req.Method = WebRequestMethods.Ftp.ListDirectory;

			try {
				response = req.GetResponse ();
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					string line = sr.ReadLine ();
					Assert.AreEqual ("KB", line, "#B1");
					line = sr.ReadLine ();
					Assert.AreEqual ("README.TXT", line, "#B2");
					line = sr.ReadLine ();
					Assert.AreEqual ("ReadMe1.txt", line, "#B3");
					line = sr.ReadLine ();
					Assert.IsNull (line, "#B4");
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
			req.Method = WebRequestMethods.Ftp.ListDirectory;

			try {
				response = req.GetResponse ();
				using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
					string line = sr.ReadLine ();
					Assert.AreEqual ("mono/.", line, "#C1");
					line = sr.ReadLine ();
					Assert.AreEqual ("mono/..", line, "#C2");
					line = sr.ReadLine ();
					Assert.IsNull (line, "#C3");
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
}
