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
    public partial class home_giaodien : Form
    {
        public home_giaodien()
        {
            InitializeComponent();
            panel_account.Hide();
        }

        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        private DataTable loaddl_nhanvien()
        {
            DataTable table = new DataTable();
            try
            {
                connect.Open();

                SqlCommand cmd = new SqlCommand("tp_xemTaiKhoan", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter hienthi = new SqlDataAdapter(cmd);
                hienthi.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return null;
        }
        private void home_giaodien_Load(object sender, EventArgs e)
        {
            table_info_accout.DataSource = loaddl_nhanvien();
            table_info_accout.DefaultCellStyle.ForeColor = Color.Black;
            
        }
        private void table_info_accout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> l = new List<string>();
            laydl_accout(l);
            Info_people info_People = new Info_people(l);
            info_People.Owner = this;
            info_People.FormClosed += new FormClosedEventHandler(home_giaodien_FormClosed);
            info_People.ShowDialog();
        }

        private void laydl_accout(List<String> list)
        {
            int dong = table_info_accout.CurrentCell.RowIndex;
            for (int i = 0; i < table_info_accout.ColumnCount; i++)
            {
                list.Add(table_info_accout.Rows[dong].Cells[i].Value.ToString());
            }
        }

        private void app_account_Click(object sender, EventArgs e)
        {
            panel_account.Show();
        }


        private void home_giaodien_FormClosed(object sender, FormClosedEventArgs e)
        {
            table_info_accout.DataSource = loaddl_nhanvien();

        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            FormDangKy dangky = new FormDangKy();
            dangky.ShowDialog();
        }


    }
}
