using System;
using System.Reflection;
using System.Runtime.Serialization;

[Serializable]
class Program
{
	static void Main ()
	{
		TestStatic ();
		TestInstance ();
	}

	static void TestStatic ()
	{
		AppDomain domain = AppDomain.CreateDomain ("foo");

		domain.DoCallBack (new CrossAppDomainDelegate (Public));

#if NET_2_0
		domain.DoCallBack (new CrossAppDomainDelegate (NonPublic));
#else
		try {
			domain.DoCallBack (new CrossAppDomainDelegate (NonPublic));
			Assert.Fail ("#B1");
#if MONO
		} catch (TargetInvocationException ex) {
			Assert.AreEqual (typeof (TargetInvocationException), ex.GetType (), "#B2");
			Assert.IsNotNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");

			SerializationException inner = ex.InnerException as SerializationException;
			Assert.IsNotNull (inner, "#B5");
			Assert.AreEqual (typeof (SerializationException), inner.GetType (), "#B6");
			Assert.IsNull (inner.InnerException, "#B7");
			Assert.IsNotNull (inner.Message, "#B8");
		}
#else
		} catch (SerializationException ex) {
			Assert.AreEqual (typeof (SerializationException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
		}
#endif
#endif

#if NET_2_0
		domain.DoCallBack (delegate {
		});
#endif
	}

	static void TestInstance ()
	{
		AppDomain domain = AppDomain.CreateDomain ("foo");

		Program p = new Program ();
		domain.DoCallBack (new CrossAppDomainDelegate (p.PublicInst));

#if NET_2_0
		domain.DoCallBack (new CrossAppDomainDelegate (p.NonPublicInst));
#else
		try {
			domain.DoCallBack (new CrossAppDomainDelegate (p.NonPublicInst));
			Assert.Fail ("#B1");
#if MONO
		} catch (TargetInvocationException ex) {
			Assert.AreEqual (typeof (TargetInvocationException), ex.GetType (), "#B2");
			Assert.IsNotNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");

			SerializationException inner = ex.InnerException as SerializationException;
			Assert.IsNotNull (inner, "#B5");
			Assert.AreEqual (typeof (SerializationException), inner.GetType (), "#B6");
			Assert.IsNull (inner.InnerException, "#B7");
			Assert.IsNotNull (inner.Message, "#B8");
		}
#else
		} catch (SerializationException ex) {
			Assert.AreEqual (typeof (SerializationException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
		}
#endif
#endif
	}

	public void PublicInst ()
	{
	}

	void NonPublicInst ()
	{
	}

	public static void Public ()
	{
	}

	static void NonPublic ()
	{
	}
}
