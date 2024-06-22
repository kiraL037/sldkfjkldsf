#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include <tchar.h>

//��� ������ �������� ����
static TCHAR WindowClass[] = _T("DesktopApp");

//������ ������� ���������� � title bar
static TCHAR Title[] = _T("Application TAKE2");

HINSTANCE hInst;

//��������� ������� window-procedure
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

//������� ������� WinMain
int WINAPI WinMain(_In_ HINSTANCE hInstance,
    _In_opt_ HINSTANCE hPrevInstance,
    _In_ LPSTR lpCmdLine, _In_ int nCmdShow
)
{
    //���������, ���������� �������� � ���� � ������ WinMain
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

    //���������� ���������� CreateWindowEx:
    // WS_EX_OVERLAPPEDWINDOW : �������������� ����������� ����� ����
    // WindowClass: ��� ����������
    // Title: ����� � title bar
    // WS_OVERLAPPEDWINDOW: ����� ��� ���� �������
    // CW_USEDEFAULT, CW_USEDEFAULT: ��������� ������� �� (x, y)
    // 500, 100: ��������� ������ �� ������, �����
    // NULL: �������� ����
    // NULL: ���������� menu bar
    // hInstance: ������ �������� WinMain
    // NULL: �� ������������ � ����������
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

    //������� ���������� hWnd ���������� ����
    if (!hWnd)
    {
        MessageBox(NULL,
            _T("Call to CreateWindow failed!"),
            _T("Windows Desktop Guided Tour"),
            NULL);

        return 1;
    }

    // �������� ShowWindow �������� Windows �� ��������� ����:
    // hWnd: ������������ �������� CreateWindow
    // nCmdShow: ��������� �������� �� WinMain
    ShowWindow(hWnd,
        nCmdShow);
    UpdateWindow(hWnd);

    // ��� ��������� ��������� �� Windows �����������
    //����� ���� ������� ���������� ���������� ��������� � WndProc:
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0))
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return (int)msg.wParam;
}

//������� WndProc ������������ ��������� ����� �������� switch
//HWND ���������� ����
//UINT ���������
//WPARAM � LPARAM ��� �������� � ���������, ������� �� message
//WM_PAINT ��������� ���� ��� �����������:
// �������� ����� BeginPaint � ������������ ������������ ������
// �������� ����� EndPaint
//WM_DESTROY ������������ ��������� � �������� ����
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