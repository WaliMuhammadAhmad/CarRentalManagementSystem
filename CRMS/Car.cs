using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS
{
    public class Car
    {
        private string car_id;
        private string model_name;
        private string car_type;
        private int rupees_per_day;
       public bool availablity;


        public Car(string car_id, string model_name, string car_type, int rupees_per_days)
        {
            this.car_id = car_id;
            this.model_name = model_name;
            this.car_type = car_type;
            this.rupees_per_day = rupees_per_days;
            availablity = true;
          
        }
        public Car() { }

        public string Car_NO {  get { return this.car_id; } set { this.car_id = value; } }
        public string Model_Name { get { return this.model_name;} set { this.model_name = value;} }
        public string Car_TYPE { get {  return this.car_type;} set {  this.car_type = value;} }
        public int Rupees_per_day { get { return this.rupees_per_day; } set { this.Rupees_per_day = value; } }
    
    }
    
}
