using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtProg
{
    public partial class Form1 : Form
    {
        Call_DB Call_db = new Call_DB();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "adminius";
            textBox2.Text = "278108324";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Call_db.Open();
            if (Call_db.Select_user(textBox1.Text, textBox2.Text))
            {
                Menu menu = new Menu();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("Не верный логин или пароль");
            }
            Call_db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
