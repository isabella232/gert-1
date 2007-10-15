using System;
using System.Web.Security;

namespace Mono.Web
{
	class DummyMembershipProvider : MembershipProvider
	{
		public override string ApplicationName {
			get { return "Mono ASP.NET"; }
			set { }
		}

		public override bool EnablePasswordReset {
			get { return false; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return false; }
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return 5; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return 3; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return 5; }
		}

		public override int PasswordAttemptWindow
		{
			get { return 2000; }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return null; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return MembershipPasswordFormat.Clear; }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return false; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return false; }
		}

		public override bool ChangePassword (string username, string oldPassword, string newPassword)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override MembershipUser CreateUser (string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override bool ChangePasswordQuestionAndAnswer (string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		protected override byte [] DecryptPassword (byte [] encodedPassword)
		{
			return base.DecryptPassword (encodedPassword);
		}

		public override bool DeleteUser (string username, bool deleteAllRelatedData)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override string Description
		{
			get
			{
				return base.Description;
			}
		}

		protected override byte [] EncryptPassword (byte [] password)
		{
			return base.EncryptPassword (password);
		}

		public override MembershipUserCollection FindUsersByEmail (string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override MembershipUserCollection FindUsersByName (string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override MembershipUserCollection GetAllUsers (int pageIndex, int pageSize, out int totalRecords)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override int GetNumberOfUsersOnline ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override string GetPassword (string username, string answer)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override MembershipUser GetUser (object providerUserKey, bool userIsOnline)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override MembershipUser GetUser (string username, bool userIsOnline)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override string GetUserNameByEmail (string email)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override void Initialize (string name, System.Collections.Specialized.NameValueCollection config)
		{
			base.Initialize (name, config);
		}

		protected override void OnValidatingPassword (ValidatePasswordEventArgs e)
		{
			base.OnValidatingPassword (e);
		}

		public override string ResetPassword (string username, string answer)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override bool UnlockUser (string userName)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override void UpdateUser (MembershipUser user)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override bool ValidateUser (string username, string password)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

	}
}
