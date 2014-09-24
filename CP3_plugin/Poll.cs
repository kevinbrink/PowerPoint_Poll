using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CP3_plugin
{
    public partial class Poll : Form
    {
        public Poll()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                // Try to get the number of questions
                uint totalQuestions = Convert.ToUInt32(numQuestionsTextBox.Text);
                // Close the poll dialog
                this.Close();
                // Create the first question
                queueQuestion(1, totalQuestions);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please insert a valid positive number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        // This function creates a new Question and displays it, and, if necessary, 
        // queues up another question to be displayed once this question has been finished
        private void queueQuestion(int questionNumber, uint totalQuestions)
        {
            Question question = new Question(questionNumber);
            question.Show();
            // If we still have another question to show
            if (questionNumber < totalQuestions)
            {
                // Recursively queue up another question
                question.Closed += new EventHandler((sender, e) => queueQuestion(questionNumber + 1, totalQuestions));
            }
        }
    }
}
