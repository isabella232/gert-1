.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 1:0:3300:0
}
.assembly libC
{
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module libC.dll
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.namespace libC
{
	.class public auto ansi beforefieldinit Blue extends [mscorlib]System.Object
	{
		.class auto ansi nested public beforefieldinit Child extends [mscorlib]System.Object
		{
		}
	}

	.class public auto ansi beforefieldinit Foo extends libC.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libC.Blue/Child
		{
		}
	}
}

.namespace libC
{
	.class public auto ansi beforefieldinit Blue extends [mscorlib]System.Object
	{
		.class auto ansi nested public beforefieldinit Child extends [mscorlib]System.Object
		{
			.method private hidebysig specialname instance string get_PrivateInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname instance void  set_PrivateInstanceBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname instance string get_FamilyInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname instance void  set_FamilyInstanceBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname instance string get_FamORAssemInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname instance void  set_FamORAssemInstanceBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname instance int64 get_PublicInstanceBlueChild() cil managed
			{
				.maxstack  2
				.locals init (int64 V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libC.Blue/Child::get_PrivateInstanceBlueChild()
				IL_0006:  brtrue.s   IL_000d

				IL_0008:  ldc.i4.0
				IL_0009:  conv.i8
				IL_000a:  stloc.0
				IL_000b:  br.s       IL_0019

				IL_000d:  ldc.i8     0x7fffffffffffffff
				IL_0016:  stloc.0
				IL_0017:  br.s       IL_0019

				IL_0019:  ldloc.0
				IL_001a:  ret
			}

			.method public hidebysig specialname instance void set_PublicInstanceBlueChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname instance int32 get_AssemblyInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname instance void set_AssemblyInstanceBlueChild(int32 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method private hidebysig specialname static string get_PrivateStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname static void set_PrivateStaticBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname static string get_FamilyStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname static void set_FamilyStaticBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname static string get_FamANDAssemStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname static void set_FamANDAssemStaticBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname static string get_FamORAssemStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname static void set_FamORAssemStaticBlueChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname static int64 get_PublicStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (int64 V_0)
				IL_0000:  call       string libC.Blue/Child::get_PrivateStaticBlueChild()
				IL_0005:  brtrue.s   IL_000c

				IL_0007:  ldc.i4.0
				IL_0008:  conv.i8
				IL_0009:  stloc.0
				IL_000a:  br.s       IL_0018

				IL_000c:  ldc.i8     0x7fffffffffffffff
				IL_0015:  stloc.0
				IL_0016:  br.s       IL_0018

				IL_0018:  ldloc.0
				IL_0019:  ret
			}

			.method public hidebysig specialname static void set_PublicStaticBlueChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname static int32 get_AssemblyStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname static void set_AssemblyStaticBlueChild(int32 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldarg.0
				IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0006:  ret
			}

			.property instance string PrivateInstanceBlueChild()
			{
				.set instance void libC.Blue/Child::set_PrivateInstanceBlueChild(string)
				.get instance string libC.Blue/Child::get_PrivateInstanceBlueChild()
			}

			.property instance string FamilyInstanceBlueChild()
			{
				.get instance string libC.Blue/Child::get_FamilyInstanceBlueChild()
				.set instance void libC.Blue/Child::set_FamilyInstanceBlueChild(string)
			}

			.property instance string FamANDAssemInstanceBlueChild()
			{
				.set instance void libC.Blue/Child::set_FamANDAssemInstanceBlueChild(string)
				.get instance string libC.Blue/Child::get_FamANDAssemInstanceBlueChild()
			}

			.property instance string FamORAssemInstanceBlueChild()
			{
				.set instance void libC.Blue/Child::set_FamORAssemInstanceBlueChild(string)
				.get instance string libC.Blue/Child::get_FamORAssemInstanceBlueChild()
			}

			.property instance int64 PublicInstanceBlueChild()
			{
				.get instance int64 libC.Blue/Child::get_PublicInstanceBlueChild()
				.set instance void libC.Blue/Child::set_PublicInstanceBlueChild(int64)
			}

			.property instance int32 AssemblyInstanceBlueChild()
			{
				.get instance int32 libC.Blue/Child::get_AssemblyInstanceBlueChild()
				.set instance void libC.Blue/Child::set_AssemblyInstanceBlueChild(int32)
			}

			.property string PrivateStaticBlueChild()
			{
				.get string libC.Blue/Child::get_PrivateStaticBlueChild()
				.set void libC.Blue/Child::set_PrivateStaticBlueChild(string)
			}

			.property string FamilyStaticBlueChild()
			{
				.get string libC.Blue/Child::get_FamilyStaticBlueChild()
				.set void libC.Blue/Child::set_FamilyStaticBlueChild(string)
			}

			.property string FamANDAssemStaticBlueChild()
			{
				.get string libC.Blue/Child::get_FamANDAssemStaticBlueChild()
				.set void libC.Blue/Child::set_FamANDAssemStaticBlueChild(string)
			}

			.property string FamORAssemStaticBlueChild()
			{
				.set void libC.Blue/Child::set_FamORAssemStaticBlueChild(string)
				.get string libC.Blue/Child::get_FamORAssemStaticBlueChild()
			}

			.property int64 PublicStaticBlueChild()
			{
				.get int64 libC.Blue/Child::get_PublicStaticBlueChild()
				.set void libC.Blue/Child::set_PublicStaticBlueChild(int64)
			}

			.property int32 AssemblyStaticBlueChild()
			{
				.set void libC.Blue/Child::set_AssemblyStaticBlueChild(int32)
				.get int32 libC.Blue/Child::get_AssemblyStaticBlueChild()
			}
		}

		.method private hidebysig specialname instance string get_PrivateInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname instance void set_PrivateInstanceBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname instance string get_FamilyInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname instance void set_FamilyInstanceBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname instance string get_FamORAssemInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname instance void set_FamORAssemInstanceBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname instance int64  get_PublicInstanceBlue() cil managed
		{
			.maxstack  2
			.locals init (int64 V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libC.Blue::get_PrivateInstanceBlue()
			IL_0006:  brtrue.s   IL_000d

			IL_0008:  ldc.i4.0
			IL_0009:  conv.i8
			IL_000a:  stloc.0
			IL_000b:  br.s       IL_0019

			IL_000d:  ldc.i8     0x7fffffffffffffff
			IL_0016:  stloc.0
			IL_0017:  br.s       IL_0019

			IL_0019:  ldloc.0
			IL_001a:  ret
		}

		.method public hidebysig specialname instance void set_PublicInstanceBlue(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname instance int32 get_AssemblyInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname instance void set_AssemblyInstanceBlue(int32 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method private hidebysig specialname static string get_PrivateStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname static void set_PrivateStaticBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname static string get_FamilyStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname static void set_FamilyStaticBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname static string get_FamANDAssemStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname static void set_FamANDAssemStaticBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname static string get_FamORAssemStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname static void set_FamORAssemStaticBlue(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname static int64 get_PublicStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (int64 V_0)
			IL_0000:  call       string libC.Blue::get_PrivateStaticBlue()
			IL_0005:  brtrue.s   IL_000c

			IL_0007:  ldc.i4.0
			IL_0008:  conv.i8
			IL_0009:  stloc.0
			IL_000a:  br.s       IL_0018

			IL_000c:  ldc.i8     0x7fffffffffffffff
			IL_0015:  stloc.0
			IL_0016:  br.s       IL_0018

			IL_0018:  ldloc.0
			IL_0019:  ret
		}

		.method public hidebysig specialname static void set_PublicStaticBlue(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname static int32 get_AssemblyStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname static void set_AssemblyStaticBlue(int32 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname rtspecialname instance void  .ctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldarg.0
			IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0006:  ret
		}

		.property instance string PrivateInstanceBlue()
		{
			.get instance string libC.Blue::get_PrivateInstanceBlue()
			.set instance void libC.Blue::set_PrivateInstanceBlue(string)
		}

		.property instance string FamilyInstanceBlue()
		{
			.get instance string libC.Blue::get_FamilyInstanceBlue()
			.set instance void libC.Blue::set_FamilyInstanceBlue(string)
		}

		.property instance string FamANDAssemInstanceBlue()
		{
			.get instance string libC.Blue::get_FamANDAssemInstanceBlue()
			.set instance void libC.Blue::set_FamANDAssemInstanceBlue(string)
		}

		.property instance string FamORAssemInstanceBlue()
		{
			.set instance void libC.Blue::set_FamORAssemInstanceBlue(string)
			.get instance string libC.Blue::get_FamORAssemInstanceBlue()
		}

		.property instance int64 PublicInstanceBlue()
		{
			.get instance int64 libC.Blue::get_PublicInstanceBlue()
			.set instance void libC.Blue::set_PublicInstanceBlue(int64)
		}

		.property instance int32 AssemblyInstanceBlue()
		{
			.set instance void libC.Blue::set_AssemblyInstanceBlue(int32)
			.get instance int32 libC.Blue::get_AssemblyInstanceBlue()
		}

		.property string PrivateStaticBlue()
		{
			.set void libC.Blue::set_PrivateStaticBlue(string)
			.get string libC.Blue::get_PrivateStaticBlue()
		}

		.property string FamilyStaticBlue()
		{
			.get string libC.Blue::get_FamilyStaticBlue()
			.set void libC.Blue::set_FamilyStaticBlue(string)
		}

		.property string FamANDAssemStaticBlue()
		{
			.get string libC.Blue::get_FamANDAssemStaticBlue()
			.set void libC.Blue::set_FamANDAssemStaticBlue(string)
		}

		.property string FamORAssemStaticBlue()
		{
			.get string libC.Blue::get_FamORAssemStaticBlue()
			.set void libC.Blue::set_FamORAssemStaticBlue(string)
		}

		.property int64 PublicStaticBlue()
		{
			.get int64 libC.Blue::get_PublicStaticBlue()
			.set void libC.Blue::set_PublicStaticBlue(int64)
		}

		.property int32 AssemblyStaticBlue()
		{
			.get int32 libC.Blue::get_AssemblyStaticBlue()
			.set void libC.Blue::set_AssemblyStaticBlue(int32)
		}
	}

	.class public auto ansi beforefieldinit Foo extends libC.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libC.Blue/Child
		{
			.method private hidebysig specialname instance string get_PrivateInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname instance void  set_PrivateInstanceFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname instance string get_FamilyInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname instance void  set_FamilyInstanceFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname instance string get_FamORAssemInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname instance void  set_FamORAssemInstanceFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname instance int64 get_PublicInstanceFooChild() cil managed
			{
				.maxstack  2
				.locals init (int64 V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libC.Foo/Child::get_PrivateInstanceFooChild()
				IL_0006:  brtrue.s   IL_000d

				IL_0008:  ldc.i4.0
				IL_0009:  conv.i8
				IL_000a:  stloc.0
				IL_000b:  br.s       IL_0019

				IL_000d:  ldc.i8     0x7fffffffffffffff
				IL_0016:  stloc.0
				IL_0017:  br.s       IL_0019

				IL_0019:  ldloc.0
				IL_001a:  ret
			}

			.method public hidebysig specialname instance void set_PublicInstanceFooChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname instance int32 get_AssemblyInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname instance void set_AssemblyInstanceFooChild(int32 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method private hidebysig specialname static string get_PrivateStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname static void set_PrivateStaticFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname static string get_FamilyStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname static void set_FamilyStaticFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname static string get_FamANDAssemStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname static void set_FamANDAssemStaticFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname static string get_FamORAssemStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname static void set_FamORAssemStaticFooChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname static int64 get_PublicStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (int64 V_0)
				IL_0000:  call       string libC.Foo/Child::get_PrivateStaticFooChild()
				IL_0005:  brtrue.s   IL_000c

				IL_0007:  ldc.i4.0
				IL_0008:  conv.i8
				IL_0009:  stloc.0
				IL_000a:  br.s       IL_0018

				IL_000c:  ldc.i8     0x7fffffffffffffff
				IL_0015:  stloc.0
				IL_0016:  br.s       IL_0018

				IL_0018:  ldloc.0
				IL_0019:  ret
			}

			.method public hidebysig specialname static void set_PublicStaticFooChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname static int32 get_AssemblyStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname static void set_AssemblyStaticFooChild(int32 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldarg.0
				IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0006:  ret
			}

			.property instance string PrivateInstanceFooChild()
			{
				.set instance void libC.Foo/Child::set_PrivateInstanceFooChild(string)
				.get instance string libC.Foo/Child::get_PrivateInstanceFooChild()
			}

			.property instance string FamilyInstanceFooChild()
			{
				.get instance string libC.Foo/Child::get_FamilyInstanceFooChild()
				.set instance void libC.Foo/Child::set_FamilyInstanceFooChild(string)
			}

			.property instance string FamANDAssemInstanceFooChild()
			{
				.set instance void libC.Foo/Child::set_FamANDAssemInstanceFooChild(string)
				.get instance string libC.Foo/Child::get_FamANDAssemInstanceFooChild()
			}

			.property instance string FamORAssemInstanceFooChild()
			{
				.set instance void libC.Foo/Child::set_FamORAssemInstanceFooChild(string)
				.get instance string libC.Foo/Child::get_FamORAssemInstanceFooChild()
			}

			.property instance int64 PublicInstanceFooChild()
			{
				.get instance int64 libC.Foo/Child::get_PublicInstanceFooChild()
				.set instance void libC.Foo/Child::set_PublicInstanceFooChild(int64)
			}

			.property instance int32 AssemblyInstanceFooChild()
			{
				.get instance int32 libC.Foo/Child::get_AssemblyInstanceFooChild()
				.set instance void libC.Foo/Child::set_AssemblyInstanceFooChild(int32)
			}

			.property string PrivateStaticFooChild()
			{
				.get string libC.Foo/Child::get_PrivateStaticFooChild()
				.set void libC.Foo/Child::set_PrivateStaticFooChild(string)
			}

			.property string FamilyStaticFooChild()
			{
				.get string libC.Foo/Child::get_FamilyStaticFooChild()
				.set void libC.Foo/Child::set_FamilyStaticFooChild(string)
			}

			.property string FamANDAssemStaticFooChild()
			{
				.get string libC.Foo/Child::get_FamANDAssemStaticFooChild()
				.set void libC.Foo/Child::set_FamANDAssemStaticFooChild(string)
			}

			.property string FamORAssemStaticFooChild()
			{
				.set void libC.Foo/Child::set_FamORAssemStaticFooChild(string)
				.get string libC.Foo/Child::get_FamORAssemStaticFooChild()
			}

			.property int64 PublicStaticFooChild()
			{
				.get int64 libC.Foo/Child::get_PublicStaticFooChild()
				.set void libC.Foo/Child::set_PublicStaticFooChild(int64)
			}

			.property int32 AssemblyStaticFooChild()
			{
				.set void libC.Foo/Child::set_AssemblyStaticFooChild(int32)
				.get int32 libC.Foo/Child::get_AssemblyStaticFooChild()
			}
		}

		.method private hidebysig specialname instance string get_PrivateInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname instance void set_PrivateInstanceFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname instance string get_FamilyInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname instance void set_FamilyInstanceFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname instance string get_FamORAssemInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname instance void set_FamORAssemInstanceFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname instance int64  get_PublicInstanceFoo() cil managed
		{
			.maxstack  2
			.locals init (int64 V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libC.Foo::get_PrivateInstanceFoo()
			IL_0006:  brtrue.s   IL_000d

			IL_0008:  ldc.i4.0
			IL_0009:  conv.i8
			IL_000a:  stloc.0
			IL_000b:  br.s       IL_0019

			IL_000d:  ldc.i8     0x7fffffffffffffff
			IL_0016:  stloc.0
			IL_0017:  br.s       IL_0019

			IL_0019:  ldloc.0
			IL_001a:  ret
		}

		.method public hidebysig specialname instance void set_PublicInstanceFoo(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname instance int32 get_AssemblyInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname instance void set_AssemblyInstanceFoo(int32 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method private hidebysig specialname static string get_PrivateStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname static void set_PrivateStaticFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname static string get_FamilyStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname static void set_FamilyStaticFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname static string get_FamANDAssemStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname static void set_FamANDAssemStaticFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname static string get_FamORAssemStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname static void set_FamORAssemStaticFoo(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname static int64 get_PublicStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (int64 V_0)
			IL_0000:  call       string libC.Foo::get_PrivateStaticFoo()
			IL_0005:  brtrue.s   IL_000c

			IL_0007:  ldc.i4.0
			IL_0008:  conv.i8
			IL_0009:  stloc.0
			IL_000a:  br.s       IL_0018

			IL_000c:  ldc.i8     0x7fffffffffffffff
			IL_0015:  stloc.0
			IL_0016:  br.s       IL_0018

			IL_0018:  ldloc.0
			IL_0019:  ret
		}

		.method public hidebysig specialname static void set_PublicStaticFoo(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname static int32 get_AssemblyStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname static void set_AssemblyStaticFoo(int32 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname rtspecialname instance void  .ctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldarg.0
			IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0006:  ret
		}

		.property instance string PrivateInstanceFoo()
		{
			.get instance string libC.Foo::get_PrivateInstanceFoo()
			.set instance void libC.Foo::set_PrivateInstanceFoo(string)
		}

		.property instance string FamilyInstanceFoo()
		{
			.get instance string libC.Foo::get_FamilyInstanceFoo()
			.set instance void libC.Foo::set_FamilyInstanceFoo(string)
		}

		.property instance string FamANDAssemInstanceFoo()
		{
			.get instance string libC.Foo::get_FamANDAssemInstanceFoo()
			.set instance void libC.Foo::set_FamANDAssemInstanceFoo(string)
		}

		.property instance string FamORAssemInstanceFoo()
		{
			.set instance void libC.Foo::set_FamORAssemInstanceFoo(string)
			.get instance string libC.Foo::get_FamORAssemInstanceFoo()
		}

		.property instance int64 PublicInstanceFoo()
		{
			.get instance int64 libC.Foo::get_PublicInstanceFoo()
			.set instance void libC.Foo::set_PublicInstanceFoo(int64)
		}

		.property instance int32 AssemblyInstanceFoo()
		{
			.set instance void libC.Foo::set_AssemblyInstanceFoo(int32)
			.get instance int32 libC.Foo::get_AssemblyInstanceFoo()
		}

		.property string PrivateStaticFoo()
		{
			.set void libC.Foo::set_PrivateStaticFoo(string)
			.get string libC.Foo::get_PrivateStaticFoo()
		}

		.property string FamilyStaticFoo()
		{
			.get string libC.Foo::get_FamilyStaticFoo()
			.set void libC.Foo::set_FamilyStaticFoo(string)
		}

		.property string FamANDAssemStaticFoo()
		{
			.get string libC.Foo::get_FamANDAssemStaticFoo()
			.set void libC.Foo::set_FamANDAssemStaticFoo(string)
		}

		.property string FamORAssemStaticFoo()
		{
			.get string libC.Foo::get_FamORAssemStaticFoo()
			.set void libC.Foo::set_FamORAssemStaticFoo(string)
		}

		.property int64 PublicStaticFoo()
		{
			.get int64 libC.Foo::get_PublicStaticFoo()
			.set void libC.Foo::set_PublicStaticFoo(int64)
		}

		.property int32 AssemblyStaticFoo()
		{
			.get int32 libC.Foo::get_AssemblyStaticFoo()
			.set void libC.Foo::set_AssemblyStaticFoo(int32)
		}
	}
}
