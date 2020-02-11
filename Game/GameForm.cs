using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameForm : Form
    {
        private bool turn = true;
        private int turn_count = 0;
        public string p1;
        public string p2;
        public int win_count_x;
        public int win_count_o;
        public string winner;
        public string opponent;
        public int w_count;
        public int o_count;
        public GameForm()
        {
            InitializeComponent();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }
       

        private void Button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";

            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            //wygrana poziomo
            bool there_is_the_winner = false;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_the_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_the_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_the_winner = true;

            //wygrana pionowo
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_the_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!B2.Enabled))
                there_is_the_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!C3.Enabled))
                there_is_the_winner = true;

            //wygrana skośnie
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_the_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled))
                there_is_the_winner = true;

            if (there_is_the_winner)
            {
                DisableButtons();

                if (turn)
                {
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                    win_count_o++;
                    NewGame();

                }
                else
                {
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                    win_count_x++;
                    NewGame();
                }
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Remis");
                    NewGame();
                }
            }
            if (win_count_x == 3)
            {
                winner = p1;
                opponent = p2;
                w_count = win_count_x;
                o_count = win_count_o;
                this.Close();
            }
            else if(win_count_o == 3)
            {
                winner = p2;
                opponent = p1;
                w_count = win_count_o;
                o_count = win_count_x;
                this.Close();
            }

        } //winner checker
        private void DisableButtons() //closer/zamykacz
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

        public void NewGame()
        {
            turn = true;
            turn_count = 0;


            foreach (Control c in Controls)
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

        private void Button_enter(object sender, EventArgs e) //enter
        {
            Button b = (Button)sender; //click2
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void Button_leave(object sender, EventArgs e) //leave
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            lblP1.Text = p1;
            lblP2.Text = p2;
        }
    }
}
