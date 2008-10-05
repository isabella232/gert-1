using System.Net.Sockets;
using System.Web.Services;

namespace BugReport
{
	[WebService]
	public class BugReportService : WebService
	{
		[WebMethod (MessageName = "Connect", Description = "")]
		public void Connect (string serverName, int port)
		{
			using (TcpClient socketClient = new TcpClient (serverName, port)) {
			}
		}
	}
}
