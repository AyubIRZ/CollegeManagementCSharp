using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sama_win
{
    public partial class showReportStudent : Form
    {
        public showReportStudent()
        {
            InitializeComponent();
        }
        public string Stno_current = "";
        private void showReportStudent_Load(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from STC where Stno='" + Stno_current + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string current_course_number = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Course where Cno='" + current_course_number + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt.DefaultView;
            con1.Close();
        }
    }
}
