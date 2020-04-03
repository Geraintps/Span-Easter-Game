using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Unit_22___Game_Development
{
    public partial class Form2 : Form
    {


        int timeLeft;
        string lastMove;
        string difficulty;


        public Form2()
        {
            InitializeComponent();
        }

        public string[,] questionEasy = { { }, { }, { }, { }, { }, { }, { }, { }, { }, { } };
        public string[,] questionMedium = { { }, { }, { }, { }, { }, { }, { }, { }, { }, { } };
        public string[,] questionHard = { { }, { }, { }, { }, { }, { }, { }, { }, { }, { } };
        public int questionCount = 0;
        public int score = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            lblUsername.Text = Form1.SetValueForUsername;

            timeLeft = 120;
            lblTime.Text = "120 seconds";
            timer1.Start();

            difficulty = Form1.SetValueForDifficulty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                lblTime.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                lblTime.Text = "Time's up!";
                MessageBox.Show("You didn't escape in time.", "Sorry!");
            }
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

            foreach (Control c in Controls)
            {
                if (c is Label)
                {
                    if (Convert.ToString(c.Tag) == "wall")
                    {
                        if (lblPlayer.Bounds.IntersectsWith(c.Bounds))
                        {
                            if (lastMove == "Up")
                            {
                                lblPlayer.Top = lblPlayer.Top + 10;
                            }
                            if (lastMove == "Down")
                            {
                                lblPlayer.Top = lblPlayer.Top - 10;
                            }
                            if (lastMove == "Right")
                            {
                                lblPlayer.Left = lblPlayer.Left - 10;
                            }
                            if (lastMove == "Left")
                            {
                                lblPlayer.Left = lblPlayer.Left + 10;
                            }
                        }                     
                    }
                    if(Convert.ToString(c.Tag) == "end")
                    {
                        if (lblPlayer.Bounds.IntersectsWith(c.Bounds))
                        {
                            timer1.Stop();
                            MessageBox.Show("You escaped with " + lblTime.Text + " to spare!");

                            Form1 Menu = new Form1();
                            Menu.Show();
                            this.Hide();
                            
                        }
                    }
                    if (Convert.ToString(c.Tag) == "egg")
                    {
                        if (lblPlayer.Bounds.IntersectsWith(c.Bounds))
                        {
                            if (difficulty == "Easy")
                            {

                            }
                            if (difficulty == "Medium")
                            {

                            }
                            if (difficulty == "Hard")
                            {

                            }
                        }
                    }
                }
            }

            if (e.KeyChar == 119)
            {
                lblPlayer.Top = lblPlayer.Top - 10;
                lblPlayer.ImageIndex = 0;
                lastMove = ("Up");
            }
            if (e.KeyChar == 115)
            {
                lblPlayer.Top = lblPlayer.Top + 10;
                lblPlayer.ImageIndex = 1;
                lastMove = ("Down");
            }
            if (e.KeyChar == 100)
            {
                lblPlayer.Left = lblPlayer.Left + 10;
                lblPlayer.ImageIndex = 2;
                lastMove = ("Right");
            }
            if (e.KeyChar == 97)
            {
                lblPlayer.Left = lblPlayer.Left - 10;
                lblPlayer.ImageIndex = 3;
                lastMove = ("Left");
            }
        }
    }
}
