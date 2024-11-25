using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doan_ver1._0
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        public DataTable LoadDuLieuDangKy()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmdDangKy = new SqlCommand("tp_xemDangKy", conn);
                cmdDangKy.CommandText = "tp_xemDangKy";
                cmdDangKy.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter daDangKy = new SqlDataAdapter(cmdDangKy);

                daDangKy.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                SqlCommand cmdthemTaiKhoan = new SqlCommand("tp_ThemTaiKhoan", conn);
                cmdthemTaiKhoan.CommandType = CommandType.StoredProcedure;

                //them bien
                SqlParameter paTen = new SqlParameter("@tenDangNhap", txtTenDangNhap.Text);
                //them vao commnand
                cmdthemTaiKhoan.Parameters.Add(paTen);

                SqlParameter paMK = new SqlParameter("@matKhau", txtPass.Text);
                cmdthemTaiKhoan.Parameters.Add(paMK);

                SqlParameter paHoTen = new SqlParameter("@hoTen", txtHoTen.Text);
                cmdthemTaiKhoan.Parameters.Add(paHoTen);

                SqlParameter paEmail = new SqlParameter("@email", txtEmail.Text);
                cmdthemTaiKhoan.Parameters.Add(paEmail);

                SqlParameter paVaiTro = new SqlParameter("@vaiTro", cbVaitro.Text);
                cmdthemTaiKhoan.Parameters.Add(paVaiTro);

                SqlParameter paNgayTao = new SqlParameter("@ngayTao", dateNgayTao.Value);
                cmdthemTaiKhoan.Parameters.Add(paNgayTao);

                //thucthi
                if (cmdthemTaiKhoan.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Dang ky thanh cong");

                }
                else
                {
                    MessageBox.Show("Dang ky that bai");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
