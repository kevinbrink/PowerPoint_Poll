/* Authors: Kevin Brink and Mark Friedrich
 * Filename: QuestionForm.cs
 * Purpose: Provides the questionForm class, which is the form that
 *          the user sees when they desire to insert a new question
 *          to the presentation. 
 *          
 *          This class includes constructors, and event handling
 *          
 *          It handles all of the poll insertion, including the 
 *          slide with the question and answers, as well as the 
 *          act of embedding the polling data into the slide itself
 *          using custom xml
 * 
 * */


using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace CP3_plugin {
    public partial class questionForm : Form {
        private bool editing = false;
 
        /// <summary>
        /// Default, no - paramater constructor
        /// </summary>
        public questionForm() {
            InitializeComponent();
        }

        /// <summary>
        /// A constructor used for editing polls, which received the necessary
        /// parameters to create the poll
        /// </summary>
        /// <param name="question">The question for this poll.</param>
        /// <param name="correctAnswers">A comma-delimited string of correct answers.</param>
        /// <param name="answers">An array of string answers.</param>
        public questionForm(string question, string correctAnswers, string [] answers = null)
        {
            // Initialize everything
            InitializeComponent();

            editing = true; // We are editing 

            // Setup the variables
            QuestionBox.Text = question;
            // If we didn't have answers, we know it's a true/false
            if (answers == null)
            {
                format1.Checked = true;
                // If true is correct
                if (Convert.ToBoolean(correctAnswers))
                {
                    trueRadio.Checked = true;
                }
                else
                {
                    falseRadio.Checked = true;
                }
            }
            else
            { // Multiple choice
                format2.Checked = true;
                // Iterate through each correct correctAnswer
                foreach (string correctAnswer in correctAnswers.Split(','))
                {
                    // Set up each correct correctAnswer
                    switch (correctAnswer)
                    {
                        case "A":
                            answerAIsCorrect.Checked = true;
                            break;
                        case "B":
                            answerBIsCorrect.Checked = true;
                            break;
                        case "C":
                            answerCIsCorrect.Checked = true;
                            break;
                        case "D":
                            answerDIsCorrect.Checked = true;
                            break;
                        case "E":
                            answerEIsCorrect.Checked = true;
                            break;
                    }
                }
                // Set up answers
                answerA.Text = answers[0];
                answerB.Text = answers[1];
                answerC.Text = answers[2];
                answerD.Text = answers[3];
                answerE.Text = answers[4];
                // Update button text
            }
            button4.Text = "Update Poll";
            button1.Text = "Update Poll";
        }

        /// <summary>
        /// Activates when question type is changed. Show correctAnswer field based on radio buttons
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">arguments.</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && ((RadioButton)sender).Text.Contains("True"))
            {
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else
            {
                panel2.Visible = true;
                panel3.Visible = false;
            }
        }

        /// <summary>
        /// Activates when cancel button is clicked. Just close dialog
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">arguments.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Activates when the insert or update button is clicked. Calls a 
        /// function to do the updating / inserting
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">arguments.</param>
        private void insertOrUpdateButton_Click(object sender, EventArgs e)
        {
            // add or edit new slide with metadata here
            addOrUpdatePoll();            
        }

        /// <summary>
        /// Inserts all the polling data to the slide. 
        /// Calls a function (addOrUpdatePollSlide) to modify the actual slide
        /// with the question and answers
        /// </summary>
        private void addOrUpdatePoll() 
        {
            // Error checking first
            string error = checkForErrors();
            if (error != null)
            {
                MessageBox.Show(error, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return; // Exit; don't do any more processing
            }

            // Get access to the presentation
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.Presentation presentation = ppApp.ActivePresentation;
            PowerPoint.Slide sld;
            PowerPoint.Slide currentSlide;
            // Attempt to get current slide
            try
            {
                currentSlide = ppApp.ActiveWindow.View.Slide;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                // Couldn't get that slide; just use the last one of the presentation
                currentSlide = ppApp.ActivePresentation.Slides[ppApp.ActivePresentation.Slides.Count];
            }

            if (!editing)
            {
                // add new slide and make it active
                // NOTE: I know it's bad practice to hard code the 7 as the index, but I have yet to figure out how to stably get access to the custom layout
                sld = presentation.Slides.AddSlide(currentSlide.SlideIndex + 1, presentation.SlideMaster.CustomLayouts[7]);
                ppApp.ActiveWindow.View.GotoSlide(sld.SlideIndex);
            }
            else
            {
                // Get the current slide
                sld = currentSlide;
            }
            
            // get current active slide

            // get data from dialog
            string question = QuestionBox.Text;
            string answerString = "";
            string correctAnswer = "";
            string[] answers;

            if (format1.Checked){
                // true or false                
                if (trueRadio.Checked){
                    correctAnswer = "true";
                } else if (falseRadio.Checked) {
                    correctAnswer = "false";
                }
                
                // Populate the answers array
                answers =  new string[] {"true", "false"};
            }else if (format2.Checked) {// multiple choice
                
                // Populate the array of answers
                answers = new string[]{answerA.Text, answerB.Text, answerC.Text, answerD.Text, answerE.Text};
                // Iterate through the array
                for (int i = 1; i <= answers.Length; ++i)
                {
                    // Add each answer to the answer string
                    answerString += "<Answer" + i + ">" + answers[i - 1] + "</Answer" + i + ">";
                }
                if (answerAIsCorrect.Checked) correctAnswer = correctAnswer + "A,";

                if (answerBIsCorrect.Checked) correctAnswer = correctAnswer + "B,";

                if (answerCIsCorrect.Checked) correctAnswer = correctAnswer + "C,";

                if (answerDIsCorrect.Checked) correctAnswer = correctAnswer + "D,";

                if (answerEIsCorrect.Checked) correctAnswer = correctAnswer + "E";
            } else { // No format selected; shouldn't ever occur
                // error must select correct correctAnswer first
                MessageBox.Show("You must specify a question format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // create custom xml tag and insert
            //http://code.msdn.microsoft.com/office/PowerPoint-2010-Use-Custom-794ffe88

            // Edit existing
            if (editing)
            {
                CustomXMLPart data = sld.CustomerData._Index(1);
                data.SelectSingleNode("/CP3Poll/PollQuestion").Text = question;
                data.SelectSingleNode("/CP3Poll/PollCorrectAnswer").Text = correctAnswer;
                var pollAnswers = data.SelectSingleNode("/CP3Poll/PollAnswers");
                if (format1.Checked) // True / false
                {
                    if (pollAnswers != null)
                    {// We used to have pollAnswers, because it used to be a MC
                        // Delete the node
                        pollAnswers.Delete();
                    }
                    data.SelectSingleNode("/CP3Poll/PollType").Text = "True or False";
                }
                else
                { // Multiple choice
                    if (pollAnswers != null)
                    {
                        // It's much more straight-forward to remove all answers and re-add them, as opposed
                        // to trying to replace xml:
                        pollAnswers.Delete();
                    }
                    // Add a new node with the answer string
                    data.SelectSingleNode("/CP3Poll").AppendChildSubtree("<PollAnswers>" + answerString + "</PollAnswers>");

                    data.SelectSingleNode("/CP3Poll/PollType").Text = "Multiple choice";
                }
            }
            else
            { // New data
                CustomXMLPart pollData = sld.CustomerData.Add();
                if (format1.Checked) // True / False question
                {
                    // Load the XML for the poll into the slide
                    pollData.LoadXML("<?xml version=\"1.0\" encoding=\"utf-8\" ?><CP3Poll><PollType>True or False</PollType><PollQuestion>" 
                        + question + "</PollQuestion><PollCorrectAnswer>" 
                        + correctAnswer + "</PollCorrectAnswer></CP3Poll>");
                }
                else // Multiple choice question
                {
                    pollData.LoadXML("<?xml version=\"1.0\" encoding=\"utf-8\" ?><CP3Poll><PollType>Multiple choice</PollType><PollQuestion>" 
                        + question + "</PollQuestion><PollAnswers>" 
                        + answerString + "</PollAnswers><PollCorrectAnswer>" 
                        + correctAnswer + "</PollCorrectAnswer></CP3Poll>");
                }
            }                  

            // How to read XML data
            //CustomXMLPart data = ppSR.CustomerData._Index(1);
            //MessageBox.Show(data.SelectSingleNode("/CP3Poll/PollQuestion").Text, "Poll Question", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            // Add Text to slide
            addOrUpdatePollSlide(ppApp.ActiveWindow.Selection.SlideRange, format1.Checked, QuestionBox.Text, answers);
            
            Close(); // the dialog
        }

        /// <summary>
        /// This function either returns null (validation was successful) or an error message
        /// </summary>
        private string checkForErrors()
        {
            // Ensure we have a question
            if (QuestionBox.Text.Length == 0)
            {
                return "The Question is missing. Please enter a question";
            }

            if (format2.Checked) { // Multiple Choice
                // Variables for validation checking
                int numAnswers = 0;
                bool noCorrectAnswers = true;

                // Create an array of answers
                string[] answers = new string[]{answerA.Text, answerB.Text, answerC.Text, answerD.Text, answerE.Text};
                // Create an array of correctAnswers
                bool[] correctAnswers = new bool[]{answerAIsCorrect.Checked, answerBIsCorrect.Checked, answerCIsCorrect.Checked, answerDIsCorrect.Checked, answerEIsCorrect.Checked, };
                
                // Iterate through arrays
                for (int i = 0; i < answers.Length; ++i) {
                    if (answers[i].Length > 0){ // This answer is not blank
                        numAnswers++; // Increment the number of answers
                        if (correctAnswers[i]) { // This is a correct answer
                            noCorrectAnswers = false;
                        }

                        // If it's not the last answer
                        if (i < (answers.Length - 1))
                        { 
                            // Check to see if this answer is a duplicate of any other answers
                            for (int j = 0; j < answers.Length; ++j)
                            {
                                // If we're not comparing to the same answer, and they're equal
                                if (j != i && answers[i].Equals(answers[j]))
                                {
                                    return "Duplicate answers found: " + answers[i] + ". Please remove or change duplicates";
                                }
                            }
                        }
                    } else if (correctAnswers[i]) { // We don't have an answer, but it's supposedly correct?
                        return "A blank answer has been specified as correct. Please either enter an answer, or unmark as correct";
                    }
                }
                if (numAnswers < 2) {
                    return "The number of answers is less than two. Please specificy at least two possible answers";
                }
                if (noCorrectAnswers) {
                    return "No correct answers were given. Please specify at least one correct answer";
                }
            }

            if (format1.Checked &&
                !trueRadio.Checked &&
                !falseRadio.Checked) {
                return "No correct answer was specified for true / false question. Please select a correct answer";
            }
            // No errors; return null
            return null;
        }

        /// <summary>
        /// This function does the modifications on the slide, like adding
        /// question and answers
        /// </summary>
        /// <param name="sld">The current slide.</param>
        /// <param name="isTrueFalse">A boolean to tell whether this question type is true or false or not.</param>
        /// <param name="question">The question.</param>
        /// <param name="answers">An array of possible answers. Not used for true / false questions</param>
        private void addOrUpdatePollSlide(PowerPoint.SlideRange sld, bool isTrueFalse, string question, string[] answers)
        {
            // Access the shapes on the slide
            var shapes = sld.Shapes;
            Microsoft.Office.Interop.PowerPoint.Shape questionShape;
            Microsoft.Office.Interop.PowerPoint.Shape answersShape;

            if (editing)
            {
                // Clear out all existing shapes
                shapes.Range().Delete();
            }
            // Add a new textbox for the question
            questionShape = shapes.AddTextbox(
                MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 50);
            // Add a new textbox for the answers
            answersShape = shapes.AddTextbox(
                MsoTextOrientation.msoTextOrientationHorizontal, 100, 170, 500, 50);
            questionShape.TextFrame.TextRange.Text = question;
            
            // Initialize possible answers with an empty string
            string possibleAnswers = "";
            if (isTrueFalse) { // Format of question is true / false
                possibleAnswers = "- True\n\n- False";
            } else { // Multiple choice
                // Use an array of letters to prepend to each question. Just way
                // nicer to loop
                string[] letters = new string[] { "A) ", "B) ", "C) ", "D) ", "E) " };
                for (int i = 0; i < answers.Length; ++i) {
                    if (answers[i] != "")
                    {
                        possibleAnswers += letters[i] + answers[i] + "\n\n";
                    }
                }
            }
            // Add the possible answers to the slide
            answersShape.TextFrame.TextRange.Text = possibleAnswers;
        }
    }
}
