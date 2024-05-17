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
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            tableName.Items.Add("BOOK, AUTHOR");
            dataGridView1.Enabled = false;

            //tableName.Items.Add("BORROWED");


        }

        private void showData_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "OnlineLibrary.mdf") +";Integrated Security=True;Connect Timeout=30");
            con.Open();
            if(tableName.Text == "BOOK, AUTHOR")
            {
                string bookNamesQuery1 = "select AUTHOR.NAME as Author_name  ,BOOK.TITLE as Book_Title , BOOK.CATEGORY as Book_Category from AUTHOR , BOOK, WRITE_BY  where AUTHOR.AUTHORID = WRITE_BY.AUTHORID and BOOK.ISBN = WRITE_BY.ISBN ";
                SqlCommand cmd = new SqlCommand(bookNamesQuery1, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Refresh();
                return;
            }
            string bookNamesQuery = "select * from " + tableName.Text;
            SqlCommand cmd1 = new SqlCommand(bookNamesQuery, con);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            adapter1.Fill(dataTable);
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
