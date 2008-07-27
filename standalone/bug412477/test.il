.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 1:0:5000:0
}
.assembly structdtor
{
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module structdtor.exe
.imagebase 0x00400000
.file alignment 0x00000200
.subsystem 0x0003
.corflags 0x00000001

.class private sequential ansi sealed beforefieldinit Bar extends [mscorlib]System.ValueType
{
	.method family hidebysig virtual instance void Finalize() cil managed
	{
		.maxstack  8
		IL_0000:  ldstr      "Finalize called"
		IL_0005:  call       void [mscorlib]System.Console::WriteLine(string)
		IL_000a:  ret
	}
}

.class private auto ansi beforefieldinit Test extends [mscorlib]System.Object
{
	.method private hidebysig static void  Main() cil managed
	{
		.entrypoint
		.maxstack  4
		.locals init (int32 V_0, valuetype Bar V_1)
		IL_0000:  ldc.i4.0
		IL_0001:  stloc.0
		IL_0002:  br         IL_001e

		IL_0007:  ldloca.s   V_1
		IL_0009:  initobj    Bar
		IL_000f:  ldloc.1
		IL_0010:  box        Bar
		IL_0015:  call       void [mscorlib]System.Console::WriteLine(object)
		IL_001a:  ldloc.0
		IL_001b:  ldc.i4.1
		IL_001c:  add
		IL_001d:  stloc.0
		IL_001e:  ldloc.0
		IL_001f:  ldc.i4.s   10
		IL_0021:  blt        IL_0007

		IL_0026:  call       void [mscorlib]System.GC::Collect()
		IL_002b:  call       void [mscorlib]System.GC::WaitForPendingFinalizers()
		IL_0030:  ret
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
		IL_0006:  ret
	}
}
