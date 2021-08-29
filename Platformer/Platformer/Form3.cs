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
    public partial class Form3 : Form
    {
        Model model;
        public Form3(Model mod)
        {
            model = mod;
            InitializeComponent();
            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Point");
            listView1.View = System.Windows.Forms.View.Details;
            model.Import();
            foreach (Leaderbard item in model.players)
            {
                string[] temp = new string[] { item.Name, item.Score };
                ListViewItem asd = new ListViewItem(temp);
                listView1.Items.Add(asd);
            }
            button1.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}
