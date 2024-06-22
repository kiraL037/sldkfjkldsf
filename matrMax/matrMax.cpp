#include <iostream>
using namespace std;

int main()
{
	int a;
	setlocale(LC_ALL, "ru");
	cout << "Введите число ";
	cin >> a;
	int** arr = new int* [a];
	for (int i = 0; i < a; i++)
	{
		arr[i] = new int[a];
		for (int j = 0; j < a; j++)
			arr[i][j]= "*"[rand%1];
			cout << arr[i][j];
	}
	for (int i = 0; i < a; i++) {
		for (int j = 0; j < a; j++) {
			if (j = a - i + 1 || j == i)
				cout << "*";
			else cout << "_";
		}
		cout << "\n";
	}
	system("pause");
}
//[i, i], побочной a[i, n - i + 1]
//B[i, j] = max(A[i, j], B[i - 1, j - 1], B[i, j - 1], B[i + 1, j - 1]).
//cout << "RAND_MAX = " << RAND_MAX << endl; 
//cout << "random number = " << rand() << endl;
//for (int i = a; i >= 0; i--) {
//    for (int j = i; j < a; j++) {
//        if (i == 0 || i == j || j == a - 1) {
//            System.out.print("*");
//        }
//        else if (j != a - 1)
//            System.out.print(" ");
//    }
//    System.out.println();
//}
//System.out.println();
//for (int i = 1; i <= a / 2 + 1; ++i) {
//    for (int j = 1; j <= a / 2 + 1 - i; ++j) {
//        System.out.print(" ");
//    }
//    for (int k = 1; k <= i * 2 - 1; ++k) {
//        System.out.print("*");
//    }
//    System.out.println();
//}
//System.out.println();
//for (int i = -a / 2; i <= a / 2; i++) {
//    for (int j = -a / 2; j <= a / 2; j++) {
//        if (Math.abs(i) + Math.abs(j) == a / 2)
//            System.out.print("*");
//        else System.out.print(" ");
//    }
//    System.out.println();
//}
//   }
//}

