using WpfAppQLCF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using System.Windows.Media.Media3D;
using System.Drawing;
using Microsoft.Win32;
using System.Net;
using System.Xml.Linq;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for UserControlNhanVien.xaml
    /// </summary>
    public partial class UserControlNhanVien : UserControl
    {
        NhanVien hd = new NhanVien();
        public UserControlNhanVien()
        {
            InitializeComponent();
            dg.ItemsSource = XuLyNhanVien.getDSNV();
        }

        private void btnThemNV_Click(object sender, RoutedEventArgs e)
        {

           
            string username = txtTk.Text;
            string pass = txtPass.Text;
            string name = txtTen.Text;
            string phone = txtphone.Text;
            string email = txtemail.Text;
            string address = txtaddress.Text;
            
           
            if (username == "")
            {
                MessageBox.Show("Chưa nhập mã");
                return;
            }
            else if (name == "")
            {
                MessageBox.Show("Chưa nhập tên ");
                return;
            }

            else if (txtLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập Lương");
                return;
            }


            else if (phone == "")
            {
                MessageBox.Show("Chưa chọn  SDT");
                return;
            }
            else if (email == "")
            {
                MessageBox.Show("Chưa Email");
                return;
            }
            else if (address == "")
            {
                MessageBox.Show("Chưa Địa Chỉ");
                return;
            }
            else if (hd.Anh == null)
            {
                MessageBox.Show("Chưa chọn Anh");
                return;
            }
            double Luong = double.Parse(txtLuong.Text);
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn Tạo Nhân viên có Mã '" + username + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                hd.Username = username;
                hd.Fullname = name;
                hd.Luong = Luong;
                hd.Phone = phone;
                hd.DiaChi = address;
                hd.Email = email;
                hd.Password = pass;

                if (XuLyNhanVien.themNhanVien(hd) == false)
                {
                    MessageBox.Show("Thêm thất bại");
                }
                else
                {
                    MessageBox.Show("Thêm thành công");


                    txtTk.Text = "";
                    txtPass.Text = "";
                    txtTen.Text = "";
                    txtphone.Text = "";
                    txtemail.Text = "";
                    txtaddress.Text = "";
                    string resourceUri = "C:\\Users\\TRUONG\\Desktop\\TTTN\\Wpf\\Wpf\\icon\\picture.png";
                    Image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;
                    hd = new NhanVien();
                    dg.ItemsSource = XuLyNhanVien.getDSNV();
                }

            }
        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            FrameworkElement fe = e.DetailsElement;
          
            // CSanPhamView? ad = e.Row.Item as CSanPhamView;
            NhanVien ad = dg.SelectedItem as NhanVien;
           
            if (ad != null)
            {
                TextBox? txtMH = fe.FindName("txtMa") as TextBox;
                txtMH.Text =ad.Username;

                TextBox? txtTH = fe.FindName("txtTen") as TextBox;
                txtTH.Text = ad.Fullname;

                TextBox? txtGia = fe.FindName("txtluong") as TextBox;
                txtGia.Text = ad.Luong.ToString();

                TextBox? dphsd = fe.FindName("txtsdt") as TextBox;
                dphsd.Text =ad.Phone;

               
                TextBox? cmbLoaiSp = fe.FindName("txtpass") as TextBox;
                cmbLoaiSp.Text = ad.Password;

                Image? image = fe.FindName("imagectnv") as Image;

                if (ad.Anh == null) return;
                string resourceUri = "..//..//..//Image//NhanVien//" + ad.Anh;
                image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;

            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSua_Click_1(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            FrameworkElement? fe = btn.Parent as FrameworkElement;
            if (fe == null) return;
            NhanVien hh = (NhanVien)dg.SelectedItem;


            TextBox? txtMH = fe.FindName("txtpass") as TextBox;


            TextBox? txtTH = fe.FindName("txtTen") as TextBox;


            TextBox? txtGia = fe.FindName("txtluong") as TextBox;


            TextBox? dphsd = fe.FindName("txtsdt") as TextBox;



            TextBox? cmbLoaiSp = fe.FindName("txtpass") as TextBox;

            Image? image = fe.FindName("imagectnv") as Image;

            if (hh.Anh == null) return;
            string resourceUri = "..//..//..//Image//NhanVien//" + hh.Anh;
            image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;



           
            hh.Fullname = txtTH.Text;
            hh.Luong =double.Parse(txtGia.Text);
            hh.Phone = dphsd.Text;
            hh.Password = txtMH.Text;
            

            if (XuLyNhanVien.suaNhanVien(hh))
            {
                MessageBox.Show("sửa thành công");
                dg.ItemsSource = XuLyNhanVien.getDSNV();
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Image.Source = new BitmapImage(fileUri);

                String sourcefile = openFileDialog.FileName;

                string resourceUri = "..//..//..//Image//NhanVien//" + System.IO.Path.GetFileName(openFileDialog.FileName);
                System.IO.File.Copy(sourcefile, resourceUri, true);
                hd.Anh = System.IO.Path.GetFileName(openFileDialog.FileName);
            }
        }
    }
}
