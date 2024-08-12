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
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=BLESSER\MSSQLSERVER01;Initial Catalog=Medical Records System;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            t{
                try
                {
                    string query = "SELECT * FROM Patients";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (!IsValidNumeric(txtSomeNumericField.Text))
            {
                MessageBox.Show("Please enter a valid numeric value for the field!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSomeNumericField.Focus();
                return;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f1 = new Form4();
            f1.Show();
            this.Hide();
        }

        private void btnUA_Click(object sender, EventArgs e)
        {
           

                try
                {
                conn.Open();
                string query = "SELECT * FROM Appointments WHERE Appointment_date >= GETDATE()";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                  
                } 
                }

                catch (Exception ex) 
                {
                MessageBox.Show("Error: " + ex.Message);
                }
            finally 
            {
                conn.Close();
            }

            
        }

        private void btnII_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointments";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnMH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM MedicalHistory";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnMA_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Medical_Aid";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAA_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM Appointments WHERE patient_id is NULL";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT a.appointment_id, a.appointment_date, a.appointment_time, a.reason, d.first_name AS doctor_first_name, d.last_name AS doctor_last_name\r\nFROM Appointments a\r\nJOIN Doctors d ON a.doctor_id = d.doctor_id;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT a.reason AS appointment_reason, CONCAT(p.first_name, ' ', p.last_name) AS patient_name\r\nFROM Appointments a\r\nJOIN Patients p ON a.patient_id = p.patient_id;;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT CONCAT(first_name, ' ', last_name) AS doctor_name, specialty\r\nFROM Doctors;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT CONCAT(d.first_name, ' ', d.last_name) AS doctor_name,\r\n       a.appointment_date,\r\n       a.appointment_time\r\nFROM Doctors d\r\nLEFT JOIN Appointments a ON d.doctor_id = a.doctor_id\r\nORDER BY doctor_name, a.appointment_date, a.appointment_time;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT a.appointment_id,\r\n       a.patient_id,\r\n       p.first_name AS patient_first_name,\r\n       p.last_name AS patient_last_name,\r\n       a.appointment_date,\r\n       a.appointment_time,\r\n       a.doctor_id,\r\n       d.first_name AS doctor_first_name,\r\n       d.last_name AS doctor_last_name,\r\n       a.reason\r\nFROM Appointments a\r\nINNER JOIN Patients p ON a.patient_id = p.patient_id\r\nINNER JOIN Doctors d ON a.doctor_id = d.doctor_id\r\nWHERE Appointment_date >= GETDATE()\r\nORDER BY a.appointment_date, a.appointment_time;";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgAccount f1 = new dgAccount();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f1 = new Form5();
            f1.Show();
            this.Hide();
        }
    }
}
