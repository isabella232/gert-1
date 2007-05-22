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

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
  .method private hidebysig static void Main() cil managed
  {
    .entrypoint
    .maxstack  8	
    IL_0000:  ldc.i4.2
    IL_0001:  call       void Program::EmitLoadI4Value(int32)
    IL_0006:  ret
  }

  .method public static void EmitLoadI4Value(int32 I) cil managed
  {
    .maxstack  8
    L_0000: ldarg.0 
    L_0001: ldc.i4.s -128
    L_0003: clt 
    L_0005: ldc.i4.0 
    L_0006: ceq 
    L_0008: brfalse L_001a
    L_000d: ldarg.0 
    L_000e: ldc.i4.s 127
    L_0010: cgt 
    L_0012: ldc.i4.0 
    L_0013: ceq 
    L_0015: brtrue L_0020
    L_001a: ldc.i4.0 
    L_001b: br L_0021
    L_0020: ldc.i4.1 
    L_0021: brfalse L_002b
    L_0026: br L_002b
    L_002b: ret 
  }

  .method public hidebysig specialname rtspecialname instance void .ctor() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  }
}
