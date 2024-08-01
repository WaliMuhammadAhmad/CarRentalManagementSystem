using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMS
{

    public partial class Customer : Form
    {
        public static List<Cusromer> customer = new List<Cusromer>();
        Cusromer obj;
        bool flag = true;
        int index = 0;
        DatabaseHelper dbHelper = DatabaseHelper.Instance;

        public Customer()
        {
            InitializeComponent();
            DataGridView();
            label5.Text = "Add Customer";
        }

        private void DataGridView()
        {
            // Create a DataTable to hold the data
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Phone", typeof(string));
            table.Columns.Add("Passport", typeof(string));

            // Add data to the DataTable
            foreach (Cusromer driver in customer)
            {
                table.Rows.Add(driver.Name, driver.ID, driver.Contact, driver.Cnic);
            }

            // Set the DataTable as the DataGridView's data source
            dataGridView1.DataSource = table;
        }



        private void button1_Click(object sender, EventArgs e)

        {
           
        }

        //Remove

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        //UPDATE

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        //UPdate

        private void button5_Click(object sender, EventArgs e)
        {
           
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label3.Visible = true;


            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                customer.Add(new Cusromer(textBox3.Text, textBox1.Text, textBox4.Text, textBox2.Text));
                dbHelper.AddCustomer(textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text);
                MessageBox.Show("Customer added successfully!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                DataGridView();
            }
            else
            {
                MessageBox.Show("Please fill in all fields!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label5.Text = "Remove Customer";
            label6.Visible = true;
            textBox5.Visible = true;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            button4.Visible = true;
            foreach (Cusromer driver in customer)
            {
                if (driver.ID == textBox5.Text)
                {
                    obj = driver;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    textBox1.Text = driver.Name;
                    textBox2.Text = driver.Cnic;
                    textBox4.Text = driver.Contact;
                    textBox3.Text = driver.ID;
                    button4.Visible = true;
                    flag = false;
                    break;
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string id = textBox5.Text;

            if (flag == false)
            {
                customer.Remove(obj);
                dbHelper.DeleteCustomer(obj.ID);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                label6.Visible = false;
                textBox5.Visible = false;
                MessageBox.Show("Customer Removed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridView();
                button4.Visible = false;
                flag = true;
            }
            else if (flag == true)
            {
                MessageBox.Show("Customer with that ID does not Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Clear();
                button4.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label5.Text = "Update Customer";

            label6.Visible = true;
            textBox5.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            button5.Visible = true;

            // Reset index before searching for the driver
            index = -1;

            foreach (Cusromer driver in customer)
            {
                index++;
                if (driver.ID == textBox5.Text)
                {
                    obj = driver;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label6.Visible = false;

                    textBox1.Text = driver.Name;
                    textBox2.Text = driver.Cnic;
                    textBox4.Text = driver.Contact;
                    textBox3.Text = driver.ID;
                    textBox5.Visible = false;
                    button5.Visible = true;
                    flag = false;
                    break;
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (flag == false && index != -1 && index < customer.Count)
            {
                label7.Visible = true;
                customer[index].ID = textBox3.Text;
                customer[index].Name = textBox1.Text;
                customer[index].Cnic = textBox2.Text;
                customer[index].Contact = textBox4.Text;
                dbHelper.UpdateCustomer(textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                label6.Visible = false;
                textBox5.Visible = false;

                MessageBox.Show("Customer Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataGridView();
                label7.Visible = false;
                button5.Visible = false;
                flag = true;
            }
            else
            {
                MessageBox.Show("Customer with that ID does not exist or no customer selected for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Clear();
                button5.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Brown;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
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

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Brown;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
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

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Brown;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.Brown;
            button6.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
        }
    }
    
}
