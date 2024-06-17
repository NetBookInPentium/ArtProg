using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArtProg
{
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        DateTime thisDay = DateTime.Today;
        
        public Menu()
        {
            InitializeComponent();
            InitializeConboBox();
            textBox8.Text = thisDay.ToString("d");
        }
        public void InitializeConboBox()
        {
            DataSet dataSet = Call_DB.Request("SELECT * FROM Clients");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
            dataSet = Call_DB.Request("SELECT * FROM Designers");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
            dataSet = Call_DB.Request("SELECT * FROM Companys");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
            
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
            if (table != "Adminn")
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Clients(surnames,namess,father_names) VALUES('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')");
                Call_DB.Close();
                Select_table("Clients");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && comboBox1.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Companys(namess,action) VALUES('{textBox1.Text}','{comboBox1.Text}')");
                Call_DB.Close();
                Select_table("Companys");
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox9.Text.Length > 0 && comboBox2.Text.Length > 0 && comboBox3.Text.Length > 0 && comboBox4.Text.Length > 0 && textBox8.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO ArtObject(namess,id_client,id_designer,id_company,date_accept) VALUES(" +
                    $"'{textBox9.Text}','{comboBox2.Text}','{comboBox3.Text}','{comboBox4.Text}','{textBox8.Text}')");
                Call_DB.Close();
                Select_table("ArtObject");
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0 && textBox5.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Designers(surnames,namess,father_names) VALUES('{textBox7.Text}','{textBox5.Text}','{textBox4.Text}')");
                Call_DB.Close();
                Select_table("Designers");
                textBox7.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }

        }
    }
}
