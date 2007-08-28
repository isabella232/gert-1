using System;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
	static int Main ()
	{
		string filename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"encrypt.tmp");
		string data = "this is sensitive data";

		DESCryptoServiceProvider des = new DESCryptoServiceProvider ();
		des.GenerateIV ();
		des.GenerateKey ();

		// -----------  WRITING ENCRYPTED SERIALIZED DATA ------------------
		Stream stream = new FileStream (filename, FileMode.Create, FileAccess.Write);
		stream = new CryptoStream (stream, des.CreateEncryptor (), CryptoStreamMode.Write);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Serialize (stream, data);
		stream.Close ();

		stream = null;
		bformatter = null;
		data = string.Empty;

		// -----------  READING ENCRYPTED SERIALIZED DATA ------------------
		stream = new FileStream (filename, FileMode.Open, FileAccess.Read);
		stream = new CryptoStream (stream, des.CreateDecryptor (), CryptoStreamMode.Read);
		bformatter = new BinaryFormatter ();
		data = (string) bformatter.Deserialize (stream);
		stream.Close ();

		//----------- CHECK RESULTS ----------------
		if (data != "this is sensitive data")
			return 1;

		return 0;
	}
}
