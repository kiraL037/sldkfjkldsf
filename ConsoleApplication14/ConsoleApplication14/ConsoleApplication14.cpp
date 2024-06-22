#include <iostream>
#include <ctime>
using namespace std;
void main()
{
	setlocale(0, "");
	srand(time(0));
	int n, i, j, k=0;
	cout << "Введите количество покупателей=";
	cin >> n;
	int* t = new int[n];
	int* C = new int[n];
	cout << "\nВремя обслуживания каждого клиента:";
	for (i = 0; i < n; i++)
	{
		t[i] = rand() % 10 + 2;
		cout << "  " << t[i];
	}
	cout << "\nВведите номер покупателя в очереди=";
	cin >> j;
	j--;
	for (i = 0; i < j; i++)
		k += t[i];
	C[i] = k;
	if (C[i] == 0)
		cout << "\nПокупатель не стоял в очереди";
	cout << "\nВремя "<<j+1<<" покупателя в очереди " << k << " минут" << endl;
	delete[] t;
	delete[] C;
}