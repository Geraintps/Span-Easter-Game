using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Unit_22___Game_Development
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string SetValueForUsername = "";
        public static string SetValueForDifficulty = "";


        private void btnStart_Click(object sender, EventArgs e)
        {

            SetValueForUsername = txtName.Text;
            SetValueForDifficulty = cmbDifficulty.Text;

            Form2 Maze = new Form2();
            Maze.Show();
            this.Hide();

        }
    }
}
