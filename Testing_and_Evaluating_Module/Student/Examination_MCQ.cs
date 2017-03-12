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
    public partial class Examination_MCQ : Form
    {
        int score = 0;
        public static int incQuestion = 1;
        public static int CurrQue = 0;

       
       // Boolean isQuiz = false;


        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();

        //Connection Properties
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
       

        public Examination_MCQ()
        {
            InitializeComponent();
            //txtClock.Text = DateTime.Now.ToString("hh:mm:ss");
                      
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("The form will now be closed.", "Time Elapsed");
            this.Close();
        }
        private void Examination_MCQ_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (10 * 60 * 1000); //10 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();



            timer2.Enabled = true;
            timer2.Interval = 1000;

            richTextBox1.Visible = false;


            // TODO: This line of code loads data into the 'e_Blind_Learning_SystemDataSet.Teacher_Add_Question' table. You can move, or remove it, as needed.
            this.teacher_Add_QuestionTableAdapter.Fill(this.e_Blind_Learning_SystemDataSet.Teacher_Add_Question);

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select UserID from Student_LoginHistory where LoginID = (Select max(LoginID) from Student_LoginHistory)", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtUser.Text = dr["UserID"].ToString();
               
            }

           
            Class1 cs2 = Class1.Instance();

            clist.Add(new String[] { "what is the current time", "Start MCQ", "One", "Two", "Three", "Four", "skip", "next MCQ", "previous MCQ", "Close MCQ","skip MCQ" });

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += cs2.sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.Speak("Hi , This is the time for starting quiz, Please say start MCQ to begin the quiz");
           
            
        }
        //private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    String s = e.Result.Text.ToString();

        //    richTextBox1.Text = "";

        //    if (s == "Start")
        //    {

        //        lblMsg.Text = "";
        //        GetQuestion();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.SpeakAsync("First Question is:");
        //        ss.SpeakAsync(lblQuestion.Text);
        //        ss.Speak("Option 1" + rdbOption1.Text);
        //        ss.Speak("Option 2" + rdbOption2.Text);
        //        ss.Speak("Option 3" + rdbOption3.Text);
        //        ss.Speak("Option 4" + rdbOption4.Text);
        //        isQuiz = true;

        //    }

        //    else if (s.Equals("next"))
        //    {
        //        GetNextQuestion();
        //    }


        //    else if (s.Equals("previous"))
        //    {
        //        GetPreviousQuestion();
        //    }

        //    else if (s.Equals("Close"))
        //    {
        //        ss.SpeakAsync("Your Score is:" + txtScore.Text);
        //        this.Close();
        //    }


        //     if  (s == "One" && isQuiz)
        //    {
        //        rdbOption1.Checked = true;
        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("Your Answer saved successfully!");
        //        calculate_score();

        //    }
        //    else if  (s == "Two" && isQuiz)
        //    {
        //        rdbOption2.Checked = true;
        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("Your Answer saved successfully!");
        //        calculate_score();

        //    }
        //    else if (s == "Three" && isQuiz)
        //    {
        //        rdbOption3.Checked = true;
        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("Your Answer saved successfully!");
        //        calculate_score();
        //    }
        //     else if (s == "Four" && isQuiz)
        //    {
        //        rdbOption4.Checked = true;
        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("Your Answer saved successfully!");
        //        calculate_score();
        //    }
        //     else if  (s == "skip" && isQuiz)
        //    {
        //        rdbOption1.Checked = false;
        //        rdbOption2.Checked = false;
        //        rdbOption3.Checked = false;
        //        rdbOption4.Checked = false;
        //        save_details();
        //        ss.SelectVoiceByHints(VoiceGender.Female);
        //        ss.Speak("First question has skipped successfully!");
        //        calculate_score();
        //    }
        

        //    richTextBox1.Text += e.Result.Text.ToString();

        //}
        public void save_details()
        {
            if (rdbOption1.Checked || rdbOption2.Checked || rdbOption3.Checked || rdbOption4.Checked)
            {
                conn.Open();
             
                if (rdbOption1.Checked)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + Convert .ToInt32 (LblQuestionID.Text.Trim()) + "','" +Convert .ToInt32 ( txtUser.Text.Trim()) + "','" + 1 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    
                }
                else if (rdbOption2.Checked)
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 2 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                   
                }
                else if (rdbOption3.Checked)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 3 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    
                }
                else if (rdbOption4.Checked)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 4 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                lblMsg.Text = "Your answer saved Successfully!";
                timer2.Enabled = true;
            }
               
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + Convert.ToInt16 (LblQuestionID.Text.Trim()) + "','" + Convert .ToInt16 (txtUser.Text.Trim()) + "','" + 0 + "','" + 1 + "')", conn);
                cmd.ExecuteNonQuery();
                          
               
            }



        }
        public void calculate_score()
        {
            if (incQuestion < 6)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"select Student_Save_Student_Answer.StudentOption,Teacher_Add_Question.CorrectOption,Student_Save_Student_Answer.QuestionID,Student_Save_Student_Answer.UserID from Student_Save_Student_Answer Inner Join Teacher_Add_Question ON Student_Save_Student_Answer.QuestionID =Teacher_Add_Question.QuestionID and Student_Save_Student_Answer.QuestionID ='" + LblQuestionID.Text.Trim() + "' and Student_Save_Student_Answer.UserID ='" + txtUser.Text.Trim() + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    if (Convert.ToInt32(dr["StudentOption"].ToString()) == Convert.ToInt32(dr["CorrectOption"].ToString()) && Convert.ToInt32(dr["QuestionID"].ToString()) == Convert.ToInt32(LblQuestionID.Text) && Convert.ToInt32(dr["UserID"].ToString()) == Convert.ToInt32(txtUser.Text.Trim()))
                    {

                        score++;

                    }

                }
                txtScore.Text = score.ToString();
            }

        }
        public void GetNextQuestion()
        {
            save_details();
            calculate_score();


            rdbOption1.Checked = false;
            rdbOption2.Checked = false;
            rdbOption3.Checked = false;
            rdbOption4.Checked = false;        
            GetQuestion();



        }
        public  void GetQuestion()
        {

            CurrQue = CurrQue + 1;
            if (CurrQue < 6 && CurrQue >0)
            {

                conn.Open();
                string str = "Select * from Teacher_Add_Question where QuestionID = '" + CurrQue + "'";
                SqlDataAdapter sa = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0) 
                {
                    DataRow dtr;
                   // int i = 0;
                    //while (i < ds.Tables[0].Rows.Count) 
                    //num = ds.count 
                    //num % 21
                    // 
                    {
                        //dtr = ds.Tables[0].Rows[CurrQue];   
                        dtr = ds.Tables[0].Rows[0]; 
                        LblQuestionID.Text = dtr["QuestionID"].ToString();
                        lblQuestion.Text = dtr["Question"].ToString();
                        rdbOption1.Text = dtr["Option1"].ToString();
                        rdbOption2.Text = dtr["Option2"].ToString();
                        rdbOption3.Text = dtr["Option3"].ToString();
                        rdbOption4.Text = dtr["Option4"].ToString();


                     //   i++;
                    }
                    //ss.SelectVoiceByHints(VoiceGender.Female);
                    //ss.SpeakAsync("Next Question is:");
                    //ss.SpeakAsync(lblQuestion.Text);
                    //ss.Speak("Option 1" + rdbOption1.Text);
                    //ss.Speak("Option 2" + rdbOption2.Text);
                    //ss.Speak("Option 3" + rdbOption3.Text);
                    //ss.Speak("Option 4" + rdbOption4.Text);
                 
                    
                }
                
            }

        }
        public void btnNext_Click(object sender, EventArgs e)
        {
            GetNextQuestion();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ss.Speak("Your time has finished!");
            ss.Speak("Your total Score in this quiz is:" + txtScore.Text);
            this.Close();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
            GetPreviousQuestion();
        }
        public  void GetPreviousQuestion()
        {
            
            CurrQue = CurrQue - 1;
          
            if (CurrQue > 0 && CurrQue<6)
            {

                conn.Open();
                string str = "Select * from Teacher_Add_Question";
                SqlDataAdapter sa = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                sa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dtr;
                    int i = 5;
                    //while (i < ds.Tables[0].Rows.Count) 
                    //num = ds.count 
                    //num % 21
                    // 
                    
                    {
                        dtr = ds.Tables[0].Rows[CurrQue];
                        LblQuestionID.Text = CurrQue +"";// dtr["QuestionID"].ToString();
                        lblQuestion.Text = dtr["Question"].ToString();
                        rdbOption1.Text = dtr["Option1"].ToString();
                        rdbOption2.Text = dtr["Option2"].ToString();
                        rdbOption3.Text = dtr["Option3"].ToString();
                        rdbOption4.Text = dtr["Option4"].ToString();
                        GetAnswer();

                       // i--;
                    }
                   
                    ss.SelectVoiceByHints(VoiceGender.Female);
                    ss.SpeakAsync("Previous Question is:" );
                    ss.SpeakAsync(lblQuestion.Text);
                    ss.Speak("Option 1" + rdbOption1.Text);
                    ss.Speak("Option 2" + rdbOption2.Text);
                    ss.Speak("Option 3" + rdbOption3.Text);
                    ss.Speak("Option 4" + rdbOption4.Text);
                    //isQuiz = true;
                }
              
            }
           
            save_update();
            ChangeScore();
        }
        public  void save_update()
        {
            if (rdbOption1.Checked || rdbOption2.Checked || rdbOption3.Checked || rdbOption4.Checked)
            {
                conn.Open();
                if (rdbOption1.Checked)
                {
                    
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 1 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                  
                }
                else if (rdbOption2.Checked)
                {
                   
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 2 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                   
                }
                else if (rdbOption3.Checked)
                {
                    
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 3 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    
                }
                else if (rdbOption4.Checked)
                {
                   
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 4 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                   
                }

            }
            conn.Close();
            lblMsg.Text = "Your answer has updated successfully!";
            
        }
        public  void ChangeScore()
        {
             conn.Open();
            SqlCommand cmd = new SqlCommand(@"select Student_Save_Student_Answer.StudentOption,Teacher_Add_Question.CorrectOption,Student_Save_Student_Answer.QuestionID,Student_Save_Student_Answer.UserID from Student_Save_Student_Answer Inner Join Teacher_Add_Question ON Student_Save_Student_Answer.QuestionID =Teacher_Add_Question.QuestionID and Student_Save_Student_Answer.QuestionID ='" + LblQuestionID.Text.Trim() + "' and Student_Save_Student_Answer.UserID ='" + txtUser.Text.Trim() + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               // if(Convert.ToInt32 (dr[""].ToString ()))
                if (Convert.ToInt32(dr["StudentOption"].ToString()) == Convert.ToInt32(dr["CorrectOption"].ToString()))
                {
                    score++;


                }
                else
                {
                    score--;
                }
            }
            txtScore.Text = score.ToString();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            txtClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        public void GetAnswer()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select StudentOption,skipped from Student_Save_Student_Answer where QuestionID='" + LblQuestionID.Text.Trim() + "' and UserID ='" + txtUser.Text.Trim() + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    if (dr["skipped"].ToString() != "0")
                    {
                        if (dr["StudentOption"].ToString() =="1")
                        {
                            rdbOption1.Checked = true;
                        }
                        if (dr["StudentOption"].ToString() == "2")
                        {
                            rdbOption2.Checked = true;
                        }
                        if (dr["StudentOption"].ToString() == "3")
                        {
                            rdbOption3.Checked = true;
                        }
                        if (dr["StudentOption"].ToString() == "4")
                        {
                            rdbOption4.Checked = true;
                        }
                    }
                    if (dr["skipped"].ToString() == "0")
                    {
                        rdbOption1.Checked = false;
                        rdbOption2.Checked = false;
                        rdbOption3.Checked = false;
                        rdbOption4.Checked = false;
                    }
                }
            }
        }



    

    }
}