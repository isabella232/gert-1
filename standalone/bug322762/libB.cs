#if NET_2_0
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo ("test")]
#endif

namespace libB
{
	public class Blue
	{
		public class Child
		{
			private Child (int x, int y)
			{
			}

			protected Child (string x)
			{
			}

			protected internal Child (string x, string y)
			{
			}

			protected internal Child (int x)
			{
			}

			public Child ()
			{
			}

			internal Child (string x, int y)
			{
			}

			static Child ()
			{
			}

			private string GetPrivateInstanceBlueChild ()
			{
				return privateInstanceBlueChild;
			}

			protected string GetFamilyInstanceBlueChild ()
			{
				return familyInstanceBlueChild;
			}

			protected internal string GetFamANDAssemInstanceBlueChild ()
			{
				return GetPrivateInstanceBlueChild ();
			}

			protected internal string GetFamORAssemInstanceBlueChild ()
			{
				return famORAssemInstanceBlueChild;
			}

			public string GetPublicInstanceBlueChild ()
			{
				return publicInstanceBlueChild;
			}

			internal string GetAssemblyInstanceBlueChild ()
			{
				return assemblyInstanceBlueChild;
			}

			private static string GetPrivateStaticBlueChild ()
			{
				return privateStaticBlueChild;
			}

			protected static string GetFamilyStaticBlueChild ()
			{
				return familyStaticBlueChild;
			}

			protected static internal string GetFamANDAssemStaticBlueChild ()
			{
				return GetPrivateStaticBlueChild ();
			}

			protected static internal string GetFamORAssemStaticBlueChild ()
			{
				return null;
			}

			public static string GetPublicStaticBlueChild ()
			{
				return null;
			}

			internal static string GetAssemblyStaticBlueChild ()
			{
				return null;
			}

			private string privateInstanceBlueChild = null;
			protected string familyInstanceBlueChild;
			protected internal string famANDAssemInstanceBlueChild;
			protected internal string famORAssemInstanceBlueChild;
			public string publicInstanceBlueChild;
			internal string assemblyInstanceBlueChild = null;

			private static string privateStaticBlueChild = null;
			protected static string familyStaticBlueChild;
			protected static internal string famANDAssemStaticBlueChild;
			protected static internal string famORAssemStaticBlueChild;
			public static string publicStaticBlueChild;
			internal static string assemblyStaticBlueChild = null;
		}

		private Blue (int x, int y)
		{
		}

		protected Blue (string x)
		{
		}

		protected internal Blue (string x, string y)
		{
		}

		protected internal Blue (int x)
		{
		}

		public Blue ()
		{
		}

		internal Blue (string x, int y)
		{
		}

		static Blue ()
		{
		}

		private string GetPrivateInstanceBlue ()
		{
			return privateInstanceBlue;
		}

		protected string GetFamilyInstanceBlue ()
		{
			return familyInstanceBlue;
		}

		protected internal string GetFamANDAssemInstanceBlue ()
		{
			return GetPrivateInstanceBlue ();
		}

		protected internal string GetFamORAssemInstanceBlue ()
		{
			return null;
		}

		public string GetPublicInstanceBlue ()
		{
			return null;
		}

		internal string GetAssemblyInstanceBlue ()
		{
			return null;
		}

		private static string GetPrivateStaticBlue ()
		{
			return privateStaticBlue;
		}

		protected static string GetFamilyStaticBlue ()
		{
			return GetPrivateStaticBlue ();
		}

		protected static internal string GetFamANDAssemStaticBlue ()
		{
			return GetPrivateStaticBlue ();
		}

		protected static internal string GetFamORAssemStaticBlue ()
		{
			return null;
		}

		public static string GetPublicStaticBlue ()
		{
			return null;
		}

		internal static string GetAssemblyStaticBlue ()
		{
			return null;
		}

		private string privateInstanceBlue = null;
		protected string familyInstanceBlue = null;
		protected internal string famANDAssemInstanceBlue = null;
		protected internal string famORAssemInstanceBlue = null;
		public string publicInstanceBlue = null;
		internal string assemblyInstanceBlue = null;

