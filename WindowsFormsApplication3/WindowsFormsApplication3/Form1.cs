using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class laitteet : Form
    {
        public laitteet()
        {
            InitializeComponent();
        }

        private void laitteet_Load(object sender, EventArgs e)

        {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\p119992\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\akses\TietokantaKirjasto1.accdb";

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\p119992\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\akses\TietokantaKirjasto1.accdb"))
            using (OleDbCommand cmd = new OleDbCommand("select * from Tuotteet", connection))
            {
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    checkedListBox1.Items.Add(reader["Tuotteen_Nimi"]);
                }

                connection.Close();
            }


        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\p119992\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\akses\TietokantaKirjasto1.accdb";

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\p119992\Documents\Visual Studio 2015\Projects\WindowsFormsApplication3\WindowsFormsApplication3\akses\TietokantaKirjasto1.accdb"))
            using (OleDbCommand cmd = new OleDbCommand("select Tuotteen_tila from Tuotteet where Tuote_ID =@Tuote_ID", connection))
            {
                cmd.Parameters.AddWithValue("@Tuote_ID", 1);
                connection.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    lblSaatavuus.Text= reader["Tuotteen_Tila"].ToString();
                }

                connection.Close();
            }
        }

    }
}
