.assembly Test { }
.assembly extern mscorlib { }
 
.method public static int32 Main() cil managed
{
	.entrypoint
	.locals init (int32 V_0, int32 V_1)
	ldc.i4.1
	stloc.0
	.try
	{
		.try
		{
			newobj instance void [mscorlib]System.Exception::.ctor()
			throw
			leave.s IL_0015
		}
		fault
		{
			ldc.i4.0
			stloc.0
			endfault
			leave.s IL_0015
		}
	}
	catch [mscorlib]System.Object 
	{
		pop
		leave.s IL_0015
	}
	IL_0015:  ldloc.0
	IL_0016:  stloc.1
	IL_0017:  br.s IL_0018
	IL_0018:  ldloc.1
	IL_0019:  ret
}
