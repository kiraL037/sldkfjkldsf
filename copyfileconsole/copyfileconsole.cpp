#include <fstream>
#include <filesystem>
#include <iostream>
#include <cstdlib>
namespace fs = std::filesystem;

int main()
{
    std::string text;    //переменная будет хранить введенные в консоль данные
    fs::create_directories("thunderous/god's_menu/surfin'");    //создаем каталог

    std::cout << "Type some text (type a dot and press enter to finish):\n";
    std::ofstream ofile("thunderous/skz.txt");
    do {
        text = std::cin.get();
        ofile << text;
    } while (text != ".");  //цикл будет работать пока не будет введена точка и нажата кнопка enter
    ofile.close();

    const auto COPY = fs::copy_options::overwrite_existing | fs::copy_options::recursive | fs::copy_options::directories_only;
    fs::copy("thunderous", "thunderousTAKE2", COPY);    //копируем каталог 
    fs::copy_file("thunderous/skz.txt", "thunderousTAKE2/skzTAKE2.txt", COPY);  //копируем текстовый файл 
}
