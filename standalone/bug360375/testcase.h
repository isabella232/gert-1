union test_union {
	unsigned char a;
	int b;
};

struct test_struct {
	unsigned char a;
	union test_union b;
};

extern void test(struct test_struct *ts);
