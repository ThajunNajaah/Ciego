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
    public partial class AddTeacher : Form
    {
        int ID = 0;
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            display_Data();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && ddlSubjects.SelectedItem != "" && txtEmail.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Admin_Add_Teacher(First_Name,Last_Name,subject,E_mail,Home,Mobile) VALUES('" + txtFirstName.Text.Trim() + "','" + txtLastName.Text.Trim() + "','" + ddlSubjects.SelectedItem + "','" + txtEmail.Text.Trim() + "','" + txtHome.Text.Trim() + "','" + txtMobile.Text.Trim() + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                display_Data();
                lblMsg.Text = "Record Inserted Successsfully";
            }
            else
            {
                if (txtFirstName.Text == "")
                {
                    lblMsg .Text ="Please select a First Name Before Add";
                }
                else if(txtLastName .Text == ""){
                    lblMsg.Text = "Please select a Last Name Befor Add";
                }
                else if (ddlSubjects.SelectedItem == "")
                {
                    lblMsg .Text ="Please select a Subject before Add";
                }
                else if (txtEmail .Text == ""){
                    lblMsg.Text = "Please select an Email before Add";
                }
            }

        }

        public void display_Data()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Add_Teacher_ID,First_Name,Last_Name,subject,E_mail ,Home ,Mobile  from Admin_Add_Teacher", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();    
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && ddlSubjects.SelectedItem != "" && txtEmail.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Admin_Add_Teacher set First_Name='" + txtFirstName.Text.Trim() + "',Last_Name='" + txtLastName.Text.Trim() + "',subject='" + ddlSubjects.SelectedItem + "' , E_mail='" + txtEmail.Text.Trim() + "',Home='" + txtHome.Text.Trim() + "',Mobile ='" + txtMobile.Text.Trim() + "' WHERE Add_Teacher_ID= '"+ID+"'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                clearAll();
                display_Data();
                lblMsg.Text = "Record Inserted Successsfully";

            }
            else
            {
                lblMsg.Text = "Please Select Record before Update";
            }
        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete Admin_Add_Teacher where Add_Teacher_ID= '"+ID+"'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMsg.Text = "Deleted Successfully!";
                display_Data();
                clearAll();

            }
            else {
                lblMsg.Text = "Please select a record before delete";
            }
                      
        }

        public void clearAll()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtHome.Text = "";
            txtMobile.Text = "";
            ddlSubjects.SelectedItem = "";
            ID = 0;
            lblMsg.Text = "";

        }
        public void mouseClick()
        {

            
        }
        public void saveNewData()
        {
          
            //dataGridView1.SelectedRows[0].Cells[0].Value.ToString() = txtFirstName.Text;

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            txtFirstName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ddlSubjects.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtHome.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtMobile.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //ddlSubjects.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //txtHome.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //txtMobile.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddSubject addSub = new AddSubject();
            this.Hide();
            addSub.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }

        private void ddlSubjects_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel9_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }
    }
}
