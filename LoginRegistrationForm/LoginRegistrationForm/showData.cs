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

namespace LoginRegistrationForm
{
    public partial class showData : Form
    {
        
        public showData()
        {
            InitializeComponent();
            tableName.Items.Clear();
            tableName.Items.Add("ADMIN");
            tableName.Items.Add("AUTHOR");
            tableName.Items.Add("BOOK");
            tableName.Items.Add("STUDENT");
            tableName.Items.Add("UserDetails");
            tableName.Items.Add("WRITE_BY");

            //tableName.Items.Add("BORROWED");

            
        }

        private void showData_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=M:\FCAI\fourth term\database\DataBaseProject\LoginRegistrationForm\LoginRegistrationForm\OnlineLibrary.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string bookNamesQuery = "select * from " + tableName.Text;
            SqlCommand cmd = new SqlCommand(bookNamesQuery, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Refresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        
    }
}
