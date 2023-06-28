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

namespace WPF_CF
{
    /// <summary>
    /// Interaction logic for UserControlProduct.xaml
    /// </summary>
    public partial class UserControlProduct : UserControl
    {

        string ma = "";
        private Sanpham hd = new Sanpham();
        public UserControlProduct()
        {
            InitializeComponent();
            List<Loai> dsloai = XuLyNhanVien.getDSLOAI();
            cmbloai.ItemsSource = dsloai;
            List<Sanpham> dssp = XuLyNhanVien.getSP();
            cmbsize.ItemsSource = XuLyNhanVien.getDSSize();
            dg.ItemsSource = CSanPhamView.getDSHocvienView(dssp, dsloai);
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedValue == null) return;
            string maso = dg.SelectedValue.ToString();
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn xóa Sản Phẩm có Mã '" + maso + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                string id = dg.SelectedValue.ToString();
                if (XuLyNhanVien.xoaSanPham(id))
                {
                    MessageBox.Show("xóa thành công ");
                    hienThi();
                }
            }


        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            FrameworkElement fe = e.DetailsElement;
            CSanPhamView? ad = e.Row.Item as CSanPhamView;
            Sanpham a = XuLyNhanVien.getSPID(ad.Sanphamid);
            if (a != null)
            {
                TextBox? txtMH = fe.FindName("txtMahang") as TextBox;
                txtMH.Text = a.Sanphamid;

                TextBox? txtTH = fe.FindName("txtTenhang") as TextBox;
                txtTH.Text = a.TenSp;

                TextBox? txtGia = fe.FindName("txtGia") as TextBox;
                txtGia.Text = a.Gia.ToString();

                DatePicker? dphsd = fe.FindName("dpHsd") as DatePicker;
                dphsd.SelectedDate = a.HanSuDung;

                ComboBox? cmbLoaiSp = fe.FindName("cmbloaiSp") as ComboBox;
                cmbLoaiSp.ItemsSource = XuLyNhanVien.getDSLOAI();
                cmbLoaiSp.SelectedValue = a.IdLoai;

                Image? image = fe.FindName("Imagect") as Image;
                string resourceUri = "..//..//..//Image//SanPham//"+a.Anh;
                image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;

            }
        }

        private void btnThemSP_Click(object sender, RoutedEventArgs e)
        {
            

            string name = txtTen.Text;
            string ma = txtMa.Text;
            if (ma == "")
            {
                MessageBox.Show("Chưa nhập mã");
                return;
            }
            else if (name == "")
            {
                MessageBox.Show("Chưa nhập tên sản phẩm");
                return;
            }
            
           else if(txtGia.Text == "")
           {
                MessageBox.Show("Chưa nhập giá");
                return;
           }
            else if (hd.Anh == null)
            {
                MessageBox.Show("Chưa chọn  ảnh");
                return;
            }
            else if (dpNgaylaphd.SelectedDate==null)
            {
                MessageBox.Show("Chưa chọn  HSD");
                return;
            }
            else if(cmbloai.SelectedValue==null|| hd.CtSpSizes.Count()==0)
            {
                MessageBox.Show("Chưa chọn loại");
                return;
            }
           
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn Tạo Sản Phẩm có Mã '" + ma + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                hd.Sanphamid = txtMa.Text;
                hd.TenSp = txtTen.Text;
                hd.Gia = float.Parse(txtGia.Text);
                hd.HanSuDung = dpNgaylaphd.SelectedDate;
                hd.IdLoai = (int?)cmbloai.SelectedValue;
                foreach (CtSpSize ct in hd.CtSpSizes)
                {
                    ct.IdSp = hd.Sanphamid;
                    ct.IdSizeNavigation = null;
                }

                if (XuLyNhanVien.themSanPham(hd) == false)
                {
                    MessageBox.Show("Thêm thất bại");
                }
                else
                {
                    MessageBox.Show("Thêm thành công");

                    hienThi();
                    txtGia.Text = "";
                    txtTen.Text = "";
                    txtMa.Text = "";
                    dgCTSIZE.ItemsSource = null;
                    dpNgaylaphd.SelectedDate = null;
                    cmbloai.SelectedValuePath = null;
                    cmbloai.SelectedItem= null;
                    string resourceUri = "C:\\Users\\TRUONG\\Desktop\\TTTN\\Wpf\\Wpf\\icon\\picture.png";
                    Image.Source= new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;
                   
                }
                hd = new Sanpham();
            }
           
        }
        private void hienThi()
        {
            List<Sanpham> ds = XuLyNhanVien.getSP();
            if (ds == null)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            else
            {
                List<Loai> dsloai = XuLyNhanVien.getDSLOAI();
                List<Sanpham> dssp = XuLyNhanVien.getSP();

                dg.ItemsSource = CSanPhamView.getDSHocvienView(dssp, dsloai);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            //Sanpham a = XuLyNhanVien.getSPID(ma);
            //if (a != null)
            //{
            //    a.TenSp = txtTen.Text;
            //    a.Gia = float.Parse(txtGia.Text);
            //    var ss = cmbloai.SelectedValue;

            //    a.IdLoai =int.Parse(cmbloai.SelectedValue.ToString());
            //    a.HanSuDung = dpNgaylaphd.SelectedDate;
            //    XuLyNhanVien.suaSanPham(a);
            //    ma = "";
            //    hienThi();
            //}
            //else
            //{
            //    MessageBox.Show("CHUA CHON SAN PHAM");
            //}
            Button? btn = sender as Button;
            FrameworkElement? fe = btn.Parent as FrameworkElement;
            if (fe == null) return;
            TextBox? txtMH = fe.FindName("txtMahang") as TextBox;
            Sanpham hh = XuLyNhanVien.getSPID(txtMH.Text);

            TextBox? txtTH = fe.FindName("txtTenhang") as TextBox;
            Image? image = fe.FindName("Imagect") as Image;

            TextBox? txtGia = fe.FindName("txtGia") as TextBox;
            DatePicker? dpHsd = fe.FindName("dpHsd") as DatePicker;
            ComboBox? cmbLoaiSp = fe.FindName("cmbloaiSp") as ComboBox;

            string resourceUri = "..//..//..//Image//SanPham//"+hh.Anh;
            image.Source = new ImageSourceConverter().ConvertFromString(resourceUri) as ImageSource;
            hh.TenSp = txtTH.Text;
            hh.Gia = float.Parse(txtGia.Text);
            hh.HanSuDung = dpHsd.SelectedDate;

            hh.IdLoai = (int?)(cmbLoaiSp.SelectedValue);

            if (XuLyNhanVien.suaSanPham(hh))
            {
                MessageBox.Show("sửa thành công");
                hienThi();
            }
            else
            {
                MessageBox.Show("sửa thất bại");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmbsize.SelectedValue == null) return;
            int mahang = (int)cmbsize.SelectedValue;
            WpfAppQLCF.Model.Size hh = XuLyNhanVien.getSizeID(mahang);
            if (hh == null)
            {
                MessageBox.Show("ERORR !");

            }
            CtSpSize ct = null;
            foreach (CtSpSize a in hd.CtSpSizes.Where(t => t.Ctsizeid == mahang))
            {
                ct = a;
                break;
            }
            if (ct == null)
            {
                ct = new CtSpSize();
                ct.IdSize = mahang;
                ct.IdSizeNavigation = hh;

                hd.CtSpSizes.Add(ct);
            }

            dgCTSIZE.ItemsSource = hd.CtSpSizes.Select(x => new
            {
                Id = x.IdSize,
                Name = x.IdSizeNavigation.Name,
            }).ToList();

        }

        private void btnXoa_Click_1(object sender, RoutedEventArgs e)
        {
            int ma = (int)dgCTSIZE.SelectedValue;

            foreach(CtSpSize a  in hd.CtSpSizes)
            {
                if (a.IdSize == ma)
                    hd.CtSpSizes.Remove(a);

            }
            dgCTSIZE.ItemsSource = hd.CtSpSizes.Select(x => new
            {
                Id = x.IdSize,
                Name = x.IdSizeNavigation.Name,
            }).ToList();
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog()==true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Image.Source = new BitmapImage(fileUri);

                String sourcefile = openFileDialog.FileName;

                string resourceUri = "..//..//..//Image//SanPham//" + System.IO.Path.GetFileName(openFileDialog.FileName);
                System.IO.File.Copy(sourcefile, resourceUri, true);
                hd.Anh = System.IO.Path.GetFileName(openFileDialog.FileName);
            }
        }
    }
}
