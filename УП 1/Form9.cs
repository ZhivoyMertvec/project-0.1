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

namespace УП_1
{
    public partial class Form9 : Form
    {
        string[] str = new string[3];
        public Form9(string p1, string p2, string p3)
        {
            InitializeComponent();
            str[0] = p1;
            str[1] = p2;
            str[2] = p3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"INSERT INTO Razrabotka (PO_NAME, PR_SERN, R_DATA) VALUES(@f1, @f2, @f3)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@f1", comboBox1.Text);
                command.Parameters.AddWithValue("@f2", comboBox2.Text);
                command.Parameters.AddWithValue("@f3", maskedTextBox1.Text);
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
                    string query = $"UPDATE Razrabotka SET PR_SERN=@f2, R_DATA=@f3 WHERE PO_NAME=@f1 ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@f1", comboBox1.Text);
                    command.Parameters.AddWithValue("@f2", comboBox2.Text);
                    command.Parameters.AddWithValue("@f3", maskedTextBox1.Text);
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
                string query = $"DELETE FROM Razrabotka WHERE PO_NAME = {comboBox1.Text}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
                comboBox1.Text = "";
                comboBox2.Text = "";
                maskedTextBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("Данные не изменились");
            }
        }

        private void Form9_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(str[0]))
            {
                comboBox1.Text = str[0];
                comboBox2.Text = str[1];
                maskedTextBox1.Text = str[2];
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query1 = $"SELECT * FROM Podrazdelenia WHERE PO_VID='Разраб';";
            SqlCommand command = new SqlCommand(query1, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["PO_NAME"].ToString());
            }
            reader.Close();

            string query2 = $"SELECT * FROM Product;";
            command = new SqlCommand(query2, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["PR_SERN"].ToString());
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
