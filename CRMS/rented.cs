using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRMS
{
    public class rented
    {
        private string customer_name;
        private string Driver_name;
        private string Car_number;
        private int number_of_days;
        private int total_rent;

        public rented(string customer_name,string Driver_name,string Car_number,int numberofdays) 
        {
            this.customer_name = customer_name;
            this.Driver_name = Driver_name;
            this.Car_number = Car_number;
            this.number_of_days = numberofdays;
            foreach(Car c in Cars.cars)
            {
                if(c.Car_NO==this.Car_number)
                {
                    total_rent = c.Rupees_per_day * number_of_days;
                    c.availablity = false;
                }
                else
                {
                    MessageBox.Show("Invalid car Number");
                }
            }
            //if (this.number_of_days > 0 && this.number_of_days < 5)
            //{
            //    total_rent = 4000;
            //}
            //else if (this.number_of_days > 5)
            //{
            //    total_rent = 6000;
            //}
        }
    
        public string CNname { get { return this.customer_name; } set { this.customer_name = value; } }
        public string DName {  get { return this.Driver_name; }set { this.Driver_name = value; } }
        public int NumberOfDays { get {  return this.number_of_days; } set { this.NumberOfDays = value; } }
        public string Cnumber { get { return this.Car_number; } set { this.Car_number = value; } }
        public int Totalamount { get {  return this.total_rent; } set { this.total_rent = value; } }
    }

    
   
}
