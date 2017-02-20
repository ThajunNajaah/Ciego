using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using Testing_and_Evaluating_Module.Student;
using System.Data;
using System.Data.SqlClient ;


namespace Testing_and_Evaluating_Module
{
    public partial class VoiceControlMain : Form
    {
        
        int score = 0;
        public static int incQuestion = 1;
        public static int currQue = 1;
        Boolean ispassedExam = false;
        Boolean ispassedInstruction = false;
        Boolean ispassedQuiz1 = false;
        Boolean ispassedQuiz2 = false;
        Boolean ispassedQuiz3 = false;
        Boolean ispassedQuiz4 = false;
        Boolean ispassedQuiz5 = false;
        Boolean ispassedQuiz6 = false;
        Boolean ispassedQuiz7 = false;
        Boolean ispassedQuiz8 = false;
        Boolean ispassedQuiz9 = false;
        Boolean ispassedQuiz10 = false;
 
        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        ProcessStartInfo pr = new ProcessStartInfo();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                      

        public VoiceControlMain()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VoiceControlMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'e_Blind_Learning_SystemDataSet.Teacher_Add_Question' table. You can move, or remove it, as needed.
            this.teacher_Add_QuestionTableAdapter.Fill(this.e_Blind_Learning_SystemDataSet.Teacher_Add_Question);
            clist.Add(new String[] { "what is the current time", "examination", "continue","ok", "One","Two","Three","Four","skip", "next", "Previous", "edit " });

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
            richTextBox1.Text = "";

           if (s == "examination" )
            {
                
                Student_Home_Page shp = new Student_Home_Page();
                shp.MdiParent = this.MdiParent;
                shp.WindowState = FormWindowState.Maximized;
                shp.Show();
                ss.SpeakAsync("Hi Ciego you are welcome to our E-learning System.Please Say continue to going exam");
                ispassedExam = true;
              
             
            }
           else if (s == "continue" && ispassedExam)
            {
                Instructions ins = new Instructions();
                ins.MdiParent = this.MdiParent;
                ins.WindowState = FormWindowState.Maximized;
                ins.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Instructions ; 1. This Paper Contains 2 Parts ;  2. Part A contains 20 MCQ and Part B contains 5 Structured type questions  ;  3. Total duration of the Exam is 1 hour ;   4. The total marks obtainable for this exam is 100 ;  5. Marks allocated for Part A is 40, Part B is 60 ;  6. This is a closed book examination ;  7. Answer all question");
                ispassedInstruction = true;
               
            }

           
           else if (s == "ok" && ispassedInstruction)
           {
              
               Examination_MCQ em = new Examination_MCQ();
               em.MdiParent = this.MdiParent;
               em.WindowState = FormWindowState.Maximized;
               em.Show();              
               ss.SelectVoiceByHints(VoiceGender.Female);
               //GetQuestion(currQue);               

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 1 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    richTextBox1.Text = "Your First Question is: " + dr["Question"].ToString();
                    radioButton1.Text = "Option 1" + dr["Option1"].ToString();
                    radioButton2.Text = "Option 2" + dr["Option2"].ToString();
                    radioButton3.Text = "Option 3" + dr["Option3"].ToString();
                    radioButton4.Text = "Option 4" + dr["Option4"].ToString();
                }
                ss.SpeakAsync(richTextBox1.Text );
                ss.Speak(radioButton1.Text);
                ss.Speak(radioButton2.Text);
                ss.Speak(radioButton3.Text);
                ss.Speak(radioButton4.Text);
                this.Hide();
                ispassedQuiz1 = true;
                

          }

           else if (s == "One" && ispassedQuiz1)
           {
               radioButton1 .Checked = true ;
               Examination_MCQ em = new Examination_MCQ();               
               em.MdiParent = this.MdiParent;
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                em.save_details ();
                //ss.Speak("Your Answer saved successfully!"); 
                em.calculate_score ();
                this.Hide();
           }
           else if (s == "Two" && ispassedQuiz1)
           {
               radioButton2 .Checked = true ;
               Examination_MCQ em = new Examination_MCQ();               
                em.MdiParent = this.MdiParent;
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                em.save_details ();
                //ss.Speak("Your Answer saved successfully!"); 
                em.calculate_score ();
                this.Hide();
              
           }
           else if (s == "Three" && ispassedQuiz1)
           {
               radioButton3 .Checked = true ;
               Examination_MCQ em = new Examination_MCQ();               
               em.MdiParent = this.MdiParent;
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                em.save_details ();
                //ss.Speak("Your Answer saved successfully!"); 
                em.calculate_score ();
                this.Hide();
           }
           else if (s == "Four" && ispassedQuiz1)
           {
               radioButton4 .Checked = true ;
               Examination_MCQ em = new Examination_MCQ();   
                em.MdiParent = this.MdiParent;
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                em.save_details ();
                //ss.Speak("Your Answer saved successfully!"); 
                em.calculate_score ();
                this.Hide();
           }
           else if (s == "skip" && ispassedQuiz1)    
           {
               radioButton1 .Checked = false;
               radioButton2 .Checked = false;
               radioButton3 .Checked = false;
               radioButton4 .Checked = false;
               Examination_MCQ em = new Examination_MCQ();               
               em.MdiParent = this.MdiParent;
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);
                em.save_details ();
                //ss.Speak("Your Answer saved successfully!"); 
                em.calculate_score ();
                this.Hide();
           }

               //******************************************************finished Quiz1**********************************************//

               //*****************************************************Start Second Question******************************************//

           else if (s == "next")
           {
               //Examination_MCQ em = new Examination_MCQ();
               //em.MdiParent = this.MdiParent;
               //em.WindowState = FormWindowState.Maximized;
               //em.Show();
               Examination_MCQ mcq = new Examination_MCQ();
               mcq.btnNext_Click(null, null);
               ss.SelectVoiceByHints(VoiceGender.Female);
               GetQuestion(currQue);
               this.Hide();
           }
        


            
         richTextBox1.Text += e.Result.Text.ToString();

        }
       
        private void GetQuestion(int no)
        {

            if (incQuestion < 9)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                string str = "Select * from Teacher_Add_Question";
                SqlDataAdapter sa = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dtr;
                    int i = 0;
                    //while (i < ds.Tables[0].Rows.Count) 
                    //num = ds.count 
                    //num % 21
                    // 
                    {
                    dtr = ds.Tables[0].Rows[no+1];
                    richTextBox1.Text = "Your First Question is: "+dtr["Question"].ToString();
                    radioButton1.Text = "Option 1"+dtr["Option1"].ToString();
                    radioButton2.Text = "Option 2"+dtr["Option2"].ToString();
                    radioButton3.Text = "Option 3"+dtr["Option3"].ToString();
                    radioButton4.Text = "Option 4"+dtr["Option4"].ToString();


                        i++;
                    }
                    incQuestion += 1;
                }
                currQue += 1;
            }

        }
        
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
