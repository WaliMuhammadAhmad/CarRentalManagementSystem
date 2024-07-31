using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMS
{
    public partial class Dashboard : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customer cusromer = new Customer();
            cusromer.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Cars car=new Cars();
            car.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Rent rent = new Rent();
            rent.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Create a DataTable to hold the data
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Car Type", typeof(string));
            table.Columns.Add("Model Name", typeof(string));
            table.Columns.Add("Rent Per day", typeof(string));


            // Set the DataTable as the DataGridView's data source
            dataGridView1.DataSource = table;

            // Call the TotalCars method to populate the DataGridView
            dbHelper.TotalCars(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Call the TotalCars method to populate the DataGridView
            dbHelper.AvalaibleCards(dataGridView1, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Call the TotalCars method to populate the DataGridView
            dbHelper.AvalaibleCards(dataGridView1,1);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Brown;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor= Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Brown;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor= Color.Black;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Brown;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor= Color.Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Brown;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Brown;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor= Color.White;
            button1.ForeColor= Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Brown;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Brown;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }
    }
    
}
