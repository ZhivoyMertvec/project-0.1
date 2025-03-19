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
    public partial class Form8 : Form
    {
        string[] str = new string[3];
        public Form8(string p1, string p2, string p3)
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
                string query = $"INSERT INTO Proizvodstro (PO_NAME, PR_SERN, P_DATA) VALUES(@f1, @f2, @f3)";
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
                    string query = $"UPDATE Proizvodstro SET PR_SERN=@f2, P_DATA=@f3 WHERE PO_NAME=@f1 ";
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
                string query = $"DELETE FROM Proizvodstro WHERE PO_NAME = {comboBox1.Text}";
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
        private void Form8_Shown(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(str[0]))
            {
                comboBox1.Text = str[0];
                comboBox2.Text = str[1];
                maskedTextBox1.Text = str[2];
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query1 = $"SELECT * FROM Podrazdelenia WHERE PO_VID='Произв';";
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

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) | (e.KeyChar > 57)) & (e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
