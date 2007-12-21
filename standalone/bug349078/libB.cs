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
			private string PrivateInstanceBlueChild
			{
				get { return null; }
				set { }
			}

			protected string FamilyInstanceBlueChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamANDAssemInstanceBlueChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamORAssemInstanceBlueChild
			{
				get { return null; }
				set { }
			}

			public long PublicInstanceBlueChild
			{
				get
				{
					if (PrivateInstanceBlueChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal int AssemblyInstanceBlueChild
			{
				get { return 0; }
				set { }
			}

			private static string PrivateStaticBlueChild
			{
				get { return null; }
				set { }
			}

			protected static string FamilyStaticBlueChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamANDAssemStaticBlueChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamORAssemStaticBlueChild
			{
				get { return null; }
				set { }
			}

			public static long PublicStaticBlueChild
			{
				get
				{
					if (PrivateStaticBlueChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal static int AssemblyStaticBlueChild
			{
				get { return 0; }
				set { }
			}
		}

		private string PrivateInstanceBlue
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceBlue
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceBlue
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceBlue
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceBlue
		{
			get
			{
				if (PrivateInstanceBlue == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceBlue
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticBlue
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticBlue
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticBlue
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticBlue
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticBlue
		{
			get
			{
				if (PrivateStaticBlue == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticBlue
		{
			get { return 0; }
			set { }
		}
	}

	public class Foo : Blue
	{
		public new class Child : Blue.Child
		{
			private string PrivateInstanceFooChild
			{
				get { return null; }
				set { }
			}

			protected string FamilyInstanceFooChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamANDAssemInstanceFooChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamORAssemInstanceFooChild
			{
				get { return null; }
				set { }
			}

			public long PublicInstanceFooChild
			{
				get
				{
					if (PrivateInstanceFooChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal int AssemblyInstanceFooChild
			{
				get { return 0; }
				set { }
			}

			private static string PrivateStaticFooChild
			{
				get { return null; }
				set { }
			}

			protected static string FamilyStaticFooChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamANDAssemStaticFooChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamORAssemStaticFooChild
			{
				get { return null; }
				set { }
			}

			public static long PublicStaticFooChild
			{
				get
				{
					if (PrivateStaticFooChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal static int AssemblyStaticFooChild
			{
				get { return 0; }
				set { }
			}
		}

		private string PrivateInstanceFoo
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceFoo
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceFoo
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceFoo
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceFoo
		{
			get
			{
				if (PrivateInstanceFoo == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceFoo
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticFoo
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticFoo
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticFoo
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticFoo
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticFoo
		{
			get
			{
				if (PrivateStaticFoo == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticFoo
		{
			get { return 0; }
			set { }
		}
	}

	public class Bar : Foo
	{
		public new class Child : Foo.Child
		{
			private string PrivateInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected string FamilyInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamANDAssemInstanceBarChild
			{
				get { return null; }
				set { }
			}

			protected internal string FamORAssemInstanceBarChild
			{
				get { return null; }
				set { }
			}

			public long PublicInstanceBarChild
			{
				get
				{
					if (PrivateInstanceBarChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal int AssemblyInstanceBarChild
			{
				get { return 0; }
				set { }
			}

			private static string PrivateStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static string FamilyStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamANDAssemStaticBarChild
			{
				get { return null; }
				set { }
			}

			protected static internal string FamORAssemStaticBarChild
			{
				get { return null; }
				set { }
			}

			public static long PublicStaticBarChild
			{
				get
				{
					if (PrivateStaticBarChild == null)
						return 0;
					return long.MaxValue;
				}
				set { }
			}

			internal static int AssemblyStaticBarChild
			{
				get { return 0; }
				set { }
			}
		}

		private string PrivateInstanceBar
		{
			get { return null; }
			set { }
		}

		protected string FamilyInstanceBar
		{
			get { return null; }
			set { }
		}

		protected internal string FamANDAssemInstanceBar
		{
			get { return null; }
			set { }
		}

		protected internal string FamORAssemInstanceBar
		{
			get { return null; }
			set { }
		}

		public long PublicInstanceBar
		{
			get
			{
				if (PrivateInstanceBar == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal int AssemblyInstanceBar
		{
			get { return 0; }
			set { }
		}

		private static string PrivateStaticBar
		{
			get { return null; }
			set { }
		}

		protected static string FamilyStaticBar
		{
			get { return null; }
			set { }
		}

		protected static internal string FamANDAssemStaticBar
		{
			get { return null; }
			set { }
		}

		protected static internal string FamORAssemStaticBar
		{
			get { return null; }
			set { }
		}

		public static long PublicStaticBar
		{
			get
			{
				if (PrivateStaticBar == null)
					return 0;
				return long.MaxValue;
			}
			set { }
		}

		internal static int AssemblyStaticBar
		{
			get { return 0; }
			set { }
		}
	}
}
