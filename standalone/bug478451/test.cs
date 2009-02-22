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
				Assert.AreEqual (FtpStatusCode.FileActionOK, resp.StatusCode, "#B");
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

			BasicFTPClient client = new BasicFTPClient ();

			byte [] send;
			byte [] receive;
			string tmpDir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
				"temp");
			Directory.CreateDirectory (tmpDir);

			try {
				send = Encoding.UTF8.GetBytes ("Mono Webclient FTP 1");
				receive = client.UploadData ("bug478451-1", send);
				Assert.IsNotNull (receive, "#A1");
				Assert.AreEqual (0, receive.Length, "#A2");
				receive = client.DownloadData ("bug478451-1");
				Assert.IsNotNull (receive, "#A3");
				Assert.AreEqual (send, receive, "#A4");

				using (StreamWriter sw = new StreamWriter (Path.Combine (tmpDir, "bug478451-2"), false, Encoding.UTF8)) {
					sw.Write ("Mono Webclient FTP 2");
				}

				client.UploadFile ("bug478451-2", Path.Combine (tmpDir, "bug478451-2"));
				client.DownloadFile ("bug478451-2", Path.Combine (tmpDir, "bug478451-2-receive"));

				using (StreamReader sr = new StreamReader (Path.Combine (tmpDir, "bug478451-2-receive"), Encoding.UTF8)) {
					Assert.AreEqual ("Mono Webclient FTP 2", sr.ReadToEnd (), "#B");
				}

				receive = client.UploadData ("bug478451-3", new byte [0]);
				Assert.IsNotNull (receive, "#C1");
				Assert.AreEqual (0, receive.Length, "#C2");
				receive = client.DownloadData ("bug478451-3");
				Assert.IsNotNull (receive, "#C3");
				Assert.AreEqual (0, receive.Length, "#C4");

				return 0;
			} finally {
				client.DeleteFile ("bug478451-1");
				client.DeleteFile ("bug478451-2");
				client.DeleteFile ("bug478451-3");
				Directory.Delete (tmpDir, true);
			}
		}
	}
}
