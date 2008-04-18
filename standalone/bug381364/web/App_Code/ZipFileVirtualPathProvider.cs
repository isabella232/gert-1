using System;
using System.Collections;
using System.Text;
using System.Web.Caching;
using System.Web.Hosting;

using ICSharpCode.SharpZipLib.Zip;

namespace Clarius.Samples.Web.VirtualPathProvider
{
	public class ZipFileVirtualPathProvider : System.Web.Hosting.VirtualPathProvider
	{
		ZipFile _zipFile;

		public ZipFileVirtualPathProvider (string zipFilename)
			: base ()
		{
			_zipFile = new ZipFile (zipFilename);
		}

		~ZipFileVirtualPathProvider ()
		{
			_zipFile.Close ();
		}

		public override bool FileExists (string virtualPath)
		{
			string zipPath = Util.ConvertVirtualPathToZipPath (virtualPath, true);
			ZipEntry zipEntry = _zipFile.GetEntry (zipPath);

			if (zipEntry != null)
				return !zipEntry.IsDirectory;

			// give previously registered provider a chance
			// to process the directory
			return Previous.FileExists (virtualPath);
		}

		public override bool DirectoryExists (string virtualDir)
		{
			string zipPath = Util.ConvertVirtualPathToZipPath (virtualDir, false);
			ZipEntry zipEntry = _zipFile.GetEntry (zipPath);

			if (zipEntry != null)
				return zipEntry.IsDirectory;

			// give previously registered provider a chance
			// to process the directory
			return Previous.DirectoryExists (virtualDir);
		}

		public override VirtualFile GetFile (string virtualPath)
		{
			string zipPath = Util.ConvertVirtualPathToZipPath (virtualPath, true);
			ZipEntry zipEntry = _zipFile.GetEntry (zipPath);

			if (zipEntry != null)
				return new ZipVirtualFile (virtualPath, _zipFile);
			return Previous.GetFile (virtualPath);
		}

		public override VirtualDirectory GetDirectory (string virtualDir)
		{
			string zipPath = Util.ConvertVirtualPathToZipPath (virtualDir, false);
			ZipEntry zipEntry = _zipFile.GetEntry (zipPath);

			if (zipEntry != null && zipEntry.IsDirectory)
				return new ZipVirtualDirectory (virtualDir, _zipFile);
			return Previous.GetDirectory (virtualDir);
		}

		public override string GetFileHash (string virtualPath, IEnumerable virtualPathDependencies)
		{
			return null;
		}

		public override CacheDependency GetCacheDependency (String virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
		{
			return null;
		}
	}
}
