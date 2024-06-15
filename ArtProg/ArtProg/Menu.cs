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
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select_table("ArtObject");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Select_table("Companys");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Select_table("Clients");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Select_table("Designers");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Select_table("Adminn");
        }

        public void Select_table(string table)
        {
            if(table != "Adminn") 
            {
                Call_DB.Open();
                DataSet ds = Call_DB.Request($"SELECT * FROM {table}");
                dataGridView1.DataSource = ds.Tables[0];
                Call_DB.Close();
            }
            else
            {
                Call_DB.Open();
                DataSet dataSet = Call_DB.Request("SELECT id, login FROM Adminn");
                dataGridView1.DataSource = dataSet.Tables[0];
                Call_DB.Close();
            }
        }
    }
}
