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
    /// Interaction logic for UserControlKhachHang.xaml
    /// </summary>
    public partial class UserControlKhachHang : UserControl
    {
        public UserControlKhachHang()
        {
            InitializeComponent();
            dg.ItemsSource = XuLyNhanVien.getDsKh();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            FrameworkElement? fe = btn.Parent as FrameworkElement;
            if (fe == null) return;
            Khachhang hh = (Khachhang)dg.SelectedItem ;

            TextBox? txtMH = fe.FindName("txtten") as TextBox;
            
            TextBox? txtTH = fe.FindName("txtdiachi") as TextBox;
           
            TextBox? txtGia = fe.FindName("txtemail") as TextBox;
            TextBox? dpHsd = fe.FindName("sdt") as TextBox;



            hh.Fullname = txtMH.Text;
            hh.Address = txtTH.Text;
            hh.Email = txtGia.Text;
            hh.Phone = dpHsd.Text;

            if (XuLyNhanVien.suaKhachHang(hh))
            {
                MessageBox.Show("sửa thành công");
                dg.ItemsSource = XuLyNhanVien.getDsKh();
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }

        }

       

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            string tk = txtTk.Text;
            Khachhang kh = XuLyNhanVien.getKhID(tk);
            if (kh == null)
            {
                Khachhang khNew = new Khachhang();
                khNew.Username= tk;
                khNew.Password= txtPass.Text;
                khNew.Fullname=txtTen.Text;
                khNew.Phone= txtphone.Text;
                khNew.Email= txtemail.Text;
                khNew.Address= txtaddress.Text;

                if (XuLyNhanVien.themKh(khNew))
                {
                    MessageBox.Show("ĐĂNG KÝ THÀNH CÔNG");
                }
                dg.ItemsSource = XuLyNhanVien.getDsKh();
            }
        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            FrameworkElement fe = e.DetailsElement;
           // CSanPhamView? ad = e.Row.Item as CSanPhamView;
            Khachhang ad = (Khachhang)dg.SelectedItem;
            ///Sanpham a = XuLyNhanVien.getSPID(ad.Sanphamid);
            if (ad != null)
            {
                TextBox? txtMH = fe.FindName("txtten") as TextBox;
                txtMH.Text = ad.Fullname;

                TextBox? txtTH = fe.FindName("txtdiachi") as TextBox;
                txtTH.Text = ad.Address;

                TextBox? txtGia = fe.FindName("txtemail") as TextBox;
                txtGia.Text =ad.Email;

                TextBox? dphsd = fe.FindName("sdt") as TextBox;
                dphsd.Text = ad.Phone;

                

            }
        }
    }
}
