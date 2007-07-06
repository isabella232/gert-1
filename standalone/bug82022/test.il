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

.class private auto ansi sealed FieldAttributes extends [mscorlib]System.Enum
{
}

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
  .method private hidebysig static void Main() cil managed
  {
    .entrypoint
    .maxstack  2
    .locals init (class [mscorlib]System.Type V_0)
    IL_0000:  ldtoken    FieldAttributes
    IL_0005:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000a:  stloc.0
    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance string [mscorlib]System.Type::get_FullName()
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0016:  ret
  }

  .method public hidebysig specialname rtspecialname instance void .ctor() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  }
}

.class private auto ansi sealed FieldAttributes extends [mscorlib]System.Enum
{
}
