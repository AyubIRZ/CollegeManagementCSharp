using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sama_win
{
    public partial class student : Form
    {
        public string stname="",stno="",stfield="";

        private void گزارشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showReportStudent sr = new showReportStudent();
            sr.Stno_current = textBox2.Text;
            sr.ShowDialog();
        }

        private void انتخابواحدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectCourse sc = new selectCourse();
            sc.stno = textBox2.Text;
            sc.ShowDialog();
        }

        public student()
        {
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            textBox1.Text = stname;
            textBox2.Text = stno;
            textBox3.Text = stfield;
        }
    }
}
