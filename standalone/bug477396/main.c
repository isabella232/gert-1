#include <stdio.h>
#include <stdlib.h>

typedef int gboolean;
#define	FALSE	(0)
#define	TRUE	(!FALSE)

typedef struct 
{
	int (*test) (void);
} test_struct;

test_struct *create_dummy_struct (void);

test_struct *create_dummy_struct ()
{
	test_struct *mystruct = (test_struct*) malloc (sizeof (test_struct));
	mystruct->test = NULL;
	return mystruct;
}
