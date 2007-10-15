using System.Web.Configuration;
using System.Web.Security;

class Program
{
	static void Main ()
	{
		MembershipProviderCollection providers = Membership.Providers;
		Assert.IsNotNull (providers, "#A1");
		Assert.AreEqual (2, providers.Count, "#A2");
		Assert.AreEqual ("DummyProvider", Membership.Provider.Name, "#A3");

		int i = 0;
		foreach (MembershipProvider provider in providers) {
			switch (i) {
			case 0:
				Assert.AreEqual ("AspNetSqlMembershipProvider", provider.Name, "#A4");
				break;
			case 1:
				Assert.AreEqual ("DummyProvider", provider.Name, "#A5");
				break;
			default:
				Assert.Fail ("#A6");
				break;
			}
			i++;
		}

		MembershipSection section = (MembershipSection) WebConfigurationManager.GetSection
			("system.web/membership");
		Assert.AreEqual (2, section.Providers.Count, "#B1");
		Assert.AreEqual ("DummyProvider", section.DefaultProvider, "#B2");
		Assert.AreEqual ("AspNetSqlMembershipProvider", section.Providers [0].Name, "#B3");
		Assert.AreEqual ("DummyProvider", section.Providers [1].Name, "#B4");
	}
}
