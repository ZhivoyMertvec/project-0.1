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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData(string st, int k)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = st;
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
                string[] columnName = new string[6];
                dataGridView1.RowCount = 2;
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

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            TabHran();
        }

        private void TabHran()
        {
            string st = "Select * from Hranenie";
            int k = 2;
            LoadData(st, k);
        }
        private void TabProizv()
        {
            string st = "Select * from Proizvodstro";
            int k = 3;
            LoadData(st, k);
        }
        private void TabRazr()
        {
            string st = "Select * from Razrabotka";
            int k = 3;
            LoadData(st, k);
        }
        private void TabPodr()
        {
            string st = "Select * from Podrazdelenia";
            int k = 4;
            LoadData(st, k);
        }
        private void TabProd()
        {
            string st = "Select * from Product";
            int k = 5;
            LoadData(st, k);
        }
        private void TabDruk()
        {
            string st = "Select * from DRuk";
            int k = 6;
            LoadData(st, k);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            TabProizv();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            TabRazr();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            TabPodr();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            TabProd();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            TabDruk();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("Podrazdelenia",4);
            f2.Show();
            this.Hide();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3("", "", "", "");
            f3.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5("", "", "", "", "");
            f5.Show();
            this.Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4("", "", "", "", "", "");
            f4.Show();
            this.Hide();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7("", "");
            f7.Show();
            this.Hide();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8("", "", "");
            f8.Show();
            this.Hide();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9("", "", "");
            f9.Show();
            this.Hide();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            this.Hide();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("Product", 5);
            f2.Show();
            this.Hide();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("DRuk", 6);
            f2.Show();
            this.Hide();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            this.Hide();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
            this.Hide();
        }
    }
}
