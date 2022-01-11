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
    public partial class form_dichvu : Form
    {
        public form_dichvu()
        {
            InitializeComponent();
        }

        string sqlConn = main.sqlConn;
        SqlConnection Conn;

        string mathongtindichvu = main.mathongtindichvu;
        private void form_dichvu_Load(object sender, EventArgs e)
        {
            this.Text = "Thông tin dịch vụ " + mathongtindichvu;
            Conn = new SqlConnection(sqlConn);
            Conn.Open();

            SqlDataAdapter daDichVu;
            DataTable dtDichVu;
            string sqlHienThiDichVu = string.Format("select * from DichVu, ThietBiVatLieu Where DichVu.MaTB = ThietBiVatLieu.MaTB and MaDV = '{0}'", mathongtindichvu);
            daDichVu = new SqlDataAdapter(sqlHienThiDichVu, Conn);
            dtDichVu = new DataTable();
            daDichVu.Fill(dtDichVu);

            lb_madichvu.Text = mathongtindichvu;
            lb_tendichvu.Text = dtDichVu.Rows[0][1].ToString();
            lb_dongia.Text = dtDichVu.Rows[0][2 ].ToString() + " VNĐ";
            lb_mota.Text = dtDichVu.Rows[0][3].ToString();
            lb_mathietbi.Text = dtDichVu.Rows[0][4].ToString();
            lb_tenthietbi.Text = dtDichVu.Rows[0][7].ToString();


            //
            SqlDataAdapter daHD;
            DataTable dtHD;
            string sqlHD = string.Format("Select * From HoaDon inner join CT_HoaDon on HoaDon.MaHD = CT_HoaDon.MaHD inner join DichVu on CT_HoaDon.MaDV = DichVu.MaDV Where DichVu.MaDV = '{0}'", mathongtindichvu);
            daHD = new SqlDataAdapter(sqlHD, Conn);
            dtHD = new DataTable();
            daHD.Fill(dtHD);
            dataview_hoadon_dichvu.DataSource = dtHD;


        }
    }
}
