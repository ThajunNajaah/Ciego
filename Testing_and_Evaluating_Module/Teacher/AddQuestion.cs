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
using System.Data.Sql;

namespace Testing_and_Evaluating_Module.Teacher
{
    public partial class AddQuestion : Form
    {
        int ID = 0;
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void AddQuestion_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        public void DisplayData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT  QuestionID,SubjectCode,Grade,Question,Option1,Option2,Option3,Option4,CorrectOption FROM Teacher_Add_Question ", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Teacher_Home_Page thp = new Teacher_Home_Page();
            this.Hide();
            thp.Show();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            ddlSubject.Value =Convert .ToInt32 (dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            ddlGrade.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            txtQuestion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtOption1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtOption2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtOption3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtOption4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtCorrectOption.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
           
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (txtQuestion.Text  !="" && txtOption1.Text  !="" && txtOption2.Text !="" && txtOption3 .Text!="" && txtOption4 .Text !="" && txtCorrectOption .Text !="")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Teacher_Add_Question(SubjectCode,Grade,Question,Option1,Option2,Option3,Option4,CorrectOption) VALUES('" +ddlSubject .Value + "','" +ddlGrade .Value + "','" +txtQuestion .Text .Trim ()+ "','" +txtOption1 .Text .Trim ()+ "','" +txtOption2 .Text .Trim ()+ "','" +txtOption3 .Text .Trim ()+ "','"+txtOption4 .Text .Trim ()+"','"+txtCorrectOption .Text .Trim ()+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                DisplayData();               
                lblMsg.Text = "Record Inserted Successsfully";
            }
            else
            {
                if (txtQuestion.Text == "")
                {
                    lblMsg.Text = "Please Insert a question Before Add";
                }
                else if (txtOption1.Text == "")
                {
                    lblMsg.Text = "Please insert Option 1 Before Add";
                }
                else if (txtOption2.Text == "")
                {
                    lblMsg.Text = "Please insert Option 2 before Add";
                }
                else if (txtOption3.Text == "")
                {
                    lblMsg.Text = "Please insert Option 3 before Add";
                }
                else if (txtOption4.Text == "")
                {
                    lblMsg.Text = "Please insert Option 4 before Add";
                }
                else if (txtCorrectOption.Text == "")
                {
                    lblMsg.Text = "Please insert Option 3 before Add";
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            if (txtQuestion.Text != "" && txtOption1.Text != "" && txtOption2.Text != "" && txtOption3.Text != "" && txtOption4.Text != "" && txtCorrectOption.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Teacher_Add_Question set SubjectCode='" +ddlSubject .Value + "',Grade='" +ddlGrade.Value + "',Question='"+txtQuestion.Text.Trim ()+"' , Option1='" +txtOption1 .Text .Trim ()+ "',Option2='" +txtOption2 .Text .Trim ()+ "',Option3 ='" +txtOption3 .Text .Trim ()+ "',Option4='"+txtOption4 .Text .Trim ()+"',CorrectOption='"+txtCorrectOption .Text.Trim ()+"' WHERE QuestionID= '" + ID + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                DisplayData();
                lblMsg.Text = "Record Inserted Successsfully";

            }
            else
            {
                lblMsg.Text = "Please Select Record before Update";
            }
        }
        public void clearAll()
        {
            ddlSubject.Value = Convert.ToInt32("1000");
            ddlGrade.Value = Convert.ToInt32("1");
            txtQuestion.Text = "";
            txtOption1.Text = "";
            txtOption2.Text = "";
            txtOption3.Text = "";
            txtOption4.Text = "";
            txtCorrectOption.Text = "";
            ID = 0;
            lblMsg.Text = "";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEssayQuestion asq = new AddEssayQuestion();
            this.Hide();
            asq.Show();
        }

        private void txtCorrectOption_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddlGrade_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ddlSubject_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtOption4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOption3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOption2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOption1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
