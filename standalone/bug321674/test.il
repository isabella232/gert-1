
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
  .ver 2:0:0:0
}
.assembly 'test'
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module 'test'
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001
.class interface private abstract auto ansi beforefieldinit ICovariantEnumerator`1<+ T>
{
  .method public hidebysig abstract virtual 
          instance bool  MoveNext() cil managed
  {
  }
  .method public hidebysig specialname abstract virtual 
          instance !T  get_Current() cil managed
  {
  }
  .property !T Current()
  {
    .get instance !T ICovariantEnumerator`1::get_Current()
  }
}
.class private auto ansi beforefieldinit Enumerator`1<T>
       extends [mscorlib]System.Object
       implements class ICovariantEnumerator`1<!T>
{
  .field private initonly class [mscorlib]System.Collections.Generic.IEnumerator`1<!T> enu
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.Collections.Generic.IEnumerator`1<!T> enu) cil managed
  {
    .maxstack  4
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class Enumerator`1<!T>::enu
    IL_000d:  ret
  }

  .method public hidebysig newslot virtual final 
          instance bool  MoveNext() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class Enumerator`1<!T>::enu
    IL_0006:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
    IL_000b:  ret
  }

  .method public hidebysig newslot specialname virtual final 
          instance !T  get_Current() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class Enumerator`1<!T>::enu
    IL_0006:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<!T>::get_Current()
    IL_000b:  ret
  }

  .property !T Current()
  {
    .get instance !T Enumerator`1::get_Current()
  }
}

.class private abstract auto ansi sealed beforefieldinit Test
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  processObjects(class ICovariantEnumerator`1<object> x) cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance bool class ICovariantEnumerator`1<object>::MoveNext()
    IL_0006:  pop
    IL_0007:  ldarg.0
    IL_0008:  callvirt   instance !0 class ICovariantEnumerator`1<object>::get_Current()
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(object)
    IL_0012:  ret
  }

  .method public hidebysig static void  processStrings(class ICovariantEnumerator`1<string> x) cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance bool class ICovariantEnumerator`1<string>::MoveNext()
    IL_0006:  pop
    IL_0007:  ldarg.0
    IL_0008:  callvirt   instance !0 class ICovariantEnumerator`1<string>::get_Current()
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0012:  ret
  }

  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    .maxstack  2
    .locals init (class [mscorlib]System.Collections.Generic.List`1<string> V_0,
             class Enumerator`1<string> V_1)
    IL_0000:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldstr      "aa"
    IL_000c:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
    IL_0011:  ldloc.0
    IL_0012:  ldstr      "bb"
    IL_0017:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
    IL_001c:  ldloc.0
    IL_001d:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<string>::GetEnumerator()
    IL_0022:  box        valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<string>
    IL_0027:  newobj     instance void class Enumerator`1<string>::.ctor(class [mscorlib]System.Collections.Generic.IEnumerator`1<!0>)
    IL_002c:  stloc.1
    IL_002d:  ldloc.1
    IL_002e:  call       void Test::processStrings(class ICovariantEnumerator`1<string>)
    IL_0033:  ldloc.1
    IL_0034:  call       void Test::processObjects(class ICovariantEnumerator`1<object>)
    IL_0039:  ret
  }
}
