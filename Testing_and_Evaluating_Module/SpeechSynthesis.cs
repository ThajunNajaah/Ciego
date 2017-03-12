using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;


namespace Testing_and_Evaluating_Module
{
    class SpeechSynthesis
    {
       
     
        public void speak()
        {
            SpeechSynthesizer s = new SpeechSynthesizer();
            s.SelectVoiceByHints(VoiceGender.Male);
            s.Speak("Hello , How are you?");
        }
      
    }
}
