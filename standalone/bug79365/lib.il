.assembly extern mscorlib
{
  .ver 1:0:5000:0
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 ) // .z\V.4..
}
.assembly 'lib'
{
  .hash algorithm 0x00008004
  .ver  0:0:0:0
}
.module RENAMED.dll // GUID = {0321B48D-22EE-49C1-B7E8-429E79D151AC}


  .class public auto ansi beforefieldinit Lib
  	extends [mscorlib]System.Object
  {

    // method line 1
    .method public hidebysig  specialname  rtspecialname 
           instance default void .ctor ()  cil managed 
    {
        // Method begins at RVA 0x20ec
	// Code size 17 (0x11)
	.maxstack 8
	IL_0000:  ldarg.0 
	IL_0001:  call instance void object::.ctor()
	IL_0006:  ldstr "Lib"
	IL_000b:  call void class [mscorlib]System.Console::WriteLine(string)
	IL_0010:  ret 
    } // end of method Lib::instance default void .ctor () 

  } // end of class Lib

