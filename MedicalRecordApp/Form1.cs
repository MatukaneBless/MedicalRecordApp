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

namespace MedicalRecordApp
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=BLESSER\MSSQLSERVER01;Initial Catalog=Medical Records System;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
          
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                string querry = "SELECT * FROM Users WHERE username = '" + txt_username.Text + "' AND password = '" + txt_password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dt = new DataTable(); 
                sda.Fill(dt);   

                if (dt.Rows.Count > 0) 
                {
                    username = txt_username.Text;
                    user_password = txt_password.Text;

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }

                else 
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    txt_username.Focus();
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
