.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 1:0:3300:0
}
.assembly libA
{
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module libA.dll
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.namespace libA
{
	.class public auto ansi beforefieldinit Blue extends [mscorlib]System.Object
	{
		.class auto ansi nested public beforefieldinit Child extends [mscorlib]System.Object
		{
		}
	}

	.class public auto ansi beforefieldinit Foo extends libA.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Blue/Child
		{
		}
	}

	.class public auto ansi beforefieldinit Bar extends libA.Foo
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Foo/Child
		{
		}
	}
}

.namespace libA
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
				IL_0001:  call       instance string libA.Blue/Child::get_PrivateInstanceBlueChild()
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
				IL_0000:  call       string libA.Blue/Child::get_PrivateStaticBlueChild()
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
				.set instance void libA.Blue/Child::set_PrivateInstanceBlueChild(string)
				.get instance string libA.Blue/Child::get_PrivateInstanceBlueChild()
			}

			.property instance string FamilyInstanceBlueChild()
			{
				.get instance string libA.Blue/Child::get_FamilyInstanceBlueChild()
				.set instance void libA.Blue/Child::set_FamilyInstanceBlueChild(string)
			}

			.property instance string FamANDAssemInstanceBlueChild()
			{
				.set instance void libA.Blue/Child::set_FamANDAssemInstanceBlueChild(string)
				.get instance string libA.Blue/Child::get_FamANDAssemInstanceBlueChild()
			}

			.property instance string FamORAssemInstanceBlueChild()
			{
				.set instance void libA.Blue/Child::set_FamORAssemInstanceBlueChild(string)
				.get instance string libA.Blue/Child::get_FamORAssemInstanceBlueChild()
			}

			.property instance int64 PublicInstanceBlueChild()
			{
				.get instance int64 libA.Blue/Child::get_PublicInstanceBlueChild()
				.set instance void libA.Blue/Child::set_PublicInstanceBlueChild(int64)
			}

			.property instance int32 AssemblyInstanceBlueChild()
			{
				.get instance int32 libA.Blue/Child::get_AssemblyInstanceBlueChild()
				.set instance void libA.Blue/Child::set_AssemblyInstanceBlueChild(int32)
			}

			.property string PrivateStaticBlueChild()
			{
				.get string libA.Blue/Child::get_PrivateStaticBlueChild()
				.set void libA.Blue/Child::set_PrivateStaticBlueChild(string)
			}

			.property string FamilyStaticBlueChild()
			{
				.get string libA.Blue/Child::get_FamilyStaticBlueChild()
				.set void libA.Blue/Child::set_FamilyStaticBlueChild(string)
			}

			.property string FamANDAssemStaticBlueChild()
			{
				.get string libA.Blue/Child::get_FamANDAssemStaticBlueChild()
				.set void libA.Blue/Child::set_FamANDAssemStaticBlueChild(string)
			}

			.property string FamORAssemStaticBlueChild()
			{
				.set void libA.Blue/Child::set_FamORAssemStaticBlueChild(string)
				.get string libA.Blue/Child::get_FamORAssemStaticBlueChild()
			}

			.property int64 PublicStaticBlueChild()
			{
				.get int64 libA.Blue/Child::get_PublicStaticBlueChild()
				.set void libA.Blue/Child::set_PublicStaticBlueChild(int64)
			}

			.property int32 AssemblyStaticBlueChild()
			{
				.set void libA.Blue/Child::set_AssemblyStaticBlueChild(int32)
				.get int32 libA.Blue/Child::get_AssemblyStaticBlueChild()
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
			IL_0001:  call       instance string libA.Blue::get_PrivateInstanceBlue()
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
			IL_0000:  call       string libA.Blue::get_PrivateStaticBlue()
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
			.get instance string libA.Blue::get_PrivateInstanceBlue()
			.set instance void libA.Blue::set_PrivateInstanceBlue(string)
		}

		.property instance string FamilyInstanceBlue()
		{
			.get instance string libA.Blue::get_FamilyInstanceBlue()
			.set instance void libA.Blue::set_FamilyInstanceBlue(string)
		}

		.property instance string FamANDAssemInstanceBlue()
		{
			.get instance string libA.Blue::get_FamANDAssemInstanceBlue()
			.set instance void libA.Blue::set_FamANDAssemInstanceBlue(string)
		}

		.property instance string FamORAssemInstanceBlue()
		{
			.set instance void libA.Blue::set_FamORAssemInstanceBlue(string)
			.get instance string libA.Blue::get_FamORAssemInstanceBlue()
		}

		.property instance int64 PublicInstanceBlue()
		{
			.get instance int64 libA.Blue::get_PublicInstanceBlue()
			.set instance void libA.Blue::set_PublicInstanceBlue(int64)
		}

		.property instance int32 AssemblyInstanceBlue()
		{
			.set instance void libA.Blue::set_AssemblyInstanceBlue(int32)
			.get instance int32 libA.Blue::get_AssemblyInstanceBlue()
		}

		.property string PrivateStaticBlue()
		{
			.set void libA.Blue::set_PrivateStaticBlue(string)
			.get string libA.Blue::get_PrivateStaticBlue()
		}

		.property string FamilyStaticBlue()
		{
			.get string libA.Blue::get_FamilyStaticBlue()
			.set void libA.Blue::set_FamilyStaticBlue(string)
		}

		.property string FamANDAssemStaticBlue()
		{
			.get string libA.Blue::get_FamANDAssemStaticBlue()
			.set void libA.Blue::set_FamANDAssemStaticBlue(string)
		}

		.property string FamORAssemStaticBlue()
		{
			.get string libA.Blue::get_FamORAssemStaticBlue()
			.set void libA.Blue::set_FamORAssemStaticBlue(string)
		}

		.property int64 PublicStaticBlue()
		{
			.get int64 libA.Blue::get_PublicStaticBlue()
			.set void libA.Blue::set_PublicStaticBlue(int64)
		}

		.property int32 AssemblyStaticBlue()
		{
			.get int32 libA.Blue::get_AssemblyStaticBlue()
			.set void libA.Blue::set_AssemblyStaticBlue(int32)
		}
	}

	.class public auto ansi beforefieldinit Foo extends libA.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Blue/Child
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
				IL_0001:  call       instance string libA.Foo/Child::get_PrivateInstanceFooChild()
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
				IL_0000:  call       string libA.Foo/Child::get_PrivateStaticFooChild()
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
				.set instance void libA.Foo/Child::set_PrivateInstanceFooChild(string)
				.get instance string libA.Foo/Child::get_PrivateInstanceFooChild()
			}

			.property instance string FamilyInstanceFooChild()
			{
				.get instance string libA.Foo/Child::get_FamilyInstanceFooChild()
				.set instance void libA.Foo/Child::set_FamilyInstanceFooChild(string)
			}

			.property instance string FamANDAssemInstanceFooChild()
			{
				.set instance void libA.Foo/Child::set_FamANDAssemInstanceFooChild(string)
				.get instance string libA.Foo/Child::get_FamANDAssemInstanceFooChild()
			}

			.property instance string FamORAssemInstanceFooChild()
			{
				.set instance void libA.Foo/Child::set_FamORAssemInstanceFooChild(string)
				.get instance string libA.Foo/Child::get_FamORAssemInstanceFooChild()
			}

			.property instance int64 PublicInstanceFooChild()
			{
				.get instance int64 libA.Foo/Child::get_PublicInstanceFooChild()
				.set instance void libA.Foo/Child::set_PublicInstanceFooChild(int64)
			}

			.property instance int32 AssemblyInstanceFooChild()
			{
				.get instance int32 libA.Foo/Child::get_AssemblyInstanceFooChild()
				.set instance void libA.Foo/Child::set_AssemblyInstanceFooChild(int32)
			}

			.property string PrivateStaticFooChild()
			{
				.get string libA.Foo/Child::get_PrivateStaticFooChild()
				.set void libA.Foo/Child::set_PrivateStaticFooChild(string)
			}

			.property string FamilyStaticFooChild()
			{
				.get string libA.Foo/Child::get_FamilyStaticFooChild()
				.set void libA.Foo/Child::set_FamilyStaticFooChild(string)
			}

			.property string FamANDAssemStaticFooChild()
			{
				.get string libA.Foo/Child::get_FamANDAssemStaticFooChild()
				.set void libA.Foo/Child::set_FamANDAssemStaticFooChild(string)
			}

			.property string FamORAssemStaticFooChild()
			{
				.set void libA.Foo/Child::set_FamORAssemStaticFooChild(string)
				.get string libA.Foo/Child::get_FamORAssemStaticFooChild()
			}

			.property int64 PublicStaticFooChild()
			{
				.get int64 libA.Foo/Child::get_PublicStaticFooChild()
				.set void libA.Foo/Child::set_PublicStaticFooChild(int64)
			}

			.property int32 AssemblyStaticFooChild()
			{
				.set void libA.Foo/Child::set_AssemblyStaticFooChild(int32)
				.get int32 libA.Foo/Child::get_AssemblyStaticFooChild()
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
			IL_0001:  call       instance string libA.Foo::get_PrivateInstanceFoo()
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
			IL_0000:  call       string libA.Foo::get_PrivateStaticFoo()
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
			.get instance string libA.Foo::get_PrivateInstanceFoo()
			.set instance void libA.Foo::set_PrivateInstanceFoo(string)
		}

		.property instance string FamilyInstanceFoo()
		{
			.get instance string libA.Foo::get_FamilyInstanceFoo()
			.set instance void libA.Foo::set_FamilyInstanceFoo(string)
		}

		.property instance string FamANDAssemInstanceFoo()
		{
			.get instance string libA.Foo::get_FamANDAssemInstanceFoo()
			.set instance void libA.Foo::set_FamANDAssemInstanceFoo(string)
		}

		.property instance string FamORAssemInstanceFoo()
		{
			.set instance void libA.Foo::set_FamORAssemInstanceFoo(string)
			.get instance string libA.Foo::get_FamORAssemInstanceFoo()
		}

		.property instance int64 PublicInstanceFoo()
		{
			.get instance int64 libA.Foo::get_PublicInstanceFoo()
			.set instance void libA.Foo::set_PublicInstanceFoo(int64)
		}

		.property instance int32 AssemblyInstanceFoo()
		{
			.set instance void libA.Foo::set_AssemblyInstanceFoo(int32)
			.get instance int32 libA.Foo::get_AssemblyInstanceFoo()
		}

		.property string PrivateStaticFoo()
		{
			.set void libA.Foo::set_PrivateStaticFoo(string)
			.get string libA.Foo::get_PrivateStaticFoo()
		}

		.property string FamilyStaticFoo()
		{
			.get string libA.Foo::get_FamilyStaticFoo()
			.set void libA.Foo::set_FamilyStaticFoo(string)
		}

		.property string FamANDAssemStaticFoo()
		{
			.get string libA.Foo::get_FamANDAssemStaticFoo()
			.set void libA.Foo::set_FamANDAssemStaticFoo(string)
		}

		.property string FamORAssemStaticFoo()
		{
			.get string libA.Foo::get_FamORAssemStaticFoo()
			.set void libA.Foo::set_FamORAssemStaticFoo(string)
		}

		.property int64 PublicStaticFoo()
		{
			.get int64 libA.Foo::get_PublicStaticFoo()
			.set void libA.Foo::set_PublicStaticFoo(int64)
		}

		.property int32 AssemblyStaticFoo()
		{
			.get int32 libA.Foo::get_AssemblyStaticFoo()
			.set void libA.Foo::set_AssemblyStaticFoo(int32)
		}
	}

	.class public auto ansi beforefieldinit Bar extends libA.Foo
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Foo/Child
		{
			.method private hidebysig specialname instance string get_PrivateInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname instance void  set_PrivateInstanceBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname instance string get_FamilyInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname instance void  set_FamilyInstanceBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname instance string get_FamORAssemInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname instance void  set_FamORAssemInstanceBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname instance int64 get_PublicInstanceBarChild() cil managed
			{
				.maxstack  2
				.locals init (int64 V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libA.Bar/Child::get_PrivateInstanceBarChild()
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

			.method public hidebysig specialname instance void set_PublicInstanceBarChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname instance int32 get_AssemblyInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname instance void set_AssemblyInstanceBarChild(int32 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method private hidebysig specialname static string get_PrivateStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig specialname static void set_PrivateStaticBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method family hidebysig specialname static string get_FamilyStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig specialname static void set_FamilyStaticBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famandassem hidebysig specialname static string get_FamANDAssemStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famandassem hidebysig specialname static void set_FamANDAssemStaticBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method famorassem hidebysig specialname static string get_FamORAssemStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig specialname static void set_FamORAssemStaticBarChild(string 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method public hidebysig specialname static int64 get_PublicStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (int64 V_0)
				IL_0000:  call       string libA.Bar/Child::get_PrivateStaticBarChild()
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

			.method public hidebysig specialname static void set_PublicStaticBarChild(int64 'value') cil managed
			{
				.maxstack  0
				IL_0000:  ret
			}

			.method assembly hidebysig specialname static int32 get_AssemblyStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (int32 V_0)
				IL_0000:  ldc.i4.0
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig specialname static void set_AssemblyStaticBarChild(int32 'value') cil managed
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

			.property instance string PrivateInstanceBarChild()
			{
				.set instance void libA.Bar/Child::set_PrivateInstanceBarChild(string)
				.get instance string libA.Bar/Child::get_PrivateInstanceBarChild()
			}

			.property instance string FamilyInstanceBarChild()
			{
				.get instance string libA.Bar/Child::get_FamilyInstanceBarChild()
				.set instance void libA.Bar/Child::set_FamilyInstanceBarChild(string)
			}

			.property instance string FamANDAssemInstanceBarChild()
			{
				.set instance void libA.Bar/Child::set_FamANDAssemInstanceBarChild(string)
				.get instance string libA.Bar/Child::get_FamANDAssemInstanceBarChild()
			}

			.property instance string FamORAssemInstanceBarChild()
			{
				.set instance void libA.Bar/Child::set_FamORAssemInstanceBarChild(string)
				.get instance string libA.Bar/Child::get_FamORAssemInstanceBarChild()
			}

			.property instance int64 PublicInstanceBarChild()
			{
				.get instance int64 libA.Bar/Child::get_PublicInstanceBarChild()
				.set instance void libA.Bar/Child::set_PublicInstanceBarChild(int64)
			}

			.property instance int32 AssemblyInstanceBarChild()
			{
				.get instance int32 libA.Bar/Child::get_AssemblyInstanceBarChild()
				.set instance void libA.Bar/Child::set_AssemblyInstanceBarChild(int32)
			}

			.property string PrivateStaticBarChild()
			{
				.get string libA.Bar/Child::get_PrivateStaticBarChild()
				.set void libA.Bar/Child::set_PrivateStaticBarChild(string)
			}

			.property string FamilyStaticBarChild()
			{
				.get string libA.Bar/Child::get_FamilyStaticBarChild()
				.set void libA.Bar/Child::set_FamilyStaticBarChild(string)
			}

			.property string FamANDAssemStaticBarChild()
			{
				.get string libA.Bar/Child::get_FamANDAssemStaticBarChild()
				.set void libA.Bar/Child::set_FamANDAssemStaticBarChild(string)
			}

			.property string FamORAssemStaticBarChild()
			{
				.set void libA.Bar/Child::set_FamORAssemStaticBarChild(string)
				.get string libA.Bar/Child::get_FamORAssemStaticBarChild()
			}

			.property int64 PublicStaticBarChild()
			{
				.get int64 libA.Bar/Child::get_PublicStaticBarChild()
				.set void libA.Bar/Child::set_PublicStaticBarChild(int64)
			}

			.property int32 AssemblyStaticBarChild()
			{
				.set void libA.Bar/Child::set_AssemblyStaticBarChild(int32)
				.get int32 libA.Bar/Child::get_AssemblyStaticBarChild()
			}
		}

		.method private hidebysig specialname instance string get_PrivateInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname instance void set_PrivateInstanceBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname instance string get_FamilyInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname instance void set_FamilyInstanceBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname instance string get_FamANDAssemInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname instance void set_FamANDAssemInstanceBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname instance string get_FamORAssemInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname instance void set_FamORAssemInstanceBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname instance int64  get_PublicInstanceBar() cil managed
		{
			.maxstack  2
			.locals init (int64 V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libA.Bar::get_PrivateInstanceBar()
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

		.method public hidebysig specialname instance void set_PublicInstanceBar(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname instance int32 get_AssemblyInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname instance void set_AssemblyInstanceBar(int32 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method private hidebysig specialname static string get_PrivateStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig specialname static void set_PrivateStaticBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method family hidebysig specialname static string get_FamilyStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig specialname static void set_FamilyStaticBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famandassem hidebysig specialname static string get_FamANDAssemStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famandassem hidebysig specialname static void set_FamANDAssemStaticBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method famorassem hidebysig specialname static string get_FamORAssemStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig specialname static void set_FamORAssemStaticBar(string 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method public hidebysig specialname static int64 get_PublicStaticBar() cil managed
		{
			.maxstack  1
			.locals init (int64 V_0)
			IL_0000:  call       string libA.Bar::get_PrivateStaticBar()
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

		.method public hidebysig specialname static void set_PublicStaticBar(int64 'value') cil managed
		{
			.maxstack  0
			IL_0000:  ret
		}

		.method assembly hidebysig specialname static int32 get_AssemblyStaticBar() cil managed
		{
			.maxstack  1
			.locals init (int32 V_0)
			IL_0000:  ldc.i4.0
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig specialname static void set_AssemblyStaticBar(int32 'value') cil managed
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

		.property instance string PrivateInstanceBar()
		{
			.get instance string libA.Bar::get_PrivateInstanceBar()
			.set instance void libA.Bar::set_PrivateInstanceBar(string)
		}

		.property instance string FamilyInstanceBar()
		{
			.get instance string libA.Bar::get_FamilyInstanceBar()
			.set instance void libA.Bar::set_FamilyInstanceBar(string)
		}

		.property instance string FamANDAssemInstanceBar()
		{
			.get instance string libA.Bar::get_FamANDAssemInstanceBar()
			.set instance void libA.Bar::set_FamANDAssemInstanceBar(string)
		}

		.property instance string FamORAssemInstanceBar()
		{
			.set instance void libA.Bar::set_FamORAssemInstanceBar(string)
			.get instance string libA.Bar::get_FamORAssemInstanceBar()
		}

		.property instance int64 PublicInstanceBar()
		{
			.get instance int64 libA.Bar::get_PublicInstanceBar()
			.set instance void libA.Bar::set_PublicInstanceBar(int64)
		}

		.property instance int32 AssemblyInstanceBar()
		{
			.set instance void libA.Bar::set_AssemblyInstanceBar(int32)
			.get instance int32 libA.Bar::get_AssemblyInstanceBar()
		}

		.property string PrivateStaticBar()
		{
			.set void libA.Bar::set_PrivateStaticBar(string)
			.get string libA.Bar::get_PrivateStaticBar()
		}

		.property string FamilyStaticBar()
		{
			.get string libA.Bar::get_FamilyStaticBar()
			.set void libA.Bar::set_FamilyStaticBar(string)
		}

		.property string FamANDAssemStaticBar()
		{
			.get string libA.Bar::get_FamANDAssemStaticBar()
			.set void libA.Bar::set_FamANDAssemStaticBar(string)
		}

		.property string FamORAssemStaticBar()
		{
			.get string libA.Bar::get_FamORAssemStaticBar()
			.set void libA.Bar::set_FamORAssemStaticBar(string)
		}

		.property int64 PublicStaticBar()
		{
			.get int64 libA.Bar::get_PublicStaticBar()
			.set void libA.Bar::set_PublicStaticBar(int64)
		}

		.property int32 AssemblyStaticBar()
		{
			.get int32 libA.Bar::get_AssemblyStaticBar()
			.set void libA.Bar::set_AssemblyStaticBar(int32)
		}
	}
}
