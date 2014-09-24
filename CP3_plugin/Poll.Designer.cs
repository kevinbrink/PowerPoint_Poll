namespace CP3_plugin
{
    partial class Poll
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
            this.numQuestionLabel = new System.Windows.Forms.Label();
            this.numQuestionsTextBox = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numQuestionLabel
            // 
            this.numQuestionLabel.AutoSize = true;
            this.numQuestionLabel.Location = new System.Drawing.Point(12, 9);
            this.numQuestionLabel.Name = "numQuestionLabel";
            this.numQuestionLabel.Size = new System.Drawing.Size(220, 13);
            this.numQuestionLabel.TabIndex = 0;
            this.numQuestionLabel.Text = "How many questions do you want in the poll?";
            // 
            // numQuestionsTextBox
            // 
            this.numQuestionsTextBox.Location = new System.Drawing.Point(15, 25);
            this.numQuestionsTextBox.Name = "numQuestionsTextBox";
            this.numQuestionsTextBox.Size = new System.Drawing.Size(100, 20);
            this.numQuestionsTextBox.TabIndex = 1;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(15, 47);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "Create Poll";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // Poll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 82);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.numQuestionsTextBox);
            this.Controls.Add(this.numQuestionLabel);
            this.Name = "Poll";
            this.Text = "Poll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numQuestionLabel;
        private System.Windows.Forms.TextBox numQuestionsTextBox;
        private System.Windows.Forms.Button submit;
    }
}