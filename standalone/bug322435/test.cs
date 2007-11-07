using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Lifetime;

public class Test
{
	static int Main ()
	{
		AppDomainSetup setup = new AppDomainSetup ();
		setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
		setup.ApplicationName = "test bug";

		AppDomain newDomain = AppDomain.CreateDomain (
			setup.ApplicationName,
			AppDomain.CurrentDomain.Evidence, setup);
		CrossDomainTesterA testerA = (CrossDomainTesterA)
			newDomain.CreateInstanceAndUnwrap (typeof (CrossDomainTesterA).Assembly.FullName,
			typeof (CrossDomainTesterA).FullName, false,
			BindingFlags.Public | BindingFlags.Instance, null,
			new object [] { new StringCollection () }, CultureInfo.InvariantCulture,
			new object [0], AppDomain.CurrentDomain.Evidence);
		testerA.Do ();

		return 0;
	}

	private class CrossDomainTesterA : MarshalByRefObject
	{
		public CrossDomainTesterA (StringCollection names)
		{
		}

		public override Object InitializeLifetimeService ()
		{
			ILease lease = (ILease) base.InitializeLifetimeService ();
			if (lease.CurrentState == LeaseState.Initial) {
				lease.InitialLeaseTime = TimeSpan.Zero;
			}
			return lease;
		}

		public void Do ()
		{
			AppDomainSetup setup = new AppDomainSetup ();
			setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
			setup.ApplicationName = "test bug";

			AppDomain newDomain = AppDomain.CreateDomain (
				setup.ApplicationName,
				AppDomain.CurrentDomain.Evidence, setup);
			CrossDomainTesterB testerB = (CrossDomainTesterB)
				newDomain.CreateInstanceAndUnwrap (typeof (CrossDomainTesterB).Assembly.FullName,
				typeof (CrossDomainTesterB).FullName, false, BindingFlags.Public | BindingFlags.Instance,
				null, new object [] { new StringCollection () }, CultureInfo.InvariantCulture, new object [0],
				AppDomain.CurrentDomain.Evidence);
			testerB.GetTypedValue (new StringCollection (),
				new StringCollection (), null, null);
		}
	}

	private class CrossDomainTesterB : MarshalByRefObject
	{
		public CrossDomainTesterB (StringCollection names)
		{
		}

		public override Object InitializeLifetimeService ()
		{
			ILease lease = (ILease) base.InitializeLifetimeService ();
			if (lease.CurrentState == LeaseState.Initial) {
				lease.InitialLeaseTime = TimeSpan.Zero;
			}
			return lease;
		}

		public object GetTypedValue (StringCollection assemblies, StringCollection imports, string typename, string value)
		{
			return assemblies.Count;
		}
	}
}
