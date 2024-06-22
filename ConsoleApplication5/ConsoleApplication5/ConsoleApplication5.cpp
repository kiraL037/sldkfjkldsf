#include <string>
#include <iostream>
#define _USE_MATH_DEFINES
#include <math.h>
using namespace std;
void main()
{
	double a, b, c;
	double C;
	cout << "a=";
	cin >> a;
	cout << "b=";
	cin >> b;
	cout << "c=";
	cin >> c;
	if (a * a == b * b + c * c)
		cout << "\npryamoy tr";
	if (b * b == a * a + c * c)
		cout << "\npryamoy tr";
	if (c * c == a * a + b * b)
		cout << "\npryamoy tr";
	else (C == acos((b * b + c * c - a * a) / (2 * b * c))*180/M_PI);
		cout << "\nne pryamoy";
}