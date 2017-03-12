using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_and_Evaluating_Module
{
    public partial class EBlind_Learning_Module : Form
    {
        public EBlind_Learning_Module()
        {
            InitializeComponent();
        }

        private void lnkExamination_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page exam = new Examination_Home_Page();
            this.Hide();
            exam.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
