using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistrationForm
{
    public partial class Signup : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30");
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup_email.Text == "" || signup_fname.Text == "" || signup_sname.Text == ""
            || signup_password.Text == "" || signup_confirmpassword.Text == "" || signup_checkAdmin.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (signup_password.Text != signup_confirmpassword.Text)
            {
                MessageBox.Show("password must match confirm password");
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String checkUsername = "SELECT * FROM [UserDetails] WHERE userid = @userid";
                        using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                        {
                            int id;
                            int.TryParse(signup_id.Text.Trim(), out id);
                            checkUser.Parameters.AddWithValue("@userid", id); // Add parameter with value
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable(); ;
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(signup_id.Text + " is already exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO UserDetails (userid, email, fname, lname, password, USERTYPE) " +
                                    "VALUES(@userid, @email, @fname, @lname, @password, @usertype)";


                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@userid", id);
                                    cmd.Parameters.AddWithValue("@fname", signup_fname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@lname", signup_sname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@usertype", signup_checkAdmin.Text);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // TO SWITCH THE FORM 
                                    Form1 lForm = new Form1();
                                    lForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            if (connect.State == ConnectionState.Open)
            {
                MessageBox.Show("opened!");
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showpass.Checked)
            {
                signup_password.PasswordChar = '\0';
                signup_confirmpassword.PasswordChar = '\0';
            }
            else
            {
                signup_password.PasswordChar = '*';
                signup_confirmpassword.PasswordChar = '*';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signup_loginhere_Click(object sender, EventArgs e)
        {
            Form1 lForm = new Form1();
            lForm.Show();
            this.Hide();
        }

        private void signup_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_userrname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
