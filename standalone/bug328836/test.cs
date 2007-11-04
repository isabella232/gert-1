using System;
using System.IO;
#if !MONO
using System.Runtime.Serialization;
#endif
using System.Web.Script.Serialization;

namespace JsonTests
{
	public class JsonTest
	{
		static int Main (string [] args)
		{
			JsonObject obj = new JsonObject ();
			string json;

#if !MONO
			MemoryStream ms = new MemoryStream ();
			DataContractJsonSerializer dcSerializer = new DataContractJsonSerializer (typeof (JsonObject));
			dcSerializer.WriteObject (ms, obj);
			ms.Position = 0;

			StreamReader sr = new StreamReader (ms);
			json = sr.ReadToEnd ();
			Assert.AreEqual ("{\"int_key\":null}", json, "#1");

			ms = new MemoryStream ();
			StreamWriter sw = new StreamWriter (ms);
			sw.Write (json);
			sw.Flush ();
			ms.Position = 0;

			obj = (JsonObject) dcSerializer.ReadObject (ms);
			Assert.IsNull (obj.int_key, "#2");
#endif

			json = "{\"int_key\":null}";

			JavaScriptSerializer jsSerializer = new JavaScriptSerializer ();
			obj = jsSerializer.Deserialize<JsonObject> (json);
			Assert.IsNull (obj.int_key, "#3");

			json = "{\"int_key\" : \"\"}";

#if !MONO
			ms = new MemoryStream ();
			sw = new StreamWriter (ms);
			sw.Write (json);
			sw.Flush ();
			ms.Position = 0;

			try {
				obj = (JsonObject) dcSerializer.ReadObject (ms);
				Assert.Fail ("#4");
			} catch (SerializationException) {
			}
#endif

			obj = jsSerializer.Deserialize<JsonObject> (json);
			Assert.IsNull (obj.int_key, "#5");

			return 0;
		}
	}

#if !MONO
	[DataContract]
#endif
	public class JsonObject
	{
		private Nullable<long> _int_key;

#if !MONO
		[DataMember]
#endif
		public Nullable<long> int_key
		{
			get { return _int_key; }
			set { _int_key = value; }
		}

		public override string ToString ()
		{
			return String.Format ("int_key = {0}", this.int_key);
		}
	}
}

