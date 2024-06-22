#include<iostream>
#include<math.h>
using namespace std;
void main()
{
	setlocale (0, "");
	float a = 0, b = 3, h, x, r, s1 = 0, s2 = 0, s, x0, xn, S = 0, R, H, X;
	int i, n;
	cout << "введите количество отрезков разбиения промежутка [a, b] =";
	cin >> n;
	x = a;
	h = (b - a) / 2 / n;
	for (i = 2; i <= 2 * n - 2; i += 2)
	{
		s1 += 1 / sqrt(pow(16 + x * x, 3));
		x += 2 * h;
	}
	s1 *= 2;
	x = a;
	for (i = 1; i <= 2 * n - 1; i += 2)
	{
		s2 += 1 / sqrt(pow(16 + x * x, 3));
		x += 2 * h;
	}
	s2 *= 4;
	x0 = 1 / sqrt(pow(16 + a * a, 3));
	xn = 1 / sqrt(pow(16 + b * b, 3));
	s = s1 + s2 + x0 + xn;
	r = h / 3 * s;
	cout << "приближенное значение интеграла по методу Симпсона =" << r;

	H = (b - a) / n;
	X = a;
	for (i = 1; i < n; i++)
	{
		S += 1 / sqrt(pow(16 + X * X, 3));
		X += H;
	}
	R = H * (S + (x0 + xn) / 2);
	cout << "\nприближенное значение интеграла по методу трапеций =" << R;
}