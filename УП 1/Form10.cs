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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        int k = 4;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Server=DESKTOP-1FIE1PI;Database=Kotofey.3021;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string st = comboBox1.Text;
            if (!String.IsNullOrEmpty(st))
            {
                string query = $"SELECT DRuk.RUK_FAM, DRuk.RUK_NAME, DRuk.RUK_OTCH, DRuk.RUK_NOM FROM DRuk INNER JOIN Podrazdelenia ON DRuk.RUK_ID=Podrazdelenia.RUK_ID WHERE Podrazdelenia.PO_VID='{st}'";
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
            else MessageBox.Show("Выберите вид подразделения");
        }
    }
}
