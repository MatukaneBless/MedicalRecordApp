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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BLESSER\MSSQLSERVER01;Initial Catalog=Medical Records System;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();


                SqlCommand command = new SqlCommand("INSERT INTO Doctors VALUES (@doctor_id,@firstName, @lastName,@specialty,@contact_number, @email)", con);
                command.Parameters.AddWithValue("@doctor_id", textBox1.Text);
                command.Parameters.AddWithValue("@firstName", textBox2.Text);
                command.Parameters.AddWithValue("@lastName", textBox3.Text);
                command.Parameters.AddWithValue("@specialty", textBox4.Text);
                command.Parameters.AddWithValue("@contact_number", textBox5.Text);
                command.Parameters.AddWithValue("@email", textBox6.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted.");
                con.Close();
                Bindata();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void Bindata()
        {
                SqlCommand command = new SqlCommand("select * from  Doctors", con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
        }
        

        private void btnU_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


        }

        private void btnD_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete Doctors where doctor_id = '" + textBox1.Text + "' ", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Succefully Deleted.");
                    con.Close();
                    Bindata();
                }
            }

            else
            {
                MessageBox.Show("Please enter the Doctor ID");
            }



        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Bindata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }
    }
}