		private static string privateStaticBlue = null;
		protected static string familyStaticBlue = null;
		protected static internal string famANDAssemStaticBlue = null;
		protected static internal string famORAssemStaticBlue = null;
		public static string publicStaticBlue = null;
		internal static string assemblyStaticBlue = null;
	}

	public class Foo : Blue
	{
		public new class Child : Blue.Child
		{
			private Child (int x, int y)
			{
			}

			protected Child (string x)
			{
			}

			protected internal Child (string x, string y)
			{
			}

			protected internal Child (int x)
			{
			}

			public Child ()
			{
			}

			internal Child (string x, int y)
			{
			}

			static Child ()
			{
			}

			private string GetPrivateInstanceFooChild ()
			{
				return privateInstanceFooChild;
			}

			protected string GetFamilyInstanceFooChild ()
			{
				return familyInstanceFooChild;
			}

			protected internal string GetFamANDAssemInstanceFooChild ()
			{
				return famANDAssemInstanceFooChild;
			}

			protected internal string GetFamORAssemInstanceFooChild ()
			{
				return famORAssemInstanceFooChild;
			}

			public string GetPublicInstanceFooChild ()
			{
				return GetPrivateInstanceFooChild ();
			}

			internal string GetAssemblyInstanceFooChild ()
			{
				return assemblyInstanceFooChild;
			}

			private static string GetPrivateStaticFooChild ()
			{
				return privateStaticFooChild;
			}

			protected static string GetFamilyStaticFooChild ()
			{
				return GetPrivateStaticFooChild ();
			}

			protected static internal string GetFamANDAssemStaticFooChild ()
			{
				return null;
			}

			protected static internal string GetFamORAssemStaticFooChild ()
			{
				return null;
			}

			public static string GetPublicStaticFooChild ()
			{
				return null;
			}

			internal static string GetAssemblyStaticFooChild ()
			{
				return assemblyStaticFooChild;
			}

			private string privateInstanceFooChild = null;
			protected string familyInstanceFooChild;
			protected internal string famANDAssemInstanceFooChild;
			protected internal string famORAssemInstanceFooChild;
			public string publicInstanceFooChild;
			internal string assemblyInstanceFooChild = null;

			private static string privateStaticFooChild = null;
			protected static string familyStaticFooChild;
			protected static internal string famANDAssemStaticFooChild;
			protected static internal string famORAssemStaticFooChild;
			public static string publicStaticFooChild;
			internal static string assemblyStaticFooChild = null;
		}

		private Foo (int x, int y)
		{
		}

		protected Foo (string x)
		{
		}

		protected internal Foo (string x, string y)
		{
		}

		protected internal Foo (int x)
		{
		}

		public Foo ()
		{
		}

		internal Foo (string x, int y)
		{
		}

		static Foo ()
		{
		}

		private string GetPrivateInstanceFoo ()
		{
			return privateInstanceFoo;
		}

		protected string GetFamilyInstanceFoo ()
		{
			return familyInstanceFoo;
		}

		protected internal string GetFamANDAssemInstanceFoo ()
		{
			return GetPrivateInstanceFoo ();
		}

		protected internal string GetFamORAssemInstanceFoo ()
		{
			return null;
		}

		public string GetPublicInstanceFoo ()
		{
			return null;
		}

		internal string GetAssemblyInstanceFoo ()
		{
			return null;
		}

		private static string GetPrivateStaticFoo ()
		{
			return privateStaticFoo;
		}

		protected static string GetFamilyStaticFoo ()
		{
			return GetPrivateStaticFoo ();
		}

		protected static internal string GetFamANDAssemStaticFoo ()
		{
			return null;
		}

		protected static internal string GetFamORAssemStaticFoo ()
		{
			return null;
		}

		public static string GetPublicStaticFoo ()
		{
			return null;
		}

		internal static string GetAssemblyStaticFoo ()
		{
			return assemblyStaticFoo;
		}

		private string privateInstanceFoo = null;
		protected string familyInstanceFoo;
		protected internal string famANDAssemInstanceFoo;
		protected internal string famORAssemInstanceFoo;
		public string publicInstanceFoo;
		internal string assemblyInstanceFoo = null;

