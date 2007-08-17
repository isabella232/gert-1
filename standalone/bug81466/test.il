.assembly extern lib
{
  .ver 0:0:0:0
}
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
  .ver 1:0:5000:0
}
.assembly test
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module test.exe
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.namespace ImplSpace
{
	.class private auto ansi beforefieldinit TestImpl extends [lib]MainSpace.CD
	{
	}

	.class public auto ansi beforefieldinit Program extends [mscorlib]System.Object
	{
	}
}

.namespace ImplSpace
{
	.class private auto ansi beforefieldinit TestImpl extends [lib]MainSpace.CD
	{
		.method public hidebysig virtual instance bool Test() cil managed
		{
			.maxstack  1
			.locals init (bool V_0)
			IL_0000:  ldstr "TestImpl.Test()"
			IL_0005:  call void [mscorlib]System.Console::WriteLine(string)
			IL_000a:  ldarg.0
			IL_000b:  call instance bool [lib]MainSpace.CD::Test()
			IL_0010:  stloc.0
			IL_0011:  br.s IL_0013

			IL_0013:  ldloc.0
			IL_0014:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldarg.0
			IL_0001:  call instance void [lib]MainSpace.CD::.ctor()
			IL_0006:  ret
		}
	}

	.class public auto ansi beforefieldinit Program extends [mscorlib]System.Object
	{
		.method private hidebysig static void Main() cil managed
		{
			.entrypoint
			.maxstack  1
			.locals init (class ImplSpace.TestImpl V_0)
			IL_0000:  newobj instance void ImplSpace.TestImpl::.ctor()
			IL_0005:  stloc.0
			IL_0006:  ldloc.0
			IL_0007:  callvirt instance bool [lib]MainSpace.AC::Test()
			IL_000c:  pop
			IL_000d:  ret
		}

		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  1
			IL_0000:  ldarg.0
			IL_0001:  call instance void [mscorlib]System.Object::.ctor()
			IL_0006:  ret
		}
	}
}
