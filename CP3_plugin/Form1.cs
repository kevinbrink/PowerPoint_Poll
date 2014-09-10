using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            Close();
        }
    }
}
