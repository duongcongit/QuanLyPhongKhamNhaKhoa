using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyPhongKham
{
    public partial class form_khachhang : Form
    {
        string sqlConn = main.sqlConn;
        SqlConnection Conn;
        public form_khachhang()
        {
            InitializeComponent();
        }

        string mathongtinkhachhang = main.mathongtinkhachhang;

        private void form_khachhang_Load(object sender, EventArgs e)
        {
            

            this.Text = "Thông tin khách hàng " + mathongtinkhachhang;
            Conn = new SqlConnection(sqlConn);
            Conn.Open();

            SqlDataAdapter daKhachHang;
            DataTable dtKhachHang;
            string sqlHienThiKhachHang = string.Format("SELECT * From KhachHang Where MaKH = '{0}'", mathongtinkhachhang);
            daKhachHang = new SqlDataAdapter(sqlHienThiKhachHang, Conn);
            dtKhachHang = new DataTable();
            daKhachHang.Fill(dtKhachHang);

            lb_makhachhang.Text = mathongtinkhachhang;
            lb_hotenkhachhang.Text = dtKhachHang.Rows[0][1].ToString();
            lb_gioitinhkhachhang.Text = dtKhachHang.Rows[0][2].ToString();
            lb_sdtkhachhang.Text = dtKhachHang.Rows[0][3].ToString();
            lb_ngaysinhkhachhang.Text = DateTime.Parse(dtKhachHang.Rows[0][4].ToString()).ToString("dd/MM/yyyy");
            lb_nghenghiepkhachhang.Text = dtKhachHang.Rows[0][5].ToString();
            lb_diachikhachhang.Text = dtKhachHang.Rows[0][6].ToString();


            //
            SqlDataAdapter daSoHoaDon;
            DataTable dtSoHoaDon;
            string sqlHienThiSoHiaDon = string.Format("Select MaHD, BacSi.MaBS, TenBS, NgayLam, NgayHenKhamLai, NgayXuatHoaDon, TongTien, MoTa From HoaDon, KhachHang, BacSi Where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaBS = BacSi.MaBS and KhachHang.MaKH = '{0}'", mathongtinkhachhang);
            daSoHoaDon = new SqlDataAdapter(sqlHienThiSoHiaDon, Conn);
            dtSoHoaDon = new DataTable();
            daSoHoaDon.Fill(dtSoHoaDon);
            lb_sohoadon.Text = dtSoHoaDon.Rows.Count.ToString();
            dataview_hoadon_khachhang.DataSource = dtSoHoaDon;



            

            SqlDataAdapter daSoDichVu;
            DataTable dtSoDichVu;
            string sqlHienThiSoDichVu = string.Format("SELECT HoaDon.MaHD, DichVu.MaDV, TenDV, HoaDon.NgayLam, SoLuong, DonGia, ThanhTien, DichVu.MoTa From CT_HoaDon, HoaDon, DichVu Where CT_HoaDon.MaHD = HoaDon.MaHD and CT_HoaDon.MaDV = DichVu.MaDV and MaKH = '{0}'", mathongtinkhachhang);
            daSoDichVu = new SqlDataAdapter(sqlHienThiSoDichVu, Conn);
            dtSoDichVu = new DataTable();
            daSoDichVu.Fill(dtSoDichVu);

            lb_sodichvu.Text = dtSoDichVu.Rows.Count.ToString();
            dataview_danhsachdichvu_khachhang.DataSource = dtSoDichVu;

            //
            SqlDataAdapter daTongtien;
            DataTable dtTongtien;
            string sqlHienThiTongtien = string.Format("SELECT SUM(TongTien) From HoaDon Where MaKH = '{0}'", mathongtinkhachhang);
            daTongtien = new SqlDataAdapter(sqlHienThiTongtien, Conn);
            dtTongtien = new DataTable();
            daTongtien.Fill(dtTongtien);
            lb_tongtien.Text = dtTongtien.Rows[0][0].ToString() + " VNĐ";

        }

        private void btn_xoahoadon_Click(object sender, EventArgs e)
        {
            string tbao_xoakhachhang = "Xác nhận xóa khách hàng này?.";
            DialogResult tbdv = MessageBox.Show(tbao_xoakhachhang, "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tbdv == DialogResult.Cancel) { return; }
            try
            {
                string sqlXoaCTHoaDon = string.Format("Delete from CT_HoaDon Where MaHD in (Select MaHD from HoaDon Where MaKH = '{0}')", mathongtinkhachhang);
                SqlCommand cmd_xoacthoadon = new SqlCommand(sqlXoaCTHoaDon, Conn);
                cmd_xoacthoadon.ExecuteNonQuery();

                string sqlXoaHoaDon = string.Format("Delete from HoaDon Where MaKH='{0}'", mathongtinkhachhang);
                SqlCommand cmd_xoahoadon = new SqlCommand(sqlXoaHoaDon, Conn);
                cmd_xoahoadon.ExecuteNonQuery();

                string sqlXoaKhachHang = string.Format("Delete from KhachHang Where MaKH='{0}'", mathongtinkhachhang);
                SqlCommand cmd_xoakhachhang = new SqlCommand(sqlXoaKhachHang, Conn);
                cmd_xoakhachhang.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Đã xóa thành công!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Close();
        }
    }
}
