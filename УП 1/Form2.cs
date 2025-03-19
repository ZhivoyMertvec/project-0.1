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
    public partial class Form2 : Form
    {
        int k;
        string tn;
        bool poisk = false;

        public Form2(string tns, int ks)
        {
            InitializeComponent();
            tn = tns;
            k = ks;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string par = comboBox1.Text;
            string zn = comboBox2.Text;
            bool osh = false;
            if ((String.IsNullOrEmpty(par)) || (String.IsNullOrEmpty(zn)))
            {
                osh = true;
            }
            if (!osh)
            {
                Poisk(par, zn);
            }
        }
        private void Poisk(string p, string z)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string[] f = new string[10];
            try
            {
                string query = $"SELECT * FROM {tn} WHERE {p}='{z}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < k; i++)
                    {
                        f[i] = reader[i].ToString();
                    }
                }
                poisk = true;
                if (tn == "Podrazdelenia")
                {
                    Form3 f3 = new Form3(f[0], f[1], f[2], f[3]);
                    f3.Show();
                    this.Hide();
                }
                 if (tn == "DRuk")
                {
                    Form4 f4 = new Form4(f[0], f[1], f[2], f[3], f[4], f[5]);
                    f4.Show();
                    this.Hide();
                }
                if (tn == "Product")
                {
                    Form5 f5 = new Form5(f[0], f[1], f[2], f[3], f[4]);
                    f5.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Данные не найдены");
            }
            finally
            {
                connection.Close();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (tn == "Podrazdelenia")
            {
                comboBox1.Items.Add("PO_NAME");
                comboBox1.Items.Add("PO_ADRES");
                comboBox1.Items.Add("PO_VID");
                comboBox1.Items.Add("RUK_ID");
            }
            if (tn == "Product")
            {
                comboBox1.Items.Add("PR_SERN");
                comboBox1.Items.Add("PR_NAME");
                comboBox1.Items.Add("PR_STOIM");
                comboBox1.Items.Add("PR_RAZM");
                comboBox1.Items.Add("PR_COLOR");
            }
            if (tn == "DRuk")
            {
                comboBox1.Items.Add("RUK_ID");
                comboBox1.Items.Add("RUK_FAM");
                comboBox1.Items.Add("RUK_NAME");
                comboBox1.Items.Add("RUK_OTCH");
                comboBox1.Items.Add("RUK_NOM");
                comboBox1.Items.Add("RUK_EMAIL");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            comboBox2.Items.Clear();
            if (tn == "Podrazdelenia")
            {
                string query = $"SELECT * FROM Podrazdelenia;";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (comboBox1.Text == "PO_NAME")
                    {
                        comboBox2.Items.Add(reader["PO_NAME"].ToString());
                    }
                    if (comboBox1.Text == "PO_ADRES")
                    {
                        comboBox2.Items.Add(reader["PO_ADRES"].ToString());
                    }
                    if (comboBox1.Text == "PO_VID")
                    {
                        comboBox2.Items.Add(reader["PO_VID"].ToString());
                    }
                    if (comboBox1.Text == "RUK_ID")
                    {
                        comboBox2.Items.Add(reader["RUK_ID"].ToString());
                    }
                }
                reader.Close();
            }
            if (tn == "Product")
            {
                string query1 = $"SELECT * FROM Product;";
                SqlCommand command1 = new SqlCommand(query1, connection);
                SqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    if (comboBox1.Text == "PR_SERN")
                    {
                        comboBox2.Items.Add(reader1["PR_SERN"].ToString());
                    }
                    if (comboBox1.Text == "PR_NAME")
                    {
                        comboBox2.Items.Add(reader1["PR_NAME"].ToString());
                    }
                    if (comboBox1.Text == "PR_STOIM")
                    {
                        comboBox2.Items.Add(reader1["PR_STOIM"].ToString());
                    }
                    if (comboBox1.Text == "PR_RAZM")
                    {
                        comboBox2.Items.Add(reader1["PR_RAZM"].ToString());
                    }
                    if (comboBox1.Text == "PR_COLOR")
                    {
                        comboBox2.Items.Add(reader1["PR_COLOR"].ToString());
                    }
                }
                reader1.Close();
            }
            if (tn == "DRuk")
            {
                string query2 = $"SELECT * FROM DRuk;";
                SqlCommand command2 = new SqlCommand(query2, connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (comboBox1.Text == "RUK_ID")
                    {
                        comboBox2.Items.Add(reader2["RUK_ID"].ToString());
                    }
                    if (comboBox1.Text == "RUK_FAM")
                    {
                        comboBox2.Items.Add(reader2["RUK_FAM"].ToString());
                    }
                    if (comboBox1.Text == "RUK_NAME")
                    {
                        comboBox2.Items.Add(reader2["RUK_NAME"].ToString());
                    }
                    if (comboBox1.Text == "RUK_OTCH")
                    {
                        comboBox2.Items.Add(reader2["RUK_OTCH"].ToString());
                    }
                    if (comboBox1.Text == "RUK_NOM")
                    {
                        comboBox2.Items.Add(reader2["RUK_NOM"].ToString());
                    }
                    if (comboBox1.Text == "RUK_EMAIL")
                    {
                        comboBox2.Items.Add(reader2["RUK_EMAIL"].ToString());
                    }
                }
                reader2.Close();
            }
                        connection.Close();
        }
    }
}

