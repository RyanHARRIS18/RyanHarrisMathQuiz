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
    public partial class MathQuiz : Form
    {
        

        // object to generate random numbers.
        Random randomizer = new Random();

        // store the numbers for the addition problem. 
        int addend1;
        int addend2;

        // store the numbers for the subtraction problem. 
        int minuend;
        int subtrahend;

        //store the numbers for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // store numbers for the division problem. 
        int dividend;
        int divisor;

        // stores remaining time.
        int timeLeft;

        // Get current date
        public void getDateNow()
        {
            DateTime currentDate = DateTime.Today;
            string thisDate = String.Format("{0: dd MMMM yyyy}", currentDate);
            myDate.Text = thisDate;

        }
        
        /// Start the quiz by filling in all of the problems and starting the timer.
        public void StartTheQuiz()
        {

            // Fill in the addition problem. Generate two random numbers to add. Store the values in the variables.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers  into strings so that they can be displayed in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //Set value is zero on Sum before adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true,  Stop the timer and show a sucess MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep decreasing the time left by one second and  display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
               if (timeLeft < 5)
                {
                    timeLabel.BackColor = Color.Red;
                } 
            }
            else
            {
                // If the user ran out of time, stop the timer, show a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        /// Check the answer to see if the user got everything right.
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
            && (minuend - subtrahend == difference.Value)
            && (multiplicand * multiplier == product.Value)
            && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public MathQuiz()
        {

            InitializeComponent();
            getDateNow();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MathQuiz_Load(object sender, EventArgs e)
        {

        }

        private void timeLabel_click(object sender, EventArgs e)
        {

        }
    }
}