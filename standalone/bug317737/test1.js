import System;

function doVerify (a, b)
{
	var delta = 1e-4;
	if (a === b)
		return 1;
	return 0;
}

Environment.Exit (doVerify (1, 2));
