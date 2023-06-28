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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppQLCF.Model;

namespace WpfAppQLCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String userId = txtID.Text;
            String pass = txtPass.Password;
            
            if (XuLyNhanVien.loGin(userId, pass)!=null)
            {
                if (XuLyNhanVien.NhanVienDaLogin.Role == "ADMIN")
                {
                    AdminAplication a= new AdminAplication();
                    txtPass.Password = "";
                    this.Hide();
                    a.ShowDialog();
                }
                else if(XuLyNhanVien.NhanVienDaLogin.Role == "Employee") {
                    NhanVienApplication a = new NhanVienApplication();
                    txtPass.Password = "";
                    this.Hide();
                    a.ShowDialog();
                }
                else
                {
                    MessageBox.Show("SAI THÔNG TIN HOẶC MẬT KHẨU HOẶC TK KHÔNG TỒN TẠI");
                }
            }
            



        }
    }
}
