using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Create a random object called randomizer
        // to generate random numbers.
        Random randomizer = new Random();


        int addend1;
        int addend2;

        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        public void StartTheQuiz() {
            // Fill in the addition problem.
            // Generate 2 random numbers to add.
            // Store the values in the variebles 'addend1' and 'addend2'

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the Numeric UpDown control.
            // This step makes sure its value is zero before 
            // adding any values to it.

            sum.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer()) {
                // If CheckTheAnswer() returns true, then the user
                // got the answer right. Stop the timer
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations I guess!");
                startButton.Enabled = true;
            }

            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds.";
            }

            else {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.

                timer1.Stop();
                timeLabel.Text = "Time's up!!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if(addend1 + addend2 == sum.Value)
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {

        }
    }
}
