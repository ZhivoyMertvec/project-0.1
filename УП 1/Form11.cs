using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace УП_1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        int k = 2;

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
                string query = $"SELECT Podrazdelenia.PO_NAME, Product.PR_NAME FROM Podrazdelenia INNER JOIN Razrabotka ON Podrazdelenia.PO_NAME=Razrabotka.PO_NAME INNER JOIN Product ON Razrabotka.PR_SERN=Product.PR_SERN WHERE Razrabotka.R_DATA LIKE '2023'";
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
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = k;
                if (reader.HasRows)
                {
                    string[] columnName = new string[k];
                    dataGridView1.RowCount = 1;
                    dataGridView1.ColumnCount = k;
                    for (int i = 0; i < k; i++)
                    {
                        columnName[i] = reader.GetName(i);
                        dataGridView1.Rows[0].Cells[i].Value = columnName[i];
                    }
                }
                reader.Close();
                connection.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT Podrazdelenia.PO_NAME, Product.PR_NAME FROM Podrazdelenia INNER JOIN Razrabotka ON Podrazdelenia.PO_NAME=Razrabotka.PO_NAME INNER JOIN Product ON Razrabotka.PR_SERN=Product.PR_SERN WHERE Razrabotka.R_DATA='    .  .  '";
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
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = k;
            if (reader.HasRows)
            {
                string[] columnName = new string[k];
                dataGridView1.RowCount = 1;
                dataGridView1.ColumnCount = k;
                for (int i = 0; i < k; i++)
                {
                    columnName[i] = reader.GetName(i);
                    dataGridView1.Rows[0].Cells[i].Value = columnName[i];
                }
            }
            reader.Close();
            connection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"SELECT Podrazdelenia.PO_NAME, Product.PR_NAME FROM Podrazdelenia INNER JOIN Razrabotka ON Podrazdelenia.PO_NAME=Razrabotka.PO_NAME INNER JOIN Product ON Razrabotka.PR_SERN=Product.PR_SERN WHERE Razrabotka.R_DATA='0000.00.00'";
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
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = k;
            if (reader.HasRows)
            {
                string[] columnName = new string[k];
                dataGridView1.RowCount = 1;
                dataGridView1.ColumnCount = k;
                for (int i = 0; i < k; i++)
                {
                    columnName[i] = reader.GetName(i);
                    dataGridView1.Rows[0].Cells[i].Value = columnName[i];
                }
            }
            reader.Close();
            connection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
