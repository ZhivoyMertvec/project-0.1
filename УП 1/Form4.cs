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
    public partial class Form4 : Form
    {
        string[] str = new string[6];
        public Form4(string p1, string p2, string p3, string p4, string p5, string p6)
        {
            InitializeComponent();
            str[0] = p1;
            str[1] = p2;
            str[2] = p3;
            str[3] = p4;
            str[4] = p5;
            str[5] = p6;
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox6.Clear();
            if (!String.IsNullOrEmpty(str[0]))
            {
                textBox1.Text = str[0];
                textBox2.Text = str[1];
                textBox3.Text = str[2];
                textBox4.Text = str[3];
                maskedTextBox1.Text = str[4];
                textBox6.Text = str[5];
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                string query = $"INSERT INTO DRuk (RUK_ID, RUK_FAM, RUK_NAME, RUK_OTCH, RUK_NOM, RUK_EMAIL) VALUES(@f1, @f2, @f3, @f4, @f5, @f6)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@f1", textBox1.Text);
                command.Parameters.AddWithValue("@f2", textBox2.Text);
                command.Parameters.AddWithValue("@f3", textBox3.Text);
                command.Parameters.AddWithValue("@f4", textBox4.Text);
                command.Parameters.AddWithValue("@f5", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@f6", textBox6.Text);
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
                    string query = $"UPDATE DRuk SET RUK_FAM=@f2, RUK_NAME=@f3, RUK_OTCH=@f4, RUK_NOM=@f5, RUK_EMAIL=@f6 WHERE RUK_ID=@f1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@f1", textBox1.Text);
                    command.Parameters.AddWithValue("@f2", textBox2.Text);
                    command.Parameters.AddWithValue("@f3", textBox3.Text);
                    command.Parameters.AddWithValue("@f4", textBox4.Text);
                    command.Parameters.AddWithValue("@f5", maskedTextBox1.Text);
                    command.Parameters.AddWithValue("@f6", textBox6.Text);
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
                string query = $"DELETE FROM DRuk WHERE RUK_ID = {textBox1.Text}";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные удалены");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                maskedTextBox1.Text = "";
                textBox6.Text = "";
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
            string st = textBox1.Text;
            if (!String.IsNullOrEmpty(st))
            {
                try
                {
                    string query = $"SELECT * FROM DRuk WHERE RUK_ID = {textBox1.Text}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader[0].ToString();
                        textBox2.Text = reader[1].ToString();
                        textBox3.Text = reader[2].ToString();
                        textBox4.Text = reader[3].ToString();
                        maskedTextBox1.Text = reader[4].ToString();
                        textBox6.Text = reader[5].ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Данные не найдены");
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) | (e.KeyChar > 57)) & (e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 1040) | (e.KeyChar > 1103)) & (e.KeyChar != 8) & (e.KeyChar != 1025) & (e.KeyChar != 1105))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 1040) | (e.KeyChar > 1103)) & (e.KeyChar != 8) & (e.KeyChar != 1025) & (e.KeyChar != 1105))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 1040) | (e.KeyChar > 1103)) & (e.KeyChar != 8) & (e.KeyChar != 1025) & (e.KeyChar != 1105))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 65) | (e.KeyChar > 90)) & (e.KeyChar != 8) & (e.KeyChar < 97 | e.KeyChar > 122))
            {
                e.Handled = true;
                return;
            }
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
