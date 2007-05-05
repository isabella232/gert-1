#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef void (* FooHandler) (int foo);

static void
foo_thread (FooHandler handler)
{
	sleep (5);
	handler (22);
}

void
foo_start_crash (FooHandler handler)
{
	pthread_t thread;
	pthread_create (&thread, NULL, foo_thread, handler);
}
