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


namespace Testing_and_Evaluating_Module.Admin
{
    public partial class AddSubject : Form
    {
        int ID = 0;
        public AddSubject()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (txtSubjectCode .Text !="" && txtSubjectName .Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Admin_Add_Subject (Subject_Code,Subject_Name) values ('"+txtSubjectCode .Text.Trim ()+"','"+txtSubjectName .Text .Trim ()+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                display_Data();
                lblMsg.Text = "Record Inserted Successsfully";
            }
            else
            {
                if (txtSubjectCode.Text == "")
                {
                    lblMsg.Text = "Please Enter a Subject Code Before Add";
                }
                else if (txtSubjectName.Text == "")
                {
                    lblMsg.Text = "Please Enter a Subject Name Before Add";
                }
                
            }

        }

        public void display_Data()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Subjec_ID as ID,Subject_Code,Subject_Name from Admin_Add_Subject", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GridAddSubject.DataSource = dt;          
            conn.Close();
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Admin_Add_Subject  where Subjec_ID='"+ID+"'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();              
                clearAll();
                display_Data();
                lblMsg.Text = "Deleted Successfully!";

            }
            else
            {
                lblMsg.Text = "Please select a record before delete";
            }
        }


        public void clearAll()
        {
            txtSubjectCode.Text = "";
            txtSubjectName.Text = "";           
            ID = 0;
            lblMsg.Text = "";

        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            if (txtSubjectCode.Text != "" && txtSubjectName.Text != "" )
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Admin_Add_Subject set Subject_Code='" + txtSubjectCode.Text.Trim() + "',Subject_Name='" + txtSubjectName.Text.Trim() + "' WHERE Subjec_ID= '" + ID + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                display_Data();
                lblMsg.Text = "Record Updated Successsfully";

            }
            else
            {
                lblMsg.Text = "Please Select Record before Update";
            }
        }

        private void GridAddSubject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            display_Data();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin_Home_Page ahp = new Admin_Home_Page();
            this.Hide();
            ahp.Show();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Conducting_Exam ce = new Conducting_Exam();
            this.Hide();
            ce.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTeacher at = new AddTeacher();
            this.Hide();
            at.Show();
        }

        private void GridAddSubject_MouseClick(object sender, MouseEventArgs e)
        {
            ID = Convert.ToInt32(GridAddSubject.SelectedRows[0].Cells[0].Value.ToString());
            txtSubjectCode.Text = GridAddSubject.SelectedRows[0].Cells[1].Value.ToString();
            txtSubjectName.Text = GridAddSubject.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }

    }
}
