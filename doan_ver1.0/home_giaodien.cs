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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection connect = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=quanly_cuahang_dienmay;Integrated Security=True;");

        //private DataTable loaddl_nhanvien() { 
        //}
        private void home_giaodien_Load(object sender, EventArgs e)
        {

        }
    }
}
