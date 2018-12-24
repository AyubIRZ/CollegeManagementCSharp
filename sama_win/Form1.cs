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
using sama_win;

namespace sama
{
    public partial class Form1 : Form
    {
        public OleDbDataReader reader(string command_text)
        {
            OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
            con1.Open();
            OleDbCommand c1 = new OleDbCommand();
            c1.CommandText = command_text;
            c1.Connection = con1;
            OleDbDataReader dr = c1.ExecuteReader();
            return dr;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "استاد")
            {
                OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                con1.Open();
                OleDbCommand c1 = new OleDbCommand();
                c1.CommandText = "select * from Teacher where Tno='" + txt_username.Text + "' and Tpass='" + txt_password.Text + "'";
                c1.Connection = con1;
                OleDbDataReader data = c1.ExecuteReader();
                if (data.Read())
                {
                    master f = new master();
                    f.Tno = data.GetValue(0).ToString();
                    f.Tname = data.GetValue(1).ToString()+" "+data.GetValue(2).ToString();
                    f.Tfield = data.GetValue(3).ToString();
                    f.Show();
                    
                }
                else
                {
                    MessageBox.Show(" !نام کاربری یا کلمه ی عبور با نوع دسترسی اشتباه است", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            
            if (comboBox1.SelectedItem.ToString() == "دانشجو")
            {
                OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                con1.Open();
                OleDbCommand c1 = new OleDbCommand();
                c1.CommandText = "select * from Student where Stno='" + txt_username.Text + "' and Stpass='" + txt_password.Text + "'";
                c1.Connection = con1;
                OleDbDataReader data = c1.ExecuteReader();
                if (data.Read())
                {
                    student s = new student();
                    s.stno = data.GetValue(0).ToString();
                    s.stname = data.GetValue(1).ToString()+" "+ data.GetValue(2).ToString();
                    s.stfield = data.GetValue(3).ToString();
                    s.Show();
                    

                }
                else
                {
                    MessageBox.Show(" !نام کاربری یا کلمه ی عبور با نوع دسترسی اشتباه است", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (comboBox1.SelectedItem.ToString() == "آموزش")
            {
                OleDbConnection con1 = new OleDbConnection("provider=Microsoft.ace.oledb.12.0;data source=university.accdb");
                con1.Open();
                OleDbCommand c1 = new OleDbCommand();
                c1.CommandText = "select * from Users where Ucode='" + txt_username.Text + "' and Upass='" + txt_password.Text + "'";
                c1.Connection = con1;
                OleDbDataReader data = c1.ExecuteReader();
                if (data.Read())
                {
                    education ed = new education();
                    ed.ucode = data.GetValue(0).ToString();
                    ed.uname = data.GetValue(2).ToString();
                    ed.Show();
                    

                }
                else
                {
                    MessageBox.Show(" !نام کاربری یا کلمه ی عبور با نوع دسترسی اشتباه است", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
