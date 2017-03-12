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
    public partial class Student_Home_Page : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();

        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        Choices clist = new Choices();
                 

        public Student_Home_Page()
        {
            InitializeComponent();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          

            Instructions ins = new Instructions();
            this.Hide();
            ins.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }

        private void Student_Home_Page_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Show();
            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.Speak("Hi , You are Welcome to the examination module, Here You can attend exam, quizes, you can view your results . What to you prefer? if you want to go examination please say 'Exam' or  if you want to attend quiz please say 'Quiz' or if you need to view your results please say 'View Result' or if you want to go home please say 'Back Home' else to going previous page please say 'Previous' ");
            clist.Add(new String[] { "Quiz", "View Result", "Back", "Previous" });

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
           
            if (s == "Quiz")
            {
                this.Hide();
                Instructions ins = new Instructions();
                ins.MdiParent = this.MdiParent;
                ins.WindowState = FormWindowState.Maximized;
                ins.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);


            }
            //else if (s == "View Result")
            //{
            //    this.Hide();
            //    Instructions ins = new Instructions();
            //    ins.MdiParent = this.MdiParent;
            //    ins.WindowState = FormWindowState.Maximized;
            //    ins.Show();
            //    ss.SelectVoiceByHints(VoiceGender.Female);


            //}
            else if (s == "Back")
            {
                this.Hide();
                EBlind_Learning_Module ins = new EBlind_Learning_Module();
                ins.MdiParent = this.MdiParent;
                ins.WindowState = FormWindowState.Maximized;
                ins.Show();
                ss.SelectVoiceByHints(VoiceGender.Female);


            }


            //else if (s == "Previous")
            //{
            //    this.Hide();
            //    Examination_Home_Page elm = new Examination_Home_Page();
            //    elm.MdiParent = this.MdiParent;
            //    elm.WindowState = FormWindowState.Maximized;
            //    elm.Show();
            //    ss.SelectVoiceByHints(VoiceGender.Female);

            //}

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_MCQ em = new Examination_MCQ();
            em.Show();
        }
    }
}
