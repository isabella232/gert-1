using Mono.Sms.Core;

namespace Mono.Sms
{
	public partial class Main
	{
		public void Test ()
		{
			Contacts frm = new Contacts ();
			frm.ContactsEventHandler += delegate () {
				Agenda.AddContact ();
			};
		}
	}

	public partial class Contacts
	{
		public void Test ()
		{
			ContactsEventHandler ();
		}

		public delegate void ContactsHandler ();
		public event ContactsHandler ContactsEventHandler;
	}
}

namespace Mono.Sms.Core
{
	public class Agenda
	{
		public static void AddContact ()
		{
		}
	}
}
