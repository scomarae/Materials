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

namespace KoryakinaSavvinova
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet10.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter2.Fill(this.dataSet10.Supplier);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet9.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter1.Fill(this.dataSet9.Supplier);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet8.MaterialType". При необходимости она может быть перемещена или удалена.
            this.materialTypeTableAdapter.Fill(this.dataSet8.MaterialType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet6.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter.Fill(this.dataSet6.Supplier);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countSearch = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            countSearch++;
                            break;
                        }

            }
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-KGL971H\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Koraalma");
            con.Open();
            string query = "select * from Material";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            label1.Text = "" + countSearch;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-KGL971H\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Koraalma");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select * from Supplier Order By INN asc", con);
            con.Open();
            da.Fill(ds, "Supplier");
            dataGridView1.DataSource = ds.Tables[0];
            da.Dispose();
            con.Dispose();
            ds.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(comboBox2.Text))

                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
