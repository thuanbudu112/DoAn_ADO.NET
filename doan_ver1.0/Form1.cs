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
    public partial class Form1 : Form
    {
        private home_giaodien home_hienthi;
        public void set_giaodien()
        {
            home_hienthi = new home_giaodien();
        }

        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-BA92BEJG\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void result(int i)
        {
            if (i == 1)
            {
                MessageBox.Show("Đăng nhập thành ");
                set_giaodien();
                home_hienthi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại hãy kiểm tra lại user, pass", "Warring !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login()
        {
            try
            {
                connect.Open();
                SqlCommand login = new SqlCommand("dangnhap_taikhoan", connect);
                login.CommandType = CommandType.StoredProcedure;

                SqlParameter user = new SqlParameter("@user", txt_user_admin.Text);
                SqlParameter pass = new SqlParameter("@pass", txt_Pass_admin.Text);

                login.Parameters.Add(user);
                login.Parameters.Add(pass);

                if ((int)login.ExecuteScalar() > 0)
                {
                    result(1);
                }
                else
                {
                    result(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
