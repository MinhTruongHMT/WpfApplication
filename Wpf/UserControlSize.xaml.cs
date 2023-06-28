using WpfAppQLCF.Model;
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


namespace WPF_CF
{
    /// <summary>
    /// Interaction logic for UserControlSize.xaml
    /// </summary>
    public partial class UserControlSize : UserControl
    {
        WpfAppQLCF.Model.Size sizeDaChon = null;
        public UserControlSize()
        {
            InitializeComponent();
            hienThi();
        }





        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedValue == null) return;
            string maso = dg.SelectedValue.ToString();
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn xóa Size có Mã '" + maso + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                int id = (int)dg.SelectedValue;
                if (XuLyNhanVien.xoaSize(id))
                {
                    MessageBox.Show("xóa thành công ");
                    hienThi();
                }
                else
                {
                    MessageBox.Show("xóa thất bại vì Size này đã có sản phẩm");
                }
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                 WpfAppQLCF.Model.Size size = dg.SelectedItem as WpfAppQLCF.Model.Size;
                sizeDaChon = size;


            }
            catch (Exception ex)
            {

            }

        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            FrameworkElement fe = e.DetailsElement;
            WpfAppQLCF.Model.Size? a = e.Row.Item as WpfAppQLCF.Model.Size;

            if (a != null)
            {
                TextBox? txtMH = fe.FindName("txtMaLoai") as TextBox;
                txtMH.Text = a.Id.ToString();
                TextBox? txtTH = fe.FindName("txtTenLoai") as TextBox;
                txtTH.Text = a.Name;
            }
        }

        private void btnThemLoai_Click(object sender, RoutedEventArgs e)
        {

            if (txtTen.Text == "") return;
            WpfAppQLCF.Model.Size loai = new WpfAppQLCF.Model.Size();
            loai.Name = txtTen.Text;
            if (XuLyNhanVien.themSize(loai) == false)
            {
                MessageBox.Show("Thêm thất bại");
            }
            else
            {
                MessageBox.Show("Thêm thành công");
                hienThi();
            }
        }
        private void hienThi()
        {
            List<WpfAppQLCF.Model.Size> ds = XuLyNhanVien.getDSSize();
            if (ds == null)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            else
            {
                dg.ItemsSource = XuLyNhanVien.getDSSize();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (sizeDaChon != null)
            {
                Button? btn = sender as Button;
                FrameworkElement? fe = btn.Parent as FrameworkElement;

                TextBox? txtTH = fe.FindName("txtTenLoai") as TextBox;


                sizeDaChon.Name = txtTH.Text;

                if (XuLyNhanVien.suaSize(sizeDaChon))
                {
                    MessageBox.Show("sửa thành công");
                    hienThi();
                    sizeDaChon = null;
                }
                else
                {
                    MessageBox.Show("sửa thất bại");
                    sizeDaChon = null;
                }
            }
        }
    }
}

