using WpfAppQLCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppQLCF.Model
{

    internal class XuLyNhanVien
    {
        public static NhanVien NhanVienDaLogin;
        private static HttpClient hc = new HttpClient();
        private static string strUrl = @"https://localhost:44359/api/NhanVien";


        public static bool suaNhanVien(NhanVien h)
        {
            try
            {
                var conn = hc.PutAsJsonAsync<NhanVien>(strUrl, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch { return false; }
        }
        public static List<NhanVien> getDSNV()
        {
            try
            {
                var conn = hc.GetAsync(strUrl);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<List<NhanVien>>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static NhanVien getNvId(string a)
        {
            try
            {
                string str = strUrl + @"/" + a;
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<NhanVien>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static bool themNhanVien(NhanVien h)
        {
            try
            {
                
                var conn = hc.PostAsJsonAsync<NhanVien>(strUrl, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public static List<Sanpham> getSP()
        {
            try
            {
                string str = strUrl + @"/SanPham";
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<List<Sanpham>>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static Sanpham getSPID(string a)
        {
            try
            {
                string str = strUrl + @"/SanPham/"+a;
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<Sanpham>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
       
        public static bool themSanPham(Sanpham h)
        {

            try
            {
                string str = strUrl + @"/SanPham";
                var conn = hc.PostAsJsonAsync<Sanpham>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
       
        
        public static NhanVien loGin(string userID,string pass)
        {
            NhanVien nvlogin = getNvId(userID);
            if (nvlogin != null)
            {
                if (nvlogin.Password == pass)
                {
                    NhanVienDaLogin = nvlogin;
                    return nvlogin;
                }
                    return null;
            }
            return null;
        }
        public static bool xoaSanPham(string id)
        {
            String str = strUrl + @"/SanPham/" + id;
            try
            {
                var conn = hc.DeleteAsync(str);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool suaSanPham(Sanpham h)
        {
            try
            {

                String str = strUrl + @"/SanPham";
                var conn = hc.PutAsJsonAsync<Sanpham>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch { return false; }
        }
        public static List<Loai> getDSLOAI()
        {
            try
            {
                string str = strUrl + @"/Loai";
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<List<Loai>>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static Loai getLoaiID(int a)
        {
            try
            {
                string str = strUrl + @"/Loai/" + a;
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<Loai>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static bool themLoai(Loai h)
        {

            try
            {
                string str = strUrl + @"/Loai";
                var conn = hc.PostAsJsonAsync<Loai>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public static bool xoaLoai(int id)
        {
            String str = strUrl + @"/Loai/" + id;
            try
            {
                var conn = hc.DeleteAsync(str);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool suaLoai (Loai h)
        {
            try
            {

                String str = strUrl + @"/Loai";
                var conn = hc.PutAsJsonAsync<Loai>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch { return false; }
        }
        public static List<WpfAppQLCF.Model.Size> getDSSize()
        {
            try
            {
                string str = strUrl + @"/Size";
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<List<WpfAppQLCF.Model.Size>>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static WpfAppQLCF.Model.Size getSizeID(int a)
        {
            try
            {
                string str = strUrl + @"/Size/" + a;
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<WpfAppQLCF.Model.Size>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static bool themSize(WpfAppQLCF.Model.Size h)
        {

            try
            {
                string str = strUrl + @"/Size";
                var conn = hc.PostAsJsonAsync<WpfAppQLCF.Model.Size>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public static bool xoaSize(int id)
        {
            String str = strUrl + @"/Size/" + id;
            try
            {
                var conn = hc.DeleteAsync(str);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool suaSize(WpfAppQLCF.Model.Size h)
        {
            try
            {

                String str = strUrl + @"/Size";
                var conn = hc.PutAsJsonAsync<WpfAppQLCF.Model.Size>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch { return false; }
        }
        public static List<DonHang> getDSDonHang()
        {
            try
            {
                string str = strUrl + @"/DonHang";
                var conn = hc.GetAsync(str);
                conn.Wait();
                bool a = conn.Result.IsSuccessStatusCode;//  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
                if (a == false)
                {
                    return null;
                }
                else
                {
                    var kq = conn.Result.Content.ReadAsAsync<List<DonHang>>();// dữ liệu trả về nằm trong context sao đó dùng hàm ReadAsAsync để xử lý nguyên cục dự liệu đó
                    kq.Wait();
                    return kq.Result; //trả về kết quả 
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static List<Khachhang> getDsKh()
        {
            try
            {
                string str = strUrl + @"/KhachHang";
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<List<Khachhang>>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static Khachhang getKhID(string a)
        {
            try
            {
                string str = strUrl + @"/KhachHang/" + a;
                var conn = hc.GetAsync(str);
                conn.Wait();
                if (conn.Result.IsSuccessStatusCode == false)
                    return null;
                var kq = conn.Result.Content.ReadAsAsync<Khachhang>();
                kq.Wait();
                return kq.Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static bool themKh(Khachhang h)
        {

            try
            {
                string str = strUrl + @"/KhachHang";
                var conn = hc.PostAsJsonAsync<Khachhang>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public static bool suaKhachHang(Khachhang h)
        {
            try
            {

                String str = strUrl + @"/KhachHang";
                var conn = hc.PutAsJsonAsync<Khachhang>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch { return false; }
        }
        public static bool themHoaDon(DonHang h)
        {
            try
            {
                string str = strUrl + @"/DonHang";
                var conn = hc.PostAsJsonAsync<DonHang>(str, h);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }
        public static bool xoaDonHang(string id)
        {
            String str = strUrl + @"/DonHang/" + id;
            try
            {
                var conn = hc.DeleteAsync(str);
                conn.Wait();
                return conn.Result.IsSuccessStatusCode;  //  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static List<Ctdonhang> getCTHD(String id)
        {
            try
            {

                String str = strUrl + @"/ChiTietHoaDon/" + id;
                var conn = hc.GetAsync(str);
                conn.Wait();
                bool a = conn.Result.IsSuccessStatusCode;//  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
                if (a == false)
                {
                    return null;
                }
                else
                {
                    var kq = conn.Result.Content.ReadAsAsync<List<Ctdonhang>>();// dữ liệu trả về nằm trong context sao đó dùng hàm ReadAsAsync để xử lý nguyên cục dự liệu đó
                    kq.Wait();
                    return kq.Result; //trả về kết quả 
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<CtSpSize> getCTSize(String id)
        {
            try
            {

                String str = strUrl + @"/ChiTietSize/" + id;
                var conn = hc.GetAsync(str);
                conn.Wait();
                bool a = conn.Result.IsSuccessStatusCode;//  conn.Result.IsSuccessStatusCode trả về giá trị true hoặc falase
                if (a == false)
                {
                    return null;
                }
                else
                {
                    var kq = conn.Result.Content.ReadAsAsync<List<CtSpSize>>();// dữ liệu trả về nằm trong context sao đó dùng hàm ReadAsAsync để xử lý nguyên cục dự liệu đó
                    kq.Wait();
                    return kq.Result; //trả về kết quả 
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
