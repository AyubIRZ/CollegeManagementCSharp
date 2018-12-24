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
    public partial class selectCourse : Form
    {
        public selectCourse()
        {
            InitializeComponent();
        }
        public string stno = "";
        private void selectCourse_Load(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Course", con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
            OleDbConnection con2 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con2.Open();
            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from STC where Stno='"+stno+"'", con2);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1.DefaultView;
            con2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                if (MessageBox.Show(" آیا از اخذ درس مطمئن هستید؟ ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                    con1.Open();
                    OleDbCommand c1 = new OleDbCommand();
                    c1.CommandText = "select * from STC where Stno='" + stno + "' and Tno='" + textBox5.Text + "' and Cno='" + textBox1.Text + "'";
                    c1.Connection = con1;
                    OleDbDataReader data = c1.ExecuteReader();
                    if (data.Read())
                    {
                        MessageBox.Show(" !شما نمیتوانید این درس را اخذ کنید ");
                    }
                    else
                    {
                        con1.Close();
                        string ctext1 = "insert into STC(Stno,Tno,Cno,Term) values('" + stno + "','" + textBox5.Text + "','" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                        try
                        {
                            OleDbConnection con11 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                            con11.Open();
                            OleDbCommand c11 = new OleDbCommand();
                            c11.Connection = con11;
                            c11.CommandText = ctext1;
                            c11.ExecuteNonQuery();
                            con11.Close();
                            MessageBox.Show(" درس با موفقیت اخذ شد ");
                            OleDbConnection con3 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                            OleDbDataAdapter da1 = new OleDbDataAdapter("select * from STC where Stno='" + stno + "'", con3);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                            dataGridView2.DataSource = dt1.DefaultView;
                            con3.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(" :مشکل در اخذ درس \n " + ex.Message);
                        }
                    }
                }
            }
            else
                MessageBox.Show(" لطفا تمام اطلاعات خواسته شده را وارد کنید ");
        }
    }
}
