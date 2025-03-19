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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string s = maskedTextBox1.Text;
            string v = maskedTextBox2.Text;
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
                if (!String.IsNullOrEmpty(s))
                {
                    try
                    {
                        string query = $"SELECT Product.PR_STOIM FROM Product INNER JOIN Proizvodstro ON Product.PR_SERN=Proizvodstro.PR_SERN WHERE Proizvodstro.P_DATA='{s}'";
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        { 
                            string r = reader[0].ToString();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Выберите даты");
                    }
                }
            {
               
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

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48) | (e.KeyChar > 57)) & (e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
