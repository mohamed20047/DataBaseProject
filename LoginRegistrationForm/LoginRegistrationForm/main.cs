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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm iForm = new MainForm();
            iForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modify mForm = new Modify();
            mForm.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showbooks_Click(object sender, EventArgs e)
        {
            Form form = new showData();
            form.Show();
            this.Hide();
        }
    }
}