		private static string privateStaticFoo = null;
		protected static string familyStaticFoo;
		protected static internal string famANDAssemStaticFoo;
		protected static internal string famORAssemStaticFoo;
		public static string publicStaticFoo;
		internal static string assemblyStaticFoo = null;
	}

	public class Bar : Foo
	{
		public new class Child : Foo.Child
		{
			private Child (int x, int y)
			{
			}

			protected Child (string x)
			{
			}

			protected internal Child (string x, string y)
			{
			}

			protected internal Child (int x)
			{
			}

			public Child ()
			{
			}

			internal Child (string x, int y)
			{
			}

			static Child ()
			{
			}

			private string GetPrivateInstanceBarChild ()
			{
				return privateInstanceBarChild;
			}

			protected string GetFamilyInstanceBarChild ()
			{
				return GetPrivateInstanceBarChild ();
			}

			protected internal string GetFamANDAssemInstanceBarChild ()
			{
				return null;
			}

			protected internal string GetFamORAssemInstanceBarChild ()
			{
				return null;
			}

			public string GetPublicInstanceBarChild ()
			{
				return null;
			}

			internal string GetAssemblyInstanceBarChild ()
			{
				return assemblyInstanceBarChild;
			}

			private static string GetPrivateStaticBarChild ()
			{
				return privateStaticBarChild;
			}

			protected static string GetFamilyStaticBarChild ()
			{
				return GetPrivateStaticBarChild ();
			}

			protected static internal string GetFamANDAssemStaticBarChild ()
			{
				return null;
			}

			protected static internal string GetFamORAssemStaticBarChild ()
			{
				return null;
			}

			public static string GetPublicStaticBarChild ()
			{
				return null;
			}

			internal static string GetAssemblyStaticBarChild ()
			{
				return assemblyStaticBarChild;
			}

			private string privateInstanceBarChild = null;
			protected string familyInstanceBarChild;
			protected internal string famANDAssemInstanceBarChild;
			protected internal string famORAssemInstanceBarChild;
			public string publicInstanceBarChild;
			internal string assemblyInstanceBarChild = null;

			private static string privateStaticBarChild = null;
			protected static string familyStaticBarChild;
			protected static internal string famANDAssemStaticBarChild;
			protected static internal string famORAssemStaticBarChild;
			public static string publicStaticBarChild;
			internal static string assemblyStaticBarChild = null;
		}

		private Bar (int x, int y)
		{
		}

		protected Bar (string x)
		{
		}

		protected internal Bar (string x, string y)
		{
		}

		protected internal Bar (int x)
		{
		}

		public Bar ()
		{
		}

		internal Bar (string x, int y)
		{
		}

		static Bar ()
		{
		}

		private string GetPrivateInstanceBar ()
		{
			return privateInstanceBar;
		}

		protected string GetFamilyInstanceBar ()
		{
			return GetPrivateInstanceBar ();
		}

		protected internal string GetFamANDAssemInstanceBar ()
		{
			return null;
		}

		protected internal string GetFamORAssemInstanceBar ()
		{
			return null;
		}

		public string GetPublicInstanceBar ()
		{
			return null;
		}

		internal string GetAssemblyInstanceBar ()
		{
			return assemblyInstanceBar;
		}

		private static string GetPrivateStaticBar ()
		{
			return privateStaticBar;
		}

		protected static string GetFamilyStaticBar ()
		{
			return GetPrivateStaticBar ();
		}

		protected static internal string GetFamANDAssemStaticBar ()
		{
			return null;
		}

		protected static internal string GetFamORAssemStaticBar ()
		{
			return null;
		}

		public static string GetPublicStaticBar ()
		{
			return null;
		}

		internal static string GetAssemblyStaticBar ()
		{
			return assemblyStaticBar;
		}

		private string privateInstanceBar = null;
		protected string familyInstanceBar;
		protected internal string famANDAssemInstanceBar;
		protected internal string famORAssemInstanceBar;
		public string publicInstanceBar;
		internal string assemblyInstanceBar = null;

		private static string privateStaticBar = null;
		protected static string familyStaticBar;
		protected static internal string famANDAssemStaticBar;
		protected static internal string famORAssemStaticBar;
		public static string publicStaticBar;
		internal static string assemblyStaticBar = null;
	}
}
