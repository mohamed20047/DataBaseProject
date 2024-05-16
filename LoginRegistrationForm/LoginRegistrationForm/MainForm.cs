using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegistrationForm
{
    public partial class MainForm : Form
    {
        public MainForm(String email)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Insert_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\SecondYear_College\Database systems\Database Project\DataBaseProject-main v1\LoginRegistrationForm\LoginRegistrationForm\OnlineLibrary.mdf"";Integrated Security=True;Connect Timeout=30");
        con.Open();
        String insertData = "insert into BOOK(ISBN, TITLE, PUBLICATIONYEAR, CATEGORY) values(@ISBN, @Title, @publicationYear, @Category)";
        using (SqlCommand command = new SqlCommand(insertData, con))
        {
            command.Parameters.AddWithValue("@ISBN", 5);
            command.Parameters.AddWithValue("@Title", textBox1.Text.ToString());
            command.Parameters.AddWithValue("@publicationYear", textBox2.Text.ToString());
            command.Parameters.AddWithValue("@Category", textBox3.Text.ToString());
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
        }
        MessageBox.Show("Insertion completed","Insert box", MessageBoxButtons.OK, MessageBoxIcon.Information);
        con.Close();
    }

    }
}
