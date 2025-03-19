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
    public partial class Form3 : Form
    {
        string[] str = new string[4];
        public Form3(string p1, string p2, string p3, string p4)
        {
            InitializeComponent();
            str[0] = p1;
            str[1] = p2;
            str[2] = p3;
            str[3] = p4;
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            if (!String.IsNullOrEmpty(str[0]))
            {
                textBox1.Text = str[0];
                textBox2.Text = str[1];
                comboBox1.Text = str[2];
                textBox4.Text = str[3];
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 1040) | (e.KeyChar > 1103)) & (e.KeyChar != 8) & (e.KeyChar != 1025) & (e.KeyChar != 1105))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) | (e.KeyChar > 57)) & (e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) | (e.KeyChar > 57)) & (e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"INSERT INTO Podrazdelenia (PO_NAME, PO_ADRES, PO_VID, RUK_ID) VALUES(@f1, @f2, @f3, @f4)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@f1", textBox1.Text);
                command.Parameters.AddWithValue("@f2", textBox2.Text);
                command.Parameters.AddWithValue("@f3", comboBox1.Text);
                command.Parameters.AddWithValue("@f4", textBox4.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные сохранены");
            }
            catch
            {
                DialogResult result = MessageBox.Show(
                    "Подразделение с таким названием уже есть. Перезаписать данные?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    string query = $"UPDATE Podrazdelenia SET PO_ADRES=@f2, PO_VID=@f3, RUK_ID=@f4 WHERE PO_NAME=@f1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@f1", textBox1.Text);
                    command.Parameters.AddWithValue("@f2", textBox2.Text);
                    command.Parameters.AddWithValue("@f3", comboBox1.Text);
                    command.Parameters.AddWithValue("@f4", textBox4.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные изменены");
                }
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string st = textBox1.Text;
            if(!String.IsNullOrEmpty(st))
            {
                try
                {
                    string query = $"SELECT * FROM Podrazdelenia WHERE PO_NAME = {textBox1.Text}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader[0].ToString();
                        textBox2.Text = reader[1].ToString();
                        comboBox1.Text = reader[2].ToString();
                        textBox4.Text = reader[3].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Данные не найдены");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"DELETE FROM Podrazdelenia WHERE PO_NAME = textBox1.Text";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
            }
            catch
            {
                MessageBox.Show("Данные не изменились");
            }
        }
    }
}

