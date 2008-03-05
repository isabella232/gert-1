.assembly extern mscorlib
{
	.ver 2:0:0:0
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
}
.assembly 'test'
{
	.custom instance void class [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = (
		01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78
		63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01)
	.hash algorithm 0x00008004
	.ver  0:0:0:0
}
.module 'test.exe'

.class public auto ansi beforefieldinit ClassA extends [mscorlib]System.Object
{
	.method public hidebysig  specialname  rtspecialname instance default void .ctor () cil managed 
	{
		.maxstack 8
		IL_0000:  ldarg.0 
		IL_0001:  call instance void object::.ctor()
		IL_0006:  ret 
	}
}

.class public auto ansi beforefieldinit GenExc`1<T> extends [mscorlib]System.Exception
{
	.method public hidebysig  specialname  rtspecialname instance default void .ctor () cil managed 
	{
		.maxstack 8
		IL_0000:  ldarg.0 
		IL_0001:  call instance void class [mscorlib]System.Exception::.ctor()
		IL_0006:  ret 
	}
}

.class public auto ansi beforefieldinit NonGen extends [mscorlib]System.Object
{
	.method public hidebysig  specialname  rtspecialname instance default void .ctor ()  cil managed 
	{
		.maxstack 8
		IL_0000:  ldarg.0 
		IL_0001:  call instance void object::.ctor()
		IL_0006:  ret 
	}

	.method public static hidebysig default void doThrow () cil managed
	{
		.maxstack 8
		IL_0000:  ldc.i4.3 
		IL_0001:  newarr ClassA
		IL_0005:  throw 
	}

	.method public static hidebysig default object newArr () cil managed
	{
		.maxstack 8
		IL_0000:  ldc.i4.3 
		IL_0001:  newarr ClassA
		IL_0006:  ret 
	}
}

.class public auto ansi beforefieldinit Gen`1<T> extends [mscorlib]System.Object
{
	.method public hidebysig  specialname  rtspecialname instance default void .ctor () cil managed
	{
		.maxstack 8
		IL_0000:  ldarg.0 
		IL_0001:  call instance void object::.ctor()
		IL_0006:  ret 
	}

	.method public hidebysig instance default void except () cil managed
	{
		.maxstack 1
		.try {
			IL_0000:  call void class NonGen::doThrow()
			IL_0005:  leave IL_0010
		} catch !0[] {
			IL_000a:  pop 
			IL_000b:  leave IL_0010
		}
		IL_0010:  ret
	}
}

.class public auto ansi beforefieldinit main extends [mscorlib]System.Object
{
	.method public hidebysig specialname  rtspecialname instance default void .ctor () cil managed 
	{
		.maxstack 8
		IL_0000:  ldarg.0 
		IL_0001:  call instance void object::.ctor()
		IL_0006:  ret 
	}

	.method public static hidebysig default int32 Main () cil managed
	{
		.entrypoint
		.maxstack 4
		.locals init (
			class Gen`1<class ClassA>	V_0,
			int32 V_1)
		IL_0000:  newobj instance void class Gen`1<class ClassA>::.ctor()
		IL_0005:  stloc.0 
		.try {
			IL_0006:  ldloc.0 
			IL_0007:  callvirt instance void class Gen`1<class ClassA>::except()
			IL_000c:  leave IL_0028
		} catch class ClassA[] {
			IL_0011:  pop 
			IL_0012:  ldstr "exception not caught"
			IL_0017:  call void class [mscorlib]System.Console::WriteLine(string)
			IL_001c:  ldc.i4.1 
			IL_001d:  stloc.1 
			IL_001e:  leave IL_002a
			IL_0023:  leave IL_0028
		}
		IL_0028:  ldc.i4.0 
		IL_0029:  ret 
		IL_002a:  ldloc.1 
		IL_002b:  ret 
	}
}
