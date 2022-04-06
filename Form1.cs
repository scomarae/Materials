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
    public partial class material : Form
    {
        public material()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet7.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter.Fill(this.dataSet7.Supplier);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet2.MaterialType". При необходимости она может быть перемещена или удалена.
            this.materialTypeTableAdapter.Fill(this.dataSet2.MaterialType);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.Material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter.Fill(this.dataSet1.Material);
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-KGL971H\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Koraalma");
            try
            {
                // Открываем подключение
                con.Open();
                MessageBox.Show("Подключение открыто");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            string query = "select * from Material";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            { count++; }


            label1.Text = "" + count;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countSearch = 0;        
                              for (int i = 0; i < dataGridView1.RowCount; i++)
                                 {
                    dataGridView1.Rows[i].Selected = false;
                                      for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                                                  if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
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
            da.SelectCommand = new SqlCommand("select * from Material Order By Cost asc", con);
            con.Open();
            da.Fill(ds, "Material");
            dataGridView1.DataSource = ds.Tables[0];
            da.Dispose();
            con.Dispose();
            ds.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
         
                for (int i = 0; i < dataGridView1.Rows.Count - 1 ; i++)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
