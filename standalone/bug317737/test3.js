import System;

function foo(bar) {
	if (bar == 0)
		 return 0;
	else if (bar == 1)
		return 1;
	return 2;
}

Environment.Exit (foo(0));
