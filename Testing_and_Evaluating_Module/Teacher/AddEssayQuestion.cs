using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Testing_and_Evaluating_Module.Teacher
{
    public partial class AddEssayQuestion : Form
    {
        int ID = 0;

        public AddEssayQuestion()
        {
            InitializeComponent();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (txtQuestion.Text != "" && txtAnswer.Text != "" && txtMarks.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Teacher_Add_Essay_Question(SubjectCode,Grade,Question,Answer,Allocated_Marks)VALUES('"+ddlSubject .Value +"','"+ddlGrade .Value +"','"+txtQuestion .Text .Trim ()+"','"+txtAnswer .Text .Trim ()+"','"+txtMarks .Text .Trim ()+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                //DisplayData();
                lblMsg.Text = "Record Inserted Successsfully";
            }
            else
            {
                if (txtQuestion.Text == "")
                {
                    lblMsg.Text = "Please Insert a question Before Add";
                }
                else if (txtAnswer.Text == "")
                {
                    lblMsg.Text = "Please insert Answer Before Add";
                }
                else if (txtMarks.Text == "")
                {
                    lblMsg.Text = "Please insert Marks before Add";
                }
            }            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //public void DisplayData()
        //{
        //    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT  QuestionID,SubjectCode,Grade,Question,Answer,Allocated_Marks FROM Teacher_Add_Essay_Question ", conn);
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    sda.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    conn.Close();
        //}

        private void AddEssayQuestion_Load(object sender, EventArgs e)
        {
            //DisplayData();
        }

        //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        //    ddlSubject.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
        //    ddlGrade.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
        //    txtQuestion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        //    txtAnswer .Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        //    txtMarks.Text  =dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            
        //}

        //private void btnUpdateQuestion_Click(object sender, EventArgs e)
        //{

        //    if (txtQuestion.Text != "" && txtAnswer.Text!= "" && txtMarks .Text != "")
        //    {
        //        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("update Teacher_Add_Essay_Question set SubjectCode='" + ddlSubject.Value + "',Grade='" + ddlGrade.Value + "',Question='" + txtQuestion.Text.Trim() + "' ,Answer='"+txtAnswer .Text .Trim ()+"',Allocated_Marks='"+txtMarks .Text .Trim ()+"' WHERE QuestionID= '" + ID + "'", conn);
        //        cmd.ExecuteNonQuery();
        //        conn.Close();
        //        clearAll();
        //        DisplayData();
        //        lblMsg.Text = "Record Inserted Successsfully";

        //    }
        //    else
        //    {
        //        lblMsg.Text = "Please Select Record before Update";
        //    }
        //}

        public void clearAll()
        {
            ddlSubject.Value = Convert.ToInt32("1");
            ddlGrade.Value = Convert.ToInt32("1");
            txtQuestion.Text = "";
            txtAnswer.Text = "";
            txtMarks.Text = "";
            ID = 0;
            lblMsg.Text = "";

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddQuestion aq = new AddQuestion();
            this.Hide();
            aq.Show();
        }

        private void ddlGrade_ValueChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }

    }
}
