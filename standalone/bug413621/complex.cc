#include <complex>
using namespace std;
typedef complex<double> dcomplex;
typedef complex<float> fcomplex;

extern "C" void addComplexS(int l, fcomplex* x, fcomplex y, fcomplex* z)
{
	for(int i = 0; i < l; i++)
		z[i] = x[i] + y;
}

extern "C" void addComplexD(int l, dcomplex* x, dcomplex y, dcomplex* z)
{
	for(int i = 0; i < l; i++)
		z[i] = x[i] + y;
}
