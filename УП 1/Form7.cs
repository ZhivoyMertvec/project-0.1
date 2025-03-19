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
    public partial class Form7 : Form
    {
        string[] str = new string[2];
        public Form7(string p1, string p2)
        {
            InitializeComponent();
            str[0] = p1;
            str[1] = p2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"INSERT INTO Hranenie (PO_NAME, PR_SERN) VALUES(@f1, @f2)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@f1", comboBox1.Text);
                command.Parameters.AddWithValue("@f2", comboBox2.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
            }
            catch
            {
                DialogResult result = MessageBox.Show(
                    "Продукт с таким серийным номером уже есть. Перезаписать данные?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    string query = $"UPDATE Hranenie SET PR_SERN=@f2 WHERE PO_NAME=@f1 ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@f1", comboBox1.Text);
                    command.Parameters.AddWithValue("@f2", comboBox2.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные изменены");
                }
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"DELETE FROM Hranenie WHERE PO_NAME = {comboBox1.Text}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch
            {
                MessageBox.Show("Данные не изменились");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string st = comboBox1.Text;
            if (!String.IsNullOrEmpty(st))
            {
                try
                {
                    string query = $"SELECT * FROM Hranenie WHERE PO_NAME = {comboBox1.Text}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Text = reader[0].ToString();
                        comboBox2.Text = reader[1].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Данные не найдены");
                }
            }
        }

        private void Form7_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(str[0]))
            {
                comboBox1.Text = str[0];
                comboBox2.Text = str[1];
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query1 = $"SELECT * FROM Hranenie WHERE PO_VID='Хранен';";
            SqlCommand command = new SqlCommand(query1, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["PO_NAME"].ToString());
            }
            reader.Close();

            string query2 = $"SELECT * FROM Product;";
            SqlCommand command1 = new SqlCommand(query2, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1["PR_SERN"].ToString());
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
