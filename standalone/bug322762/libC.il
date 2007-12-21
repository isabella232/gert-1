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
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famorassem hidebysig specialname rtspecialname instance void .ctor(int32 x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Blue/Child::privateInstanceBlueChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Blue/Child::assemblyInstanceBlueChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method private hidebysig specialname rtspecialname static void .cctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldnull
				IL_0001:  stsfld     string libC.Blue/Child::privateStaticBlueChild
				IL_0006:  ldnull
				IL_0007:  stsfld     string libC.Blue/Child::assemblyStaticBlueChild
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
				IL_0001:  call       instance string libC.Blue/Child::GetPrivateInstanceBlueChild()
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
				IL_0000:  call       string libC.Blue/Child::GetPrivateStaticBlueChild()
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
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famorassem hidebysig specialname rtspecialname void .ctor(int32 x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Blue::privateInstanceBlue
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Blue::familyInstanceBlue
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Blue::famANDAssemInstanceBlue
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Blue::famORAssemInstanceBlue
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Blue::publicInstanceBlue
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Blue::assemblyInstanceBlue
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method private hidebysig specialname rtspecialname static void .cctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldnull
			IL_0001:  stsfld     string libC.Blue::privateStaticBlue
			IL_0006:  ldnull
			IL_0007:  stsfld     string libC.Blue::familyStaticBlue
			IL_000c:  ldnull
			IL_000d:  stsfld     string libC.Blue::famANDAssemStaticBlue
			IL_0012:  ldnull
			IL_0013:  stsfld     string libC.Blue::famORAssemStaticBlue
			IL_0018:  ldnull
			IL_0019:  stsfld     string libC.Blue::publicStaticBlue
			IL_001e:  ldnull
			IL_001f:  stsfld     string libC.Blue::assemblyStaticBlue
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
			IL_0001:  call       instance string libC.Blue::GetPrivateInstanceBlue()
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
			IL_0000:  call       string libC.Blue::GetPrivateStaticBlue()
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

	.class public auto ansi beforefieldinit Foo extends libC.Blue
	{
		.class auto ansi nested public beforefieldinit Child extends libC.Blue/Child
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
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method famorassem hidebysig specialname rtspecialname instance void .ctor(int32 x) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
			{
				.maxstack  2
				IL_0000:  ldarg.0
				IL_0001:  ldnull
				IL_0002:  stfld      string libC.Foo/Child::privateInstanceFooChild
				IL_0007:  ldarg.0
				IL_0008:  ldnull
				IL_0009:  stfld      string libC.Foo/Child::assemblyInstanceFooChild
				IL_000e:  ldarg.0
				IL_000f:  call       instance void [mscorlib]System.Object::.ctor()
				IL_0014:  ret
			}

			.method private hidebysig specialname rtspecialname static void .cctor() cil managed
			{
				.maxstack  1
				IL_0000:  ldnull
				IL_0001:  stsfld     string libC.Foo/Child::privateStaticFooChild
				IL_0006:  ldnull
				IL_0007:  stsfld     string libC.Foo/Child::assemblyStaticFooChild
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
				IL_0001:  call       instance string libC.Foo/Child::GetPrivateInstanceFooChild()
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
				IL_0000:  call       string libC.Foo/Child::GetPrivateStaticFooChild()
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
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method family hidebysig specialname rtspecialname instance void .ctor(string x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famandassem hidebysig specialname rtspecialname instance void .ctor(string x, string y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method famorassem hidebysig specialname rtspecialname void .ctor(int32 x) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method assembly hidebysig specialname rtspecialname instance void .ctor(string x, int32 y) cil managed
		{
			.maxstack  2
			IL_0000:  ldarg.0
			IL_0001:  ldnull
			IL_0002:  stfld      string libC.Foo::privateInstanceFoo
			IL_0007:  ldarg.0
			IL_0008:  ldnull
			IL_0009:  stfld      string libC.Foo::familyInstanceFoo
			IL_000e:  ldarg.0
			IL_000f:  ldnull
			IL_0010:  stfld      string libC.Foo::famANDAssemInstanceFoo
			IL_0015:  ldarg.0
			IL_0016:  ldnull
			IL_0017:  stfld      string libC.Foo::famORAssemInstanceFoo
			IL_001c:  ldarg.0
			IL_001d:  ldnull
			IL_001e:  stfld      string libC.Foo::publicInstanceFoo
			IL_0023:  ldarg.0
			IL_0024:  ldnull
			IL_0025:  stfld      string libC.Foo::assemblyInstanceFoo
			IL_002a:  ldarg.0
			IL_002b:  call       instance void [mscorlib]System.Object::.ctor()
			IL_0030:  ret
		}

		.method private hidebysig specialname rtspecialname static void .cctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldnull
			IL_0001:  stsfld     string libC.Foo::privateStaticFoo
			IL_0006:  ldnull
			IL_0007:  stsfld     string libC.Foo::familyStaticFoo
			IL_000c:  ldnull
			IL_000d:  stsfld     string libC.Foo::famANDAssemStaticFoo
			IL_0012:  ldnull
			IL_0013:  stsfld     string libC.Foo::famORAssemStaticFoo
			IL_0018:  ldnull
			IL_0019:  stsfld     string libC.Foo::publicStaticFoo
			IL_001e:  ldnull
			IL_001f:  stsfld     string libC.Foo::assemblyStaticFoo
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
			IL_0001:  call       instance string libC.Foo::GetPrivateInstanceFoo()
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
			IL_0000:  call       string libC.Foo::GetPrivateStaticFoo()
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
}
