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
    public partial class master : Form
    {
        public string Tname = "", Tno = "", Tfield = "";

        private void انتخابواحدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showCourseMaster sc = new showCourseMaster();
            sc.Tno_current = textBox2.Text;
            sc.ShowDialog();

        }

        private void لیستدانشجویانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showListMaster sl = new showListMaster();
            sl.Tno_current = textBox2.Text;
            sl.ShowDialog();
        }

        private void درجنمرهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addMarkMaster am = new addMarkMaster();
            am.Tno_current = textBox2.Text;
            am.ShowDialog();
        }

        private void master_Load(object sender, EventArgs e)
        {
            textBox1.Text = Tname;
            textBox2.Text = Tno;
            textBox3.Text = Tfield;
        }

        public master()
        {
            InitializeComponent();
        }
    }
}
