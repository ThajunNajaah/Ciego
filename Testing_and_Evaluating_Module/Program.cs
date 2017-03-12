using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Testing_and_Evaluating_Module.Student;

namespace Testing_and_Evaluating_Module
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


           //Application.Run(new EBlind_Learning_Module());         
          Application.Run(new Instructions());
        // Application.Run(new Examintion_Essay());
           // Application.Run(new Examination_MCQ());
    
          
        }
    }
}
