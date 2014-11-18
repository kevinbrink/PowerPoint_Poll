namespace CP3_plugin {
    partial class questionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionBox = new System.Windows.Forms.TextBox();
            this.format1 = new System.Windows.Forms.RadioButton();
            this.format2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.answerEIsCorrect = new System.Windows.Forms.CheckBox();
            this.answerDIsCorrect = new System.Windows.Forms.CheckBox();
            this.answerCIsCorrect = new System.Windows.Forms.CheckBox();
            this.answerBIsCorrect = new System.Windows.Forms.CheckBox();
            this.answerAIsCorrect = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.answerE = new System.Windows.Forms.TextBox();
            this.answerD = new System.Windows.Forms.TextBox();
            this.answerC = new System.Windows.Forms.TextBox();
            this.answerB = new System.Windows.Forms.TextBox();
            this.answerA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.falseRadio = new System.Windows.Forms.RadioButton();
            this.trueRadio = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question:";
            // 
            // QuestionBox
            // 
            this.QuestionBox.Location = new System.Drawing.Point(20, 32);
            this.QuestionBox.Margin = new System.Windows.Forms.Padding(4);
            this.QuestionBox.Multiline = true;
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(568, 85);
            this.QuestionBox.TabIndex = 1;
            // 
            // format1
            // 
            this.format1.AutoSize = true;
            this.format1.Location = new System.Drawing.Point(13, 4);
            this.format1.Margin = new System.Windows.Forms.Padding(4);
            this.format1.Name = "format1";
            this.format1.Size = new System.Drawing.Size(105, 21);
            this.format1.TabIndex = 2;
            this.format1.TabStop = true;
            this.format1.Text = "True / False";
            this.format1.UseVisualStyleBackColor = true;
            this.format1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // format2
            // 
            this.format2.AutoSize = true;
            this.format2.Location = new System.Drawing.Point(135, 4);
            this.format2.Margin = new System.Windows.Forms.Padding(4);
            this.format2.Name = "format2";
            this.format2.Size = new System.Drawing.Size(122, 21);
            this.format2.TabIndex = 3;
            this.format2.TabStop = true;
            this.format2.Text = "Multiple choice";
            this.format2.UseVisualStyleBackColor = true;
            this.format2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.format2);
            this.panel1.Controls.Add(this.format1);
            this.panel1.Location = new System.Drawing.Point(20, 126);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 31);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.answerEIsCorrect);
            this.panel2.Controls.Add(this.answerDIsCorrect);
            this.panel2.Controls.Add(this.answerCIsCorrect);
            this.panel2.Controls.Add(this.answerBIsCorrect);
            this.panel2.Controls.Add(this.answerAIsCorrect);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.answerE);
            this.panel2.Controls.Add(this.answerD);
            this.panel2.Controls.Add(this.answerC);
            this.panel2.Controls.Add(this.answerB);
            this.panel2.Controls.Add(this.answerA);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 164);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 322);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(510, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 34);
            this.label9.TabIndex = 16;
            this.label9.Text = "Correct answer";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Possible answers";
            // 
            // answerEIsCorrect
            // 
            this.answerEIsCorrect.AutoSize = true;
            this.answerEIsCorrect.Location = new System.Drawing.Point(528, 234);
            this.answerEIsCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.answerEIsCorrect.Name = "checkBox5";
            this.answerEIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.answerEIsCorrect.TabIndex = 14;
            this.answerEIsCorrect.UseVisualStyleBackColor = true;
            // 
            // answerDIsCorrect
            // 
            this.answerDIsCorrect.AutoSize = true;
            this.answerDIsCorrect.Location = new System.Drawing.Point(528, 189);
            this.answerDIsCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.answerDIsCorrect.Name = "checkBox4";
            this.answerDIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.answerDIsCorrect.TabIndex = 13;
            this.answerDIsCorrect.UseVisualStyleBackColor = true;
            // 
            // answerCIsCorrect
            // 
            this.answerCIsCorrect.AutoSize = true;
            this.answerCIsCorrect.Location = new System.Drawing.Point(528, 144);
            this.answerCIsCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.answerCIsCorrect.Name = "checkBox3";
            this.answerCIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.answerCIsCorrect.TabIndex = 12;
            this.answerCIsCorrect.UseVisualStyleBackColor = true;
            // 
            // answerBIsCorrect
            // 
            this.answerBIsCorrect.AutoSize = true;
            this.answerBIsCorrect.Location = new System.Drawing.Point(528, 100);
            this.answerBIsCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.answerBIsCorrect.Name = "checkBox2";
            this.answerBIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.answerBIsCorrect.TabIndex = 11;
            this.answerBIsCorrect.UseVisualStyleBackColor = true;
            // 
            // answerAIsCorrect
            // 
            this.answerAIsCorrect.AutoSize = true;
            this.answerAIsCorrect.Location = new System.Drawing.Point(528, 57);
            this.answerAIsCorrect.Margin = new System.Windows.Forms.Padding(4);
            this.answerAIsCorrect.Name = "checkBox1";
            this.answerAIsCorrect.Size = new System.Drawing.Size(18, 17);
            this.answerAIsCorrect.TabIndex = 10;
            this.answerAIsCorrect.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(465, 274);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 274);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Insert Poll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.insertOrUpdateButton_Click);
            // 
            // answerE
            // 
            this.answerE.Location = new System.Drawing.Point(37, 232);
            this.answerE.Margin = new System.Windows.Forms.Padding(4);
            this.answerE.Name = "textBox6";
            this.answerE.Size = new System.Drawing.Size(464, 22);
            this.answerE.TabIndex = 9;
            // 
            // answerD
            // 
            this.answerD.Location = new System.Drawing.Point(35, 188);
            this.answerD.Margin = new System.Windows.Forms.Padding(4);
            this.answerD.Name = "textBox5";
            this.answerD.Size = new System.Drawing.Size(466, 22);
            this.answerD.TabIndex = 8;
            // 
            // answerC
            // 
            this.answerC.Location = new System.Drawing.Point(33, 144);
            this.answerC.Margin = new System.Windows.Forms.Padding(4);
            this.answerC.Name = "textBox4";
            this.answerC.Size = new System.Drawing.Size(468, 22);
            this.answerC.TabIndex = 7;
            // 
            // answerB
            // 
            this.answerB.Location = new System.Drawing.Point(33, 100);
            this.answerB.Margin = new System.Windows.Forms.Padding(4);
            this.answerB.Name = "textBox3";
            this.answerB.Size = new System.Drawing.Size(468, 22);
            this.answerB.TabIndex = 6;
            // 
            // answerA
            // 
            this.answerA.Location = new System.Drawing.Point(33, 55);
            this.answerA.Margin = new System.Windows.Forms.Padding(4);
            this.answerA.Name = "textBox2";
            this.answerA.Size = new System.Drawing.Size(468, 22);
            this.answerA.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 236);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "E";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 192);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "C";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "A";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.falseRadio);
            this.panel3.Controls.Add(this.trueRadio);
            this.panel3.Location = new System.Drawing.Point(19, 164);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 106);
            this.panel3.TabIndex = 6;
            this.panel3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Select the correct answer";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(465, 60);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(356, 60);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 8;
            this.button4.Text = "Insert Poll";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.insertOrUpdateButton_Click);
            // 
            // falseRadio
            // 
            this.falseRadio.AutoSize = true;
            this.falseRadio.Location = new System.Drawing.Point(80, 33);
            this.falseRadio.Margin = new System.Windows.Forms.Padding(4);
            this.falseRadio.Name = "falseRadio";
            this.falseRadio.Size = new System.Drawing.Size(63, 21);
            this.falseRadio.TabIndex = 1;
            this.falseRadio.TabStop = true;
            this.falseRadio.Text = "False";
            this.falseRadio.UseVisualStyleBackColor = true;
            // 
            // trueRadio
            // 
            this.trueRadio.AutoSize = true;
            this.trueRadio.Location = new System.Drawing.Point(13, 31);
            this.trueRadio.Margin = new System.Windows.Forms.Padding(4);
            this.trueRadio.Name = "TrueRadio";
            this.trueRadio.Size = new System.Drawing.Size(59, 21);
            this.trueRadio.TabIndex = 0;
            this.trueRadio.TabStop = true;
            this.trueRadio.Text = "True";
            this.trueRadio.UseVisualStyleBackColor = true;
            // 
            // questionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(605, 505);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poll Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QuestionBox;
        private System.Windows.Forms.RadioButton format1;
        private System.Windows.Forms.RadioButton format2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox answerE;
        private System.Windows.Forms.TextBox answerD;
        private System.Windows.Forms.TextBox answerC;
        private System.Windows.Forms.TextBox answerB;
        private System.Windows.Forms.TextBox answerA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox answerAIsCorrect;
        private System.Windows.Forms.CheckBox answerEIsCorrect;
        private System.Windows.Forms.CheckBox answerDIsCorrect;
        private System.Windows.Forms.CheckBox answerCIsCorrect;
        private System.Windows.Forms.CheckBox answerBIsCorrect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton falseRadio;
        private System.Windows.Forms.RadioButton trueRadio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}