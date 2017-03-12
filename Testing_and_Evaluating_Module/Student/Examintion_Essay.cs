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


namespace Testing_and_Evaluating_Module.Student
{
    public partial class Examintion_Essay : Form
    {
       // public static Form Examintion_Essay;
        public static int incQuestion = 1;
        public static int CurrQue = 0;


        Boolean isQuiz = false;
        
        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
             

        public void paras(String s){

            richTextBox1.Text = s;
    
            }



        public Examintion_Essay()
        {
            InitializeComponent();
        }       
        private void Examintion_Essay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'e_Blind_Learning_SystemDataSet8.Teacher_Add_Essay_Question_1' table. You can move, or remove it, as needed.
            this.teacher_Add_Essay_Question_1TableAdapter.Fill(this.e_Blind_Learning_SystemDataSet8.Teacher_Add_Essay_Question_1);
            
            Timer MyTimer = new Timer();
            MyTimer.Interval = (10 * 60 * 1000); //10 mins
            MyTimer.Tick += new EventHandler(timer3_Tick);
            MyTimer.Start();



            timer2.Enabled = true;
            timer2.Interval = 1000;

            richTextBox1.Visible = false;
            btnNext.Visible = false;
            btnSave.Visible = false;
            rtbAnswer.Enabled = false;

            

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select UserID from Student_LoginHistory where LoginID = (Select max(LoginID) from Student_LoginHistory)", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtUser.Text = dr["UserID"].ToString();

            }

            Class1 c1 = Class1.Instance();

            clist.Add(new String[] { "what is the current time", "Start Essay", "Save Essay Answer", "skip Essay", "Save Essay Answer", "Save Answer", "Close Essay", "previous" });

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized +=c1.sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.Speak("Hi , This is the time for starting quiz, Please say start to begin the quiz");
           

        }


        //private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    String s = e.Result.Text.ToString();


        //    //Examintion_Essay xform = new Examintion_Essay();

        //    //xform.paras("");



        //    if (s == "Start")
        //    {

        //        lblMsg.Text = "";


        //        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Essay_Question_1 where QuestionID='" + 1 + "'", conn);
        //        SqlDataReader dr;
        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {

        //            lblQuestionID.Text = dr["QuestionID"].ToString();
        //            lblQuestion.Text = dr["Question"].ToString();


        //        }
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.SpeakAsync("First Question is:");
        //        ss.SpeakAsync(lblQuestion.Text);
        //        isQuiz = true;
        //        rtbAnswer.Enabled = true;



        //    }



        //    if (s == "Save Answer")
        //    {
        //        save_details();
        //        ss.Speak("Your Answer Saved Successfully!");
        //    }

        //    else if (s.Equals("next"))
        //    {
        //        GetNextQuestion();
        //    }


        //    else if (s.Equals("Close"))
        //    {
        //        ss.SpeakAsync("Your Score is:" + txtScore.Text);
        //        this.Close();
        //    }
        //    else if (s == "skip" && isQuiz)
        //    {

        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("First question has skipped successfully!");
        //        calculate_score();
        //    }



        //    richTextBox1.Text += e.Result.Text.ToString();
        //}
        private void timer3_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("The form will now be closed.", "Time Elapsed");
            ss.Speak("Your time has finished!");
            ss.Speak("Your total Score in this quiz is:" + txtScore.Text);
            this.Close();
        }
     
        public void save_details()
        {
            btnNext.Visible = true;
            btnSave.Visible = true;
            

                if (rtbAnswer .Text !="")
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Essay_Answer(QuestionID,UserID,StudentAnswer,skipped)VALUES('" + lblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + rtbAnswer.Text.Trim() + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblMsg.Text = "Your answer saved Successfully!";
                    timer2.Enabled = true;
                }
               
        

            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Essay_Answer(QuestionID,UserID,StudentAnswer,skipped)VALUES('" + lblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + "Not Answered" + "','" + 1 + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMsg.Text = "Your answer has skipped Successfully!";
                timer2.Enabled = true;
            }


                calculate_score();


        }
        public void calculate_score()
        {
            tokenizeStudentAnswer();
            tokenizeKeyAnswer();
         

        }
        public void GetNextQuestion()
        {
            save_details();
          
            rtbAnswer.Text = "";

            CurrQue = CurrQue + 1;
            GetQuestion(CurrQue);

         
        }
        private void GetQuestion(int question )
        {

            if (CurrQue < 6 && CurrQue > 0)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                string str = "Select * from Teacher_Add_Essay_Question_1";
                SqlDataAdapter sa = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dtr;
                   // int i = 0;
                   
                    {
                        dtr = ds.Tables[0].Rows[CurrQue];

                        lblQuestionID.Text = dtr["QuestionID"].ToString();
                        lblQuestion.Text = dtr["Question"].ToString();
                       


                    //    i++;
                    }
                    ss.SelectVoiceByHints(VoiceGender.Female);
                    ss.SpeakAsync("Next Question is:");
                    ss.SpeakAsync(lblQuestion.Text);                   
                    isQuiz = true;
                    incQuestion += 1;
                }
                CurrQue += 1;
            }

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
          
            GetNextQuestion();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            save_details();
        }
        private void tokenizeStudentAnswer(){
            string text = rtbAnswer.Text;
            string[] tokens = GreedyTokenize(text);

            foreach (string token in tokens)
            {
               
                rtbProcessSAns.AppendText(token + "\r\n");
            }

        }
        private void tokenizeKeyAnswer()
        {

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();

                SqlCommand cmd = new SqlCommand("select Answer from Teacher_Add_Essay_Question_1 where QuestionID = '"+lblQuestionID .Text.Trim ()+"'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     string text = dr["Answer"].ToString();
                     string[] tokens = GreedyTokenize(text);
                     foreach (string token in tokens)
                     {
                         rdbProcessKey.AppendText(token + "\r\n");

                     }
                }
    
        }


    public static string[] GreedyTokenize( string text )
        {
            char[] delimiters = new char[] {

                  '{', '}', '(',')', '[', ']', '>', '<','-', '_', '=', '+',
                  '|', '\\', ':', ';', ' ', '\'', ',', '.', '/', '?', '~', '!',
                  '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t'
                  
                  };

            return text.Split( delimiters, StringSplitOptions.RemoveEmptyEntries );
        }
    }
}
