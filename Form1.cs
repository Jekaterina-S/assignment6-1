using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment6_1
{
    // string constants
    struct StringConstants
    {
        // choises
        public const string Rock = "Rock";
        public const string Paper = "Paper";
        public const string Scissors = "Scissors";
        // win states
        public const string Win = "You win.";
        public const string Lose = "You lose.";
        public const string Tie = "You tie.";
        // choise combinations
        public const string PaperRock = "Paper wraps rock.";
        public const string RockScissors = "Rock smashes scissors.";
        public const string ScissorsPaper = "Scissors cur paper.";
    }

    public partial class Form1 : Form
    {
        private string computerChoise = ComputerChoise();

        public Form1()
        {
            InitializeComponent();
        }

        // rock choise
        private void button1_Click(object sender, EventArgs e)
        {
            GameWin(StringConstants.Rock);
        }

        // paper choise
        private void button2_Click(object sender, EventArgs e)
        {
            GameWin(StringConstants.Paper);
        }

        // scissor choise
        private void button3_Click(object sender, EventArgs e)
        {
            GameWin(StringConstants.Scissors);
        }

        // try again button
        private void button4_Click(object sender, EventArgs e)
        {
            WindowRenew();
        }

        // computer random choise
        private static string ComputerChoise()
        {
            Random generator = new Random();
            int number = generator.Next(1, 4);

            switch (number)
            {
                case 1:
                    return StringConstants.Rock;
                case 2:
                    return StringConstants.Paper;
                case 3:
                    return StringConstants.Scissors;
                default:
                    return "None";
            }
        }

        // renew window
        private void WindowRenew()
        {
            label2.Hide();
            label3.Text = "";
            label5.Text = "";
            button4.Hide();

            computerChoise = ComputerChoise();

            button1.Show();
            button2.Show();
            button3.Show();
        }

        // win game
        private void GameWin(string playerChoise)
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();

            if (playerChoise == computerChoise) {
                label3.Text = StringConstants.Tie;
                button4.Show();
            }
            else if (playerChoise == StringConstants.Rock) {
                switch (computerChoise) {
                    case "Paper":
                        label3.Text = $"{StringConstants.PaperRock}\n{StringConstants.Lose}";
                        break;
                    case "Scissors":
                        label3.Text = $"{StringConstants.RockScissors}\n{StringConstants.Win}";
                        break;
                }
            } else if (playerChoise == StringConstants.Paper)
            {
                switch (computerChoise)
                {
                    case "Scissors":
                        label3.Text = $"{StringConstants.ScissorsPaper}\n{StringConstants.Lose}";
                        break;
                    case "Rock":
                        label3.Text = $"{StringConstants.PaperRock}\n{StringConstants.Win}";
                        break;
                }
            }
            else if (playerChoise == StringConstants.Scissors)
            {
                switch (computerChoise)
                {
                    case "Rock":
                        label3.Text = $"{StringConstants.RockScissors}\n{StringConstants.Lose}";
                        break;
                    case "Paper":
                        label3.Text = $"{StringConstants.ScissorsPaper}\n{StringConstants.Win}";
                        break;
                }
            }

            label2.Text = computerChoise;
            label5.Text = playerChoise;
            label2.Show();
            button4.Show();
        }
    }
}
