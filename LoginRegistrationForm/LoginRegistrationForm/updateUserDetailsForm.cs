using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegistrationForm
{
    public partial class updateUserDetailsForm : Form
    {
        int userID = 0;
        public updateUserDetailsForm(int id)
        {
            InitializeComponent();
            userID = id;
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "OnlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();

            string selectQuery = "select fname, lname, email, password from student where userid = @userid";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@userid", userID);
            SqlDataReader reader = selectCommand.ExecuteReader();
            while (reader.Read())
            {
                firstNameBox.Text = reader["fname"].ToString();
                LastNameBox.Text = reader["lname"].ToString();
                emailBox.Text = reader["email"].ToString();
                PasswordBox.Text = reader["password"].ToString();
            }
            reader.Close();
            con.Close();

        }

        private void update_Click(object sender, EventArgs e)
        {
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string updateQuery = "update student set fname = @fname, lname = @lname, email = @email, password = @pass where userid = @userid";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
            {
                updateCommand.Parameters.AddWithValue("@fname", firstNameBox.Text.ToString());
                updateCommand.Parameters.AddWithValue("@lname", LastNameBox.Text.ToString());
                updateCommand.Parameters.AddWithValue("@email", emailBox.Text.ToString());
                updateCommand.Parameters.AddWithValue("@pass", PasswordBox.Text.ToString());
                updateCommand.Parameters.AddWithValue("@userid", userID);
            }
            con.Close();
        }
    }
}
