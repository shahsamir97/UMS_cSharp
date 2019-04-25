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
    public partial class AdminPanelTeachersInfo : Form
    {
        public AdminPanelTeachersInfo()
        {
            InitializeComponent();
        }

        private void AdminPanelTeachersInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMS_DatabaseDataSet.Teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.uMS_DatabaseDataSet.Teacher);

        }
        void populateDataGridView()
        {
            dataGridView1.DataSource = context.Teachers.ToList<Teacher>();
        }

        //Other class objects 
        Teacher teachersModel = new Teacher();
        UserInfo userModel = new UserInfo();
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "" && passwordTxt.Text != "")
            {
                teachersModel.t_name = nameTxt.Text;
                teachersModel.t_email = emailTxt.Text;
                teachersModel
                context.Teachers.Add(teachersModel);

                context.SaveChanges();

                
                
                populateDataGridView();
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to save Changes", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                this.teacherTableAdapter.Update(this.uMS_DatabaseDataSet.Teacher);
                dataGridView1.Refresh();
                context.SaveChanges();
                MessageBox.Show("Record Updated");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var teacher = context.Teachers.ToList();
            if (searchTxt.Text != "")
            {
                teacher = teacher.Where(d => d.t_name.Contains(searchTxt.Text)).ToList();
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = teacher;
            dataGridView1.Refresh();
        }


        bool isCellSelected = false;
        string deleteTeacherID;
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (isCellSelected == true)
            {
                int deletingId = Int32.Parse(deleteTeacherID);
                var deletingTeacher = context.Teachers.FirstOrDefault(tid => tid.ID == deletingId);
                if (deletingTeacher == null)
                {
                    MessageBox.Show("Something went wrong!No data available for delete!Make sure you selected a Row to delete.");
                    return;
                }
                context.Teachers.Remove(deletingTeacher);
                context.SaveChanges();

                populateDataGridView();
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("No Row selected!");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isCellSelected = true;
                deleteTeacherID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Refresh();
        }
    }
}
