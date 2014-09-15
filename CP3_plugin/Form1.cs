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
            // add meta data to slide here
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange ppSR = ppApp.ActiveWindow.Selection.SlideRange;

            // get data from dialog
            int slideIndex = ppSR.SlideIndex;
            string question = QuestionBox.Text;
            bool tfCorrect;

            if (format1.Checked){
                // true or false                
                if (TrueRadio.Checked){
                    tfCorrect = true;
                } else if (falseRadio.Checked) {
                    tfCorrect = false;
                }
                else
                {
                    // error must select correct answer first
                }
            }else if (format2.Checked){
                // multiple choice

            }

            // create custom xml tag and insert
            //http://code.msdn.microsoft.com/office/PowerPoint-2010-Use-Custom-794ffe88
            //ppSR.CustomerData

            CustomXMLPart pollData = ppSR.CustomerData.Add();
            pollData.LoadXML("<Customer><CustomerID>Customer #1</CustomerID></Customer>");

            QuestionBox.Text = Convert.ToString(pollData.XML);

            //Close();
        }
    }
}
