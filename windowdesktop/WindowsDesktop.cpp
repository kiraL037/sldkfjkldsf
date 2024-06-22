#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include <tchar.h>

//имя класса главного окна
static TCHAR WindowClass[] = _T("DesktopApp");

//строка которая появляется в title bar
static TCHAR Title[] = _T("Application TAKE2");

HINSTANCE hInst;

//объявляем функцию window-procedure
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

//главная функция WinMain
int WINAPI WinMain(_In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPSTR lpCmdLine, _In_ int nCmdShow
)
{
    //структура, содержащая сведения о окне в классе WinMain
    WNDCLASSEX wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);
    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProc;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(wcex.hInstance, IDI_APPLICATION);
    wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
    wcex.lpszMenuName = NULL;
    wcex.lpszClassName = WindowClass;
    wcex.hIconSm = LoadIcon(wcex.hInstance, IDI_APPLICATION);

    if (!RegisterClassEx(&wcex))
    {
        MessageBox(NULL,
            _T("Call to RegisterClassEx failed!"),
            _T("Windows Desktop Guided Tour"),
            NULL);

        return 1;
    }

    hInst = hInstance;

    //объяснение параметров CreateWindowEx:
    // WS_EX_OVERLAPPEDWINDOW : необязательный расширенный стиль окна
    // WindowClass: имя приложения
    // Title: текст в title bar
    // WS_OVERLAPPEDWINDOW: какой тип окна создать
    // CW_USEDEFAULT, CW_USEDEFAULT: начальные позиции по (x, y)
    // 500, 100: начальный размер по ширине, длине
    // NULL: родитель окна
    // NULL: отсутствие menu bar
    // hInstance: первый параметр WinMain
    // NULL: не используется в приложении
    HWND hWnd = CreateWindowEx(
        WS_EX_OVERLAPPEDWINDOW,
        WindowClass,
        Title,
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT, CW_USEDEFAULT,
        500, 100,
        NULL,
        NULL,
        hInstance,
        NULL
    );

    //функция возвращает hWnd дексриптор окна
    if (!hWnd)
    {
        MessageBox(NULL,
            _T("Call to CreateWindow failed!"),
            _T("Windows Desktop Guided Tour"),
            NULL);

        return 1;
    }

    // параметр ShowWindow сообщает Windows об созданном окне:
    // hWnd: возвращаемое значение CreateWindow
    // nCmdShow: четвертый параметр из WinMain
    ShowWindow(hWnd,
        nCmdShow);
    UpdateWindow(hWnd);

    // для обработки сообщений от Windows приложением
    //нужен цикл который отправляет полученное сообщение в WndProc:
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}

//функция WndProc обрабатывает сообщения через оператор switch
//HWND дескриптор окна
//UINT сообщение
//WPARAM и LPARAM доп сведения о сообщении, зависят от message
//WM_PAINT обновляет окно при отображении:
// вызываем метод BeginPaint и обрабатываем расположение текста
// вызываем метод EndPaint
//WM_DESTROY обрабатывает сообщение о закрытии окна
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    PAINTSTRUCT ps;
    HDC hdc;
    TCHAR greeting[] = _T("Hello! Somebody once told me the world is gonna roll me, I ain't the sharpest tool in the shed.");

    switch (message)
    {
    case WM_PAINT:
        hdc = BeginPaint(hWnd, &ps);
        TextOut(hdc, 5, 5, greeting, _tcslen(greeting));
        EndPaint(hWnd, &ps);
        break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
        break;
    }

    return 0;
}