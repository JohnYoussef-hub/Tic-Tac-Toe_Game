using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen Pen = new Pen(Color.Black);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // Vertical
            e.Graphics.DrawLine(Pen, 680, 50, 680, 460);
            e.Graphics.DrawLine(Pen, 500, 50, 500, 460);

            // Horizontal
            e.Graphics.DrawLine(Pen, 350, 180, 840, 180);
            e.Graphics.DrawLine(Pen, 350, 330, 840, 330);
        }

        int Turn = 1;

        bool Xturn(int Turn)
        {
            if (Turn % 2 != 0)
            {
                lblTurn.Text = "Player 2 (O)";
                return true;
            }
            else
            {
                lblTurn.Text = "Player 1 (X)";
                return false;
            }
        }

        void ChangeImage(PictureBox pb)
        {
            if (Xturn(Turn))
            {
                pb.Image = Resources.X;
                pb.Tag = "X";
            }
            else
            {
                pb.Image = Resources.O;
                pb.Tag = "O";
            }

            pb.Enabled = false;
            Turn++;

            CheckWin();
        }

        private void pb_Click(object sender, EventArgs e)
        {
            ChangeImage((PictureBox)sender);
        }


        void ChangeBackColor(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            pb1.BackColor = Color.GreenYellow;
            pb2.BackColor = Color.GreenYellow;
            pb3.BackColor = Color.GreenYellow;
        }

        private bool WinStatus()
        {
            // Check horizontal rows
            if (pb1.Tag != null && pb1.Tag == pb2.Tag && pb2.Tag == pb3.Tag)
            {
                ChangeBackColor(pb1, pb2, pb3);
                return true;
            }
            if (pb4.Tag != null && pb4.Tag == pb5.Tag && pb5.Tag == pb6.Tag)
            {
                ChangeBackColor(pb4, pb5, pb6);
                return true;
            }
            if (pb7.Tag != null && pb7.Tag == pb8.Tag && pb8.Tag == pb9.Tag)
            {
                ChangeBackColor(pb7, pb8, pb9);
                return true;
            }

            // Check vertical columns
            if (pb1.Tag != null && pb1.Tag == pb4.Tag && pb4.Tag == pb7.Tag)
            {
                ChangeBackColor(pb1, pb4, pb7);
                return true;
            }
            if (pb2.Tag != null && pb2.Tag == pb5.Tag && pb5.Tag == pb8.Tag)
            {
                ChangeBackColor(pb2, pb5, pb8);
                return true;
            }
            if (pb3.Tag != null && pb3.Tag == pb6.Tag && pb6.Tag == pb9.Tag)
            {
                ChangeBackColor(pb3, pb6, pb9);
                return true;
            }

            // Check diagonals
            if (pb1.Tag != null && pb1.Tag == pb5.Tag && pb5.Tag == pb9.Tag)
            {
                ChangeBackColor(pb1, pb5, pb9);
                return true;
            }
            if (pb3.Tag != null && pb3.Tag == pb5.Tag && pb5.Tag == pb7.Tag)
            {
                ChangeBackColor(pb3, pb5, pb7);
                return true;
            }

            // No win found
            return false;
        }

        void CheckWin()
        {
            if (WinStatus())
            {
                lblWinner.Text = "Player " + (Xturn(Turn - 1) ? "1 (X)" : "2 (O) ");
                lblWins.Text = "Wins!"; lblTurn.Text = "Game Over!";
                
                pb1.Enabled = false;
                pb2.Enabled = false;
                pb3.Enabled = false;
                pb4.Enabled = false;
                pb5.Enabled = false;
                pb6.Enabled = false;
                pb7.Enabled = false;
                pb8.Enabled = false;
                pb9.Enabled = false;

                MessageBox.Show(lblWinner.Text + " Wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (Turn == 10)
            {
                lblWinner.Text = "No One Wins!";
                lblWins.Text = "(Draw)";
                lblTurn.Text = "Game Over!";

                MessageBox.Show("Draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            pb1.Enabled = true;
            pb2.Enabled = true;
            pb3.Enabled = true;
            pb4.Enabled = true;
            pb5.Enabled = true;
            pb6.Enabled = true;
            pb7.Enabled = true;
            pb8.Enabled = true;
            pb9.Enabled = true;

            lblTurn.Text = "Player 1 (X)";
            lblWinner.Text = "IN PROGRESS..";
            lblWins.Text = null;
            Turn = 1;

            pb1.Image = Resources.question_mark;
            pb2.Image = Resources.question_mark;
            pb3.Image = Resources.question_mark;
            pb4.Image = Resources.question_mark;
            pb5.Image = Resources.question_mark;
            pb6.Image = Resources.question_mark;
            pb7.Image = Resources.question_mark;
            pb8.Image = Resources.question_mark;
            pb9.Image = Resources.question_mark;

            pb1.Tag = null;
            pb2.Tag = null;
            pb3.Tag = null;
            pb4.Tag = null;
            pb5.Tag = null;
            pb6.Tag = null;
            pb7.Tag = null;
            pb8.Tag = null;
            pb9.Tag = null;

            pb1.BackColor = TransparencyKey;
            pb2.BackColor = TransparencyKey;
            pb3.BackColor = TransparencyKey;
            pb4.BackColor = TransparencyKey;
            pb5.BackColor = TransparencyKey;
            pb6.BackColor = TransparencyKey;
            pb7.BackColor = TransparencyKey;
            pb8.BackColor = TransparencyKey;
            pb9.BackColor = TransparencyKey;

        }
    }
}
