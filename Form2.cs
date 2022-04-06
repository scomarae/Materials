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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Title = textBox1.Text.Trim();
            int CountInPack = Convert.ToInt32(textBox2.Text.Trim());
            string Unit = textBox3.Text.Trim();
            float CountInStock = Convert.ToSingle(textBox4.Text.Trim());
            float MinCount = Convert.ToSingle(textBox5.Text.Trim());
            string Description= textBox6.Text.Trim();
            decimal Cost = Convert.ToDecimal(textBox7.Text.Trim());
            string Image = textBox8.Text.Trim();
            object MaterialTypeID = comboBox1.Text.Trim();
            SqlConnection con = new SqlConnection(@"Data Source =SQLNCLI11;Data Source=DESKTOP-KGL971H\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Koraalma");
            con.Open();
            string query = "SELECT ID FROM MaterialType WHERE Title = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    object ID = reader.GetValue(0);
                    MaterialTypeID = ID;
                }
                reader.Close();
                try
                {
                    string insertquery = "INSERT INTO Material (Title, CountInPack, Unit, CountInStock,MinCount,Description,Cost,Image,MaterialTypeID) VALUES ('" + Title + "','" + CountInPack + "','" + Unit + "','" + CountInStock + "','" + MinCount + "','" + Description + "','" + Cost + "','" + Image + "','" + MaterialTypeID + "')";
                    SqlCommand cmd2 = new SqlCommand(insertquery, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("успешно добавили запись");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Form2.ActiveForm.Close();
            }


            con.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet5.MaterialType". При необходимости она может быть перемещена или удалена.
            this.materialTypeTableAdapter1.Fill(this.dataSet5.MaterialType);

        }

        //private void Form2_Load(object sender, EventArgs e)
        //{
        //TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet3.MaterialType". При необходимости она может быть перемещена или удалена.
        //this.materialTypeTableAdapter.Fill(this.dataSet3.MaterialType);

        //}
    }
}
