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
            setPanelviews(studentinfo);
        }

        private void teachersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPanelTeachersInfos teachersInfo = new AdminPanelTeachersInfos();
            setPanelviews(teachersInfo);
        }

       private void setPanelviews(Form e)
        {
            this.panel2.Controls.Clear();
            e.TopLevel = false;
            e.AutoScroll = true;
            e.FormBorderStyle = FormBorderStyle.None;
            e.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(e);
            e.Show();
        }
    }
}
