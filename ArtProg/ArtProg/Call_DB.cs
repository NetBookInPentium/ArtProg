using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtProg
{
    internal class Call_DB
    {
        private OleDbConnection myConnection;
        static string db_name = "ArtObject";
        public string connectString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={db_name}.mdb;";

        public Call_DB()
        {
            myConnection = new OleDbConnection(connectString);
        }
        public void Open()
        {
            try
            {
                myConnection.Open();
            }
            catch
            {
                try
                {
                    connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={db_name}.mdb;";
                    myConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Возникло  исключение: {ex}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }
        public void Close()
        {
            myConnection.Close();
        }

        public bool Select_user(string login, string password)
        {
            string query = "SELECT * FROM Adminn WHERE login = @uL AND password = @uP";
            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.Parameters.Add("@uL", OleDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", OleDbType.VarChar).Value = password;

            OleDbDataReader myOleDbDataReader = command.ExecuteReader();
            bool check;

            if (myOleDbDataReader.Read())
            { check = true; }
            else
            { check = false; }

            return check;
        }

        public DataSet Request(string query)
        {
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);

            DataSet table = new DataSet();
            command.Fill(table);

            return table;
        }
    }
}
