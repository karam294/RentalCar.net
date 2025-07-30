using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace I3332_Project
{
    public partial class AdminCarListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCars();
            }
        }
        protected void Btn_Delete(object sender, CommandEventArgs e)
        {
            int carId = Convert.ToInt32(e.CommandArgument);  // get car ID from button
            DeleteCar(carId);                                // delete from DB
            LoadCars();                                      // refresh the list
        }
        private void DeleteCar(int carId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "DELETE FROM Cars WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", carId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Car deleted successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error deleting car: " + ex.Message + "');</script>");
                }
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
        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            string brand = txtBrand.Text.Trim();
            string model = txtModel.Text.Trim();
            string type = txtType.Text.Trim();
            string imagePath = txtImagePath.Text.Trim();
            bool available = chkAvailable.Checked;
            decimal pricePerDay;

            if (!decimal.TryParse(txtPricePerDay.Text, out pricePerDay))
            {
                lblAddCarMessage.Text = "Please enter a valid price.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Cars (Brand, Model, Type, PricePerDay, ImagePath, Available) " +
                               "VALUES (@Brand, @Model, @Type, @PricePerDay, @ImagePath, @Available)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@PricePerDay", pricePerDay);
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                cmd.Parameters.AddWithValue("@Available", available ? 1 : 0);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblAddCarMessage.ForeColor = System.Drawing.Color.Green;
                    lblAddCarMessage.Text = "Car added successfully.";

                    // Clear form fields
                    txtBrand.Text = txtModel.Text = txtType.Text = txtImagePath.Text = txtPricePerDay.Text = "";
                    chkAvailable.Checked = true;

                    LoadCars(); // Refresh the list
                }
                catch (Exception ex)
                {
                    lblAddCarMessage.ForeColor = System.Drawing.Color.Red;
                    lblAddCarMessage.Text = "Error adding car: " + ex.Message;
                }
            }
        }


    }
}