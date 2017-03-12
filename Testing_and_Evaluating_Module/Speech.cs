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


namespace Testing_and_Evaluating_Module
{
    public partial class Speech : Form
    {

        string lastword;
        string speak;
        string hold;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\M.A.Thajun Najaah\Documents\Visual Studio 2013\Projects\Testing_and_Evaluating_Module\Testing_and_Evaluating_Module\bin\Debug\dic.txt");
        string fword;
        string sword;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();



        public Speech()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                button1.Text = "Speak Now";
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                button1.Text = result.Text;
                //richTextBox1.Text = result.ToString();
            }
            catch (InvalidOperationException exception)
            {
                button1.Text = String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message);
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }    

        }

        private void Speech_Load(object sender, EventArgs e)
        {
            foreach (string line in lines)
            {
                string[] words = line.Split('-');
                int i = 0;
                foreach (string word in words)
                {
                    if (i == 0)
                    {
                        fword = word;
                        i = 1;
                    }
                    else
                    {
                        sword = word;
                        i = 0;
                    }

                }
                dictionary.Add(fword,sword);
            }
            load();
            startrec();
        }

        private void load()
        {
            Choices commands = new Choices();
            foreach (string line in lines)
            {
                string[] words = line.Split('-');
                int i = 0;
                foreach (string word in words)
                {
                    if (i == 0)
                    {
                        commands.Add(new string[] { word });
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }

                }

            }
            commands.Add(new string[] { "enter", "clear text", "delete" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammer = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                if (e.Result.Text == "delete")
                {

                }
                else
                {
                    hold = textBox1.Text;
                }
                textBox1.Text = textBox1.Text + dictionary[e.Result.Text];
                lastword = e.Result.Text;
            }
            catch (Exception)
            {

            }

            switch (e.Result.Text)
            {
                case "enter":
                    textBox1.AppendText("\r\n");
                    speak = "ok";
                    speech();
                    break;
                case "clear text":
                    textBox1.Text = "";
                    break;
                case "delete":
                    stoprec();
                    textBox1.Text = "";
                    textBox1.Text = hold;
                    speak = " deleted";
                    speech();
                    startrec();
                    break;
            }
        }
        private void startrec()
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void stoprec()
        {
            recEngine.RecognizeAsyncStop();
        }

        public void speech()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(speak);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
