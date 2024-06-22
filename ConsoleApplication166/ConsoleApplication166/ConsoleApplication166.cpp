#include <iostream>
#include <string>
using namespace std;

int main()
{
    setlocale(0, "");
    char st[100];
    int i = 0;
    cout << "введите строку: ";
    gets_s(st);
    while (st[i])
    {
        if (st[i] == ':') break;
        i++;
    }
    cout << "количество символов до знака : =" << i << "\n";
}