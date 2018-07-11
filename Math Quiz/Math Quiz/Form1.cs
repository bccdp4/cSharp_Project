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

        // These integer variables store the numbers
        // for the subtraction problem

        int minuend;
        int subtrahend;

        // These integer variables store the numbers
        // for the multiplication problem

        int multiplicand;
        int multiplier;

        // These integer variables store the numbers
        // for the division problem

        int dividend;
        int divisor;

        // These integer variables store the numbers
        // for the modulus problems

        int mod1;
        int mod2;

        // These integer variables store the numbers
        // for the exponenet problems

        double number;
        double power;

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

            // subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // modulus problem
            mod1 = randomizer.Next(1, 100);
            mod2 = 2;
            modLabelLeft.Text = mod1.ToString();
            modLabelRight.Text = mod2.ToString();
            remainder.Value = 0;

            // exponent problem
  /*          number = randomizer.Next(1, 4);
            power = randomizer.Next(1, 3);
            powerLeftLabel.Text = number.ToString();
            powerRightLabel.Text = power.ToString();
            exponential.Value = 0;*/
            

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
            timeLabel.BackColor = Color.Transparent;
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
                timeLabel.BackColor = Color.Transparent;
            }

            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds.";
                if (timeLeft < 16)
                {
                    timeLabel.BackColor = Color.Yellow;
                    if (timeLeft < 6)
                    {
                        timeLabel.BackColor = Color.Red;
                    }
                }

                
            }

            else {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.

                timer1.Stop();
                timeLabel.Text = "Time's up!!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                remainder.Value = mod1 % mod2;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Transparent;
            }
        }

        private bool CheckTheAnswer()
        {
            if((addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value)
                && (mod1 % mod2 == remainder.Value))
            {
                return true;
            }
            else {
                return false;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }


    }
}
