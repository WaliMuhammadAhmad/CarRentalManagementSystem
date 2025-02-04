﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRMS
{
    public partial class Cars : Form
    {
        public static List<Car> cars = new List<Car>();

        DatabaseHelper dbHelper = DatabaseHelper.Instance;

        bool flag = true;
        public Cars()
        {
            InitializeComponent();
            DataGridView();
            label5.Text = "Add Car";
        }


        private void DataGridView()
        {
            // Create a DataTable to hold the data
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Car Type", typeof(string));
            table.Columns.Add("Car Name", typeof(string));
            table.Columns.Add("Rent Per day", typeof(string));

            // Add data to the DataTable
            foreach (Car car in cars)
            {
                table.Rows.Add(car.Car_NO, car.Car_TYPE, car.Model_Name, car.Rupees_per_day.ToString());
            }

            // Set the DataTable as the DataGridView's data source
            dataGridView1.DataSource = table;
        }

        //-----------------addedd-------------------
        private void button1_Click(object sender, EventArgs e)
        {
            // Show all text boxes and labels
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label3.Visible = true;

            // Check if all text boxes are filled
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                
                    // Add a new Car object to the cars list
                    //cars.Add(new Car(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text)));
                    dbHelper.AddCar(textBox1.Text, textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text),1);
                    MessageBox.Show("Car added successfully!");
                    // Clear all text boxes
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

            }
            else
            {
                MessageBox.Show("Please fill in all fields!");
            }
        }


        //----------remove car-----------------------
        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = "Remove Car";

            textBox2.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;

            label2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            button4.Visible = true;

            string Car_NO = textBox1.Text;
            
            if (Car_NO != null)
            {
                dbHelper.DeleteCar(Car_NO);
                DataGridView();
            }
            else
            {
                MessageBox.Show("Please fill in all fields!");
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        



        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {

                
                button4.Visible = true;
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Dashboard obj=new Dashboard();
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
    }
}
    

