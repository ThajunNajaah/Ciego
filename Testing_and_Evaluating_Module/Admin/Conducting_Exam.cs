using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace Testing_and_Evaluating_Module.Admin
{
    public partial class Conducting_Exam : Form
    {
        private DateTimePicker timePicker;
       
        public Conducting_Exam()
        {
            //InitializetimePicker();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_Home_Page ahp = new Admin_Home_Page();
            this.Hide();
            ahp.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
       
        //private void InitializetimePicker()
        //{
        //    timePicker = new DateTimePicker();
        //    timePicker.Format = DateTimePickerFormat.Time;
        //    timePicker.ShowUpDown = true;
        //    timePicker.Location = new Point(10, 10);
        //    timePicker.Width = 100;
        //    Controls.Add(timePicker);
        //}

        private void Conducting_Exam_Load(object sender, EventArgs e)
        {
            this.Show();
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Admin_Exam_Schedule (Grade,Subject,Date,StartTime,EndTime) VALUES('"+ddlGrade.Value +"','"+ ddlSubjects .SelectedItem +"','"+dateTimePicker1 .Value+"','"+dateTimePicker2 .Value +"','"+dateTimePicker3.Value+"')",conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //if (dateTimePicker2.Value == dateTimePicker3.Value)
            //{
            //    lblMsg.Text = "Please select a duration for exam";
            //}
            //if (ddlSubjects.SelectedItem == "")
            //{
            //    lblMsg.Text = " Please select a subject before saving it";
            //}

            lblMsg.Text = "Saved Successsfully";


            
        }

        private void ddlGrade_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTeacher at = new AddTeacher();
            this.Hide();
            at.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddSubject addSub = new AddSubject();
            this.Hide();
            addSub.Show();

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }
    }
}
