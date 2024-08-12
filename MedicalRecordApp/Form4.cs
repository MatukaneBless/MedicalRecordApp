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

namespace MedicalRecordApp
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=BLESSER\MSSQLSERVER01;Initial Catalog=Medical Records System;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Bindata();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();


                SqlCommand command = new SqlCommand("INSERT INTO Patients VALUES (@patient_id,@firstName, @lastName, @date_of_birth, @gender, @contact_number, @email, @address)", con);
                command.Parameters.AddWithValue("@patient_id", textBox1.Text);
                command.Parameters.AddWithValue("@firstName", textBox2.Text);
                command.Parameters.AddWithValue("@lastName", textBox3.Text);
                command.Parameters.AddWithValue("@date_of_birth", textBox4.Text);
                command.Parameters.AddWithValue("@gender", textBox5.Text);
                command.Parameters.AddWithValue("@contact_number", textBox6.Text);
                command.Parameters.AddWithValue("@email", textBox7.Text);
                command.Parameters.AddWithValue("@address", textBox8.Text);
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
            SqlCommand command = new SqlCommand("select * from Patients", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnU_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("update Patients set address = '" + textBox7.Text + "' where first_name = '" + textBox2.Text + "' ", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            this.Hide();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Delete Patients where patient_id = '" + textBox1.Text + "' ", con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Succefully Deleted.");
                    con.Close();
                    Bindata();
                }
            }

            else
            {
                MessageBox.Show("Please enter the patient_id");
            }
        }
    }
}