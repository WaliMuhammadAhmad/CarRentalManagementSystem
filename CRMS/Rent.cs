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
    public partial class Rent : Form
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public static List<rented> list = new List<rented>();
        public Rent()

        {
            InitializeComponent();
            foreach (Cusromer c in Customer.customer)
            {
                comboBox1.Items.Add(c.Name);
                
            }
            foreach (Class1 c in Driver.Drivers)
            {
                comboBox2.Items.Add(c.Name);

            }
            foreach (Car c in Cars.cars)
            {
                comboBox3.Items.Add(c.Car_NO);

            }
        }

        // Do not remove or else they will throw visual error
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Rent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text!="" &&  comboBox3.Text!="" && textBox1.Text!="0")
            { 
                list.Add(new rented(comboBox1.Text,comboBox2.Text,comboBox3.Text, int.Parse(textBox1.Text)));
                string num = comboBox3.Text;
                dbHelper.RentCar(0, int.Parse(textBox1.Text), num);
                foreach(rented rented in list)
                {
                    if (rented.Cnumber == comboBox3.Text)
                    {
                        textBox2.Text = rented.Totalamount.ToString() ;
                    }
                    else
                    {
                        MessageBox.Show("invalid car number");
                    }
                }
                MessageBox.Show("Car Rented successfully!");
            }
            else
            {
                MessageBox.Show("Please fill in all fields!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard obj= new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
    }
}
