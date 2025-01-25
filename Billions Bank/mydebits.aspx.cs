using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billions_Bank
{
    public partial class mydebits : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlTransaction transaction = null;

        // Page Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is not being loaded in response to a postback
            if (!IsPostBack)
            {
                // Redirect to the login page if the userId session variable is not set
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                // Load and display the debit transactions for the current user
                getMyDebit();
            }
        }

        // Method to retrieve and display debit transactions for the current user
        void getMyDebit()
        {
            try
            {
                // Initialize SQL connection
                con = new SqlConnection(Common.GetConnectionString());

                // SQL command to retrieve debit transactions for the current user
                cmd = new SqlCommand(@"SELECT a.AccountNumber, t.RecipientName, t.Amount, t.TransactionDate, t.Reference
                               FROM [Transaction] t
                               INNER JOIN Account a ON t.ReceiverAccountId = a.AccountId
                               WHERE t.SenderAccountId = @SenderAccountId", con);

                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue(@"SenderAccountId", Session["userId"]);

                // Initialize a SqlDataAdapter and DataTable for fetching and storing data
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                // Fill the DataTable with data from the SQL command
                sda.Fill(dt);

                // Bind the DataTable to the GridView for display
                gvMyDebits.DataSource = dt;
                gvMyDebits.DataBind();
            }
            catch (Exception ex)
            {
                // Display an error message in case of an exception
                Response.Write("<script>alert('Error - " + ex.Message + "');</script>");
            }
        }
    }
}