// project created on 20/08/2006 at 15:34
using System;

using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace AntDownloader
{
	public class Downloads : List<Pattern>{
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Pattern> aPatternList = MainClass.ReadXmlRuleFile();
			if (aPatternList != null){
				foreach(Pattern oPattern in aPatternList)
				{
					MainClass.DownloadPattern(oPattern);
				}
			}
		}
		
		public static Downloads ReadXmlRuleFile()
		{
			Downloads aList = new Downloads();
			
			XmlDocument oDoc = new XmlDocument();
			try{
				oDoc.Load("downloads.xml");
			}
			catch(FileNotFoundException){
				Console.WriteLine("File 'downloads.xml' not found.");
				return null;
			}
			
			XmlNodeList oPatterns = oDoc.GetElementsByTagName("Pattern");
			
			foreach(XmlNode oPatternNode in oPatterns){
				Pattern oPattern = new Pattern();
				oPattern.Name = oPatternNode.Attributes.GetNamedItem("Name").Value;
				oPattern.BaseUrl = oPatternNode.Attributes.GetNamedItem("BaseUrl").Value;
			
				XmlNodeList oSustitutions = oPatternNode.ChildNodes;
				foreach(XmlNode oSustitutionNode in oSustitutions){
					Sustitution oSust = new Sustitution();
					oSust.Number = int.Parse(oSustitutionNode.Attributes.GetNamedItem("Number").Value);
					
					XmlNodeList oSustTypes = oSustitutionNode.ChildNodes;
					foreach(XmlNode oSustTypeNode in oSustTypes){
						if (oSustTypeNode.NodeType == XmlNodeType.Comment)
						{
							continue;
						}
						ISustitutionType oSustType = null;
						switch(oSustTypeNode.Name){
							case "Range":
								Range oRange = new Range();
								oRange.HigherLimit =
									oSustTypeNode.Attributes.GetNamedItem("HigherLimit").Value;
								oRange.LowerLimit = 
									oSustTypeNode.Attributes.GetNamedItem("LowerLimit").Value;
								oSustType = oRange;
								break;
							case "StringList":
								StringList oStringList = new StringList();
								XmlNodeList oValues = oSustTypeNode.ChildNodes;
								foreach(XmlNode oValueNode in oValues){
									oStringList.Add(oValueNode.ChildNodes[0].Value);
								}
								oSustType = oStringList;
								break;
							default:
								throw new NotSupportedException(
									String.Format("SustType '{0}' not expected", oSustTypeNode.Name));
						}
						if (oSustType == null)
						{
							throw new Exception("Unexpected input adding SustType");
						}
						oSust.Add(oSustType);
					}
					if (oSust == null)
					{
						throw new Exception("Unexpected input adding Sust");
					}
					oPattern.Add(oSust);
				}
				if (oPattern == null)
				{
					throw new Exception("Unexpected input adding Pattern");
				}
				aList.Add(oPattern);
			}

			return aList;
		}
		
		public static void DownloadPattern(Pattern oPattern)
		{
			Console.WriteLine();
			Console.WriteLine("Begginning download of pattern " + oPattern.Name);
			
			string sUrl = oPattern.GetNextUrl();
			while (!String.IsNullOrEmpty(sUrl))
			{
				string sPhysPath =
					MainClass.GetPhysicalPathFromUrl(oPattern.Name, sUrl);
				if (File.Exists(sPhysPath)){
					Console.WriteLine("Was going to download {0} but...",
						sUrl);
					Console.WriteLine("File already downloaded! ({0})",
						sPhysPath);
				}
				else {					
					MainClass.DownloadUrl(sUrl, sPhysPath);
				}
				sUrl = oPattern.GetNextUrl();
			}
		}
		
		public static void DownloadUrl(string sUrl, string sPhysPath)
		{
			try{
				byte[] yFile = MainClass.DownloadBinaryFileFromUrl(sUrl);
				MainClass.WriteToDisk(yFile, sPhysPath);
			}
			catch(WebException){
				Console.WriteLine("Download failed");
			}
		}
		
		public static string GetPhysicalPathFromUrl(string sPatternName, string sUrl)
		{
			string sDir = Path.GetDirectoryName(sUrl);
			string sLastDir = sDir.Substring(0, sDir.LastIndexOf(Path.DirectorySeparatorChar));
			sLastDir = sLastDir.Substring(sLastDir.LastIndexOf(Path.DirectorySeparatorChar)+1);
			sDir = sDir.Substring(sDir.LastIndexOf(Path.DirectorySeparatorChar)+1);
			sDir = sLastDir + "-" + sDir;
			string sFilePath =  
				AppDomain.CurrentDomain.BaseDirectory + sPatternName + 
				Path.DirectorySeparatorChar + sDir +
				"-" + Path.GetFileName(sUrl);
			return sFilePath;
		}
		
		public static void WriteToDisk(byte[] yFile, string sFilePath){
		    Console.WriteLine("Saving {0} ...", sFilePath);
		    if (!Directory.Exists(Path.GetDirectoryName(sFilePath)))
		    {
		    	Directory.CreateDirectory(Path.GetDirectoryName(sFilePath));
		    }

			FileStream oFile = new FileStream(
				sFilePath,
				FileMode.CreateNew);
			BinaryWriter oWriter = new BinaryWriter(oFile);
			oWriter.Write(yFile);
		}
		
		public static byte[] DownloadBinaryFileFromUrl(string sUrl){
		    Console.WriteLine("Downloading {0} ...", sUrl);
			byte[] result;
			byte[] buffer = new byte[4096];
			 
			WebRequest wr = WebRequest.Create(sUrl);
			 
			using(WebResponse response = wr.GetResponse())
			{
			   using(Stream responseStream = response.GetResponseStream())
			   {
			      using(MemoryStream memoryStream = new MemoryStream())
			      {
			         int count = 0;
			         do
			         {
			            count = responseStream.Read(buffer, 0, buffer.Length);
			            memoryStream.Write(buffer, 0, count);
			 			Console.Write(".");
			         } while(count != 0);
			 
			         result = memoryStream.ToArray();
			 
			      }	
			   }
			}
			
			Console.WriteLine();
			
			return result;
		}
	}
}