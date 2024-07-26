using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CRMS
{
    internal class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void OpenConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection Opened.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public bool AdminLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                
                try
                {
                    connection.Open();
                    int result = (int)command.ExecuteScalar();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }

        //public void TotalCars(Boolean aval)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Cars WHERE Avalaible = @avalaible";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@avalaible", aval);

        //        try
        //        {
        //            connection.Open();
        //            int result = (int)command.ExecuteScalar();
        //            //return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("An error occurred: " + ex.Message);
        //            //return false;
        //        }
        //    }
        //}

        public void AddCustomer(string id, string name, string passport, string contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (Id, Name, Passport, Contact) VALUES (@Id, @Name, @Passport, @Contact)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Passport", passport);
                command.Parameters.AddWithValue("@Contact", contact);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void UpdateCustomer(string customerId, string name, string passport, string contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET Id = @CustomerID, Name = @Name,Passport = @Passport, Contact = @Contact WHERE Id = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Passport", passport);
                command.Parameters.AddWithValue("@Contact", contact);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void DeleteCustomer(string customerId)
        {
            MessageBox.Show(customerId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE Id = @CustomerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Customer deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    
                }
            }
        }

        public void AddCar(string number, string type, string name, int rent)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cars (Number, Type, Name, Rent) VALUES (@Number, @Type, @Name, @Rent)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Rent", rent);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Car added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void UpdateCar(string number, string type, string name, int rent)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cars SET Make = @Make, Model = @Model, Year = @Year WHERE CarID = @CarID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Rent", rent);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Car updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void DeleteCar(string carno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cars WHERE Number = @CarID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CarID", carno);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Car Removed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed! " + ex.Message,"Error");
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void AddDriver(string id, string name, string licenseNumber, string contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Drivers (Id, Name, LicenseNumber, Contact) VALUES (@Id, @Name, @LicenseNumber, @Contact)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LicenseNumber", licenseNumber);
                command.Parameters.AddWithValue("@Contact", contact);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Driver added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void UpdateDriver(string id, string name, string licenseNumber, string contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Drivers SET Name = @Name, LicenseNumber = @LicenseNumber, Contact = @Contact WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LicenseNumber", licenseNumber);
                command.Parameters.AddWithValue("@Contact", contact);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Driver updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void DeleteDriver(string driverId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Drivers WHERE Id = @DriverID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", driverId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Driver deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

    }
}
