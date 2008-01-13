namespace MyDemo.Remoting
{
	public interface IController
	{
		ISession CreateSession (string userName, string password);
	}
}
