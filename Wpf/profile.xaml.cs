using Microsoft.Win32;
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
using WpfAppQLCF.Model;


namespace Wpf
{
    /// <summary>
    /// Interaction logic for profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        NhanVien hd = XuLyNhanVien.NhanVienDaLogin;
        public profile()
        {
            InitializeComponent();
            hienthi();
        }
        public void hienthi()
        {
            txtMa.Text = hd.Username;
            txtpass.Text = hd.Password;
            txtTen.Text = hd.Fullname;
            txtluong.Text = hd.Luong.ToString();
            txtsdt.Text = hd.Phone;
            if (hd.Anh == null) return;
            string resourceUri = "..//..//..//Image//NhanVien//" + hd.Anh;
            imagectnv.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imagectnv.Source = new BitmapImage(fileUri);

                String sourcefile = openFileDialog.FileName;

                string resourceUri = "..//..//..//Image//NhanVien//" + System.IO.Path.GetFileName(openFileDialog.FileName);
                System.IO.File.Copy(sourcefile, resourceUri, true);
                hd.Anh = System.IO.Path.GetFileName(openFileDialog.FileName);
            }
        }

        private void btnSua_Click_1(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            FrameworkElement? fe = btn.Parent as FrameworkElement;
            if (fe == null) return;
           


            TextBox? txtMH = fe.FindName("txtpass") as TextBox;


            TextBox? txtTH = fe.FindName("txtTen") as TextBox;


            TextBox? txtGia = fe.FindName("txtluong") as TextBox;


            TextBox? dphsd = fe.FindName("txtsdt") as TextBox;



            TextBox? cmbLoaiSp = fe.FindName("txtpass") as TextBox;

            Image? image = fe.FindName("imagectnv") as Image;

            if (hd.Anh == null) return;
            string resourceUri = "..//..//..//Image//NhanVien//" + hd.Anh;
            image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;




            hd.Fullname = txtTH.Text;
            hd.Luong = double.Parse(txtGia.Text);
            hd.Phone = dphsd.Text;
            hd.Password = txtMH.Text;


            if (XuLyNhanVien.suaNhanVien(hd))
            {
                MessageBox.Show("sửa thành công");
                hd = XuLyNhanVien.getNvId(hd.Username);
                hienthi();
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }
        }
    }
}
