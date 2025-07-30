using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;//FOR CRYPTOGRAPHIC FUNCTIONS BUT NOT USED HERE 

namespace I3332_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//Retrieves the database connection string from web.config

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Use parameterized query to avoid SQL injection
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    string getIdQuery = "SELECT Id FROM Users WHERE Username = @Username";
                    MySqlCommand idCmd = new MySqlCommand(getIdQuery, conn);
                    idCmd.Parameters.AddWithValue("@Username", username);

                    int userId = Convert.ToInt32(idCmd.ExecuteScalar());
                    //Session["UserId"] = userId;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            // Successful login
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Login successful!";
                            Session["UserName"] = username;
                            Session["UserId"] = userId;
                            // Redirect to another page (e.g., Dashboard)
                             Response.Redirect("~/CarListing.aspx");
                        }
                        else
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Invalid username or password.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}