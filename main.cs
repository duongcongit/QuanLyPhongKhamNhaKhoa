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
    public partial class main : Form
    {

        public static string sqlConn = "Data Source=HI\\AVG;Initial Catalog=PhongKhamNhaKhoa;Integrated Security=True";
        SqlConnection Conn;
        public main()
        {
            Conn = new SqlConnection(sqlConn);
            Conn.Open();
            InitializeComponent();
            hienthihoadon();
            hienthidulieu();
            
        }

        void hienthihoadon()
        {
            SqlDataAdapter daHoaDon;
            DataTable dtHoaDon;
            string sqlHienThiHoaDon = "SELECT * From view_hoadon";
            daHoaDon = new SqlDataAdapter(sqlHienThiHoaDon, Conn);
            dtHoaDon = new DataTable();
            daHoaDon.Fill(dtHoaDon);
            form_dshoadon.DataSource = dtHoaDon;   
        }

        void hienthidulieu()
        {
            SqlDataAdapter daBS;
            DataTable dtBS;
            string sqlHienThiBacSi = "SELECT * From BacSi";
            daBS = new SqlDataAdapter(sqlHienThiBacSi, Conn);
            dtBS = new DataTable();
            daBS.Fill(dtBS);
            dataview_bacsi.DataSource = dtBS;
            //
            foreach(DataRow dr in dtBS.Rows)
            {
                cbb_hoadon_bacsi.Items.Add(dr["MaBS"].ToString() + ":" + dr["TenBS"].ToString());
            }
            //
            SqlDataAdapter daKH;
            DataTable dtKH;
            string sqlHienThiKhachHang = "SELECT * From KhachHang";
            daKH = new SqlDataAdapter(sqlHienThiKhachHang, Conn);
            dtKH = new DataTable();
            daKH.Fill(dtKH);
            dataview_khachhang.DataSource = dtKH;
            //
            SqlDataAdapter daDV;
            DataTable dtDV;
            string sqlHienThiDichVu = "SELECT * From DichVu";
            daDV = new SqlDataAdapter(sqlHienThiDichVu, Conn);
            dtDV = new DataTable();
            daDV.Fill(dtDV);
            dataview_dichvu.DataSource = dtDV;

            //
            SqlDataAdapter daTBVL;
            DataTable dtTBVL;
            string sqlHienThiTBVL = "SELECT * From ThietBiVatLieu";
            daTBVL = new SqlDataAdapter(sqlHienThiTBVL, Conn);
            dtTBVL = new DataTable();
            daTBVL.Fill(dtTBVL);
            dataview_thietbivatlieu.DataSource = dtTBVL;
            //
            SqlDataAdapter daNCC;
            DataTable dtNCC;
            string sqlHienNCC = "SELECT * From view_ncc";
            daNCC = new SqlDataAdapter(sqlHienNCC, Conn);
            dtNCC = new DataTable();
            daNCC.Fill(dtNCC);
            dataview_nhacungcap.DataSource = dtNCC;
            //

            lb_hoadon_bs.Text = dtBS.Rows.Count.ToString();
            lb_hoadon_kh.Text = dtKH.Rows.Count.ToString();
            lb_hoadon_tb.Text = dtTBVL.Rows.Count.ToString();
            lb_hoadon_ncc.Text = dtNCC.Rows.Count.ToString();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(date_hoadon_ngayhenkhamlai.Enabled == false)
            {
                date_hoadon_ngayhenkhamlai.Enabled = true;
            }
            else
            {
                date_hoadon_ngayhenkhamlai.Enabled = false;
            }
        }

        // Hàm kiểm tra sdt
        bool Ktra_sdt(string sdt)//Hàm kiểm tra số điện thoại hợp lệ
        {
            if (sdt == "")
            { MessageBox.Show("Bạn chưa nhập thông tin SĐT!\nVui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
            try
            {
                ulong tsdt;
                tsdt = Convert.ToUInt64(sdt);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai định dạng số điện thoại!\nVui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (sdt.Count() != 10)
            {
                MessageBox.Show("Bạn nhập sai số điện định dạng số điện thoại!\nSố điện thoại phải có 10 chữ số!\nVui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //
        string ktra_dacokhachhang(string sdt)
        {
            string makh = "";
            SqlDataAdapter daKH;
            DataTable dtKH;
            string sqlHienThiKhachHang = string.Format("SELECT * From KhachHang Where SDT='{0}'", sdt);
            daKH = new SqlDataAdapter(sqlHienThiKhachHang, Conn);
            dtKH = new DataTable();
            daKH.Fill(dtKH);
            if(dtKH.Rows.Count > 0)
            {
                makh = dtKH.Rows[0][0].ToString();
            }
            return makh;
        }
        //
        void themhoadon(string mahoadon, string makhachhang, string mabacsi, string ngaylam, string ngayhenkhamlai, string mota, int[] dichvu)
        {
            string ngayxuat = DateTime.Today.ToString("MM/dd/yyyy");
            //
            int layvoi = dichvu[0];
            int lamtrang = dichvu[1];
            int rangkhon = dichvu[2];
            int rangsau = dichvu[3];
            int niengrang = dichvu[4];
            int nhachu = dichvu[5];
            int rangsu = dichvu[6];
            int nhorang = dichvu[7];
            string sqlThenHoadon = string.Format("Insert into HoaDon(MaHD, MaKH, MaBS, NgayLam, NgayXuatHoaDon, NgayHenKhamLai, MoTa) Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', N'{6}');", mahoadon, makhachhang, mabacsi, ngaylam, ngayxuat, ngayhenkhamlai, mota);
            SqlCommand cmd_hoadon = new SqlCommand(sqlThenHoadon, Conn);
            cmd_hoadon.ExecuteNonQuery();
            //
            if(layvoi > 0)
            {
                string madv = "DV01";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, layvoi);
                SqlCommand cmd_dv01 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv01.ExecuteNonQuery();
            }
            if (lamtrang > 0)
            {
                string madv = "DV02";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, lamtrang);
                SqlCommand cmd_dv02 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv02.ExecuteNonQuery();
            }
            if (rangkhon > 0)
            {
                string madv = "DV03";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, rangkhon);
                SqlCommand cmd_dv03 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv03.ExecuteNonQuery();
            }
            if (rangsau > 0)
            {
                string madv = "DV04";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, rangsau);
                SqlCommand cmd_dv04 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv04.ExecuteNonQuery();
            }
            if (niengrang > 0)
            {
                string madv = "DV05";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, niengrang);
                SqlCommand cmd_dv05 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv05.ExecuteNonQuery();
            }
            if (nhachu > 0)
            {
                string madv = "DV06";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, nhachu);
                SqlCommand cmd_dv06 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv06.ExecuteNonQuery();
            }
            if (rangsu > 0)
            {
                string madv = "DV07";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, rangsu);
                SqlCommand cmd_dv07 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv07.ExecuteNonQuery();
            }
            if (nhorang > 0)
            {
                string madv = "DV08";
                string sqlCT_HoaDon = string.Format("INSERT INTO CT_HoaDon(MaHD, MaDV, SoLuong)VALUES('{0}', '{1}', {2})", mahoadon, madv, nhorang);
                SqlCommand cmd_dv08 = new SqlCommand(sqlCT_HoaDon, Conn);
                cmd_dv08.ExecuteNonQuery();
            }
        }
        //
        void themkhachhang(string makhachhang, string hovaten, string gioitinh, string sdt, string ngaysinh, string nghenghiep, string diachi)
        {
            
            string sqlThenKhachhang = string.Format("Insert into KhachHang Values('{0}', N'{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}')", makhachhang, hovaten, gioitinh, sdt, ngaysinh, nghenghiep, diachi);
            SqlCommand cmd_khach = new SqlCommand(sqlThenKhachhang, Conn);
            cmd_khach.ExecuteNonQuery();
        }

        private void btn_taohoadon_Click(object sender, EventArgs e)
        {
            int num_hoadon = RandomNumber(10000, 99999);
            string mahoadon = "HD0" + num_hoadon.ToString() + "CA";

            int num_khachhang = RandomNumber(10009, 99999);
            string makhachhang = "KH0" + num_khachhang.ToString() + "DC";

            string sdt = text_hoadon_sdt.Text;
            string hovaten = text_hoadon_hoten.Text;
            string gioitinh = "";
            string ngaysinh = date_hoadon_ngaysinh.Value.Date.ToString("MM/dd/yyyy");
            string nghenghiep = text_hoadon_nghenghiep.Text;
            string diachi = text_hoadon_diachi.Text;

            string ngaylam = date_hoadon_ngaylam.Value.Date.ToString("MM/dd/yyyy");
            string ngayhenkhamlai = "";
            string mabacsi = "";
            //
            string mota = "";
            // Dịch vụ
            int layvoi = Convert.ToInt32(num_hoadondv_layvoi.Value);
            int lamtrang = Convert.ToInt32(num_hoadondv_lamtrang.Value);
            int rangkhon = Convert.ToInt32(num_hoadondv_rangkhon.Value);
            int rangsau = Convert.ToInt32(num_hoadondv_rangsau.Value);
            int niengrang = Convert.ToInt32(num_hoadondv_niengrang.Value);
            int nhachu = Convert.ToInt32(num_hoadondv_nhachu.Value);
            int rangsu = Convert.ToInt32(num_hoadondv_thayrangsu.Value);
            int nhorang = Convert.ToInt32(num_hoadondv_nhorang.Value);

            int[] dichvu = {layvoi, lamtrang, rangkhon, rangsau, niengrang, nhachu, rangsu, nhorang };

            if (rd_hoadon_nam.Checked)
            {
                gioitinh = "Nam";
            }
            else if (rd_hoadon_nu.Checked)
            {
                gioitinh = "Nữ";
            }
            //
            if (check_hoadon_ngayhenkhamlai.Checked)
            {
                ngayhenkhamlai = date_hoadon_ngayhenkhamlai.Value.Date.ToString("MM/dd/yyyy");
            }
            //
            if (!Ktra_sdt(sdt))
            {
                return;
            }
            // Kiem tra dich vu
            if (layvoi == 0 && lamtrang == 0 && rangkhon == 0 && rangsau == 0 && niengrang == 0 && nhachu == 0 & rangsu == 0 && nhorang == 0)
            {
                MessageBox.Show("Chưa chọn dịch vụ nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Bac si
            if (cbb_hoadon_bacsi.Text == "")
            {
                MessageBox.Show("Chưa chọn bác sĩ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string bacsi = cbb_hoadon_bacsi.Text.Split(':')[0];
            mabacsi = string.Concat(bacsi.Where(c => !char.IsWhiteSpace(c)));
            //
            
            if (ktra_dacokhachhang(sdt) != "")
            {
                string tbao_datontaikhach = String.Format("Số điện thoại khách hàng {0} đã tồn tại, nếu tiếp tục sẽ chỉ tạo hóa đơn và không thêm khách hàng vào danh sách hay cập nhật thông tin của khách hàng này.", sdt);
                DialogResult tbdv = MessageBox.Show(tbao_datontaikhach, "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (tbdv == DialogResult.Cancel) { return; }
                themhoadon(mahoadon, makhachhang, mabacsi, ngaylam, ngayhenkhamlai, mota, dichvu);
                try
                {
                    themhoadon(mahoadon, makhachhang, mabacsi, ngaylam, ngayhenkhamlai, mota, dichvu);
                }
                catch
                {
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
            }
            else
            {
                try
                {
                    themkhachhang(makhachhang, hovaten, gioitinh, sdt, ngaysinh, nghenghiep, diachi);
                    themhoadon(mahoadon, makhachhang, mabacsi, ngaylam, ngayhenkhamlai, mota, dichvu);
                }
                catch
                {
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            MessageBox.Show("Đã tạo thành công hóa đơn!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            hienthihoadon();

        }
        //
        public static string mathongtinhoadon = "";
        private void form_dshoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            mathongtinhoadon = form_dshoadon.CurrentRow.Cells[0].Value.ToString();
            Form thongtinhoadon = new form_hoadon();
            thongtinhoadon.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void btn_tailai_Click(object sender, EventArgs e)
        {
            hienthihoadon();
            hienthidulieu();
        }

        //
        public static string mathongtinkhachhang = "";
        private void dataview_khachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mathongtinkhachhang = dataview_khachhang.CurrentRow.Cells[0].Value.ToString();
            Form thongtinkhachhang = new form_khachhang();
            thongtinkhachhang.ShowDialog();
        }
        //

        

        private void btn_themkhachhang_Click(object sender, EventArgs e)
        {
            string sdt = tb_khachhang_sdt.Text;
            if (!Ktra_sdt(sdt))
            {
                return;
            }

            int num_khachhang = RandomNumber(10009, 99999);
            string makhachhang = "KH0" + num_khachhang.ToString() + "DC";

            string hovaten = tb_khachhang_hovaten.Text;
            string gioitinh = "";
            string ngaysinh = datetime_khachhang_ngaysinh.Value.Date.ToString("MM/dd/yyyy");
            string nghenghiep = tb_khachhang_nghenghiep.Text;
            string diachi = tb_khachhang_diachi.Text;

            if (ktra_dacokhachhang(sdt) == "")
            {
                try
                {
                    themkhachhang(makhachhang, hovaten, gioitinh, sdt, ngaysinh, nghenghiep, diachi);
                }
                catch
                {
                    MessageBox.Show("Lỗi không xác định!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                string tbao_datontaikhach = String.Format("Số điện thoại khách hàng {0} đã tồn tại.\n Vui lòng kiểm tra lại", sdt);
                MessageBox.Show(tbao_datontaikhach, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            MessageBox.Show("Đã thêm thành công khách hàng!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            hienthidulieu();

        }

        //
        public static string mathongtinbacsi = "";
        private void dataview_bacsi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mathongtinbacsi = dataview_bacsi.CurrentRow.Cells[0].Value.ToString();
            Form thongtinbacsi = new form_bacsi();
            thongtinbacsi.ShowDialog();
        }


        //

        public static string mathongtindichvu = "";
        private void dataview_dichvu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mathongtindichvu = dataview_dichvu.CurrentRow.Cells[0].Value.ToString();
            Form thongtindichvu = new form_dichvu();
            thongtindichvu.ShowDialog();
        }
    }
}
