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
    /// Interaction logic for UserControlLoai.xaml
    /// </summary>
    public partial class UserControlLoai : UserControl
    {
        Loai loaiDaChon = null;
        public UserControlLoai()
        {
            InitializeComponent();
            hienThi();
        }

        

        

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedValue == null) return;
            string maso = dg.SelectedValue.ToString();
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn xóa Loại có Mã '" + maso + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                int id = (int)dg.SelectedValue;
                if (XuLyNhanVien.xoaLoai(id))
                {
                    MessageBox.Show("xóa thành công ");
                    hienThi();
                }
                else
                {
                    MessageBox.Show("xóa thất bại vì loại này đã có sản phẩm"); 
                }
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Loai loai = dg.SelectedItem as Loai;
                loaiDaChon = loai;
                

            }
            catch (Exception ex)
            {

            }

        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            FrameworkElement fe = e.DetailsElement;
            Loai? a = e.Row.Item as Loai;

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
            Loai loai = new Loai();
            loai.Name = txtTen.Text;
            if (XuLyNhanVien.themLoai(loai) == false)
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
            List<Loai> ds = XuLyNhanVien.getDSLOAI();
            if (ds == null)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            else
            {
                dg.ItemsSource = XuLyNhanVien.getDSLOAI();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (loaiDaChon != null)
            {
                Button? btn = sender as Button;
                FrameworkElement? fe = btn.Parent as FrameworkElement;
               
                TextBox? txtTH = fe.FindName("txtTenLoai") as TextBox;


                loaiDaChon.Name = txtTH.Text; 
               
                if (XuLyNhanVien.suaLoai(loaiDaChon))
                {
                    MessageBox.Show("sửa thành công");
                    hienThi();
                    loaiDaChon = null;
                }
                else
                {
                    MessageBox.Show("sửa thất bại");
                    loaiDaChon = null;
                }
            }
        }
    }
}
