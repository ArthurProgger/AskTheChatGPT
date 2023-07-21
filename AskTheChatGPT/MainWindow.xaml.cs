using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AskTheChatGPT
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => SetWindowDisplayAffinity(Process.GetCurrentProcess().MainWindowHandle, 1);
    }
}