using System;
using System.IO;
using System.Web;
using System.Text;
using System.Collections;

namespace ServerTransfer
{
	public class AlbumRequestHandler : IHttpHandler
	{
		public void ProcessRequest (HttpContext context)
		{
			context.Server.Transfer ("~/AlbumListing.aspx?albumID=" +
				Path.GetFileName (context.Request.FilePath));
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
