using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_and_Evaluating_Module.Teacher
{
    public partial class Teacher_Home_Page : Form
    {
        public Teacher_Home_Page()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddQuestion aq = new AddQuestion();
            this.Hide();
            aq.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEssayQuestion asq = new AddEssayQuestion();
            this.Hide();
            asq.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Examination_Home_Page ehp = new Examination_Home_Page();
            this.Hide();
            ehp.Show();
        }
    }
}
