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
    public partial class showListMaster : Form
    {
        public showListMaster()
        {
            InitializeComponent();
        }
        public string Tno_current = "",course_number="";
        private void showListMaster_Load(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Course where Tno='" + Tno_current + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt.DefaultView;
            con1.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string student = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select Stno,Stname,Stfamily,Stfield,Staddress,Stphone from Student where Stno='" + student + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt.DefaultView;
            con1.Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            course_number = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from STC where Cno='" + course_number + "'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }
    }
}
