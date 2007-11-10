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
.module test.dll
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.class interface public abstract auto ansi import SummaryInfo
{
	//.custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = ( 01 00 08 50 72 6F 70 65 72 74 79 00 00 )

	.method public hidebysig newslot specialname abstract virtual instance object get_Property(int32 Pid) runtime managed
	{
	}

	.method public hidebysig newslot specialname abstract virtual instance void  set_Property(int32 Pid, object 'value') runtime managed
	{
	}

	.property instance object Property(int32)
	{
	.get instance object SummaryInfo::get_Property(int32)
	.set instance void SummaryInfo::set_Property(int32,object)
	}
}
