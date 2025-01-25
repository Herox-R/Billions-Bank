using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace Billions_Bank
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        // Page Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // This section is intentionally left empty as there is no specific initialization needed on page load.
        }

        // Event handler for the "Change Password" button click
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Check if the "forgotpassword" session variable is set
            if (Session["forgotpassword"] != null)
            {
                // Initialize SQL connection and command
                con = new SqlConnection(Common.GetConnectionString());
                cmd = new SqlCommand(@"Update Account set Password= @Password where Username = @Username ", con);

                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Username", Session["forgotpassword"].ToString());

                try
                {
                    // Open the connection
                    con.Open();

                    // Execute the command and get the number of affected rows
                    int r = cmd.ExecuteNonQuery();

                    // Redirect to the login page if the password is successfully updated
                    if (r > 0)
                    {
                        Response.Redirect("Login.aspx", false);
                    }
                    else
                    {
                        // Display an error message if the input is invalid
                        error.InnerText = "Invalid Input.";
                    }

                }
                catch (Exception ex)
                {
                    // Display an error message for exceptions
                    Response.Write("<script>alert('Error - " + ex.Message + " ');</script>");
                }
                finally
                {
                    // Close the connection in the finally block
                    con.Close();
                }
            }
            else
            {
                // Redirect to the login page if the "forgotpassword" session variable is not set
                Response.Redirect("Login.aspx");
            }
        }

        // Event handler for the "Cancel" button click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the ForgotPassword.aspx page when the "Cancel" button is clicked
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}