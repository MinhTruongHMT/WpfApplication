using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf;
using WPF_CF;
using WpfAppQLCF.Model;

namespace WpfAppQLCF
{
    /// <summary>
    /// Interaction logic for NhanVienApplication.xaml
    /// </summary>
    public partial class NhanVienApplication : Window
    {
        public NhanVienApplication()
        {
            InitializeComponent();
            name.Header = XuLyNhanVien.NhanVienDaLogin.toString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
            XuLyNhanVien.NhanVienDaLogin = null;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cc.Content = new UserControlProduct();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cc.Content = new UserControlDonHang();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cc.Content = new UserControlKhachHang();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
            XuLyNhanVien.NhanVienDaLogin = null;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new UserControlLoai();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            cc.Content = new UserControlSize();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            profile a = new profile();
            a.Show();
        }
    }
}
