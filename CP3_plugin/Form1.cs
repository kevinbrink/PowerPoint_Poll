﻿using Microsoft.Office.Core;
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
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange ppSR = ppApp.ActiveWindow.Selection.SlideRange;
            // Poll slide label
            ppSR.Shapes.AddLabel(MsoTextOrientation.msoTextOrientationHorizontal, 10, 10, 100, 100).TextFrame.TextRange.Text = "POLL SLIDE";

            // get data from dialog
            int slideIndex = ppSR.SlideIndex;
            string question = QuestionBox.Text;
            string ans1, ans2, ans3, ans4, ans5;
            string answerString = "";
            string correctAnswer = "";

            if (format1.Checked){
                // true or false                
                if (TrueRadio.Checked){
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
            }else if (format2.Checked) {
                // multiple choice
                ans1 = textBox2.Text;
                answerString = answerString + "<Answer1>" + ans1 + "</Answer1>";
                if (checkBox1.Checked) correctAnswer = correctAnswer + "A,";

                ans2 = textBox3.Text;
                answerString = answerString + "<Answer2>" + ans2 + "</Answer2>";
                if (checkBox2.Checked) correctAnswer = correctAnswer + "B,";

                ans3 = textBox4.Text;
                answerString = answerString + "<Answer3>" + ans3 + "</Answer3>";
                if (checkBox3.Checked) correctAnswer = correctAnswer + "C,";

                ans4 = textBox5.Text;
                answerString = answerString + "<Answer4>" + ans4 + "</Answer4>";
                if (checkBox4.Checked) correctAnswer = correctAnswer + "D,";

                ans5 = textBox6.Text;
                answerString = answerString + "<Answer5>" + ans5 + "</Answer5>";
                if (checkBox5.Checked) correctAnswer = correctAnswer + "E";

                if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
                {
                    // error must select correct answer first
                    MessageBox.Show("There was no correct answer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
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

            Close();
                        
        }
    }
}
