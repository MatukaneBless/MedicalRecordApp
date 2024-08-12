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

namespace MedicalRecordApp
{
    public partial class dgAccount : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BLESSER\MSSQLSERVER01;Initial Catalog=Medical Records System;Integrated Security=True");

        public dgAccount()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Bindata();

        }

        private void btnA_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("insert into Medical_Aid values ('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted.");
            con.Close();
            Bindata();

        }

        void Bindata()
        {
            SqlCommand command = new SqlCommand("select * from Medical_Aid", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }




        private void btnU_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update Medical_Aid set policy_number = '" + textBox4.Text + "' where Medical_provider = '" + textBox3.Text + "' ", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated.");
            con.Close();
            Bindata();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete Medical_Aid where Medical_id = '" + textBox1.Text + "' ", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Succefully Deleted.");
                    con.Close();
                    Bindata();
                }
            }

            else
            {
                MessageBox.Show("Please enter the Medical_id");
            }

        }
    }
}