using System.Windows;
using System.Windows.Controls;

namespace MediaApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        // начало воспроизведения
        void Play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }
        // пауза
        void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (media.CanPause)
                media.Pause();
        }
        // остановка
        void Stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }
        // если открытие файла завершилось с ошибкой
        void Media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            headerBlock.Text = "Ошибка открытия файла";
        }
        // открытие файла
        void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            headerBlock.Text = media.Source.LocalPath;
        }
        // окончание воспроизведения
        void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            headerBlock.Text = "Воспроизведение завершено";
        }
    }
}

