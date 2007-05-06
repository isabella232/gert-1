.assembly test
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module test
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.method public static int32 main() cil managed
{
  .entrypoint
  .maxstack  3
  IL_0000:  ldc.r4     (00 00 80 7F)
  IL_0005:  ldc.r4     (00 00 C0 7F)
  IL_000a:  bgt.s      IL_000e

  IL_000c:  ldc.i4.0
  IL_000d:  ret

  IL_000e:  ldc.i4.1
  IL_000f:  ret
}
