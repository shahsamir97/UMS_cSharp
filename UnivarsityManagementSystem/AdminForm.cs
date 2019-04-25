using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnivarsityManagementSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AdminPanelStudentsInfo studentinfo = new AdminPanelStudentsInfo();
            studentinfo.TopLevel = false;
            studentinfo.AutoScroll = true;
            studentinfo.FormBorderStyle = FormBorderStyle.None;
            studentinfo.Dock = DockStyle.Fill;
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(studentinfo);
            studentinfo.Show();
        }
    }
}
