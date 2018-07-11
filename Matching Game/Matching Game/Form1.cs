﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        /* firstClicked points to the first Label control
         * that the player clicks, but it will be null
         * if the player hasn't clicked a label yet
         */
        Label firstClicked = null;

        /* secondClicked points to the second Label control
         * that the player clicks
         */
        Label secondClicked = null;


        // Use this Random object to choose random icons for the squares
        Random random = new Random();

        /* Each of these letters is an interesting icon
         * in the Webdings font,
         * and each icon appears twice in this list
         */
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", 
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        // Assign each icon from the list of icons to a random square

        private void AssignIconsToSquares()
        {
            /* The TableLayoutPanel has 16 labels,
             * and the icon list has 16 icons,
             * so an icon is pulled at random from the list
             * and added to each label
             */
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void label_Click(object sender, EventArgs e)
        {
            /* The timer is only on after two non-matching
             * icons have been shown to the player,
             * so ignore any clicks if the timer is running
             */
            if (Timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                /* If the clicked label is black, the player clicked
                 * an icon that's already been revealed --
                 * ignore that click
                 */
                if (clickedLabel.ForeColor == Color.Black)               
                    return;

                /* If firstClicked is null, this is the first icon
                 * in the pair that the player clicked,
                 * so set firstClicked to the label that the player
                 * clicked, change its color to black, and return
                 */

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                /* If the player gets this far, the timer isn't
                 * running and firstClicked isn't null,
                 * so this must be the second icon the player clicked
                 * Set its color to black
                 */
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // Check to see if player won
                CheckForWinner();

                /* If the player clicked two matching icons, keep them
                 * black and reset firstClicked and secondClicked
                 * so the player can click another icon
                 */
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                /* If the player gets this far, the player
                 * clicked two different icons, so start the
                 * timer (which will wait 3/4 seconds and then
                 * hide the icons
                 */
                Timer1.Start();
                
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            Timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            /* Reset firstClicked and secondClicked
             * so the next time a label is 
             * clicked, the program knows it's the first click
             */
            firstClicked = null;
            secondClicked = null;
        }

        /* Check every icon to see if it is matched, by
         * comparing its foreground color to its background color.
         * If all of the icons are matched, the player wins
         */
        private void CheckForWinner()
        {
            /* Go through all of the labels in the TableLayoutPanel,
             * Checking each one to see if its icon is matched
             */
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }

            /* If the loop didn't return, it didn't find
             * any unmatched icons
             * That means the user won. Show a message and close form
             */
            MessageBox.Show("You matched all the icons!", "Awesome job!");
            Close();
        }
    }
}
