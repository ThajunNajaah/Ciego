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
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using Testing_and_Evaluating_Module.Student;



namespace Testing_and_Evaluating_Module.Student
{
    class Class1
    {

        private static Class1 instance;
        Boolean isEssay = false;
        Boolean isMCQ = false;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechSynthesizer ss = new SpeechSynthesizer();
 


        public static Class1 Instance()
        {
            if (instance == null)
            {
                instance = new Class1();
            }
            return instance;
        }


        public  void  sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String s = e.Result.Text.ToString();
            var Examintion_Essay = new Examintion_Essay();
            var Examination_MCQ = new Examination_MCQ();
            var Instructions = new Instructions();

           if (s == "Start Essay")
            {
         
                Examintion_Essay.lblMsg.Text = "";
                conn.Open();               
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Essay_Question_1 where QuestionID='" + 1 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     Examintion_Essay.lblQuestionID.Text = dr["QuestionID"].ToString();
                     Examintion_Essay. lblQuestion.Text = dr["Question"].ToString();
                }

                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("First Question is:");
                ss.SpeakAsync(Examintion_Essay.lblQuestion.Text);
                isEssay = true;
                Examintion_Essay.rtbAnswer.Enabled = true;

            }

            
            if (s == "Save Essay Answer")
            {
                Examintion_Essay.save_details();
                ss.Speak("Your Answer Saved Successfully!");
            }

            else if (s.Equals("next Essay"))
            {
                Examintion_Essay.GetNextQuestion();
            }


            else if (s.Equals("Close Essay"))
            {
                ss.SpeakAsync("Your Score is:" + Examintion_Essay.txtScore.Text);
                Examintion_Essay.Close();
            }
            else if (s == "skip Essay" && isEssay)
            {

                Examintion_Essay.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("First question has skipped successfully!");
                Examintion_Essay.calculate_score();
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++for MCQ+++++++++++++++++++++++++++++++++++++++++++//

            if (s == "Start MCQ")
            {

               // Examination_MCQ.lblMsg.Text = "";
                Examination_MCQ.GetQuestion();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("First Question is:");
                ss.SpeakAsync(Examination_MCQ.lblQuestion.Text);
                ss.Speak("Option 1" + Examination_MCQ.rdbOption1.Text);
                ss.Speak("Option 2" + Examination_MCQ.rdbOption2.Text);
                ss.Speak("Option 3" + Examination_MCQ.rdbOption3.Text);
                ss.Speak("Option 4" + Examination_MCQ.rdbOption4.Text);
                isMCQ = true;

            }

            else if (s.Equals("next MCQ"))
            {
                Examination_MCQ.GetNextQuestion();
            }

            else if (s.Equals("previous MCQ"))
            {
                Examination_MCQ.GetPreviousQuestion();
            }

            else if (s.Equals("Close MCQ"))
            {
                ss.SpeakAsync("Your Score is:" + Examination_MCQ.txtScore.Text);
                Examination_MCQ.Close();
            }

            else if (s.Equals("One") && isMCQ)
            {
                Examination_MCQ.rdbOption1.Checked = true;
                Examination_MCQ.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                Examination_MCQ.calculate_score();

            }
            else if (s == "Two" && isMCQ)
            {
                Examination_MCQ.rdbOption2.Checked = true;
                Examination_MCQ.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                Examination_MCQ.calculate_score();
            }

            else if (s == "Three" && isMCQ)
            {
                Examination_MCQ.rdbOption3.Checked = true;
                Examination_MCQ.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                Examination_MCQ.calculate_score();
            }
            else if (s == "Four" && isMCQ)
            {
                Examination_MCQ.rdbOption4.Checked = true;
                Examination_MCQ.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                Examination_MCQ.calculate_score();
            }

            else if (s == "skip MCQ" && isMCQ)
            {
                Examination_MCQ.rdbOption1.Checked = false;
                Examination_MCQ.rdbOption2.Checked = false;
                Examination_MCQ.rdbOption3.Checked = false;
                Examination_MCQ.rdbOption4.Checked = false;
                Examination_MCQ.save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("First question has skipped successfully!");
                Examination_MCQ.calculate_score();
            }


            //+++++++++++++++++++++++++++++++++++++++++++++++++++for Instruction++++++++++++++++++++++++++++++++++++++++++++==//

             else if (s == "Ok")
            {
                Instructions.Hide();
                Examination_MCQ em = new Examination_MCQ();               
                em.WindowState = FormWindowState.Maximized;
                em.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);

            }

            
          //  Examintion_Essay.richTextBox1.Text += e.Result.Text.ToString();
        }

        

      
       
    }
}
