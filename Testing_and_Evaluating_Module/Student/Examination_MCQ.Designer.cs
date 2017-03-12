namespace Testing_and_Evaluating_Module.Student
{
    partial class Examination_MCQ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Examination_MCQ));
            this.LblQuestionID = new System.Windows.Forms.Label();
            this.teacherAddQuestionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.e_Blind_Learning_SystemDataSet = new Testing_and_Evaluating_Module.E_Blind_Learning_SystemDataSet();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.teacher_Add_QuestionTableAdapter = new Testing_and_Evaluating_Module.E_Blind_Learning_SystemDataSetTableAdapters.Teacher_Add_QuestionTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClock = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.rdbOption4 = new System.Windows.Forms.RadioButton();
            this.rdbOption3 = new System.Windows.Forms.RadioButton();
            this.rdbOption1 = new System.Windows.Forms.RadioButton();
            this.rdbOption2 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teacherAddQuestionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_Blind_Learning_SystemDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblQuestionID
            // 
            this.LblQuestionID.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "QuestionID", true));
            this.LblQuestionID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "QuestionID", true));
            this.LblQuestionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQuestionID.Location = new System.Drawing.Point(26, 67);
            this.LblQuestionID.Name = "LblQuestionID";
            this.LblQuestionID.Size = new System.Drawing.Size(124, 23);
            this.LblQuestionID.TabIndex = 0;
            this.LblQuestionID.Text = "Question ID";
            this.LblQuestionID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // teacherAddQuestionBindingSource
            // 
            this.teacherAddQuestionBindingSource.DataMember = "Teacher_Add_Question";
            this.teacherAddQuestionBindingSource.DataSource = this.e_Blind_Learning_SystemDataSet;
            // 
            // e_Blind_Learning_SystemDataSet
            // 
            this.e_Blind_Learning_SystemDataSet.DataSetName = "E_Blind_Learning_SystemDataSet";
            this.e_Blind_Learning_SystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblQuestion
            // 
            this.lblQuestion.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Question", true));
            this.lblQuestion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Question", true));
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(26, 102);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(1209, 86);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Question";
            // 
            // teacher_Add_QuestionTableAdapter
            // 
            this.teacher_Add_QuestionTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.txtClock);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.txtScore);
            this.groupBox1.Controls.Add(this.lblScore);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.LblQuestionID);
            this.groupBox1.Controls.Add(this.rdbOption4);
            this.groupBox1.Controls.Add(this.lblQuestion);
            this.groupBox1.Controls.Add(this.rdbOption3);
            this.groupBox1.Controls.Add(this.rdbOption1);
            this.groupBox1.Controls.Add(this.rdbOption2);
            this.groupBox1.Location = new System.Drawing.Point(39, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1261, 467);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtClock
            // 
            this.txtClock.Location = new System.Drawing.Point(387, 19);
            this.txtClock.Name = "txtClock";
            this.txtClock.Size = new System.Drawing.Size(185, 20);
            this.txtClock.TabIndex = 15;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(616, 364);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 63);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(62, 414);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(606, 23);
            this.lblMsg.TabIndex = 13;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(815, 16);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(148, 20);
            this.txtScore.TabIndex = 12;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(728, 16);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(56, 20);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Score";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(103, 16);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(148, 20);
            this.txtUser.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "User ID";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(948, 398);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(138, 29);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1092, 398);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(127, 29);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // rdbOption4
            // 
            this.rdbOption4.AutoSize = true;
            this.rdbOption4.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option4", true));
            this.rdbOption4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option4", true));
            this.rdbOption4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOption4.Location = new System.Drawing.Point(91, 323);
            this.rdbOption4.Name = "rdbOption4";
            this.rdbOption4.Size = new System.Drawing.Size(131, 24);
            this.rdbOption4.TabIndex = 5;
            this.rdbOption4.Text = "radioButton4";
            this.rdbOption4.UseVisualStyleBackColor = true;
            // 
            // rdbOption3
            // 
            this.rdbOption3.AutoSize = true;
            this.rdbOption3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option3", true));
            this.rdbOption3.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option3", true));
            this.rdbOption3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOption3.Location = new System.Drawing.Point(91, 276);
            this.rdbOption3.Name = "rdbOption3";
            this.rdbOption3.Size = new System.Drawing.Size(131, 24);
            this.rdbOption3.TabIndex = 4;
            this.rdbOption3.Text = "radioButton3";
            this.rdbOption3.UseVisualStyleBackColor = true;
            // 
            // rdbOption1
            // 
            this.rdbOption1.AutoSize = true;
            this.rdbOption1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option1", true));
            this.rdbOption1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option1", true));
            this.rdbOption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOption1.Location = new System.Drawing.Point(91, 191);
            this.rdbOption1.Name = "rdbOption1";
            this.rdbOption1.Size = new System.Drawing.Size(131, 24);
            this.rdbOption1.TabIndex = 2;
            this.rdbOption1.Text = "radioButton1";
            this.rdbOption1.UseVisualStyleBackColor = true;
            // 
            // rdbOption2
            // 
            this.rdbOption2.AutoSize = true;
            this.rdbOption2.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option2", true));
            this.rdbOption2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option2", true));
            this.rdbOption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOption2.Location = new System.Drawing.Point(91, 237);
            this.rdbOption2.Name = "rdbOption2";
            this.rdbOption2.Size = new System.Drawing.Size(131, 24);
            this.rdbOption2.TabIndex = 3;
            this.rdbOption2.Text = "radioButton2";
            this.rdbOption2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1349, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Examination_MCQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1354, 711);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Examination_MCQ";
            this.Text = "Examination_MCQ";
            this.Load += new System.EventHandler(this.Examination_MCQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacherAddQuestionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_Blind_Learning_SystemDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.Label LblQuestionID;
        public  System.Windows.Forms.Label lblQuestion;
        public E_Blind_Learning_SystemDataSet e_Blind_Learning_SystemDataSet;
        public System.Windows.Forms.BindingSource teacherAddQuestionBindingSource;
        public E_Blind_Learning_SystemDataSetTableAdapters.Teacher_Add_QuestionTableAdapter teacher_Add_QuestionTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrevious;
        public System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox pictureBox1;
        public  System.Windows.Forms.RadioButton rdbOption4;
        public  System.Windows.Forms.RadioButton rdbOption3;
        public  System.Windows.Forms.RadioButton rdbOption1;
        public  System.Windows.Forms.RadioButton rdbOption2;
        public  System.Windows.Forms.TextBox txtScore;
        public  System.Windows.Forms.Label lblScore;
        public  System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        public  System.Windows.Forms.Label lblMsg;
        public  System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtClock;
        private System.Windows.Forms.Timer timer2;
    }
}