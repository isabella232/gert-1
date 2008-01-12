using System;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.Threading;

class Program
{
	static void Main ()
	{
		GetFreshWebClient ("http://localhost:8081/Default.aspx");
		m_nvcollectionmain = new NameValueCollection ();
		m_nvcollectionmain.Add ("q", "mono");
		m_nvcollectionmain.Add ("q", "rocks");
		m_nvcollectionmain.Add ("t", "ASP.NET&Mono" + Environment.NewLine + "!");
		m_nvcollectionmain.Add ("x", "Open\nSource");
		m_nvcollectionmain.Add ("z", "Open\r\nSuse");
		m_threadmain = new Thread (BeginCaptureLoop);
		m_threadmain.Start ();
		while (m_threadmain.IsAlive)
			Thread.Sleep (3000);
		Assert.IsNotNull (_response, "#1");
		Assert.IsTrue (_response.IndexOf ("<p>Total: 4</p>") != -1, "#2: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"q\">Lenght: 1</p>") != -1, "#3: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"q\">P[0]: mono,rocks</p>") != -1, "#4: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"t\">Lenght: 1</p>") != -1, "#5: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"t\">P[0]: ASP.NET&Mono" + Environment.NewLine + "!</p>") != -1, "#6: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"x\">Lenght: 1</p>") != -1, "#7: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"x\">P[0]: Open\nSource</p>") != -1, "#8: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"z\">Lenght: 1</p>") != -1, "#9: " + _response);
		Assert.IsTrue (_response.IndexOf ("<p key=\"z\">P[0]: Open\r\nSuse</p>") != -1, "#10: " + _response);
	}

	static void BeginCapture_UploadValuesCompleted (object sender, UploadValuesCompletedEventArgs e)
	{
		byte [] bytResponse = e.Result;
		_response = Encoding.UTF7.GetString (bytResponse);
	}

	static void GetFreshWebClient (string q)
	{
		m_urimainforcapture = new System.Uri (q);
		m_webclientforcapture = new WebClient ();
		m_webclientforcapture.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
		m_webclientforcapture.UploadValuesCompleted += new UploadValuesCompletedEventHandler (BeginCapture_UploadValuesCompleted);
	}

	static void BeginCaptureLoop ()
	{
		m_webclientforcapture.UploadValuesAsync (m_urimainforcapture, "POST", m_nvcollectionmain);
		Thread.Sleep (3000);
		while (m_webclientforcapture.IsBusy)
			Thread.Sleep (3000);
	}

	private static WebClient m_webclientforcapture;
	private static Uri m_urimainforcapture;
	private static NameValueCollection m_nvcollectionmain;
	private static Thread m_threadmain;
	private static string _response;
}
