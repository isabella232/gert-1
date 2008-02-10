#include "testcase.h"

int main(int argc, const char* argv[])
{
	struct test_struct ts;
	test(&ts);
	printf("%d\n", ts.b.b);
}
