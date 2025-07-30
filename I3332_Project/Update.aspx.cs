using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace I3332_Project
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int carId;
                    if (int.TryParse(Request.QueryString["id"], out carId))
                    {
                        hfCarId.Value = carId.ToString();
                        LoadCarData(carId);
                    }
                    else
                    {
                        lblMessage.Text = "Invalid car ID.";
                    }
                }
                else
                {
                    lblMessage.Text = "No car ID provided.";
                }
            }
        }

        private void LoadCarData(int carId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string query = "SELECT Brand, Model, Type, PricePerDay, ImagePath, Available FROM Cars WHERE Id = @Id";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", carId);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtBrand.Text = reader["Brand"].ToString();
                        txtModel.Text = reader["Model"].ToString();
                        txtType.Text = reader["Type"].ToString();
                        txtPricePerDay.Text = reader["PricePerDay"].ToString();
                        txtImagePath.Text = reader["ImagePath"].ToString();
                        chkAvailable.Checked = Convert.ToBoolean(reader["Available"]);
                    }
                    else
                    {
                        lblMessage.Text = "Car not found.";
                    }
                }
            }
        }
        public void Back(object sender, EventArgs e)   
        {
            Response.Redirect("~/AdminCarListing.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int carId = int.Parse(hfCarId.Value);

            string brand = txtBrand.Text.Trim();
            string model = txtModel.Text.Trim();
            string type = txtType.Text.Trim();
            string imagePath = txtImagePath.Text.Trim();
            bool available = chkAvailable.Checked;
            decimal pricePerDay;

            if (!decimal.TryParse(txtPricePerDay.Text.Trim(), out pricePerDay))
            {
                lblMessage.Text = "Price per day must be a valid decimal number.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            string updateQuery = @"UPDATE Cars SET 
                                    Brand = @Brand, 
                                    Model = @Model, 
                                    Type = @Type, 
                                    PricePerDay = @PricePerDay, 
                                    ImagePath = @ImagePath, 
                                    Available = @Available
                                   WHERE Id = @Id";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@PricePerDay", pricePerDay);
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                cmd.Parameters.AddWithValue("@Available", available ? 1 : 0);
                cmd.Parameters.AddWithValue("@Id", carId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Car updated successfully!";
                        Response.Redirect("~/AdminCarListing.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Update failed.";
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
}
