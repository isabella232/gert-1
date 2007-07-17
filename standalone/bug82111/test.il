
//  Microsoft (R) .NET Framework IL Disassembler.  Version 1.1.4322.573
//  Copyright (C) Microsoft Corporation 1998-2002. All rights reserved.

.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 1:0:5000:0
}
.assembly test
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module test.exe
// MVID: {C135DCAC-9FD3-44D5-9B80-7C885ECFE274}
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001
// Image base: 0x00c40000
//
// ============== CLASS STRUCTURE DECLARATION ==================
//
.class public abstract auto ansi beforefieldinit MyAbstractBase
       extends [mscorlib]System.Object
{
} // end of class MyAbstractBase

.class public abstract auto ansi beforefieldinit MyAbstract
       extends MyAbstractBase
{
} // end of class MyAbstract

.class public auto ansi beforefieldinit MyConcrete
       extends MyAbstract
{
} // end of class MyConcrete

.class public auto ansi beforefieldinit Program
       extends [mscorlib]System.Object
{
} // end of class Program


// =============================================================


// =============== GLOBAL FIELDS AND METHODS ===================


// =============================================================


// =============== CLASS MEMBERS DECLARATION ===================
//   note that class flags, 'extends' and 'implements' clauses
//          are provided here for information only

.class public abstract auto ansi beforefieldinit MyAbstractBase
       extends [mscorlib]System.Object
{
  .method family hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method MyAbstractBase::.ctor

  .method public hidebysig newslot abstract virtual 
          instance void  Initialize() cil managed
  {
  } // end of method MyAbstractBase::Initialize

} // end of class MyAbstractBase

.class public abstract auto ansi beforefieldinit MyAbstract
       extends MyAbstractBase
{
  .method family hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void MyAbstractBase::.ctor()
    IL_0006:  ret
  } // end of method MyAbstract::.ctor

  .method public hidebysig newslot virtual 
          instance void  Initialize() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  ldstr      "MyAbstract Initialized!"
    IL_0005:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000a:  ret
  } // end of method MyAbstract::Initialize

} // end of class MyAbstract

.class public auto ansi beforefieldinit MyConcrete
       extends MyAbstract
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void MyAbstract::.ctor()
    IL_0006:  ret
  } // end of method MyConcrete::.ctor

} // end of class MyConcrete

.class public auto ansi beforefieldinit Program
       extends [mscorlib]System.Object
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       13 (0xd)
    .maxstack  2
    .locals init (class MyAbstractBase V_0)
    IL_0000:  newobj     instance void MyConcrete::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  callvirt   instance void MyAbstractBase::Initialize()
    IL_000c:  ret
  } // end of method Program::Main

} // end of class Program


// =============================================================

//*********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file test.res
