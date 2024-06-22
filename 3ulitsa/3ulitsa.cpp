#include <iostream>
using namespace std;

int main()
{
    setlocale(LC_ALL, "RU");
    int A, B, t;
    cout << "Введите номер дома с которого начинается путь ";
    cin >> A;
    cout << "Введите номер дома до которого надо идти ";
    cin >> B;
    t = abs((A + 1) / 2 - (B + 1) / 2);
    cout << "Время пути от дома А до дома Б равно ";
    cout << t;

    cout << "\n";
    int a, b, c;
    cout << "\nВведите скорость ветра, которую выдерживает крепление 1 ";
    cin >> a;
    cout << "Крепление 2 ";
    cin >> b;
    cout << "Крепление 3 ";
    cin >> c;
    cout << "Максимальная скорость ветра, которую выдержит щит ";
    if (a <= b <= c || c <= b <= a)
        cout << b;
    else if (b <= a <= c || c <= a <= b)
        cout << a;
    else cout << c;

    cout << "\n";
    int M, sq = 2, x = 1;
    cout << "\nВведите количество людей ";
    cin >> M;
    for (; sq*sq <= M; sq++) {
        if (M % (sq * sq) == 0)
            x = sq*sq;
    }
    cout << x;
}




