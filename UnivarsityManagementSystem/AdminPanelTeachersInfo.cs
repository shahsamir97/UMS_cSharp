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
    public partial class AdminPanelTeachersInfos : Form
    {
        public AdminPanelTeachersInfos()
        {
            InitializeComponent();
        }

        private void AdminPanelTeachersInfo_Load(object sender, EventArgs e)
        {
            populateDataGridView();
        }
        void populateDataGridView()
        {
            var teacherslist = context.UserInfoes.Where(u => u.u_type == "Teacher").ToList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = teacherslist;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();

        }

        //Other class objects 
        TeacherTable teachersModel = new TeacherTable();
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        private void addBtn_Click(object sender, EventArgs e)
        {
            UserInfo userModel;
            userModel = new UserInfo();
            userModel.TeacherTable = new TeacherTable();
            if (nameTxt.Text != "" && passwordTxt.Text != "")
            {
                userModel.u_name = nameTxt.Text;
                userModel.u_password = passwordTxt.Text;
                userModel.TeacherTable.EMAIL = emailTxt.Text;
                userModel.u_type = "Teacher";
                context.UserInfoes.Add(userModel);
                context.SaveChanges();
                populateDataGridView();
                this.dataGridView1.Refresh();

                //clearing fields
                nameTxt.Text = passwordTxt.Text = emailTxt.Text = "";
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
                this.dataGridView1.Update();
                dataGridView1.Refresh();
                context.SaveChanges();
                MessageBox.Show("Record Updated");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var teacher = context.UserInfoes.Where(u=>u.u_type=="Teacher").ToList();
            if (searchTxt.Text != "")
            {
                teacher=teacher.Where(d => d.u_name.Contains(searchTxt.Text)).ToList();
                dataGridView1.DataSource = teacher;
            }
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
                var deletingTeacher = context.UserInfoes.FirstOrDefault(tid => tid.ID == deletingId);
                if (deletingTeacher == null)
                {
                    MessageBox.Show("Something went wrong!No data available for delete!Make sure you selected a Row to delete.");
                    return;
                }
              context.TeacherTables.Remove(deletingTeacher.TeacherTable);
                context.UserInfoes.Remove(deletingTeacher);
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
            this.populateDataGridView();
        }

        private void searchTxt_Click(object sender, EventArgs e)
        {
            searchTxt.ForeColor = Color.Black;
            searchTxt.Text = "";
        }
    }
}
