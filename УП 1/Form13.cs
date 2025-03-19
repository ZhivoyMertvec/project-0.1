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

namespace УП_1
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = $"SELECT * FROM Product INNER JOIN Proizvodstro ON PR_SERN=PR_SERN INNER JOIN Podrazdelenia ON RUK_ID=RUK_ID";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["PO_NAME"].ToString());
                comboBox2.Items.Add(reader["PR_NAME"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string st = comboBox1.Text;
            if(!String.IsNullOrEmpty(st))
            {
                string query = $"SELECT SUM(Product.PR_STOIM) FROM Product INNER JOIN Proizvodstro ON PR_SERN=PR_SERN INNER JOIN Podrazdelenia ON RUK_ID=RUK_ID WHERE Proizvodstro.PO_NAME='{comboBox1.Text}' AND Proizvodstro.PR_SERN='{comboBox2.Text}'";
                SqlCommand command = new SqlCommand(query, connection);
                var rez = command.ExecuteScalar();
                label1.Text = "Ha " + rez + " рублей выбранный завод выпустил выбранную продукцию за отчетный период";
            }
        }
    }
}
