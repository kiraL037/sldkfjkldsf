#include <iostream>
#include <ctime>
#include <iomanip>
using namespace std;
int main()
{
    setlocale(0, "");
    int i, n, j, m, h = 1, k = 1, l = 1;
    float min, max;
    cout << "Введите количество строк массива=";
    cin >> n;
    cout << "Введите количество столбцов массива=";
    cin >> m;
    float** x = new float* [n];
    for (i = 0; i < n; i++)
    {
        x[i] = new float[m];
        for (j = 0; j < m; j++)
        {
            x[i][j] = rand() % 15;
            cout << setw(4) << x[i][j];
        }
        cout << endl;
    }
    for (i = 0; i < n; i++)
    {
        min = x[1][j];
        for (j = 0; j < m; j++)
        {
            if (x[i][j] < min)
                min = x[1][j];
        }
        cout << "\nМинимальный элемент среди всех элементов в строке=";
        cout << setw(4) << min;
    }
    for (i = 0; i < n; i++)
    {
        max = x[i][1];
        for (j = 0; j < m; j++)
        {
            if (min > max) 
            { 
               max = x[i][j]; 
               k = j; 
               l = i;
               h = l;
            }
        }
    }
    cout << "Максимальный элемент среди минимальных в строке=" << max << "\n";
    cout << "Индексы искомого элемента равны " << h << " " << k << "\n";
    return 0;
}
