#include<iostream>
#include<math.h>
using namespace std;
void main()
{
	setlocale(0, "");
	float a, b, h, x, x0, x2n, r, s1 = 0, s2 = 0, s;
	int i, n;
	cout << "введите количество отрезков разбиения промежутка [a, b] =";
	cin >> n;
	a = -0.8;
	b = 0;
	h = (b - a) / n;
	cout << "h=" << h;
	for (x = a; x < b; x += h)
	{
		if (fmod(x, 2) == 0)
		s1 += 1 / (sqrt(3 + pow(x, 5)));
		cout << "s1=" << s1;
	}
	s1 *= 2;
	for (x = a; x < b; x += h)
	{
		if (fmod(x, 2 == 1))
		s2 += 1 / (sqrt(3 + pow(x, 5)));
		cout << "s2=" << s2;
	}
	s2 *= 4;
	x0 = 1 / (sqrt(3 + pow(a, 5))) * a;
	x2n = 1 / (sqrt(3 + pow(b, 5))) * b;
	s = s1 + s2 + x0 + x2n;
	r = h / 3 * s;
	cout << "приближенное значение интеграла =" << r;
}