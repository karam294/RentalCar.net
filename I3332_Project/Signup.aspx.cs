using System;   //ings in the base class library (basic types like string, int, Exception, etc.)
using System.Collections.Generic;//Used for collections like List<>, Dictionary<>. (Not used in your current code, but fine to include.)    
using System.Configuration;//Allows access to configuration files like Web.config — specifically to read connection strings.
using System.Data.SqlClient;//For working with SQL Server. ✅ Not used in your code since you're using MySQL. Can be removed. 
using System.Linq;//Adds LINQ (Language Integrated Query). Also not used in this code.
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//abocve three:Used for ASP.NET Web Forms features like Page, TextBox, Label, and Button.
using MySql.Data.MySqlClient;//required to interact with mysql database


namespace I3332_Project
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            // Get values from the input fields
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Get the connection string from Web.config
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                // Create a connection to MySQL database
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();  // Open the connection

                    // SQL query to insert a new user into the Users table
                    string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";

                    // Create a command to execute the SQL query
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Execute the query to insert data
                        int result = cmd.ExecuteNonQuery();

                        // Check if the insertion was successful
                        if (result > 0)
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Registration successful!";
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Registration failed. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message if something goes wrong
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }

        }
    }
}