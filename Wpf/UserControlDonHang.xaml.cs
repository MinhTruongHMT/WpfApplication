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
using WpfAppQLCF.Model;
using System.Runtime.CompilerServices;
using System.Drawing;
using Wpf.Model;

namespace WPF_CF
{
    /// <summary>
    /// Interaction logic for UserControlDonHang.xaml
    /// </summary>
    public partial class UserControlDonHang : UserControl
    {
        private DonHang hd= new DonHang();
        public UserControlDonHang()
        {
            InitializeComponent();
        }

       

        private void dgHoadon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {

            FrameworkElement fe = e.DetailsElement;
            DonHang hd = e.Row.Item as DonHang;


            TextBox txtSHD = fe.FindName("txtSohd") as TextBox;
            TextBox txtTKH = fe.FindName("txtTenkh") as TextBox;
            TextBox txtTong = fe.FindName("txtThanhtienhd") as TextBox;
            TextBox txtNgay = fe.FindName("txtNgaylaphd") as TextBox;
            DataGrid dg = fe.FindName("dgCTHD") as DataGrid;
            TextBox txtThanhtienhd = fe.FindName("txtThanhtienhd") as TextBox;


            txtSHD.Text = hd.DonHangId;
            txtTKH.Text = XuLyNhanVien.getKhID(hd.KhachHangId).Fullname;
            txtTong.Text = hd.Ctdonhangs.Where(x => x.DonHangId == hd.DonHangId).Sum(t => t.SoLuong * t.Gia).ToString();
            txtNgay.Text = hd.NgayTaoDon.ToString();
            txtThanhtienhd.Text =hd.TongTien.ToString();
            List<Ctdonhang> dsct = XuLyNhanVien.getCTHD(hd.DonHangId);
            List<Sanpham> dssp = XuLyNhanVien.getSP();
                // (System.Collections.IEnumerable)XuLyNhanVien.getCTHD(hd.DonHangId);
            dg.ItemsSource = dsct.Join(dssp,x=>x.SanPhamId,y=>y.Sanphamid, (x, y) => new {
                Mahang = y.Sanphamid,
                Tenhang = y.TenSp,
                Dongia=x.Gia,
                Soluong=x.SoLuong,
                Thanhtien=x.SoLuong*x.Gia
            }).ToList();
        }

        private void btnChonhang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mahang = cmbSanPham.SelectedValue.ToString();
                Sanpham hh = XuLyNhanVien.getSPID(mahang);
                if (cmbSize.SelectedValue == null)
                {
                    MessageBox.Show("Chưa chọn Size !");
                    return;
                }
                WpfAppQLCF.Model.Size size = XuLyNhanVien.getSizeID((int)cmbSize.SelectedValue);

                if (hh == null || mahang == null || size == null)
                {
                    MessageBox.Show("ERORR !");
                    return;
                }
                Ctdonhang ct = null;

                if (size == null)
                    return;
                foreach (Ctdonhang a in hd.Ctdonhangs.Where(t => t.SanPhamId == mahang && t.Size == size.Name))
                {
                    ct = a;
                    break;
                }
                if (ct == null)
                {
                    ct = new Ctdonhang();
                    ct.SanPhamId = mahang;
                    ct.SanPham = hh;
                    ct.SoLuong = int.Parse(txtSoluong.Text);
                    ct.Gia = double.Parse(txtGia.Text);

                    ct.Size = size.Name;
                    hd.Ctdonhangs.Add(ct);
                }
                else
                {
                    ct.SoLuong += int.Parse(txtSoluong.Text);
                }
                //dgCTHD.ItemsSource = hd.Ctdonhangs.Select(x => new {
                //    Mahang = x.CtdonHangId,
                //    Tenhang = x.SanPham.TenSp,
                //    Dongia = x.SanPham.Gia,
                //    Soluong = x.SoLuong,
                //    Thanhtien = x.SoLuong * x.Gia,
                //    Size = x.Size
                //}).ToList();
                List<Sanpham> listSP = XuLyNhanVien.getSP();
                
                dgCTHD.ItemsSource = CTSanPhamDaChonView.getDSSpdaChonView(listSP,hd.Ctdonhangs.ToList());

