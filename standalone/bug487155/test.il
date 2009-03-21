.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 1:0:3300:0
}
.assembly test
{
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module test.exe
.imagebase 0x00400000
.file alignment 0x00000200

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
	.method private hidebysig static int32 Main() cil managed
	{
		.entrypoint
		.maxstack  2
		.locals init (string V_0, int32 V_1, bool V_2)
		IL_0000:  nop
		IL_0001:  ldstr      "Mono\040Ro\
			 cks!"
		IL_0006:  stloc.0
		IL_0007:  ldloc.0
		IL_0008:  ldstr      "Mono Rocks!"
		IL_000d:  call       bool [mscorlib]System.String::op_Inequality(string, string)
		IL_0012:  ldc.i4.0
		IL_0013:  ceq
		IL_0015:  stloc.2
		IL_0016:  ldloc.2
		IL_0017:  brtrue.s   IL_001d

		IL_0019:  ldc.i4.1
		IL_001a:  stloc.1
		IL_001b:  br.s       IL_0021

		IL_001d:  ldc.i4.0
		IL_001e:  stloc.1
		IL_001f:  br.s       IL_0021

		IL_0021:  ldloc.1
		IL_0022:  ret
	}
}
