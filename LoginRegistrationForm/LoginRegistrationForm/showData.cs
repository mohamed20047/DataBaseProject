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
using System.Runtime.Remoting.Contexts;

namespace LoginRegistrationForm
{
    public partial class showData : Form
    {
        int adminID = 0;

        public showData(int id)
        {
            InitializeComponent();
            adminID = id;
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
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            if (tableName.Text == "BOOK, AUTHOR")
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
            string replace = @"bin\Debug";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace(replace, "onlineLibrary.mdf") + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            String selectData = "SELECT UserType FROM UserDetails WHERE userid = " + adminID;
            using (SqlCommand cmd = new SqlCommand(selectData, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); // Move to the first retrieved row
                        string userType = reader.GetString(0); // Get user type from the second column

                        if (userType == "Admin")
                        {
                            Main mForm = new Main(adminID); // Pass user ID to constructor
                            mForm.Show();
                        }
                        else
                        {
                            userMainForm uForm = new userMainForm(adminID); // Pass user ID to constructor
                            uForm.Show();
                        }
                        this.Hide();
                    }

                }
            }
        }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        }
    }
