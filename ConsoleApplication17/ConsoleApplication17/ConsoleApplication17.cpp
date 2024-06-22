#include <iostream>
#include <ctime>
using namespace std;
void Matr(int n, int M[])
{
	int i;
	srand(time(0));
	for (i = 0; i < n; i++);
	{
		M[i] = rand() % 100;
		cout << "  " << M[i];
	}
}
float sum(int K, int L[])
{
	int i;
	float s = 0;
	for (i = 0; i < K; i++)
		if (L[i] < 0)
			s += L[i];
	return s;
}
int main()
{
	setlocale(0, "");
	int X[100], Y[100], N1, N2;
	float S1=0, S2=0;
	cout << "введите размерность массива X = ";
	cin >> N1;
	Matr(N1, X);
	S1 = sum(N1, X);
	cout << "введите размерность массива Y = ";
	cin >> N2;
	Matr(N2, Y);
	S2 = sum(N2, Y);
	cout << "\nZ = " << (S1 + S2) / 2 << endl;
	return 0;
}