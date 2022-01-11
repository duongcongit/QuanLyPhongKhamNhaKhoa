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
    public partial class form_hoadon : Form
    {
        string sqlConn = main.sqlConn;
        SqlConnection Conn;
        public form_hoadon()
        {
            
            InitializeComponent();
        }

        string mathongtinhoadon = main.mathongtinhoadon;

        private void tthoadon_Load(object sender, EventArgs e)
        {
            

            this.Text = "Thông tin hóa đơn " + mathongtinhoadon;
            Conn = new SqlConnection(sqlConn);
            Conn.Open();
            
            SqlDataAdapter daHoaDon;
            DataTable dtHoaDon;
            string sqlHienThiHoaDon = string.Format("SELECT * From view_hoadon Where MaHoaDon = '{0}'", mathongtinhoadon);
            daHoaDon = new SqlDataAdapter(sqlHienThiHoaDon, Conn);
            dtHoaDon = new DataTable();
            daHoaDon.Fill(dtHoaDon);
            lb_mahoadon.Text = mathongtinhoadon;
            lb_sodichvu.Text = dtHoaDon.Rows[0][3].ToString();
            lb_tongtien.Text = dtHoaDon.Rows[0][7].ToString() + " VNĐ";
            date_ngaylam.Value = DateTime.Parse(dtHoaDon.Rows[0][5].ToString());
            date_ngayxuat.Value = DateTime.Parse(dtHoaDon.Rows[0][6].ToString());
            date_ngayhenkhamlai.Value = DateTime.Parse(dtHoaDon.Rows[0][8].ToString());


            //
            SqlDataAdapter daHD;
            DataTable dtHD;
            string sqlHD = string.Format("SELECT * From HoaDon Where MaHD = '{0}'", mathongtinhoadon);
            daHD = new SqlDataAdapter(sqlHD, Conn);
            dtHD = new DataTable();
            daHD.Fill(dtHD);


            // ======== Bác sĩ

            string bacsi = dtHD.Rows[0][2].ToString();
            string mabacsi = string.Concat(bacsi.Where(c => !char.IsWhiteSpace(c)));
            SqlDataAdapter daBacSi;
            DataTable dtBacSi;
            string sqlHienThiBacSi = string.Format("SELECT * From BacSi Where MaBS = '{0}'", mabacsi);
            daBacSi = new SqlDataAdapter(sqlHienThiBacSi, Conn);
            dtBacSi = new DataTable();
            daBacSi.Fill(dtBacSi);
            lb_hotenbacsi.Text = dtBacSi.Rows[0][1].ToString();
            lb_gioitinhbacsi.Text = dtBacSi.Rows[0][2].ToString();
            lb_sdtbacsi.Text = dtBacSi.Rows[0][4].ToString();
            lb_chucdanhbacsi.Text = dtBacSi.Rows[0][7].ToString();
            //


            // ========= Khách hàng
            string khachhang = dtHoaDon.Rows[0][1].ToString();
            string makhachhang = string.Concat(khachhang.Where(c => !char.IsWhiteSpace(c)));
            SqlDataAdapter daKhachHang;
            DataTable dtKhachHang;
            string sqlHienThiKhachHang = string.Format("SELECT * From KhachHang Where MaKH = '{0}'", makhachhang);
            daKhachHang = new SqlDataAdapter(sqlHienThiKhachHang, Conn);
            dtKhachHang = new DataTable();
            daKhachHang.Fill(dtKhachHang);
            lb_makhachhang.Text = makhachhang;
            lb_hotenkhachhang.Text = dtKhachHang.Rows[0][1].ToString();
            lb_sdtkhachhang.Text = dtKhachHang.Rows[0][3].ToString();
            lb_gioitinhkhachhang.Text = dtKhachHang.Rows[0][2].ToString();
            lb_ngaysinhkhachhang.Text = DateTime.Parse(dtKhachHang.Rows[0][4].ToString()).ToString("dd/MM/yyyy");
            lb_nghenghiepkhachhang.Text = dtKhachHang.Rows[0][5].ToString();
            lb_diachikhachhang.Text = dtKhachHang.Rows[0][6].ToString();

            // ========= Chi tiết Dịch vụ
            SqlDataAdapter daDichVu;
            DataTable dtDichVu;
            string sqlHienThi = string.Format("Select CT_HoaDon.MaDV, TenDV, SoLuong, DonGia, ThanhTien, MaTB, MoTa from CT_HoaDon, DichVu Where CT_HoaDon.MaDV = DichVu.MaDV and MaHD = '{0}'", mathongtinhoadon);
            daDichVu = new SqlDataAdapter(sqlHienThi, Conn);
            dtDichVu = new DataTable();
            daDichVu.Fill(dtDichVu);
            dataview_danhsachdichvu.DataSource = dtDichVu;
        }



        //
        private void btn_xoahoadon_Click(object sender, EventArgs e)
        {
            string tbao_xoahoadon = "Xác nhận xóa hóa đơn này?.";
            DialogResult tbdv = MessageBox.Show(tbao_xoahoadon, "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tbdv == DialogResult.Cancel) { return; }
            try
            {
                string sqlXoaCTHoaDon = string.Format("Delete from CT_HoaDon Where MaHD='{0}'", mathongtinhoadon);
                SqlCommand cmd_xoacthoadon = new SqlCommand(sqlXoaCTHoaDon, Conn);
                cmd_xoacthoadon.ExecuteNonQuery();

                string sqlHoaDon = string.Format("Delete from HoaDon Where MaHD='{0}'", mathongtinhoadon);
                SqlCommand cmd_xoahoadon = new SqlCommand(sqlHoaDon, Conn);
                cmd_xoahoadon.ExecuteNonQuery();
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
