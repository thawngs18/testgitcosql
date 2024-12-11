using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace test
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new StudentDBEntities()) // StudentDBEntities là tên DbContext bạn đã tạo
            {
                var students = context.Students.ToList(); // Lấy tất cả sinh viên từ bảng Students
                dataGridView1.DataSource = students; // Hiển thị lên DataGridView
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new StudentDBEntities())
            {
                var student = new Student
                {
                    Name = textBox2.Text,
                    Age = int.Parse(textBox3.Text)
                };
                context.Students.Add(student); // Thêm sinh viên mới vào context
                context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                MessageBox.Show("Added successfully!");
                button4.PerformClick(); // Làm mới DataGridView
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                using (var context = new StudentDBEntities())
                {
                    var student = context.Students.SingleOrDefault(s => s.Id == id);
                    if (student != null)
                    {
                        student.Name = textBox2.Text;
                        student.Age = int.Parse(textBox3.Text);
                        context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                        MessageBox.Show("Updated successfully!");
                        button4.PerformClick(); // Làm mới DataGridView
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                using (var context = new StudentDBEntities())
                {
                    var student = context.Students.SingleOrDefault(s => s.Id == id);
                    if (student != null)
                    {
                        context.Students.Remove(student); // Xóa sinh viên khỏi context
                        context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                        MessageBox.Show("Deleted successfully!");
                        button4.PerformClick(); // Làm mới DataGridView
                    }
                }
            }
            }
        }
}
