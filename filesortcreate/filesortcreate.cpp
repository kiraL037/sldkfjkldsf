#include <fstream>
#include <filesystem>
#include <iostream>
#include <cstdlib>
#include <cstdio>
#include <iterator>
#include <vector>
#include <algorithm>
namespace fs = std::filesystem;

//создаем класс для сортировки начала и конца текста в файле по алфавиту
//используем iterator для перебора слов в тексте
//
bool SortAlphabetically(const std::string& a, const std::string& b) {
    std::string::const_iterator i, j;
    for (i = a.begin(), j = b.begin(); i != a.end() && j != b.end(); ++i, ++j) {
        if (tolower(*i) < tolower(*j))
            return true;
        else if (tolower(*i) > tolower(*j))
            return false;
    }
    return (a.length() < b.length());
}
int main() 
{
    std::ifstream ifs("data.txt");
    std::list<std::string> strings;
    std::string buf;
    
    //цикл while работает пока читается ifs и переносит текст из ifs в buf 
    //вложенный цикл работает если видит знаки препинания то стирает их
    while (ifs >> buf) {
        while (ispunct(*(buf.end() - 1)))
            buf.erase(buf.end() - 1);
        strings.push_back(buf);
    }

    //unique удаляет одинаковые слова
    //sort сортирует по классу SortAlphabetically
    strings.unique();
    strings.sort(SortAlphabetically);

    //копируем от начала до конца текст и выводим его в консоль через пробел
    std::copy(strings.begin(), strings.end(), std::ostream_iterator<std::string>(std::cout, " ")); 
}

