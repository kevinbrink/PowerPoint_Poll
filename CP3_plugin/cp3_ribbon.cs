/* Authors: Kevin Brink and Mark Friedrich
 * Filename: cp3_ribbon.cs
 * Purpose: Provides the ribbon control which adds buttons for adding
 *          or editing polls. 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Windows.Forms;

// Note: Several items refer to CP3. This is for legacy reasons. 
namespace CP3_plugin {
    public partial class cp3_ribbon {
        /// <summary>
        /// Loading function
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">Event arguments.</param>
        private void cp3_ribbon_Load(object sender, RibbonUIEventArgs e) {
            // Nothing to see here
        }

        /// <summary>
        /// Called when the add poll button is clicked. Creates a new question
        /// form and shows it
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">Event arguments.</param>
        private void addPoll_Click(object sender, RibbonControlEventArgs e) {
            questionForm myFrm = new questionForm();
            myFrm.Show();
        }

        /// <summary>
        /// Called when the edit poll button is clicked. It gets all the poll
        /// data from the slide, and then creates a new question form, with all
        /// of the data pre-populated
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">Event arguments.</param>
        private void editPoll_Click(object sender, RibbonControlEventArgs e)
        {
            // Get the current slide
            PowerPoint.Slide sld = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            
            // Get access to the xml for that slide
            CustomXMLPart xml = sld.CustomerData._Index(1);
            string question = xml.SelectSingleNode("/CP3Poll/PollQuestion").Text;
            string type = xml.SelectSingleNode("/CP3Poll/PollType").Text;
            string correctAnswer = xml.SelectSingleNode("/CP3Poll/PollCorrectAnswer").Text;

            // Ensure we got valid results
            if (question != null && type != null && correctAnswer != null)
            {
                // If this is a multiple choice question
                if (type.ToLower().Contains("multiple choice"))
                {
                    string[] answers = new string[5];
                    // Iterate through each possible correctAnswer
                    for (int i = 1; i <= 5; ++i)
                    {
                        // Add the correctAnswer to the array
                        answers[i-1] = xml.SelectSingleNode("/CP3Poll/PollAnswers/Answer" + i).Text;
                    }
                    // Populate a new question poll with the information
                    questionForm editPoll = new questionForm(question, correctAnswer, answers);
                    // Display it
                    editPoll.Show();
                }
                else
                { // True / false
                    // Create and show the poll form
                    questionForm editPoll = new questionForm(question, correctAnswer);
                    editPoll.Show();
                }
            }
        }
    }
}
