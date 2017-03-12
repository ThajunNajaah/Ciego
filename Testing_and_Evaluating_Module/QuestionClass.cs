using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testing_and_Evaluating_Module
{
    class QuestionClass
    {
        private int QuestionID;
        private int SubjectCode;
        private int Grade;
        private string Question;
        private string Option1;
        private string Option2;
        private string Option3;
        private string Option4;
        private int CorrectOption;


        public QuestionClass(int QuestionID, int SubjectCode, int Grade, string Question, string Option1, string Option2, string Option3, string Option4, int CorrectOption)
        {
            this.QuestionID = QuestionID;
            this.SubjectCode = SubjectCode;
            this.Grade = Grade;
            this.Question = Question;
            this.Option1 = Option1;
            this.Option2 = Option2;
            this.Option3 = Option3;
            this.Option4 = Option4;
            this.CorrectOption = CorrectOption;

        }
        //public int QuestionID
        //{
        //    get { return QuestionID; }
        //    set { QuestionID = value; }
        //}

        //public int SubjectCode
        //{
        //    get { return SubjectCode; }
        //    set { SubjectCode = value; }
        //}
        //public int Grade
        //{
        //    get { return Grade; }
        //    set { Grade = value; }
        //}
        //public string Question
        //{
        //    get { return Question; }
        //    set { Question = value; }
        //}
        //public string Option1
        //{
        //    get { return Option1; }
        //    set { Option1 = value; }
        //}
        //public string Option2
        //{
        //    get { return Option2; }
        //    set { Option2 = value; }
        //}
        //public string Option3
        //{
        //    get { return Option3; }
        //    set { Option3 = value; }
        //}
        //public string Option4
        //{
        //    get { return Option4; }
        //    set { Option4 = value; }
        //}
        //public int CorrectOption
        //{
        //    get { return CorrectOption; }
        //    set { CorrectOption = value; }
        //}

    }
}
