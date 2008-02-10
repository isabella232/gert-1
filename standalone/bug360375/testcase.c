#include "testcase.h"

void test(struct test_struct *ts)
{
	int a = 42;
	ts->b.b = a;
}
