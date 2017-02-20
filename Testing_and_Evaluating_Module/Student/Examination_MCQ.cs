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
        public static int CurrQue = 1;

        Boolean isQuiz1 = false;
        Boolean isQuiz2 = false;
        Boolean isQuiz3 = false;
        Boolean isQuiz4 = false;
        Boolean isQuiz5 = false;


        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
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
            MyTimer.Interval = (5 * 60 * 1000); // 5 mins
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

            clist.Add(new String[] { "what is the current time", "examination", "Start", "firstQuestion", "SecondQuestion", "ThirdQuestion", "FourthQuestion", "FifthQuestion", "last", "One", "Two", "Three", "Four", "skip", "next" });

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

            if (Convert.ToInt32(txtUser.Text) == 3)
            {
                ss.Speak("Hi , This is the time for starting quiz, Please say start to begin the quiz");
            }
        }
        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String s = e.Result.Text.ToString();

            richTextBox1.Text = "";

            if (s == "Start" || s == "firstQuestion")
            {
                lblMsg.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 1 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LblQuestionID.Text = dr["QuestionID"].ToString();
                    lblQuestion.Text = dr["Question"].ToString();
                    rdbOption1.Text = dr["Option1"].ToString();
                    rdbOption2.Text = dr["Option2"].ToString();
                    rdbOption3.Text = dr["Option3"].ToString();
                    rdbOption4.Text = dr["Option4"].ToString();

                }
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("First Question is:");
                ss.SpeakAsync(lblQuestion.Text);
                ss.Speak("Option 1" + rdbOption1.Text);
                ss.Speak("Option 2" + rdbOption2.Text);
                ss.Speak("Option 3" + rdbOption3.Text);
                ss.Speak("Option 4" + rdbOption4.Text);
                isQuiz1 = true;



            }



            else if (s == "One" && isQuiz1)
            {
                rdbOption1.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Two" && isQuiz1)
            {
                rdbOption2.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Three" && isQuiz1)
            {
                rdbOption3.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "Four" && isQuiz1)
            {
                rdbOption4.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "skip" && isQuiz1)
            {
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("First question has skipped successfully!");
                calculate_score();
            }



        /*************************************************Second Question*************************************************************/
            else if (s == "SecondQuestion" && isQuiz1)
            {
                lblMsg.Text = "";
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 2 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LblQuestionID.Text = dr["QuestionID"].ToString();
                    lblQuestion.Text = dr["Question"].ToString();
                    rdbOption1.Text = dr["Option1"].ToString();
                    rdbOption2.Text = dr["Option2"].ToString();
                    rdbOption3.Text = dr["Option3"].ToString();
                    rdbOption4.Text = dr["Option4"].ToString();

                }
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("Second Question is:");
                ss.SpeakAsync(lblQuestion.Text);
                ss.Speak("Option 1" + rdbOption1.Text);
                ss.Speak("Option 2" + rdbOption2.Text);
                ss.Speak("Option 3" + rdbOption3.Text);
                ss.Speak("Option 4" + rdbOption4.Text);
                isQuiz2 = true;
            }

            else if (s == "One" && isQuiz2)
            {
                rdbOption1.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Two" && isQuiz2)
            {
                rdbOption2.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Three" && isQuiz2)
            {
                rdbOption3.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "Four" && isQuiz2)
            {
                rdbOption4.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "skip" && isQuiz2)
            {
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Second question has skipped successfully!");
                calculate_score();
            }

    /************************************************************Third****************************************************************/
            else if (s == "ThirdQuestion" && isQuiz2)
            {
                lblMsg.Text = "";
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 3 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LblQuestionID.Text = dr["QuestionID"].ToString();
                    lblQuestion.Text = dr["Question"].ToString();
                    rdbOption1.Text = dr["Option1"].ToString();
                    rdbOption2.Text = dr["Option2"].ToString();
                    rdbOption3.Text = dr["Option3"].ToString();
                    rdbOption4.Text = dr["Option4"].ToString();

                }
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("Third Question is:");
                ss.SpeakAsync(lblQuestion.Text);
                ss.Speak("Option 1" + rdbOption1.Text);
                ss.Speak("Option 2" + rdbOption2.Text);
                ss.Speak("Option 3" + rdbOption3.Text);
                ss.Speak("Option 4" + rdbOption4.Text);
                isQuiz3 = true;
            }

            else if (s == "One" && isQuiz3)
            {
                rdbOption1.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Two" && isQuiz3)
            {
                rdbOption2.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Three" && isQuiz3)
            {
                rdbOption3.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "Four" && isQuiz3)
            {
                rdbOption4.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "skip" && isQuiz3)
            {
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Third question has skipped successfully!");
                calculate_score();
            }

/****************************************************Fourth*********************************************************/
            else if (s == "FourthQuestion" && isQuiz3)
            {
                lblMsg.Text = "";
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 4 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LblQuestionID.Text = dr["QuestionID"].ToString();
                    lblQuestion.Text = dr["Question"].ToString();
                    rdbOption1.Text = dr["Option1"].ToString();
                    rdbOption2.Text = dr["Option2"].ToString();
                    rdbOption3.Text = dr["Option3"].ToString();
                    rdbOption4.Text = dr["Option4"].ToString();

                }
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("Fourth Question is:");
                ss.SpeakAsync(lblQuestion.Text);
                ss.Speak("Option 1" + rdbOption1.Text);
                ss.Speak("Option 2" + rdbOption2.Text);
                ss.Speak("Option 3" + rdbOption3.Text);
                ss.Speak("Option 4" + rdbOption4.Text);
                isQuiz4 = true;
            }

            else if (s == "One" && isQuiz4)
            {
                rdbOption1.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Two" && isQuiz4)
            {
                rdbOption2.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();

            }
            else if (s == "Three" && isQuiz4)
            {
                rdbOption3.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "Four" && isQuiz4)
            {
                rdbOption4.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
            }
            else if (s == "skip" && isQuiz4)
            {
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Fourth question has skipped successfully!");
                calculate_score();
            }

            /***********************************************************Fifth******************************************************/

            else if ((s == "FifthQuestion" || s == "last") && isQuiz4)
            {
                lblMsg.Text = "";
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher_Add_Question where QuestionID='" + 5 + "'", conn);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LblQuestionID.Text = dr["QuestionID"].ToString();
                    lblQuestion.Text = dr["Question"].ToString();
                    rdbOption1.Text = dr["Option1"].ToString();
                    rdbOption2.Text = dr["Option2"].ToString();
                    rdbOption3.Text = dr["Option3"].ToString();
                    rdbOption4.Text = dr["Option4"].ToString();

                }
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.SpeakAsync("Fifth Question is:");
                ss.SpeakAsync(lblQuestion.Text);
                ss.Speak("Option 1" + rdbOption1.Text);
                ss.Speak("Option 2" + rdbOption2.Text);
                ss.Speak("Option 3" + rdbOption3.Text);
                ss.Speak("Option 4" + rdbOption4.Text);
                isQuiz5 = true;
            }

            else if (s == "One" && isQuiz5)
            {
                rdbOption1.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
                ss.Speak("You have Successfully finished your Part 1 , MCQ!");
                ss.Speak("The Total Score you acheived is:" + txtScore.Text);


            }
            else if (s == "Two" && isQuiz5)
            {
                rdbOption2.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
                ss.Speak("You have Successfully finished your Part 1 , MCQ!");
                ss.Speak("The Total Score you acheived is:" + txtScore.Text);


            }
            else if (s == "Three" && isQuiz5)
            {
                rdbOption3.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
                ss.Speak("You have Successfully finished your Part 1 , MCQ!");
                ss.Speak("The Total Score you acheived is:" + txtScore.Text);

            }
            else if (s == "Four" && isQuiz5)
            {
                rdbOption4.Checked = true;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Your Answer saved successfully!");
                calculate_score();
                ss.Speak("You have Successfully finished your Part 1 , MCQ!");
                ss.Speak("The Total Score you acheived is:" + txtScore.Text);

            }
            else if (s == "skip" && isQuiz5)
            {
                rdbOption1.Checked = false;
                rdbOption2.Checked = false;
                rdbOption3.Checked = false;
                rdbOption4.Checked = false;
                save_details();
                ss.SelectVoiceByHints(VoiceGender.Female);
                ss.Speak("Fourth question has skipped successfully!");
                calculate_score();
                ss.Speak("You have Successfully finished your Part 1 , MCQ!");
                ss.Speak("The Total Score you acheived is:" + txtScore.Text);

            }

            richTextBox1.Text += e.Result.Text.ToString();
        }
        public void save_details()
        {
            if (rdbOption1.Checked || rdbOption2.Checked || rdbOption3.Checked || rdbOption4.Checked)
            {

                if (rdbOption1.Checked)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 1 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption2.Checked)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 2 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption3.Checked)
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 3 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption4.Checked)
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 4 + "','" + 0 + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                lblMsg.Text = "Your answer saved Successfully!";
                timer2.Enabled = true;
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student_Save_Student_Answer(QuestionID,UserID,StudentOption,skipped)VALUES('" + LblQuestionID.Text.Trim() + "','" + txtUser.Text.Trim() + "','" + 0 + "','" + 1 + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                lblMsg.Text = "Your answer has skipped Successfully!";
                timer2.Enabled = true;
            }



        }
        public void calculate_score()
        {
            if (incQuestion < 6)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
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


            rdbOption1.Checked = false;
            rdbOption2.Checked = false;
            rdbOption3.Checked = false;
            rdbOption4.Checked = false;
            GetQuestion(CurrQue);



        }
        private void GetQuestion(int no)
        {

            if (incQuestion < 6)
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
                        dtr = ds.Tables[0].Rows[no];
                        LblQuestionID.Text = dtr["QuestionID"].ToString();
                        lblQuestion.Text = dtr["Question"].ToString();
                        rdbOption1.Text = dtr["Option1"].ToString();
                        rdbOption2.Text = dtr["Option2"].ToString();
                        rdbOption3.Text = dtr["Option3"].ToString();
                        rdbOption4.Text = dtr["Option4"].ToString();


                        i++;
                    }
                    incQuestion += 1;
                }
                CurrQue += 1;
            }

        }
        public void btnNext_Click(object sender, EventArgs e)
        {
            save_details();
            calculate_score();
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
            save_update();
            ChangeScore();
            GetPreviousQuestion(CurrQue);
        }
        private void GetPreviousQuestion(int no)
        {
            if (incQuestion > 0)
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
                    int i = 9;
                    //while (i < ds.Tables[0].Rows.Count) 
                    //num = ds.count 
                    //num % 21
                    // 
                    {
                        dtr = ds.Tables[0].Rows[no];
                        LblQuestionID.Text = dtr["QuestionID"].ToString();
                        lblQuestion.Text = dtr["Question"].ToString();
                        rdbOption1.Text = dtr["Option1"].ToString();
                        rdbOption2.Text = dtr["Option2"].ToString();
                        rdbOption3.Text = dtr["Option3"].ToString();
                        rdbOption4.Text = dtr["Option4"].ToString();


                        i--;
                    }
                    incQuestion -= 1;
                }
                CurrQue -= 1;
            }
        }
        private void save_update()
        {
            if (rdbOption1.Checked || rdbOption2.Checked || rdbOption3.Checked || rdbOption4.Checked)
            {

                if (rdbOption1.Checked)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 1 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption2.Checked)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 2 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption3.Checked)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 3 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else if (rdbOption4.Checked)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update Student_Save_Student_Answer set StudentOption='" + 4 + "' Where QuestionID ='" + LblQuestionID.Text.Trim() + "' and UserID='" + txtUser.Text.Trim() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            lblMsg.Text = "Your answer has updated successfully!";
            //timer2.Enabled = true;
        }
        private void ChangeScore()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"select Student_Save_Student_Answer.StudentOption,Teacher_Add_Question.CorrectOption from Student_Save_Student_Answer Inner Join Teacher_Add_Question ON Student_Save_Student_Answer.QuestionID =Teacher_Add_Question.QuestionID and Student_Save_Student_Answer.QuestionID ='" + LblQuestionID.Text.Trim() + "'", conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

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



    

    }
}