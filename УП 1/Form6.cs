using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace УП_1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int k = 3;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string st = comboBox1.Text;
            if (!String.IsNullOrEmpty(st))
            {
                string query = $"SELECT Product.PR_SERN, Product.PR_NAME, Podrazdelenia.PO_NAME FROM Product INNER JOIN Proizvodstro ON Product.PR_SERN=Proizvodstro.PR_SERN INNER JOIN Proizvodstro.PO_NAME=Podrazdelenia.PO_NAME WHERE Podrazdelenia.PO_NAME='{st}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[k]);
                    for (int i = 0; i < k; i++)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }

                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT * FROM Podrazdelenia WHERE Podrazdelenia.PO_VID='Произв';";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader(); 
            while(reader.Read())
            {
                comboBox1.Items.Add(reader["PO_NAME"].ToString());
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
