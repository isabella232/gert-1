.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
  .ver 2:0:0:0
}
.assembly test
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78
																												63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )
	.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module test.exe
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.class private auto ansi beforefieldinit Program extends [mscorlib]System.Object
{
	.field public class [mscorlib]System.Collections.Generic.IList`1<string> MyField1
	.custom instance void MyAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 80 CD 53 79 73 74 65 6D 2E 43 6F 6C 6C 65
																			63 74 69 6F 6E 73 2E 47 65 6E 65 72 69 63 2E 49
																			4C 69 73 74 60 31 5B 5B 53 79 73 74 65 6D 2E 53
																			74 72 69 6E 67 2C 20 6D 73 63 6F 72 6C 69 62 2C
																			20 56 65 72 73 69 6F 6E 3D 32 2E 30 2E 30 2E 30
																			2C 20 43 75 6C 74 75 72 65 3D 6E 65 75 74 72 61
																			6C 2C 20 50 75 62 6C 69 63 4B 65 79 54 6F 6B 65
																			6E 3D 62 37 37 61 35 63 35 36 31 39 33 34 65 30
																			38 39 5D 5D 2C 20 6D 73 63 6F 72 6C 69 62 2C 20
																			56 65 72 73 69 6F 6E 3D 32 2E 30 2E 30 2E 30 2C
																			20 43 75 6C 74 75 72 65 3D 6E 65 75 74 72 61 6C
																			2C 20 50 75 62 6C 69 63 4B 65 79 54 6F 6B 65 6E
																			3D 62 37 37 61 35 63 35 36 31 39 33 34 65 30 38
																			39 00 00 )
	.field public class [mscorlib]System.Collections.Generic.IList`1<class Program> MyField2
	.custom instance void MyAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 78 53 79 73 74 65 6D 2E 43 6F 6C 6C 65 63
																			74 69 6F 6E 73 2E 47 65 6E 65 72 69 63 2E 49 4C
																			69 73 74 60 31 5B 50 72 6F 67 72 61 6D 5D 2C 20
																			6D 73 63 6F 72 6C 69 62 2C 20 56 65 72 73 69 6F
																			6E 3D 32 2E 30 2E 30 2E 30 2C 20 43 75 6C 74 75
																			72 65 3D 6E 65 75 74 72 61 6C 2C 20 50 75 62 6C
																			69 63 4B 65 79 54 6F 6B 65 6E 3D 62 37 37 61 35
																			63 35 36 31 39 33 34 65 30 38 39 00 00 )
	.method private hidebysig static int32 Main() cil managed
	{
		.entrypoint
		.maxstack  2
		.locals init (class [mscorlib]System.Reflection.FieldInfo V_0,
				object[] V_1,
				class MyAttribute V_2,
				int32 V_3,
				bool V_4)
		IL_0000:  nop
		IL_0001:  ldtoken    Program
		IL_0006:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_000b:  ldstr      "MyField1"
		IL_0010:  call       instance class [mscorlib]System.Reflection.FieldInfo [mscorlib]System.Type::GetField(string)
		IL_0015:  stloc.0
		IL_0016:  ldloc.0
		IL_0017:  ldc.i4.1
		IL_0018:  callvirt   instance object[] [mscorlib]System.Reflection.MemberInfo::GetCustomAttributes(bool)
		IL_001d:  stloc.1
		IL_001e:  ldloc.1
		IL_001f:  ldlen
		IL_0020:  conv.i4
		IL_0021:  ldc.i4.1
		IL_0022:  ceq
		IL_0024:  stloc.s    V_4
		IL_0026:  ldloc.s    V_4
		IL_0028:  brtrue.s   IL_002e

		IL_002a:  ldc.i4.1
		IL_002b:  stloc.3
		IL_002c:  br.s       IL_00a9

		IL_002e:  ldloc.1
		IL_002f:  ldc.i4.0
		IL_0030:  ldelem.ref
		IL_0031:  castclass  MyAttribute
		IL_0036:  stloc.2
		IL_0037:  ldloc.2
		IL_0038:  callvirt   instance class [mscorlib]System.Type MyAttribute::get_Type()
		IL_003d:  ldtoken    class [mscorlib]System.Collections.Generic.IList`1<string>
		IL_0042:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_0047:  ceq
		IL_0049:  stloc.s    V_4
		IL_004b:  ldloc.s    V_4
		IL_004d:  brtrue.s   IL_0053

		IL_004f:  ldc.i4.2
		IL_0050:  stloc.3
		IL_0051:  br.s       IL_00a9

		IL_0053:  ldtoken    Program
		IL_0058:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_005d:  ldstr      "MyField2"
		IL_0062:  call       instance class [mscorlib]System.Reflection.FieldInfo [mscorlib]System.Type::GetField(string)
		IL_0067:  stloc.0
		IL_0068:  ldloc.0
		IL_0069:  ldc.i4.1
		IL_006a:  callvirt   instance object[] [mscorlib]System.Reflection.MemberInfo::GetCustomAttributes(bool)
		IL_006f:  stloc.1
		IL_0070:  ldloc.1
		IL_0071:  ldlen
		IL_0072:  conv.i4
		IL_0073:  ldc.i4.1
		IL_0074:  ceq
		IL_0076:  stloc.s    V_4
		IL_0078:  ldloc.s    V_4
		IL_007a:  brtrue.s   IL_0080

		IL_007c:  ldc.i4.3
		IL_007d:  stloc.3
		IL_007e:  br.s       IL_00a9

		IL_0080:  ldloc.1
		IL_0081:  ldc.i4.0
		IL_0082:  ldelem.ref
		IL_0083:  castclass  MyAttribute
		IL_0088:  stloc.2
		IL_0089:  ldloc.2
		IL_008a:  callvirt   instance class [mscorlib]System.Type MyAttribute::get_Type()
		IL_008f:  ldtoken    class [mscorlib]System.Collections.Generic.IList`1<class Program>
		IL_0094:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_0099:  ceq
		IL_009b:  stloc.s    V_4
		IL_009d:  ldloc.s    V_4
		IL_009f:  brtrue.s   IL_00a5

		IL_00a1:  ldc.i4.4
		IL_00a2:  stloc.3
		IL_00a3:  br.s       IL_00a9

		IL_00a5:  ldc.i4.0
		IL_00a6:  stloc.3
		IL_00a7:  br.s       IL_00a9

		IL_00a9:  ldloc.3
		IL_00aa:  ret
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
		IL_0006:  stfld      class [mscorlib]System.Collections.Generic.IList`1<string> Program::MyField1
		IL_000b:  ldarg.0
		IL_000c:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Program>::.ctor()
		IL_0011:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Program> Program::MyField2
		IL_0016:  ldarg.0
		IL_0017:  call       instance void [mscorlib]System.Object::.ctor()
		IL_001c:  nop
		IL_001d:  ret
	}
}

.class public auto ansi beforefieldinit MyAttribute extends [mscorlib]System.Attribute
{
	.field private class [mscorlib]System.Type _type
	.method public hidebysig specialname rtspecialname instance void .ctor(class [mscorlib]System.Type 'type') cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call       instance void [mscorlib]System.Attribute::.ctor()
		IL_0006:  nop
		IL_0007:  nop
		IL_0008:  ldarg.0
		IL_0009:  ldarg.1
		IL_000a:  stfld      class [mscorlib]System.Type MyAttribute::_type
		IL_000f:  nop
		IL_0010:  ret
	}

	.method public hidebysig specialname instance class [mscorlib]System.Type get_Type() cil managed
	{
		.maxstack  1
		.locals init (class [mscorlib]System.Type V_0)
		IL_0000:  nop
		IL_0001:  ldarg.0
		IL_0002:  ldfld      class [mscorlib]System.Type MyAttribute::_type
		IL_0007:  stloc.0
		IL_0008:  br.s       IL_000a

		IL_000a:  ldloc.0
		IL_000b:  ret
	}

	.property instance class [mscorlib]System.Type Type()
	{
		.get instance class [mscorlib]System.Type MyAttribute::get_Type()
	}
}
