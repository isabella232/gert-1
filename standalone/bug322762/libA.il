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
			.field private string privateInstanceBlueChild
			.field family string familyInstanceBlueChild
			.field famandassem string famANDAssemInstanceBlueChild
			.field famorassem string famORAssemInstanceBlueChild
			.field public string publicInstanceBlueChild
			.field assembly string assemblyInstanceBlueChild
			.field private static string privateStaticBlueChild
			.field static family string familyStaticBlueChild
			.field static famandassem string famANDAssemStaticBlueChild
			.field static famorassem string famORAssemStaticBlueChild
			.field public static string publicStaticBlueChild
			.field static assembly string assemblyStaticBlueChild

			.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famorassem hidebysig specialname rtspecialname instance void .ctor(int32 x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method private hidebysig specialname rtspecialname static void .cctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldnull
				IL_0001:  stsfld     string libA.Blue/Child::privateStaticBlueChild
				IL_0006:  ldnull
				IL_0007:  stsfld     string libA.Blue/Child::assemblyStaticBlueChild
				IL_000c:  ret
			}

			.method private hidebysig instance string GetPrivateInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig instance string GetFamilyInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libA.Blue/Child::GetPrivateInstanceBlueChild()
				IL_0006:  stloc.0
				IL_0007:  br.s       IL_0009

				IL_0009:  ldloc.0
				IL_000a:  ret
			}

			.method famandassem hidebysig instance string GetFamANDAssemInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig instance string GetFamORAssemInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig instance string GetPublicInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig instance string GetAssemblyInstanceBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig static string GetPrivateStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig static string GetFamilyStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  call       string libA.Blue/Child::GetPrivateStaticBlueChild()
				IL_0005:  stloc.0
				IL_0006:  br.s       IL_0008

				IL_0008:  ldloc.0
				IL_0009:  ret
			}

			.method famandassem hidebysig static string GetFamANDAssemStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig static string GetFamORAssemStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig static string GetPublicStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig static string GetAssemblyStaticBlueChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}
		}

		.field private string privateInstanceBlue
		.field family string familyInstanceBlue
		.field famandassem string famANDAssemInstanceBlue
		.field famorassem string famORAssemInstanceBlue
		.field public string publicInstanceBlue
		.field assembly string assemblyInstanceBlue
		.field private static string privateStaticBlue
		.field static family string familyStaticBlue
		.field static famandassem string famANDAssemStaticBlue
		.field static famorassem string famORAssemStaticBlue
		.field public static string publicStaticBlue
		.field static assembly string assemblyStaticBlue

		.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famorassem hidebysig specialname rtspecialname void .ctor(int32 x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method private hidebysig specialname rtspecialname static void .cctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldnull
			IL_0001:  stsfld     string libA.Blue::privateStaticBlue
			IL_0006:  ldnull
			IL_0007:  stsfld     string libA.Blue::familyStaticBlue
			IL_000c:  ldnull
			IL_000d:  stsfld     string libA.Blue::famANDAssemStaticBlue
			IL_0012:  ldnull
			IL_0013:  stsfld     string libA.Blue::famORAssemStaticBlue
			IL_0018:  ldnull
			IL_0019:  stsfld     string libA.Blue::publicStaticBlue
			IL_001e:  ldnull
			IL_001f:  stsfld     string libA.Blue::assemblyStaticBlue
			IL_0024:  ret
		}

		.method private hidebysig instance string GetPrivateInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig instance string GetFamilyInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libA.Blue::GetPrivateInstanceBlue()
			IL_0006:  stloc.0
			IL_0007:  br.s       IL_0009

			IL_0009:  ldloc.0
			IL_000a:  ret
		}

		.method famandassem hidebysig instance string GetFamANDAssemInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig instance string GetFamORAssemInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig instance string GetPublicInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig instance string GetAssemblyInstanceBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig static string GetPrivateStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig static string GetFamilyStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  call       string libA.Blue::GetPrivateStaticBlue()
			IL_0005:  stloc.0
			IL_0006:  br.s       IL_0008

			IL_0008:  ldloc.0
			IL_0009:  ret
		}

		.method famandassem hidebysig static string GetFamANDAssemStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig static string GetFamORAssemStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig static string GetPublicStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig static string GetAssemblyStaticBlue() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}
	}

	.class public auto ansi beforefieldinit Foo extends libA.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Blue/Child
		{
			.field private string privateInstanceFooChild
			.field family string familyInstanceFooChild
			.field famandassem string famANDAssemInstanceFooChild
			.field famorassem string famORAssemInstanceFooChild
			.field public string publicInstanceFooChild
			.field assembly string assemblyInstanceFooChild
			.field private static string privateStaticFooChild
			.field static family string familyStaticFooChild
			.field static famandassem string famANDAssemStaticFooChild
			.field static famorassem string famORAssemStaticFooChild
			.field public static string publicStaticFooChild
			.field static assembly string assemblyStaticFooChild

			.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famorassem hidebysig specialname rtspecialname instance void .ctor(int32 x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method private hidebysig specialname rtspecialname static void .cctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldnull
				IL_0001:  stsfld     string libA.Foo/Child::privateStaticFooChild
				IL_0006:  ldnull
				IL_0007:  stsfld     string libA.Foo/Child::assemblyStaticFooChild
				IL_000c:  ret
			}

			.method private hidebysig instance string GetPrivateInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig instance string GetFamilyInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libA.Foo/Child::GetPrivateInstanceFooChild()
				IL_0006:  stloc.0
				IL_0007:  br.s       IL_0009

				IL_0009:  ldloc.0
				IL_000a:  ret
			}

			.method famandassem hidebysig instance string GetFamANDAssemInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig instance string GetFamORAssemInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig instance string GetPublicInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig instance string GetAssemblyInstanceFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig static string GetPrivateStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig static string GetFamilyStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  call       string libA.Foo/Child::GetPrivateStaticFooChild()
				IL_0005:  stloc.0
				IL_0006:  br.s       IL_0008

				IL_0008:  ldloc.0
				IL_0009:  ret
			}

			.method famandassem hidebysig static string GetFamANDAssemStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig static string GetFamORAssemStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig static string GetPublicStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig static string GetAssemblyStaticFooChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}
		}

		.field private string privateInstanceFoo
		.field family string familyInstanceFoo
		.field famandassem string famANDAssemInstanceFoo
		.field famorassem string famORAssemInstanceFoo
		.field public string publicInstanceFoo
		.field assembly string assemblyInstanceFoo
		.field private static string privateStaticFoo
		.field static family string familyStaticFoo
		.field static famandassem string famANDAssemStaticFoo
		.field static famorassem string famORAssemStaticFoo
		.field public static string publicStaticFoo
		.field static assembly string assemblyStaticFoo

		.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famorassem hidebysig specialname rtspecialname void .ctor(int32 x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method private hidebysig specialname rtspecialname static void .cctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldnull
			IL_0001:  stsfld     string libA.Foo::privateStaticFoo
			IL_0006:  ldnull
			IL_0007:  stsfld     string libA.Foo::familyStaticFoo
			IL_000c:  ldnull
			IL_000d:  stsfld     string libA.Foo::famANDAssemStaticFoo
			IL_0012:  ldnull
			IL_0013:  stsfld     string libA.Foo::famORAssemStaticFoo
			IL_0018:  ldnull
			IL_0019:  stsfld     string libA.Foo::publicStaticFoo
			IL_001e:  ldnull
			IL_001f:  stsfld     string libA.Foo::assemblyStaticFoo
			IL_0024:  ret
		}

		.method private hidebysig instance string GetPrivateInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig instance string GetFamilyInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libA.Foo::GetPrivateInstanceFoo()
			IL_0006:  stloc.0
			IL_0007:  br.s       IL_0009

			IL_0009:  ldloc.0
			IL_000a:  ret
		}

		.method famandassem hidebysig instance string GetFamANDAssemInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig instance string GetFamORAssemInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig instance string GetPublicInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig instance string GetAssemblyInstanceFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig static string GetPrivateStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig static string GetFamilyStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  call       string libA.Foo::GetPrivateStaticFoo()
			IL_0005:  stloc.0
			IL_0006:  br.s       IL_0008

			IL_0008:  ldloc.0
			IL_0009:  ret
		}

		.method famandassem hidebysig static string GetFamANDAssemStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig static string GetFamORAssemStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig static string GetPublicStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig static string GetAssemblyStaticFoo() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}
	}

	.class public auto ansi beforefieldinit Bar extends libA.Foo
	{
		.class auto ansi nested public beforefieldinit Child extends libA.Foo/Child
		{
			.field private string privateInstanceBarChild
			.field family string familyInstanceBarChild
			.field famandassem string famANDAssemInstanceBarChild
			.field famorassem string famORAssemInstanceBarChild
			.field public string publicInstanceBarChild
			.field assembly string assemblyInstanceBarChild
			.field private static string privateStaticBarChild
			.field static family string familyStaticBarChild
			.field static famandassem string famANDAssemStaticBarChild
			.field static famorassem string famORAssemStaticBarChild
			.field public static string publicStaticBarChild
			.field static assembly string assemblyStaticBarChild

			.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famorassem hidebysig specialname rtspecialname instance void .ctor(int32 x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libA.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libA.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method private hidebysig specialname rtspecialname static void .cctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldnull
				IL_0001:  stsfld     string libA.Blue/Child::privateStaticBlueChild
				IL_0006:  ldnull
				IL_0007:  stsfld     string libA.Blue/Child::assemblyStaticBlueChild
				IL_000c:  ret
			}

			.method private hidebysig instance string GetPrivateInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig instance string GetFamilyInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldarg.0
				IL_0001:  call       instance string libA.Bar/Child::GetPrivateInstanceBarChild()
				IL_0006:  stloc.0
				IL_0007:  br.s       IL_0009

				IL_0009:  ldloc.0
				IL_000a:  ret
			}

			.method famandassem hidebysig instance string GetFamANDAssemInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig instance string GetFamORAssemInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig instance string GetPublicInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig instance string GetAssemblyInstanceBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method private hidebysig static string GetPrivateStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method family hidebysig static string GetFamilyStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  call       string libA.Bar/Child::GetPrivateStaticBarChild()
				IL_0005:  stloc.0
				IL_0006:  br.s       IL_0008

				IL_0008:  ldloc.0
				IL_0009:  ret
			}

			.method famandassem hidebysig static string GetFamANDAssemStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method famorassem hidebysig static string GetFamORAssemStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method public hidebysig static string GetPublicStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}

			.method assembly hidebysig static string GetAssemblyStaticBarChild() cil managed
			{
				.maxstack  1
				.locals init (string V_0)
				IL_0000:  ldnull
				IL_0001:  stloc.0
				IL_0002:  br.s       IL_0004

				IL_0004:  ldloc.0
				IL_0005:  ret
			}
		}

		.field private string privateInstanceBar
		.field family string familyInstanceBar
		.field famandassem string famANDAssemInstanceBar
		.field famorassem string famORAssemInstanceBar
		.field public string publicInstanceBar
		.field assembly string assemblyInstanceBar
		.field private static string privateStaticBar
		.field static family string familyStaticBar
		.field static famandassem string famANDAssemStaticBar
		.field static famorassem string famORAssemStaticBar
		.field public static string publicStaticBar
		.field static assembly string assemblyStaticBar

		.method private hidebysig specialname rtspecialname instance void .ctor(int32 x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famorassem hidebysig specialname rtspecialname void .ctor(int32 x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libA.Bar::privateInstanceBar
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libA.Bar::familyInstanceBar
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libA.Bar::famANDAssemInstanceBar
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libA.Bar::famORAssemInstanceBar
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libA.Bar::publicInstanceBar
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libA.Bar::assemblyInstanceBar
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method private hidebysig specialname rtspecialname static void .cctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldnull
			IL_0001:  stsfld     string libA.Bar::privateStaticBar
			IL_0006:  ldnull
			IL_0007:  stsfld     string libA.Bar::familyStaticBar
			IL_000c:  ldnull
			IL_000d:  stsfld     string libA.Bar::famANDAssemStaticBar
			IL_0012:  ldnull
			IL_0013:  stsfld     string libA.Bar::famORAssemStaticBar
			IL_0018:  ldnull
			IL_0019:  stsfld     string libA.Bar::publicStaticBar
			IL_001e:  ldnull
			IL_001f:  stsfld     string libA.Bar::assemblyStaticBar
			IL_0024:  ret
		}

		.method private hidebysig instance string GetPrivateInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig instance string GetFamilyInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldarg.0
			IL_0001:  call       instance string libA.Bar::GetPrivateInstanceBar()
			IL_0006:  stloc.0
			IL_0007:  br.s       IL_0009

			IL_0009:  ldloc.0
			IL_000a:  ret
		}

		.method famandassem hidebysig instance string GetFamANDAssemInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig instance string GetFamORAssemInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig instance string GetPublicInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig instance string GetAssemblyInstanceBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method private hidebysig static string GetPrivateStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method family hidebysig static string GetFamilyStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  call       string libA.Bar::GetPrivateStaticBar()
			IL_0005:  stloc.0
			IL_0006:  br.s       IL_0008

			IL_0008:  ldloc.0
			IL_0009:  ret
		}

		.method famandassem hidebysig static string GetFamANDAssemStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method famorassem hidebysig static string GetFamORAssemStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method public hidebysig static string GetPublicStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}

		.method assembly hidebysig static string GetAssemblyStaticBar() cil managed
		{
			.maxstack  1
			.locals init (string V_0)
			IL_0000:  ldnull
			IL_0001:  stloc.0
			IL_0002:  br.s       IL_0004

			IL_0004:  ldloc.0
			IL_0005:  ret
		}
	}
}
