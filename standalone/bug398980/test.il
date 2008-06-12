.assembly extern mscorlib
{
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
	.ver 2:0:0:0
}
.assembly 'test'
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = (
		01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78
		63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01)
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module 'test.exe'
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.class private auto ansi beforefieldinit X extends [mscorlib]System.Object
{
	.class auto ansi nested private beforefieldinit '<>c__CompilerGenerated0`1'<T> extends [mscorlib]System.Object
	{
		.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 )
		.field assembly class X '<>f__this'
		.field assembly !T u
		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack 8
			IL_0000: ldarg.0
			IL_0001: call instance void [mscorlib]System.Object::.ctor()
			IL_0006: ret
		}

		.method assembly hidebysig instance void '<Test>c__1'() cil managed
		{
			.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 )
			.maxstack 8
			IL_0000: ldarg.0
			IL_0001: ldfld class X class X/'<>c__CompilerGenerated0`1'<!T>::'<>f__this'
			IL_0006: ldarg.0
			IL_0007: ldfld !0 class X/'<>c__CompilerGenerated0`1'<!T>::u
			IL_000c: call instance void X::Hello<!T>(!!0)
			IL_0011: ret
		}
	}

	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack 8
		IL_0000: ldarg.0
		IL_0001: call instance void [mscorlib]System.Object::.ctor()
		IL_0006: ret
	}

	.method public hidebysig instance void Hello<U>(!!U u) cil managed
	{
		.maxstack 8
		IL_0000: ret
	}

	.method public hidebysig instance void Test<T>(!!T t) cil managed
	{
		.maxstack 7
		.locals init (class Foo V_0, class X/'<>c__CompilerGenerated0`1'<!!T> V_1)
		IL_0000: newobj instance void class X/'<>c__CompilerGenerated0`1'<!!T>::.ctor()
		IL_0005: stloc.1
		IL_0006: ldloc.1
		IL_0007: ldarg.0
		IL_0008: stfld class X class X/'<>c__CompilerGenerated0`1'<!!T>::'<>f__this'
		IL_000d: ldloc.1
		IL_000e: ldarg.1
		IL_000f: stfld !!T class X/'<>c__CompilerGenerated0`1'<!!T>::u
		IL_0014: ldarg.0
		IL_0015: ldloc.1
		IL_0016: ldfld !!T class X/'<>c__CompilerGenerated0`1'<!!T>::u
		IL_001b: call instance void X::Hello<!!0>(!!0)
		IL_0020: ldloc.1
		IL_0021: ldftn instance void class X/'<>c__CompilerGenerated0`1'<!!T>::'<Test>c__1'()
		IL_0027: newobj instance void Foo::.ctor(object, native int)
		IL_002c: stloc.0
		IL_002d: ldloc.0
		IL_002e: callvirt instance void Foo::Invoke()
		IL_0033: ldarg.0
		IL_0034: ldloc.1
		IL_0035: ldfld !!T class X/'<>c__CompilerGenerated0`1'<!!T>::u
		IL_003a: call instance void X::Hello<!!0>(!!0)
		IL_003f: ret
	}

	.method private hidebysig static int32 Main() cil managed
	{
		.entrypoint
		.maxstack 2
		.locals init (int32 V_0)
		IL_0000:  nop
		.try {
			IL_0001: nop
			IL_0002: newobj instance void X::.ctor()
			IL_0005: ldc.i4.3
			IL_0006: callvirt instance void X::Test<int32>(!!0)
			IL_0007: nop
			IL_0008: ldc.i4.1
			IL_0009: stloc.0
			IL_000a: leave.s    IL_0010
		} catch [mscorlib]System.MissingFieldException {
			IL_000b: pop
			IL_000c: nop
			IL_000d: ldc.i4.0
			IL_000e: stloc.0
			IL_000f: leave.s    IL_0010
		}
		IL_0010:  nop
		IL_0011:  ldloc.0
		IL_0012:  ret
	}
}

.class private auto ansi sealed Foo extends [mscorlib]System.MulticastDelegate
{
	.method public hidebysig specialname rtspecialname instance void .ctor(object 'object', native int 'method') runtime managed
	{
	}

	.method public hidebysig newslot virtual instance void Invoke() runtime managed
	{
	}

	.method public hidebysig newslot virtual instance class [mscorlib]System.IAsyncResult BeginInvoke(class [mscorlib]System.AsyncCallback callback, object 'object') runtime managed
	{
	}

	.method public hidebysig newslot virtual instance void EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
	{
	}
}
