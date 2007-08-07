.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 2:0:0:0
}
.assembly extern a
{
	.ver 0:0:0:0
}
.assembly b
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
	.custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78
																											63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module b.exe
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.class private auto ansi beforefieldinit M extends [mscorlib]System.Object
{
	.method public hidebysig static void Main() cil managed
	{
		.entrypoint
		.maxstack  0
		.locals init (valuetype [a]S`1<int32> V_0)
		IL_0000:  nop
		IL_0001:  ret
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void [mscorlib]System.Object::.ctor()
		IL_0006:  ret
	}
}
