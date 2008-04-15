using System;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web.Security;

public sealed class ErrorRoleProvider : RoleProvider
{
	private string _applicationName;
	private bool _errorMode;

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

		if (string.IsNullOrEmpty (config ["errorMode"])) {
			_errorMode = false;
		} else {
			_errorMode = bool.Parse (config ["errorMode"]);
		}
	}

	public override string ApplicationName {
		get { return _applicationName; }
		set { _applicationName = value; }
	}

	public override void AddUsersToRoles (string [] usernames, string [] rolenames)
	{
		if (_errorMode)
			throw new NotImplementedException ();
	}

	public override void CreateRole (string rolename)
	{
		if (_errorMode)
			throw new NotImplementedException ();
	}

	public override bool DeleteRole (string rolename, bool throwOnPopulatedRole)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return true;
	}

	public override string [] GetAllRoles ()
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return new string [] { "Administrators" };
	}

	public override string [] GetRolesForUser (string username)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return new string [] { "Administrators" };
	}

	public override string [] GetUsersInRole (string rolename)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return new string [] { "gert" };
	}

	public override bool IsUserInRole (string username, string rolename)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		if (username == "gert" && rolename == "Administrators")
			return true;
		return false;
	}

	public override void RemoveUsersFromRoles (string [] usernames, string [] rolenames)
	{
		if (_errorMode)
			throw new NotImplementedException ();
	}

	public override bool RoleExists (string rolename)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return true;
	}

	public override string [] FindUsersInRole (string rolename, string usernameToMatch)
	{
		if (_errorMode)
			throw new NotImplementedException ();

		return new string [0];
	}
}
