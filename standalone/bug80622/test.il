.assembly extern mscorlib
{
	.ver 1:0:5000:0
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) // .z\V.4..
}
.assembly 'a'
{
	.hash algorithm 0x00008004
	.ver  0:0:0:0
}
.module a.exe // GUID = {F30FC3CE-EB4E-4F8D-AD6F-F5312B7F0510}

.class private auto ansi beforefieldinit X extends [mscorlib]System.Object
{
	.method private static hidebysig default void Do (object x) cil managed
	{
		// Method begins at RVA 0x2050
		// Code size 14 (0xe)
		.maxstack 8
		IL_0000:  ldarg.0
		IL_0001:  unbox unsigned int8
		IL_0006:  ldobj unsigned int8
		IL_000b:  conv.ovf.i4.un
		IL_000c:  pop
		IL_000d:  ret
	}

	.method private static hidebysig default void Main () cil managed
	{
		// Method begins at RVA 0x2060
		.entrypoint
		// Code size 16 (0x10)
		.maxstack 8
		IL_0000:  ldc.i4 255
		IL_0005:  box unsigned int8
		IL_000a:  call void class X::Do(object)
		IL_000f:  ret
	}

	.method public hidebysig specialname rtspecialname instance default void .ctor () cil managed
	{
		// Method begins at RVA 0x2074
		// Code size 7 (0x7)
		.maxstack 8
		IL_0000:  ldarg.0
		IL_0001:  call instance void object::.ctor()
		IL_0006:  ret
	}
}
