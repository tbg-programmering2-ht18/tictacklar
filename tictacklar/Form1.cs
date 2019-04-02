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
        bool turn = true; // When True It's X turn, If false O's turn
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)    ///exit button
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) /// gives information when you press on about button in the meny
        {
            MessageBox.Show("By Axel", "Tic Tac Toe");
        }

        private void button_click(object sender, EventArgs e) /// the playfield
        {
            Button b = (Button)sender;              //gives the button on the playfield a value.
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turnCount++;                                // counting the moves on the playfield

            WinnerCheck();
        }

        private void WinnerCheck()                  //choose the winner
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

            //Diaganol checks
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                winner = true;



            if (winner)                                         //shows whos the winner and a popup message show if X or O won.
            {
                DisableButtons();
                string win = "";
                if (turn)
                {
                    win = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    win = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show("Player " + win + " Wins!", "Winner");
            }
            else
            {
                
                    if (turnCount == 9)                                    // If no one win a popup massage (Draw)
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                
                    MessageBox.Show("Draw! ", "Who Won!?");
            }
        }

        private void DisableButtons()                           //Disable the rest of buttons when someone has won or it's a draw.
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
       
        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e) // crate a new match when you press on button "New Game"
        {
            turn = true;                        // resets the playfield after a new game starts.
            turnCount = 0;
            
                foreach (Control c in Controls) // enable all button again.
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
            }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "x";                
                else
                b.Text = "o";
            
        }

        private void button_leave(object sender, MouseEventArgs e)
        {

        }

        private void button_leave(object sender, EventArgs e)
        {

        }
    }
    }


