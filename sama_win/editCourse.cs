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
    public partial class editCourse : Form
    {
        public editCourse()
        {
            InitializeComponent();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Course where Cno like '" + txt_search.Text + "%'", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }
        public string current_course;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            current_course = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (MessageBox.Show(" آیا از ویرایش درس مطمئن هستید؟ ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string ctext1 = "update Course set Cno = '" + textBox1.Text + "',Cname = '" + textBox2.Text + "',Ctype = '" + textBox3.Text + "',Cunit = '" + textBox4.Text + "',Tno = '" + textBox5.Text + "' where Cno='" + current_course + "'";
                    string ctext2 = "update STC set Cno = '" + textBox1.Text + "',Tno='"+textBox5.Text+"' where Cno='" + current_course + "'";
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
                        MessageBox.Show(" درس با موفقیت ویرایش شد ");
                        OleDbConnection con2 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                        con2.Open();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from Course", con2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt.DefaultView;
                        con2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" :مشکل در ویرایش درس \n " + ex.Message);
                    }
                }
            }
            else
                MessageBox.Show(" لطفا تمام اطلاعات خواسته شده را وارد کنید ");
        }

        private void editCourse_Load(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Course", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }
    }
}
