#include <stdio.h>
#include <unistd.h>

int main (int argc, char *argv[])
{
		close (0);
		close (1);
		close (2);

		return execlp (argv[1], argv[1], argv[2], NULL);
}
