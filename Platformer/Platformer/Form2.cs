using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer
{
    public partial class Form2 : Form
    {
        Model model;
        public Form2(Model mod)
        {
            model = mod;
            Random rnd = new Random();
            int speed = 12;
            int score = -1;
            int gravity = 8;
            bool moveLeft = false;
            bool moveRight = false;
            InitializeComponent();
            gameTimer.Stop();
            timer1.Tick += (s, e) =>
            {
                int timer = Convert.ToInt32(label2.Text);
                timer = timer - 1;
                label2.Text = Convert.ToString(timer);
                if(timer==0)
                {
                    gameTimer.Start();
                    timer1.Stop();
                    label2.Text = "";
                }
            };
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight = true;
                }
            };
            KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight = false;
                }
            };
            gameTimer.Tick += (s, e) =>
            {
                player.Top += gravity;
                label1.Text = "Score: " + score;

                if (moveLeft && player.Left > 1)
                {
                    player.Left -= speed;
                }
                if (moveRight && player.Left + player.Width < panel1.Width)
                {
                    player.Left += speed;
                }
                foreach (Control x in panel1.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform")
                    {
                        x.Top -= 5;
                        if (x.Top < panel1.Top - x.Height)
                        {
                            x.Top = panel1.Height + x.Height;
                            x.Width = rnd.Next(150, 400);
                            score++;
                            if(score==10 || score==20 || score==30 || score==40 || score==50 || score==60)
                                gameTimer.Interval -= 1;
                        }
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gravity = 0;
                            player.Top = x.Top - player.Height;
                        }
                        else
                        {
                            gravity = 8;
                        }
                    }
                }
                if (player.Top + player.Height < 0 || player.Top > panel1.Height)
                {
                    gameTimer.Stop();
                    MessageBox.Show("Meghaltál, az elért pontszámod " + Convert.ToString(score) + " volt");
                    mod.PontExport(Convert.ToString(score));
                    this.Close();
                }
            };
        }
    }
}
