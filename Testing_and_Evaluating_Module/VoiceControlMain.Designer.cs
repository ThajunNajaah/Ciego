namespace Testing_and_Evaluating_Module
{
    partial class VoiceControlMain
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.teacherAddQuestionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.e_Blind_Learning_SystemDataSet = new Testing_and_Evaluating_Module.E_Blind_Learning_SystemDataSet();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblQuestionID = new System.Windows.Forms.Label();
            this.teacher_Add_QuestionTableAdapter = new Testing_and_Evaluating_Module.E_Blind_Learning_SystemDataSetTableAdapters.Teacher_Add_QuestionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.teacherAddQuestionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_Blind_Learning_SystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(82, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(935, 115);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option1", true));
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option1", true));
            this.radioButton1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.teacherAddQuestionBindingSource, "Option1", true));
            this.radioButton1.Location = new System.Drawing.Point(118, 254);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
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
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option2", true));
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option2", true));
            this.radioButton2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.teacherAddQuestionBindingSource, "Option2", true));
            this.radioButton2.Location = new System.Drawing.Point(118, 283);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.teacherAddQuestionBindingSource, "Option3", true));
            this.radioButton3.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option3", true));
            this.radioButton3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option3", true));
            this.radioButton3.Location = new System.Drawing.Point(118, 317);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.teacherAddQuestionBindingSource, "Option4", true));
            this.radioButton4.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.teacherAddQuestionBindingSource, "Option4", true));
            this.radioButton4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherAddQuestionBindingSource, "Option4", true));
            this.radioButton4.Location = new System.Drawing.Point(118, 350);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(14, 13);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(131, 6);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(174, 20);
            this.txtUserID.TabIndex = 7;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(421, 6);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(174, 20);
            this.txtScore.TabIndex = 8;
            // 
            // lblQuestionID
            // 
            this.lblQuestionID.AutoSize = true;
            this.lblQuestionID.Location = new System.Drawing.Point(79, 41);
            this.lblQuestionID.Name = "lblQuestionID";
            this.lblQuestionID.Size = new System.Drawing.Size(60, 13);
            this.lblQuestionID.TabIndex = 9;
            this.lblQuestionID.Text = "QuestionID";
            // 
            // teacher_Add_QuestionTableAdapter
            // 
            this.teacher_Add_QuestionTableAdapter.ClearBeforeFill = true;
            // 
            // VoiceControlMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 452);
            this.Controls.Add(this.lblQuestionID);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "VoiceControlMain";
            this.Text = "VoiceControlMain";
            this.Load += new System.EventHandler(this.VoiceControlMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacherAddQuestionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e_Blind_Learning_SystemDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblQuestionID;
        private E_Blind_Learning_SystemDataSet e_Blind_Learning_SystemDataSet;
        private System.Windows.Forms.BindingSource teacherAddQuestionBindingSource;
        private E_Blind_Learning_SystemDataSetTableAdapters.Teacher_Add_QuestionTableAdapter teacher_Add_QuestionTableAdapter;
    }
}