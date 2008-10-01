using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

[Serializable]
public class CommsInfo
{
	private String id = string.Empty;
	private String message = string.Empty;
	private String type = string.Empty;
	private String code = string.Empty;

	public CommsInfo (String id, String Message)
	{
		this.message = this.base64Encode (Message);
		this.id = id;
	}

	public CommsInfo (String id, String type, String Message)
	{
		this.message = this.base64Encode (Message);
		this.id = id;
		this.type = type;
	}

	public CommsInfo (String id, String type, String code, String Message)
	{
		this.message = this.base64Encode (Message);
		this.id = id;
		this.code = code;
		this.type = type;
	}

	public string Message
	{
		get { return this.base64Decode (message); }
		set { message = this.base64Encode (value); }
	}

	public string Id
	{
		get { return id; }
		set { id = value; }
	}

	public string Code
	{
		get { return code; }
		set { code = value; }
	}

	public string Type
	{
		get { return type; }
		set { type = value; }
	}

	private string base64Encode (string data)
	{
		return data;
	}

	private string base64Decode (string data)
	{
		return data;
	}
}
