using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

[Serializable]
class Program
{
	static void Main ()
	{
		for (int i = 1; i <= 50; i++) {
			AppDomain newDomain = AppDomain.CreateDomain ("TypeGatheringDomain", AppDomain.CurrentDomain.Evidence, new AppDomainSetup ());
			TypedValueGatherer typedValueGatherer = (TypedValueGatherer)
				newDomain.CreateInstanceAndUnwrap (
					typeof (TypedValueGatherer).Assembly.FullName,
					typeof (TypedValueGatherer).FullName, false,
					BindingFlags.Public | BindingFlags.Instance,
					null, new object [] { ( i ) },
					CultureInfo.InvariantCulture, new object [0],
					AppDomain.CurrentDomain.Evidence);
			typedValueGatherer.GetTypedValue ();
			AppDomain.Unload (newDomain);
		}
	}

	private class TypedValueGatherer : MarshalByRefObject
	{
		private readonly int _instance;

		public TypedValueGatherer (int instance)
		{
			_instance = instance;
		}

		public object GetTypedValue ()
		{
			return 3;
		}

		~TypedValueGatherer ()
		{
			Console.WriteLine ("Finalizing instance " + _instance.ToString (CultureInfo.InvariantCulture));
			if (_instance == 1 || (_instance % 10 == 0))
				Thread.Sleep (40 * 1000);
		}
	}
}
