using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        bool Turn = true; // When True It's X turn, If false O's turn


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Axel", "Tic Tac Toe");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (Turn)
                b.Text = "X";
            else
                b.Text = "O";

            Turn = !Turn;
            b.Enabled = false;

            WinnerCheck();
        }

        private void WinnerCheck()
        {
            bool winner = false;


            //horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            //vertical checks
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            //obliquely checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winner = true;



            if (winner)
            {
                DisableButtons();
                string win = "";
                if (Turn)
                    win = "O";
                else
                    win = "X";
                MessageBox.Show("Player " + win + " Wins!", "Winner");
            }

        }

        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void A3_Click(object sender, EventArgs e)
        {

        }
    }
}