                txtThanhtienhd.Text = hd.Ctdonhangs.Sum(x => x.SoLuong * x.Gia).ToString();

            }
            catch
            (Exception ex)
            {
                return;
            }
           
            
        }

        private void btnLaphd_Click(object sender, RoutedEventArgs e)
        {
            hd.DonHangId=txtMaHd.Text;
            hd.NgayTaoDon = (DateTime)dpNgaylaphd.SelectedDate;
            hd.KhachHangId = cmbKhachHang.SelectedValue.ToString();

            hd.NhanVienId = XuLyNhanVien.NhanVienDaLogin.Username;
            hd.TongTien =float.Parse(txtThanhtienhd.Text);
            hd.TinhTrang = "ĐANG XỮ LÝ";
            //hd.KhachHang = XuLyNhanVien.getKhID(cmbKhachHang.SelectedValue.ToString());
            //hd.NhanVien = XuLyNhanVien.NhanVienDaLogin;
           
            foreach (Ctdonhang ct in hd.Ctdonhangs)
            {
                ct.DonHangId = hd.DonHangId;
                ct.SanPham = null;
            }

            if (XuLyNhanVien.themHoaDon(hd))
            {
                MessageBox.Show("THÊM THÀNH CÔNG");
            }
           
            hd = new DonHang();

            dgCTHD.ItemsSource = null;
            hienThi();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
        }
        private void hienThi()
        {
            List<Sanpham> ds = XuLyNhanVien.getSP();
            List<DonHang> dshd = XuLyNhanVien.getDSDonHang();
            List<Khachhang> dskh = XuLyNhanVien.getDsKh();
           
            if (ds == null || dshd == null|| dskh ==null)
            {
                MessageBox.Show("Không có dữ liệu");
            }
            else
            {
                cmbSanPham.ItemsSource = ds;
                dgHoadon.ItemsSource = dshd;
                cmbKhachHang.ItemsSource = dskh;
                
            }
        }

        private void cmbKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(cmbKhachHang.SelectedValue.ToString());
        }

        private void cmbSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (cmbSanPham.SelectedValue!=null)
            {
                string ma = cmbSanPham.SelectedValue.ToString();
                Sanpham sp = XuLyNhanVien.getSPID(ma);

                List<CtSpSize> ds = XuLyNhanVien.getCTSize(sp.Sanphamid);
                List<WpfAppQLCF.Model.Size> dsSize = XuLyNhanVien.getDSSize();
                cmbSize.ItemsSource = ds.Join(dsSize, x => x.IdSize, y => y.Id, (x, y) => new {
                    Ctsizeid = x.IdSize,
                    Name = y.Name,

                }).ToList();
            }
           
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgHoadon.SelectedValue == null) return;
            string maso = dgHoadon.SelectedValue.ToString();
            MessageBoxResult ok = MessageBox.Show("Bạn có thật sự muốn xóa Đơn Hàng có Mã '" + maso + "' không?",
                "Cảnh báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ok == MessageBoxResult.OK)
            {
                string id = dgHoadon.SelectedValue.ToString();
                if (XuLyNhanVien.xoaDonHang(id))
                {
                    MessageBox.Show("xóa thành công ");
                    hienThi();
                }
            }
        }

        private void btnXoa_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
               // string maCTLOAI = dgCTHD.SelectedValue.ToString();
                CTSanPhamDaChonView A = (CTSanPhamDaChonView)dgCTHD.SelectedItem;
                //string mahang = cmbSanPham.SelectedValue.ToString();
                Sanpham hh = XuLyNhanVien.getSPID(A.Sanphamid);
                WpfAppQLCF.Model.Size size = XuLyNhanVien.getSizeID((int)cmbSize.SelectedValue);

                //if ( mahang == null )
                //{
                //    MessageBox.Show("ERORR !");
                //    return;
                //}
                Ctdonhang ct = null;

                if (size == null)
                    return;
                foreach (Ctdonhang a in hd.Ctdonhangs.Where(t => t.SanPhamId == A.Sanphamid && t.Size == A.Size))
                {
                    ct = a;
                    break;
                }
                if (ct == null)
                {
                    ct = new Ctdonhang();
                    ct.SanPhamId = A.Sanphamid;
                    ct.SanPham = hh;
                    ct.SoLuong = int.Parse(txtSoluong.Text);
                    ct.Gia = double.Parse(txtGia.Text);

                    ct.Size = size.Name;
                    hd.Ctdonhangs.Add(ct);
                }
                else
                {
                    ct.SoLuong += int.Parse(txtSoluong.Text);
                }
                //dgCTHD.ItemsSource = hd.Ctdonhangs.Select(x => new {
                //    Mahang = x.CtdonHangId,
                //    Tenhang = x.SanPham.TenSp,
                //    Dongia = x.SanPham.Gia,
                //    Soluong = x.SoLuong,
                //    Thanhtien = x.SoLuong * x.Gia,
                //    Size = x.Size
                //}).ToList();
                List<Sanpham> listSP = XuLyNhanVien.getSP();

                dgCTHD.ItemsSource = CTSanPhamDaChonView.getDSSpdaChonView(listSP, hd.Ctdonhangs.ToList());

                
                txtThanhtienhd.Text = hd.Ctdonhangs.Sum(x => x.SoLuong * x.Gia).ToString();

            }
            catch
            (Exception ex)
            {
                return;
            }
        }

        private void btnXoa_Click_2(object sender, RoutedEventArgs e)
        {
            
            CTSanPhamDaChonView A = (CTSanPhamDaChonView)dgCTHD.SelectedItem;
            //string mahang = cmbSanPham.SelectedValue.ToString();
            Sanpham hh = XuLyNhanVien.getSPID(A.Sanphamid);
            WpfAppQLCF.Model.Size size = XuLyNhanVien.getSizeID((int)cmbSize.SelectedValue);

            foreach (Ctdonhang a in hd.Ctdonhangs)
            {
                if (a.Size == A.Size && a.SanPhamId==A.Sanphamid)
                {
                    hd.Ctdonhangs.Remove(a);
                }
            }
            //dgCTHD.ItemsSource = hd.Ctdonhangs.Select(x => new {
            //    Mahang = x.CtdonHangId,
            //    Tenhang = x.SanPham.TenSp,
            //    Dongia = x.SanPham.Gia,
            //    Soluong = x.SoLuong,
            //    Thanhtien = x.SoLuong * x.Gia,
            //    Size = x.Size
            //}).ToList();
            List<Sanpham> listSP = XuLyNhanVien.getSP();

            dgCTHD.ItemsSource = CTSanPhamDaChonView.getDSSpdaChonView(listSP, hd.Ctdonhangs.ToList());

            txtThanhtienhd.Text = hd.Ctdonhangs.Sum(x => x.SoLuong * x.Gia).ToString();

        }

        private void btnGiam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // string maCTLOAI = dgCTHD.SelectedValue.ToString();
                CTSanPhamDaChonView A = (CTSanPhamDaChonView)dgCTHD.SelectedItem;
                //string mahang = cmbSanPham.SelectedValue.ToString();
                Sanpham hh = XuLyNhanVien.getSPID(A.Sanphamid);
                WpfAppQLCF.Model.Size size = XuLyNhanVien.getSizeID((int)cmbSize.SelectedValue);

                //if ( mahang == null )
                //{
                //    MessageBox.Show("ERORR !");
                //    return;
                //}
                Ctdonhang ct = null;

                if (size == null)
                    return;
                foreach (Ctdonhang a in hd.Ctdonhangs.Where(t => t.SanPhamId == A.Sanphamid && t.Size == A.Size))
                {
                    ct = a;
                    break;
                }
                if (ct == null)
                {
                    ct = new Ctdonhang();
                    ct.SanPhamId = A.Sanphamid;
                    ct.SanPham = hh;
                    ct.SoLuong = int.Parse(txtSoluong.Text);
                    ct.Gia = double.Parse(txtGia.Text);

                    ct.Size = size.Name;
                    hd.Ctdonhangs.Add(ct);
                }
                else
                {
                    ct.SoLuong -= int.Parse(txtSoluong.Text);
                }
                //dgCTHD.ItemsSource = hd.Ctdonhangs.Select(x => new {
                //    Mahang = x.CtdonHangId,
                //    Tenhang = x.SanPham.TenSp,
                //    Dongia = x.SanPham.Gia,
                //    Soluong = x.SoLuong,
                //    Thanhtien = x.SoLuong * x.Gia,
                //    Size = x.Size
                //}).ToList();
                List<Sanpham> listSP = XuLyNhanVien.getSP();

                dgCTHD.ItemsSource = CTSanPhamDaChonView.getDSSpdaChonView(listSP, hd.Ctdonhangs.ToList());


                txtThanhtienhd.Text = hd.Ctdonhangs.Sum(x => x.SoLuong * x.Gia).ToString();

            }
            catch
            (Exception ex)
            {
                return;
            }
        }
    }
}
