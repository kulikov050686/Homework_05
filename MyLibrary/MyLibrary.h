#pragma once

namespace MyLibrary 
{
	class VinohradStrassen
	{
	public:
		void mult_standart(double* c, double* a, double* b, int n);
		void mult(double* c, double* a, double* b, int n);
	private:
		void copy(double* a, double* b, int ib, int jb, int n);
		void copyback(double* a, int ia, int ja, double* b, int n);
		void add(double* c, double* a, double* b, int n);
		void sub(double* c, double* a, double* b, int n);
	};
}

#ifdef __cplusplus
extern "C"
{
#endif

	__declspec(dllexport) void VinohradStrassenAlgorithm(double* c, double* a, double* b, int n);

#ifdef __cplusplus
}
#endif