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

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
}

.class public auto ansi sealed TestEnum extends [mscorlib]System.Enum
{
}

.class public auto ansi beforefieldinit Class1 extends [mscorlib]System.Object
{
}

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
	.method private hidebysig static void Main(string[] args) cil managed
	{
		.entrypoint
		.maxstack 1
		IL_0000:  call valuetype TestEnum Class1::Foo()
		IL_0005:  pop
		IL_0006:  ret
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack 1
		IL_0000:  ldarg.0
		IL_0001:  call instance void [mscorlib]System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi sealed TestEnum extends [mscorlib]System.Enum
{
	.field public specialname rtspecialname int8 value__
	.field public static literal valuetype TestEnum None = int8(0x00)
}

.class public auto ansi beforefieldinit Class1 extends [mscorlib]System.Object
{
	.field public static bool var
	.method public hidebysig static valuetype TestEnum Foo() cil managed
	{
		.maxstack 1
		.locals init (valuetype TestEnum V_0)
		IL_0000:  ldsfld     bool Class1::var
		IL_0005:  brfalse.s  IL_000b

		IL_0007:  ldc.i4.0
		IL_0008:  stloc.0
		IL_0009:  br.s       IL_000f

		IL_000b:  ldc.i4.0
		IL_000c:  stloc.0
		IL_000d:  br.s       IL_000f

		IL_000f:  ldloc.0
		IL_0010:  ret
	}

	.method private hidebysig specialname rtspecialname static void .cctor() cil managed
	{
		.maxstack 1
		IL_0000:  ldc.i4.1
		IL_0001:  stsfld     bool Class1::var
		IL_0006:  ret
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack 1
		IL_0000:  ldarg.0
		IL_0001:  call instance void [mscorlib]System.Object::.ctor()
		IL_0006:  ret
	}
}
