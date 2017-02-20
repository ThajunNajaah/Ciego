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
    public partial class SpeechRecognition : Form
    {
        SpeechRecognitionEngine Engine = new SpeechRecognitionEngine();
        DictationGrammar Grammar = new DictationGrammar();  

        public SpeechRecognition()
        {
            InitializeComponent();
        }

        private void SpeechRecognition_Load(object sender, EventArgs e)
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            rec.LoadGrammar(new Grammar(new GrammarBuilder("exit"))); // load grammar
            // rec.GrammarBuilder.Append(string);
            rec.LoadGrammar(new DictationGrammar());

            rec.SpeechRecognized += speech1;
            Engine.BabbleTimeout = TimeSpan.FromSeconds(10.0);
            Engine.EndSilenceTimeout = TimeSpan.FromSeconds(10.0);
            Engine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(10.0);
            Engine.InitialSilenceTimeout = TimeSpan.FromSeconds(10.0);

            rec.SetInputToDefaultAudioDevice(); // set input to default audio device
            rec.RecognizeAsync(RecognizeMode.Multiple); // recognize speech

        }

        void speech1(object sender, SpeechRecognizedEventArgs e)
    {
        if (e.Result.Text == "exit")
        {
            Application.Exit();
        }
        else
        {
            richTextBox1.AppendText(" " +e.Result.Text);
        }

    }
            
      
       
            }
}
