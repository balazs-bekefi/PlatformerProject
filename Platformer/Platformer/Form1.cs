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
    public partial class Form1 : Form
    {
        Model mod;
        public Form1()
        {
            mod = new Model();
            InitializeComponent();
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            textBox1.TextChanged += (s, e) =>
            {
                button1.Enabled = true;
            };
            button1.Click += (s, e) =>
            {
                Form2 form = new Form2(mod);
                form.Show();
                this.Hide();
                form.FormClosed += GameIsClosed;
            };  
            button3.Click += (s, e) =>
            {
                Application.Exit();
            };
            button2.Click += (s, e) =>
            {
                Form3 form = new Form3(mod);
                form.Show();
                this.Hide();
                form.FormClosed += LeaderBoardIsClosed;
            };
        }

        private void LeaderBoardIsClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void GameIsClosed(object sender, FormClosedEventArgs e)
        {
            mod.Export(textBox1.Text, mod.PontImport());
            this.Show();
        }
    }
}
