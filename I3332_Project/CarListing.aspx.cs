using System;
using System.Configuration;  // For ConfigurationManager
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace I3332_Project
{
    public partial class CarListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCars();
            }
        }

        private void LoadCars()
        {
            // Access connection string from Web.config
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM Cars WHERE Available = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();//is a forward-only, read-only cursor used to loop through database records one by one.

                    if (reader.HasRows)
                    {
                        rptCars.DataSource = reader;
                        rptCars.DataBind();//DataSource = reader: Binds the reader (which contains all the car records) to the control. 
                    }
                    else
                    {
                        Response.Write("<script>alert('No available cars found.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Simple error display (you can improve this later)
                    Response.Write("<script>alert('Error loading cars: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
