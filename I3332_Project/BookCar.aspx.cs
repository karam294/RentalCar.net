using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace I3332_Project
{
    public partial class BookCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                int carId = Convert.ToInt32(Request.QueryString["id"]);
                LoadCarDetails(carId);
            }
        }

        private void LoadCarDetails(int carId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM Cars WHERE Id = @CarId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CarId", carId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    imgCar.ImageUrl = reader["ImagePath"].ToString();
                    lblBrandModel.Text = reader["Brand"] + " " + reader["Model"];
                    lblType.Text = "Type: " + reader["Type"];
                    lblPricePerDay.Text = reader["PricePerDay"].ToString();

                    // Store info in ViewState for use on postback
                    ViewState["CarId"] = carId;
                    ViewState["PricePerDay"] = Convert.ToDecimal(reader["PricePerDay"]);
                }
                reader.Close();
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    lblMessage.Text = "You must be logged in to book a car.";
                    return;
                }

                int userId = Convert.ToInt32(Session["UserId"]);
                int carId = Convert.ToInt32(ViewState["CarId"]);
                decimal pricePerDay = Convert.ToDecimal(ViewState["PricePerDay"]);

                DateTime startDate, endDate;
                if (!DateTime.TryParse(txtStartDate.Text, out startDate) ||
                    !DateTime.TryParse(txtEndDate.Text, out endDate) ||
                    endDate <= startDate)
                {
                    lblMessage.Text = "Invalid date range.";
                    return;
                }

                // Check for overlapping bookings
                if (IsCarAlreadyBooked(carId, startDate, endDate))
                {
                    lblMessage.Text = "This car is already booked for the selected dates.";
                    return;
                }

                int totalDays = (endDate - startDate).Days;
                decimal totalPrice = totalDays * pricePerDay;

                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = "INSERT INTO Bookings (UserId, CarId, StartDate, EndDate, TotalPrice) " +
                                   "VALUES (@UserId, @CarId, @StartDate, @EndDate, @TotalPrice)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Booking successful!";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "An error occurred. Please try again later.";
            }
        }
        private bool IsCarAlreadyBooked(int carId, DateTime startDate, DateTime endDate)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"
            SELECT COUNT(*) 
            FROM Bookings 
            WHERE CarId = @CarId
            AND (
                (StartDate <= @EndDate AND EndDate >= @StartDate)  -- Check if the dates overlap
            )";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CarId", carId);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                conn.Open();
                int overlappingBookings = Convert.ToInt32(cmd.ExecuteScalar());

                return overlappingBookings > 0;  // Return true if there is an overlap
            }
        }

    }
}
