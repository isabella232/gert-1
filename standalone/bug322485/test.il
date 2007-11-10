.assembly extern mscorlib {}
.assembly test {}
.module test.exe
.subsystem 0x00000003

.class public NULLABLE_ERROR extends [mscorlib]System.Object
{
	.method public static void main() cil managed
	{
		.entrypoint
		.locals init ([0] valuetype [mscorlib]System.Nullable`1<int32>  nilV)
		.maxstack 2
		ldloc.0          //nilV
		ldloc.0          //nilV
		call bool [mscorlib]System.Nullable::Equals<int32> (valuetype [mscorlib]System.Nullable`1<!!0>, valuetype [mscorlib]System.Nullable`1<!!0>)
		call void  [mscorlib]System.Console::WriteLine (bool)
		ret
	}
}
