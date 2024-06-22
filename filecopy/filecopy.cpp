#include <iostream> 
#include <string> 
#include <fstream> 
#include <algorithm> 
#include <sys/stat.h>  
#include <chrono> 
#include <Windows.h> 

using namespace std;



int main()
{
	setlocale(LC_ALL, "RU");

	ofstream file;
	file.open("file1.txt");
	file.close();
	file.open("file2.txt");
	file.close();
	file.open("file3.txt");
	file.close();

	string str, name, type = ".txt", read;
	cout << "Введите данные файла: ";
	cin >> str;
	cout << "\nВведите название файла(file1; file2; file3;): ";
	cin >> name;

	file.open(name + type);
	file << str;
	file.close();

	ifstream file1(name + type);
	if (file1.is_open())
	{
		while (getline(file1, read))
		{
		}
	}
	sort(read.begin(), read.end());
	cout << "Отсортированные данные файла: " << read;

	struct stat fi;
	FILETIME LastWriteTime = {};
	SYSTEMTIME T;
	WIN32_FILE_ATTRIBUTE_DATA Data;


	if (name == "file1")
	{
		stat("file1.txt", &fi);
		if (GetFileAttributesExA("file1.txt", GetFileExInfoStandard, &Data))
		{
			LastWriteTime = Data.ftLastWriteTime;
		}
		FileTimeToSystemTime(&LastWriteTime, &T);
		cout << "\nРазмер файла: " << fi.st_size;
		cout << "\nПоследнее изменение в файле: " << T.wYear << ":" << T.wMonth << ":" << T.wDay << ":" << T.wHour + 3 << ":" << T.wMinute << ":" << T.wSecond;
		system("file1.txt");

	}
	else if (name == "file2")
	{
		stat("file2.txt", &fi);
		if (GetFileAttributesExA("file2.txt", GetFileExInfoStandard, &Data))
		{
			LastWriteTime = Data.ftLastWriteTime;
		}
		FileTimeToSystemTime(&LastWriteTime, &T);
		cout << "\nРазмер файла: " << fi.st_size;
		cout << "\nПоследнее изменение в файле: " << T.wYear << ":" << T.wMonth << ":" << T.wDay << ":" << T.wHour + 3 << ":" << T.wMinute << ":" << T.wSecond;
		system("file2.txt");
	}
	else if (name == "file3.txt")
	{
		stat("file3.txt", &fi);
		if (GetFileAttributesExA("file3.txt", GetFileExInfoStandard, &Data))
		{
			LastWriteTime = Data.ftLastWriteTime;
		}
		FileTimeToSystemTime(&LastWriteTime, &T);
		cout << "\nРазмер файла: " << fi.st_size;
		cout << "\nПоследнее изменение в файле: " << T.wYear << ":" << T.wMonth << ":" << T.wDay << ":" << T.wHour + 3 << ":" << T.wMinute << ":" << T.wSecond;
		system("file3.txt");
	}




	file1.close();
}