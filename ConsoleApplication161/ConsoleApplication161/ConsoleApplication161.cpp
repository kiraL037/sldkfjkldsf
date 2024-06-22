#include <iostream>
#include <conio.h>
#include <ctime>
#include <iomanip>
using namespace std;
void main()
{
	setlocale(0, "");
	srand(time(0));
	int i, j, n, m, x[100][100], jmin, imin, imax, jmax, min[100];
	cout << "\nВведите количество строк=";
	cin >> n;
	cout << "\nВведите количество столбцов=";
	cin >> m;
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			x[i][j] = rand() % 100;
			cout << setw(4) << x[i][j];
		}
		cout << endl;
	}
	cout << endl;
	cout << "\nэлементы с минимальным значением= ";
	imin = 0;
	for (i = 0; i < n; i++)
	{
		jmin = 0;
		for (j = 0; j < m; j++)
		{
			if (x[i][j] < x[imin][jmin])
			{
				x[imin][jmin] = x[i][j];
				imin = i;
				jmin = j;
			}
		}
		min[j] = x[imin][jmin];
		cout << setw(1) << min[j];
		cout << setw(1) << "(" << imin << jmin << ")  ";
	}
	cout << endl;
	imax = 0;
	for (i = 0; i < n; i++)
	{
		jmax = 0;
		for (j = 0; j < m; j++)
		{
			if (min[j] > x[imax][jmax])
			{
				x[imax][jmax] = min[j];
				imax = imin;
				jmax = jmin;
			}
		}
	}
	cout << "\nэлемент с максимальным значением= " << x[imax][jmax] << "  индекс элемента " << imax << jmax << endl;
}
