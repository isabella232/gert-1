#include <stdio.h>
#include <unistd.h>

int main (int argc, char *argv[])
{
		printf("1=%s\n", argv[1]);
		printf("2=%s\n", argv[2]);

        close (0);
        close (1);
        close (2);

        return execlp (argv[1], argv[1], argv[2], NULL);
}
