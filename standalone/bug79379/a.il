.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 2:0:0:0
}
.assembly a
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 )
	.custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78
																											63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module a.dll
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.class interface public abstract auto ansi IA`1<(class IA`1<!T>) T>
{
}

.class interface public abstract auto ansi IB`1<(class IA`1<!T>) T>
	implements class IA`1<!T>
{
}

.class public sequential ansi sealed beforefieldinit S`1<T> extends [mscorlib]System.ValueType
	implements class IB`1<valuetype S`1<!T>>, class IA`1<valuetype S`1<!T>>
{
	.pack 0
	.size 1
}
