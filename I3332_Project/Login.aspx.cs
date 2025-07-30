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

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Single query to get Id and Role if username and password match
                    string query = "SELECT Id, Role FROM Users WHERE Username = @Username AND Password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("Id");
                                string role = reader.GetString("Role");

                                // Save info to session
                                Session["UserName"] = username;
                                Session["UserId"] = userId;
                                Session["UserRole"] = role;

                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                lblMessage.Text = "Login successful!";

                                // Redirect based on role
                                if (role == "admin")
                                {
                                    Response.Redirect("~/AdminCarListing.aspx"); // Replace with your admin page
                                }
                                else
                                {
                                    Response.Redirect("~/CarListing.aspx");
                                }
                            }
                            else
                            {
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                lblMessage.Text = "Invalid username or password.";
                            }
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