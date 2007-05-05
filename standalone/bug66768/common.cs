using System;
using System.Runtime.Serialization;

public interface IRemoteLoggingSink
{
	void LogEvents (LoggingEvent [] events);
}

[Serializable]
public class LoggingEvent : ISerializable
{
	public LoggingEvent (string message)
	{
		_message = message;
		_timeStamp = DateTime.Now;
	}

	protected LoggingEvent (SerializationInfo info, StreamingContext context)
	{
		_message = info.GetString ("Message");
		_timeStamp = info.GetDateTime ("TimeStamp");
	}

	public DateTime TimeStamp
	{
		get { return _timeStamp; }
	}

	public string Message
	{
		get { return _message; }
	}

	public void GetObjectData (SerializationInfo info, StreamingContext context)
	{
		info.AddValue ("Message", _message);
		info.AddValue ("TimeStamp", _timeStamp);
	}

	private string _message;
	private DateTime _timeStamp;
}
