.assembly mscorlib
{
	.hash algorithm 0x00008004
	.ver 0:0:0:0
}
.module mscorlib.dll
.imagebase 0x00400000
.file alignment 0x00000200
.subsystem 0x0003
.corflags 0x00000001

.namespace System
{
.class public auto ansi beforefieldinit Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  br.s IL_0002
		IL_0002:  ret
	}
}

.class public auto ansi beforefieldinit ValueType extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi sealed beforefieldinit Byte extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Int16 extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Int32 extends System.ValueType
{
	.method public hidebysig static void DoMagic() cil managed
	{
		.maxstack  0
		IL_0000:  ret
	}
}

.class public auto ansi sealed beforefieldinit Int64 extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Single extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Double extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Char extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Boolean extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit SByte extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit UInt16 extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit UInt32 extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit UInt64 extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit IntPtr extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit UIntPtr extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit Decimal extends System.ValueType
{
}

.class public auto ansi beforefieldinit String extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Delegate extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit MulticastDelegate extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Array extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Exception extends System.Object
{
	.field public static literal int32 Unknown = int32(0x00000001)
	
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Type extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Enum extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit Attribute extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi sealed beforefieldinit Void extends System.ValueType
{
}

.class public auto ansi beforefieldinit ParamArrayAttribute extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi beforefieldinit DefaultMemberAttribute extends System.Object
{
	.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
	{
		.maxstack  8
		IL_0000:  ldarg.0
		IL_0001:  call instance void System.Object::.ctor()
		IL_0006:  ret
	}
}

.class public auto ansi sealed beforefieldinit RuntimeTypeHandle extends System.ValueType
{
}

.class public auto ansi sealed beforefieldinit RuntimeFieldHandle extends System.ValueType
{
}

.class interface public abstract auto ansi IDisposable
{
}
}

.namespace System.Runtime.InteropServices
{
	.class public auto ansi beforefieldinit OutAttribute extends System.Object
	{
		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  8
			IL_0000:  ldarg.0
			IL_0001:  call instance void System.Object::.ctor()
			IL_0006:  ret
		}
	}
}

.namespace System.Collections
{
	.class interface public abstract auto ansi IEnumerable
	{
	}

	.class interface public abstract auto ansi IEnumerator
	{
	}
}

.namespace System.Reflection
{
	.class public auto ansi beforefieldinit DefaultMemberAttribute extends System.Object
	{
		.method public hidebysig specialname rtspecialname instance void .ctor() cil managed
		{
			.maxstack  8
			IL_0000:  ldarg.0
			IL_0001:  call instance void System.Object::.ctor()
			IL_0006:  ret
		}
	}
}
