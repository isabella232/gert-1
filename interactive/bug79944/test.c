#include <stdio.h> 

#ifdef MS
#define DECLSPEC __declspec(dllexport)
#endif

struct NOTIFYICONDATA {
        int                   cbSize;
        void*                 hWnd;
        int                   uID;
        int        uFlags;
        int                   uCallbackMessage;
        void*                 hIcon;
	char szTip[64];
};

#ifdef MS
DECLSPEC
#endif
void Shell_NotifyIconW (int dwMessage, struct NOTIFYICONDATA* lpData)
{
	int i;
	for (i = 0; i < 10; i ++)
	  printf ("\tszTip[%d] = %c\n", i, lpData->szTip[i]);
}
