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
    public partial class education : Form
    {
        public string uname = "", ucode = "";

        private void education_Load(object sender, EventArgs e)
        {
            textBox1.Text = uname;
            textBox2.Text = ucode;
        }

        private void دانشجوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newMaster nm = new newMaster();
            nm.ShowDialog();
        }

        private void استادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newStudent ns = new newStudent();
            ns.ShowDialog();
        }

        private void درسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourse nc = new newCourse();
            nc.ShowDialog();
        }

        private void استادToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteMaster dm = new deleteMaster();
            dm.ShowDialog();
        }

        private void دانشجوToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteStudent ds = new deleteStudent();
            ds.ShowDialog();
        }

        private void درسToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteCourse dc = new deleteCourse();
            dc.ShowDialog();
        }

        private void استادToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editMaster em = new editMaster();
            em.ShowDialog();
        }

        private void دانشجوToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editStudent es = new editStudent();
            es.ShowDialog();
        }

        private void درسToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            editCourse ec = new editCourse();
            ec.ShowDialog();
        }

        public education()
        {
            InitializeComponent();
        }
    }
}
