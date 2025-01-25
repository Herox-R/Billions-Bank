using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billions_Bank
{
    public partial class mycredits : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

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

                // Load and display the credit transactions for the current user
                getMyCredits();
            }
        }

        // Method to retrieve and display credit transactions for the current user
        void getMyCredits()
        {
            try
            {
                // Initialize SQL connection
                con = new SqlConnection(Common.GetConnectionString());

                // SQL command to retrieve credit transactions for the current user
                cmd = new SqlCommand(@"SELECT s.AccountNumber AS SenderAccountNumber, s.UserName AS SenderName,
                                   r.AccountNumber AS ReceiverAccountNumber, r.UserName AS ReceiverName,
                                   t.Amount, t.TransactionDate, t.Reference
                           FROM [Transaction] t
                           INNER JOIN Account s ON t.SenderAccountId = s.AccountId
                           INNER JOIN Account r ON t.ReceiverAccountId = r.AccountId
                           WHERE t.ReceiverAccountId = @ReceiverAccountId", con);

                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@ReceiverAccountId", Session["userId"]);

                // Initialize a SqlDataAdapter and DataTable for fetching and storing data
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();

                // Fill the DataTable with data from the SQL command
                sda.Fill(dt);

                // Check if there are matching records in the DataTable
                if (dt.Rows.Count > 0)
                {
                    // Bind the DataTable to the GridView for display
                    gvMyCredits.DataSource = dt;
                    gvMyCredits.DataBind();
                }
                else
                {
                    // Display a message if no matching records are found
                    error.InnerText = "No matching records found.";
                }
            }
            catch (Exception ex)
            {
                // Display an error message in case of an exception
                Response.Write("<script>alert('Error - " + ex.Message + "');</script>");
            }
        }
    }
}