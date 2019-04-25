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
            // TODO: This line of code loads data into the 'uMS_DatabaseDataSet4.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.uMS_DatabaseDataSet4.Student);
        }

        //Other class objects 
        Student studentModel = new Student();
        UMS_DatabaseEntities context = new UMS_DatabaseEntities();

        void populateDataGridView()
        {
            dataGridView1.DataSource = context.Students.ToList<Student>();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "" && passwordTxt.Text != "")
            {
                studentModel.student_name = nameTxt.Text;
                studentModel.student_password = passwordTxt.Text;

                context.Students.Add(studentModel);
                context.SaveChanges();
                context.SaveChangesAsync();
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
                this.studentTableAdapter.Update(this.uMS_DatabaseDataSet4.Student);
                dataGridView1.Refresh();
                context.SaveChanges();
                MessageBox.Show("Record Updated");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var students = context.Students.ToList();
            if (searchTxt.Text != "")
            {
                students = students.Where(d => d.student_name.Contains(searchTxt.Text)).ToList();
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = students;
            dataGridView1.Refresh();
        }

        //variable
        bool isCellSelected = false;
        string deleteStudentID;
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (isCellSelected == true)
            {
                int deletingId = Int32.Parse(deleteStudentID);
                var deletingStudent = context.Students.FirstOrDefault(sid => sid.ID == deletingId);
                if (deletingStudent == null)
                {
                    MessageBox.Show("Something went wrong!No data available for delete!Make sure you selected a Row to delete.");
                    return;
                }
                context.Students.Remove(deletingStudent);
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
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isCellSelected = true;
                deleteStudentID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}
