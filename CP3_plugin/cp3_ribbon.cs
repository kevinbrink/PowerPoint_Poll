using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Core;
using System.Windows.Forms;

namespace CP3_plugin {
    public partial class cp3_ribbon {
        private void cp3_ribbon_Load(object sender, RibbonUIEventArgs e) {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e) {
            Form1 myFrm = new Form1();
            myFrm.Show();
        }

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
                // TODO: Change this question type thing to an enum
                if (type.ToLower().Contains("multiple choice"))
                {
                    string[] answers = new string[5];
                    // Iterate through each possible correctAnswer
                    for (int i = 1; i <= 5; ++i)
                    {
                        // Add the correctAnswer to the array
                        answers[i-1] = xml.SelectSingleNode("/CP3Poll/PollAnswers/Answer" + i).Text;
                    }
                    Form1 editPoll = new Form1(question, correctAnswer, answers);
                    editPoll.Show();
                }
                else
                { // True / false
                    Form1 editPoll = new Form1(question, correctAnswer);
                    editPoll.Show();
                }
            }
        }
    }
}
