using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Core;

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
            // add meta data to slide here
            addPoll();
            Close();
        }
        private void addPoll()
        {
            var presentation = Globals.ThisAddIn.Application.ActivePresentation;
            // Add the slide to the end of the presentation
            var sld = presentation.Slides.AddSlide(presentation.Slides.Count + 1, presentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutTitle]);
            // TODO: Use something better; I want this to work: var sld = presentation.Slides.AddSlide(1, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank);
            var shapes = sld.Shapes;
            // Clear out all the existing shapes first (from the range of 1 to the number of shapes we have on the slide)
            // TODO: Figure out a way to not have to do this
            shapes.Range(new int[2] { 1, shapes.Count }).Delete();
            // Add a new textbox for the question
            Microsoft.Office.Interop.PowerPoint.Shape questionShape = shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 50);
            questionShape.TextFrame.TextRange.InsertAfter(question.Text);
            // Add a new textbox for the answers
            Microsoft.Office.Interop.PowerPoint.Shape answersShape = shapes.AddTextbox(
                Office.MsoTextOrientation.msoTextOrientationHorizontal, 100, 170, 500, 50);

            
            //DocumentProperties properties;
            //properties = (DocumentProperties)presentation.CustomDocumentProperties;
            //// Check to see if don't already have this property
            //if (properties["Slides with Polls"] == null) 
            //{
            //    properties.Add("Slides with Polls", false, MsoDocProperties.msoPropertyTypeString, "");
            //}

            //// Add to the property; semi-colon delimited list of slides that have polls
            //// TODO: Make this an actual array, or bind this info to the sld object itself
            //properties["Slides with Polls"].Value += presentation.Slides.Count + ";";

            //// Check to see what type of question it is
            //if (trueFalse.Checked)
            //{
            //    answersShape.TextFrame.TextRange.InsertAfter("- True\n\n- False");
            //    if (properties["Poll Correct Answers"] == null) 
            //    {
            //        properties.Add("Poll Correct Answers", false, MsoDocProperties.msoPropertyTypeString, "");
            //    }
            //    // Each question has an entry in the correct answers delimited by semi-colons
            //    properties["Poll Correct Answers"].Value += true.Value + ";";
            //}
            //else
            //{ // Multiple choice
            //    // Set up all the possible answers
            //    string possibleAnswers = "A) " + answerA.Text + "\n\n"
            //     + "B) " + answerB.Text + "\n\n"
            //     + "C) " + answerC.Text + "\n\n"
            //     + "D) " + answerD.Text + "\n\n"
            //     + "E) " + answerE.Text;
            //    answersShape.TextFrame.TextRange.InsertAfter(possibleAnswers);
            //    if (properties["Poll Correct Answers"] == null) 
            //    {
            //        properties.Add("Poll Correct Answers", false, MsoDocProperties.msoPropertyTypeString, "");
            //    }
            //    string correctAnswers;
            //    // Add each of the correct answers for this question to a comma-delimited list
            //    if (answerAIsCorrect.Checked) { correctAnswers += "A,"}
            //    if (answerBIsCorrect.Checked) { correctAnswers += "B,"}
            //    if (answerCIsCorrect.Checked) { correctAnswers += "C,"}
            //    if (answerDIsCorrect.Checked) { correctAnswers += "D,"}
            //    if (answerEIsCorrect.Checked) { correctAnswers += "E,"}
            //    properties["Poll Correct Answers"].Value += correctAnswers + ";";
            //}

            // TODO: At this point, we need to add some sort of data to the 
            // powerpoint file that allows CP to parse out the data
            var customXML = sld.CustomerData.Add();
            customXML.LoadXML("<Question>" + question.Text + "</Question>");
            //Sld.HeaderFooter
            //Sld.HeadersFooters
            //Sld.NotesPage
            //Sld.Tags
            // If we don't already have this property
           

            //properties.Add()
            //properties["slidesWithPolls"];
        }
    }
}
