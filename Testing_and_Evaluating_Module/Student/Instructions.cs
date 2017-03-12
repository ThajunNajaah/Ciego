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


    public partial class Instructions : Form
    {


        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DQ2CE3B\NAJA;Initial Catalog=E_Blind_Learning_System;Integrated Security=True");
                  


        public Instructions()
        {
            InitializeComponent();
        }
        private void Instructions_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Show();
            ss.SelectVoiceByHints(VoiceGender.Female);
            // ss.Speak(textBox1 .Text);
            ss.SpeakAsync (" Hi this is the time for examination, Please follow these instructions.....Instructions ;   1. This Paper Contains 2 Parts ;  2. Part A contains 5 MCQ and Part B contains 5 Structured type questions  ;  3. Total duration of the Exam is 30 Minutes ;   4. The total marks obtainable for this exam is 100 ;  5. Marks allocated for Part A is 40, Part B is 60 ;  6. This is a closed book examination ;  7. Try to Answer all question");

            Class1 cl3 = Class1.Instance();
           
            clist.Add(new String[] { "Ok" });

            Grammar gr = new Grammar(new GrammarBuilder(clist));
            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += cl3.sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


           
            //this.Show();
           


        }
        //private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        //{
        //    String s = e.Result.Text.ToString();


        //    if (s == "Ok")
        //    {
        //        this.Hide();
        //        Examination_MCQ em = new Examination_MCQ();               
        //      //  em.MdiParent = this.MdiParent;
        //        em.WindowState = FormWindowState.Maximized;
        //        em.Show();
        //        ss.SelectVoiceByHints(VoiceGender.Female);                
             

        //    }

        //    //else if (s == "exit")
        //    //{
        //    //    this.Hide();
        //    //    EBlind_Learning_Module elm = new EBlind_Learning_Module();
        //    //    elm.MdiParent = this.MdiParent;
        //    //    elm.WindowState = FormWindowState.Maximized;
        //    //    elm.Show();
        //    //    ss.SelectVoiceByHints(VoiceGender.Female);
            
        //    //}
           
        //}
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            Examination_MCQ em = new Examination_MCQ();
            this.Hide();
            em.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
