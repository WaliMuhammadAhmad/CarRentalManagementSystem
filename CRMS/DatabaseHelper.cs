using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;

namespace CRMS
{
    internal class DatabaseHelper
    {
        // Private static variable to hold the single instance of the class
        private static DatabaseHelper _instance;

        // Private static object for locking
        private static readonly object _lock = new object();

        // Private field to hold the connection string
        private string connectionString;

        // Private constructor to prevent instantiation
        private DatabaseHelper()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        // Public static method to provide access to the single instance
        public static DatabaseHelper Instance
        {
            get
            {
                // Double-check locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseHelper();
                        }
                    }
                }
                return _instance;
            }
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

        public void GetCustomer(DataGridView dataGridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    dataGridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while fetching the customers: " + ex.Message);
                }
            }
        }

        public void AddCar(string number, string type, string name, int rent, int available)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cars (Number, Type, Name, Rent, Avalaible) VALUES (@Number, @Type, @Name, @Rent, @Avalaible)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Number", number);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Rent", rent);
                command.Parameters.AddWithValue("@Avalaible", available);

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
                string query = "UPDATE Cars SET Number = @Number, Type = @Type, Name = @Name, Rent = @Rent WHERE Number = @CarID";
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

        public void TotalCars(DataGridView dataGridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cars";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    // Create a DataTable to hold the data
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    // Set the DataTable as the DataGridView's data source
                    dataGridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void TotalCars(DataGridView dataGridView, int available)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cars WHERE Avalaible = @available";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@available", available);

                try
                {
                    connection.Open();

                    // Create a DataTable to hold the data
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    // Set the DataTable as the DataGridView's data source
                    dataGridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public void RentCar(int available,int days, string num)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cars SET Avalaible = @Avalaible, RentDay = @Days WHERE Number = @CarID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Avalaible", available);
                command.Parameters.AddWithValue("@Days", days);
                command.Parameters.AddWithValue("@CarID", num);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Car Rented successfully.");
                }
                catch (Exception ex)
                {
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

        public void GetDrivers(DataGridView dataGridView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Drivers";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    dataGridView.DataSource = table;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while fetching the customers: " + ex.Message);
                }
            }
        }

    }
}
