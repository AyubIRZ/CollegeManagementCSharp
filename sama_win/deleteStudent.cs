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
    public partial class deleteStudent : Form
    {
        public deleteStudent()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Student where Tno like '" + txt_search.Text + "%'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show(" آیا از حذف دانشجو مطمئن هستید؟ ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string ctext1 = "delete from Student where Stno = '" + textBox1.Text + "'", ctext2 = "delete from STC where Stno = '" + textBox1.Text + "'";
                    try
                    {
                        OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                        con1.Open();
                        OleDbCommand c1 = new OleDbCommand();
                        c1.Connection = con1;
                        c1.CommandText = ctext1;
                        c1.ExecuteNonQuery();
                        con1.Close();
                        con1.Open();
                        c1.CommandText = ctext2;
                        c1.ExecuteNonQuery();
                        con1.Close();
                        MessageBox.Show(" دانشجو و درس های آن با موفقیت حذف شدند ");
                        OleDbConnection con2 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                        con2.Open();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from Student", con2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt.DefaultView;
                        con2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" :مشکل در حذف دانشجو \n " + ex.Message);
                    }
                }
            }
        }

        private void deleteStudent_Load(object sender, EventArgs e)
        {
            OleDbConnection con2 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con2.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Student", con2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con2.Close();
        }
    }
}
