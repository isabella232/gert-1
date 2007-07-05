#include <stdlib.h>
#include <stdio.h>

//
// Define the interface for a callback function that will call from C++ into a C# function.
// also allocate a static function pointer of that type to hold the function ptr
//
typedef unsigned short* (* SWIG_CSharpUTF16StringHelperCallback)(unsigned short*);
static SWIG_CSharpUTF16StringHelperCallback stringCallback = NULL;

//
// export a registration function which the C# project will invoke to give us the callback 
//
void SWIGRegisterUTF16StringCallback_libtest(SWIG_CSharpUTF16StringHelperCallback callback)
{
   stringCallback = callback;
}

//
// export a simple function that the C# project can call which will use the given callback function.
//
void my_test_func()
{
    //I'm going to create a utf16 string in the mono world.

   unsigned short* ms;
   unsigned short* ms2;
   int x;

   ms = malloc(27 * 2);
   for (x=0; x<26; ++x)   
   {
       ms[x] = 'a' + x;
   }
   ms[26] = 0;

   //
   // print out the bytes before sending to the C# callback function
   //
   for (x=0; x<26; ++x)
   {
       printf("%c", ms[x]);
   }
   printf("|");

   //
   // Send the bytes to the C# callback function
   //
   ms2 = stringCallback(ms);

   //
   // print out the bytes after the C# callback function.  They will be destroyed by now 
   //
   x = 0;
   while (ms2[x] != 0)
   {
       printf("%c", ms2[x]);
       x++;
   }
}
