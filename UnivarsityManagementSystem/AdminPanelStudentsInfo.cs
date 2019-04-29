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
    public partial class AdminPanelStudentsInfo : Form
    {
        public AdminPanelStudentsInfo()
        {
            InitializeComponent();
        }

        private void studentInfoAdmin_Load(object sender, EventArgs e)
        {
            populateDataGridView();
        }

       //Database Object
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        void populateDataGridView()
        {
            var studentlist = context.UserInfoes.Where(u => u.u_type == "Student").ToList();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = studentlist;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Database Table Obejcts
            UserInfo studentModel;
            studentModel = new UserInfo();
            studentModel.student = new student();
            //
            if (nameTxt.Text != "" && passwordTxt.Text != "" && email.Text!=" " && comboBox1.SelectedItem.ToString()!="")
            {
                studentModel.u_name = nameTxt.Text;
                studentModel.u_password = passwordTxt.Text;
                studentModel.u_type = "Student";
                studentModel.student.email = emailTxt.Text;
                studentModel.student.int_stu = comboBox1.SelectedItem.ToString();
                context.UserInfoes.Add(studentModel);
                context.SaveChanges();
                populateDataGridView();

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
            var studentlist = context.UserInfoes.Where(u => u.u_type == "Student").ToList();
            if (searchTxt.Text != "")
            {
                studentlist = studentlist.Where(d => d.u_name.Contains(searchTxt.Text)).ToList();
                dataGridView1.DataSource = studentlist;
            }
            dataGridView1.DataSource = studentlist;
            dataGridView1.Refresh();
        }

        //variable for below functions
            bool isCellSelected = false;
            string deleteStudentID;
            private void deleteBtn_Click(object sender, EventArgs e)
            {
                if (isCellSelected == true)
                {
                    int deletingId = Int32.Parse(deleteStudentID);
                    var deletingStudent = context.UserInfoes.FirstOrDefault(tid => tid.ID == deletingId);
                    if (deletingStudent == null)
                    {
                        MessageBox.Show("Something went wrong!No data available for delete!Make sure you selected a Row to delete.");
                        return;
                    }
                    context.students.Remove(deletingStudent.student);
                    context.UserInfoes.Remove(deletingStudent);
                    context.SaveChanges();

                    populateDataGridView();
                    dataGridView1.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No Row selected!");
                }
            }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            populateDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isCellSelected = true;
                deleteStudentID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void searchTxt_Click(object sender, EventArgs e)
        {
            searchTxt.ForeColor = Color.Black;
            searchTxt.Text = "";
        }
    }
}
