using System;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web.Security;

public sealed class StaticRoleProvider : RoleProvider
{
	private string _applicationName;

	public override void Initialize (string name, NameValueCollection config)
	{
		if (name == null || name.Length == 0)
			name = this.GetType ().Name;

		base.Initialize (name, config);

		if (string.IsNullOrEmpty (config ["applicationName"])) {
			_applicationName = HostingEnvironment.ApplicationVirtualPath;
		} else {
			_applicationName = config ["applicationName"];
		}
	}

	public override string ApplicationName {
		get { return _applicationName; }
		set { _applicationName = value; }
	}

	public override void AddUsersToRoles (string [] usernames, string [] rolenames)
	{
	}

	public override void CreateRole (string rolename)
	{
	}

	public override bool DeleteRole (string rolename, bool throwOnPopulatedRole)
	{
		return true;
	}

	public override string [] GetAllRoles ()
	{
		return new string [] { "Viewers", "Administrators" };
	}

	public override string [] GetRolesForUser (string username)
	{
		if (username == "gert")
			return new string [] { "Administrators" };
		return new string [0];
	}

	public override string [] GetUsersInRole (string rolename)
	{
		return new string [] { "gert" };
	}

	public override bool IsUserInRole (string username, string rolename)
	{
		if (username == "gert" && rolename == "Administrators")
			return true;
		return false;
	}

	public override void RemoveUsersFromRoles (string [] usernames, string [] rolenames)
	{
	}

	public override bool RoleExists (string rolename)
	{
		return true;
	}

	public override string [] FindUsersInRole (string rolename, string usernameToMatch)
	{
		return new string [0];
	}
}
