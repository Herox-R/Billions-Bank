using System.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Billions_Bank
{
    public class Common
    {
        // Method to get the connection string from the configuration file
        public static string GetConnectionString()
        {
            // Return the connection string named "BillionsBankDBConnectionString" from the configuration file
            return ConfigurationManager.ConnectionStrings["BillionsBankDBConnectionString"].ConnectionString;
        }
    }

    public class Utils
    {
        // Fields for database operations
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        // Method to retrieve account balance for a given user ID
        public int accountBalance(int userId)
        {
            int balanceAmount = 0;

            try
            {
                // Create a new SqlConnection using the connection string obtained from the Common class
                con = new SqlConnection(Common.GetConnectionString());

                // Prepare a SQL command to select the Amount from the Account table based on AccountId
                cmd = new SqlCommand(@"Select  Amount from Account where AccountId = @AccountId", con);

                // Add parameters to the SQL command to prevent SQL injection
                cmd.Parameters.AddWithValue("@AccountId", userId);

                // Create a new SqlDataAdapter and DataTable for fetching and storing data
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                // Fill the DataTable with data from the SQL command
                sda.Fill(dt);

                // Get the balance amount from the DataTable, defaulting to 0 if no records are found
                balanceAmount = Convert.ToInt32(dt.Rows.Count > 0 ? dt.Rows[0]["Amount"] : 0);
            }
            catch (Exception ex)
            {
                // Display an error message in case of an exception
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error - '" + ex.Message + ");</script>");
            }

            // Return the calculated balance amount
            return balanceAmount;
        }
    }
}