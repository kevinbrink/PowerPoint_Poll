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
    public partial class Form1 : Form { 
        public Form1() {
            InitializeComponent();
        }

        // show answer field based on radio buttons
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

        // cancel button clicked
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        // insert meta data and close form
        private void button1_Click(object sender, EventArgs e)
        {
            // add new slide with metadata here
            addPoll();
            Close();
        }

        private void addPoll() {
            // Get access to the presentation
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.Presentation presentation = ppApp.ActivePresentation;

            // add new slide and make it active
            // NOTE: I know it's bad practice to hard code the 7 as the index, but I have yet to figure out how to stably get access to the custom layout
            var sld = presentation.Slides.AddSlide(ppApp.ActiveWindow.View.Slide.SlideIndex + 1, presentation.SlideMaster.CustomLayouts[7]);
            ppApp.ActiveWindow.View.GotoSlide(sld.SlideIndex);
            
            // get current active slide
            PowerPoint.SlideRange ppSR = ppApp.ActiveWindow.Selection.SlideRange;

            // get data from dialog
            int slideIndex = ppApp.ActiveWindow.View.Slide.SlideIndex;
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
                else
                {
                    // error must select correct answer first
                    MessageBox.Show("There was no correct answer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                // Populate the answers array
                answers =  new string[] {"true", "false"};
            }else if (format2.Checked) {// multiple choice
                // First check to make sure we have at least one 'correct' answer
                if (answerAIsCorrect.Checked == false && answerBIsCorrect.Checked == false && answerCIsCorrect.Checked == false && answerDIsCorrect.Checked == false && answerEIsCorrect.Checked == false)
                {
                    // error must select correct answer first
                    MessageBox.Show("There was no correct answer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                // Populate the array of answers
                answers = new string[]{answerA.Text, answerB.Text, answerC.Text, answerD.Text, answerE.Text};
                // Iterate through the array
                for (int i = 1; i <= answers.Length; ++i)
                {
                    // Add each answer to the answer string
                    answerString += "<Answer" + i + ">" + answers[i-1] + "</Answer" + i + ">";
                }
                if (answerAIsCorrect.Checked) correctAnswer = correctAnswer + "A,";

                if (answerBIsCorrect.Checked) correctAnswer = correctAnswer + "B,";

                if (answerCIsCorrect.Checked) correctAnswer = correctAnswer + "C,";

                if (answerDIsCorrect.Checked) correctAnswer = correctAnswer + "D,";

                if (answerEIsCorrect.Checked) correctAnswer = correctAnswer + "E";
            } else { // No format selected; shouldn't ever occur
                // error must select correct answer first
                MessageBox.Show("You must specify a question format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // create custom xml tag and insert
            //http://code.msdn.microsoft.com/office/PowerPoint-2010-Use-Custom-794ffe88

            CustomXMLPart pollData = ppSR.CustomerData.Add();
            if (format1.Checked)
            {
                pollData.LoadXML("<?xml version=\"1.0\" encoding=\"utf-8\" ?><CP3Poll><PollSlide>" + slideIndex + "</PollSlide><PollType>True or False</PollType><PollQuestion>" + question + "</PollQuestion><PollCorrectAnswer>" + correctAnswer + "</PollCorrectAnswer></CP3Poll>");
            } else {
                pollData.LoadXML("<?xml version=\"1.0\" encoding=\"utf-8\" ?><CP3Poll><PollSlide>" + slideIndex + "</PollSlide><PollType>Multiple choice</PollType><PollQuestion>" + question + "</PollQuestion><PollAnswers>" + answerString + "</PollAnswers><PollCorrectAnswer>" + correctAnswer + "</PollCorrectAnswer></CP3Poll>");
            }                        

            // How to read XML data
            //CustomXMLPart tmp = ppSR.CustomerData._Index(1);
            //MessageBox.Show(tmp.SelectSingleNode("/CP3Poll/PollQuestion").Text, "Poll Question", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            // Add Text to slide
            addPollSlide(ppApp, format1.Checked, QuestionBox.Text, answers);
        }

        private void addPollSlide(PowerPoint.Application application, bool isTrueFalse, string question, string[] answers)
        {            
            PowerPoint.SlideRange sld = application.ActiveWindow.Selection.SlideRange;
            var shapes = sld.Shapes;
            
            // Add a new textbox for the question
            Microsoft.Office.Interop.PowerPoint.Shape questionShape = shapes.AddTextbox(
                MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 50);
            questionShape.TextFrame.TextRange.InsertAfter(question);
            // Add a new textbox for the answers
            Microsoft.Office.Interop.PowerPoint.Shape answersShape = shapes.AddTextbox(
                MsoTextOrientation.msoTextOrientationHorizontal, 100, 170, 500, 50);

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
            answersShape.TextFrame.TextRange.InsertAfter(possibleAnswers);            
            // TODO: update status bar?
            // [Note: Based on this: http://www.pcreview.co.uk/forums/acessing-powerpoint-status-bar-via-vba-t3380533.html it's not possible in 2013]
        }
    }
}
