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
    public partial class form_bacsi : Form
    {
        public form_bacsi()
        {
            InitializeComponent();
        }

        string sqlConn = main.sqlConn;
        SqlConnection Conn;


        string mathongtinbacsi = main.mathongtinbacsi;
        private void form_bacsi_Load(object sender, EventArgs e)
        {
            this.Text = "Thông tin bác sĩ " + mathongtinbacsi;
            Conn = new SqlConnection(sqlConn);
            Conn.Open();

            SqlDataAdapter dabacSi;
            DataTable dtBacSi;
            string sqlHienThiBacSi = string.Format("SELECT * From BacSi Where MaBS = '{0}'", mathongtinbacsi);
            dabacSi = new SqlDataAdapter(sqlHienThiBacSi, Conn);
            dtBacSi = new DataTable();
            dabacSi.Fill(dtBacSi);

            lb_mabacsi.Text = mathongtinbacsi;
            lb_hotenbacsi.Text = dtBacSi.Rows[0][1].ToString();
            lb_gioitinhbacsi.Text = dtBacSi.Rows[0][2].ToString();
            lb_ngaysinh_bacsi.Text = DateTime.Parse(dtBacSi.Rows[0][3].ToString()).ToString("dd/MM/yyyy");
            lb_sdtbacsi.Text = dtBacSi.Rows[0][4].ToString();
            lb_email_bacsi.Text = dtBacSi.Rows[0][5].ToString();
            lb_diachibacsi.Text = dtBacSi.Rows[0][6].ToString();
            lb_chucdanhbacsi.Text = dtBacSi.Rows[0][7].ToString();
            lb_namkinhnghiembacsi.Text = dtBacSi.Rows[0][8].ToString();


            //
            SqlDataAdapter daSoHoaDon;
            DataTable dtSoHoaDon;
            string sqlHienThiSoHiaDon = string.Format("Select MaHD, KhachHang.MaKH, TenKH, NgayLam, NgayHenKhamLai, NgayXuatHoaDon, TongTien, MoTa From HoaDon, KhachHang, BacSi Where HoaDon.MaKH = KhachHang.MaKH and HoaDon.MaBS = BacSi.MaBS and BacSi.MaBS = '{0}'", mathongtinbacsi);
            daSoHoaDon = new SqlDataAdapter(sqlHienThiSoHiaDon, Conn);
            dtSoHoaDon = new DataTable();
            daSoHoaDon.Fill(dtSoHoaDon);
            lb_sohoadon_bacsi.Text = dtSoHoaDon.Rows.Count.ToString();
            dataview_hoadon_bacsi.DataSource = dtSoHoaDon;



        }



        //
    }
}
