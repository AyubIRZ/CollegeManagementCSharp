using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace sama_win
{
    public partial class newMaster : Form
    {
        public newMaster()
        {
            InitializeComponent();
        }

        private void newMaster_Load(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Teacher",con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            con1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cstring = "insert into Teacher values('" + textBox1.Text + "','" +textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+ textBox5.Text+"','"+ textBox6.Text+"')";
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbCommand c1 = new OleDbCommand();
            c1.Connection = con1;
            c1.CommandText = cstring;
            try
            {
                c1.ExecuteNonQuery();
                MessageBox.Show(" استاد جدید با موفقیت افزوده شد ");
                OleDbConnection con2 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                con2.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Teacher", con2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con2.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" مشکل در افزودن استاد جدید: \n"+ex.Message);
            }
            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
