/***
 *
 * Simple mono embedding example.
 *
 *
 ***/

#include <iostream>

#define CALLING_CONVENTION __attribute__((cdecl))

extern "C"
{

    typedef CALLING_CONVENTION void (*CallbackFunction)(void);

    void CALLING_CONVENTION print_hello_world()
    {
        std::wcout << "Hello, World!" << std::endl;
    }

    void CALLING_CONVENTION DoNothing()
    {
        std::wcout << "Not doing anything!" << std::endl;
    }


    CallbackFunction CALLING_CONVENTION GetCallbackI()
    {
        std::wcout << "In GetCallbackI!" << std::endl;
        return print_hello_world;
    }


    void CALLING_CONVENTION GetCallbackII(CallbackFunction * callback)
    {
        std::wcout << "In GetCallbackII!" << std::endl;
        *callback = print_hello_world;
    }
}



