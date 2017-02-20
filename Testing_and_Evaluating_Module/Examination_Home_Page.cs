using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Testing_and_Evaluating_Module.Admin;
using Testing_and_Evaluating_Module.Teacher;
using Testing_and_Evaluating_Module.Student;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;


namespace Testing_and_Evaluating_Module
{
    public partial class Examination_Home_Page : Form
    {
        SqlDataReader rd;
        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();


        public Examination_Home_Page()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtPassword.MaxLength = 4;
        }           

        private void lnkExamination_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EBlind_Learning_Module learn = new EBlind_Learning_Module();
            learn.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CiegoUser where USER_ID ='" + txtUserID.Text.Trim() + "'and Password ='" + txtPassword.Text.Trim() + "'", conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if(rd["USER_ID"].ToString () == txtUserID .Text && rd["Password"].ToString ()==txtPassword .Text && rd["Category"].ToString() =="Admin")
                {
                    Admin_Home_Page ahp = new Admin_Home_Page();
                    this.Hide();
                    ahp.Show();
                }
                else if (rd["USER_ID"].ToString() == txtUserID.Text && rd["Password"].ToString() == txtPassword.Text && rd["Category"].ToString() == "Teacher")
                {
                    Teacher_Home_Page thp = new Teacher_Home_Page();
                    this.Hide();
                    thp.Show();
                }
                else if (rd["USER_ID"].ToString() == txtUserID.Text && rd["Password"].ToString() == txtPassword.Text && rd["Category"].ToString() == "Student")
                {
                    Student_Home_Page shp = new Student_Home_Page();
                    this.Hide();
                    shp.Show();
                }
                else if (rd["USER_ID"].ToString() == txtUserID.Text && rd["Password"].ToString() == txtPassword.Text && rd["Category"].ToString() == "Blind")
                {
                    VoiceControlMain shp = new VoiceControlMain();
                    this.Hide();
                    shp.Show();
                }
                else
                {
                    lblMsg.Text = "Invalid UserID and Password!";
                }
                saveHistory();
            }
        }
        private void saveHistory()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into Student_LoginHistory(UserID)values('"+Convert .ToInt32 (txtUserID .Text .Trim ())+"')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }     

        private void Examination_Home_Page_Load(object sender, EventArgs e)
        {


            txtPassword.Enabled = false;
            // Construct an image object from a file in the local directory.
            // ... This file must exist in the solution.
            Image image = Image.FromFile("H:\\QuestionBank\\Login\\Login.jpg");
            // Set the PictureBox image property to this image.
            // ... Then, adjust its height and width properties.
            pictureBox2.Image = image;
            pictureBox2.Height = image.Height;
            pictureBox2.Width = image.Width;

            this.WindowState = FormWindowState.Maximized;
            this.Show();
            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.Speak("Hi , You are Welcome to the examination module, Please give user ID and Password to login the module! ");
            clist.Add(new String[] { "UserID", "Password","login","cancel"});

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }




        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String s = e.Result.Text.ToString();

            if (s == "UserID")
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();

              
                


            }
            else if (s == "Password")
            {
                this.Hide();
                Instructions ins = new Instructions();
                ins.MdiParent = this.MdiParent;
                ins.WindowState = FormWindowState.Maximized;
                ins.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);


            }
            else if (s == "login")
            {
                this.Hide();
                EBlind_Learning_Module ins = new EBlind_Learning_Module();
                ins.MdiParent = this.MdiParent;
                ins.WindowState = FormWindowState.Maximized;
                ins.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);


            }


            else if (s == "cancel")
            {
                this.Hide();
                Examination_Home_Page elm = new Examination_Home_Page();
                elm.MdiParent = this.MdiParent;
                elm.WindowState = FormWindowState.Maximized;
                elm.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);

            }

        }
        
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
         
        private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = true;
            txtPassword.Focus();
        }
    }
}
