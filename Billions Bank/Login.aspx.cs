using System;
using System.Data.SqlClient;

namespace Billions_Bank
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        // Page Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // This section is intentionally left empty as there is no specific initialization needed on page load.
        }

        // Event handler for the "Sign Up" button click
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // Redirect to the SignUp.aspx page when the "Sign Up" button is clicked
            Response.Redirect("SignUp.aspx");
        }

        // Event handler for the "Forgot Password" link click
        protected void lblForgotPassword_Click(object sender, EventArgs e)
        {
            // Check if the username is empty
            if (txtUsername.Text.Trim() == String.Empty)
            {
                // Display an error message if the username is empty and focus on the username textbox
                error.InnerText = "Invalid Input";
                txtUsername.Focus();
            }
            else
            {
                // Set the "forgotpassword" session variable and redirect to ForgotPassword.aspx
                Session["forgotpassword"] = txtUsername.Text.Trim();
                Response.Redirect("ForgotPassword.aspx");
            }
        }

        // Event handler for the "Login" button click
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Initialize SQL connection and command
            con = new SqlConnection(Common.GetConnectionString());
            cmd = new SqlCommand(@"Select * from Account where Username = @Username and Password =  @Password", con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

            try
            {
                // Open the connection
                con.Open();

                // Execute the command and read the result using a data reader
                reader = cmd.ExecuteReader();
                bool isTrue = false;

                // Check if there is at least one matching user
                while (reader.Read())
                {
                    isTrue = true;

                    // Set the "userId" session variable with the AccountId of the authenticated user
                    Session["userId"] = reader["AccountId"].ToString();
                }

                // Redirect to the Transaction.aspx page if authentication is successful
                if (isTrue)
                {
                    Response.Redirect("Transaction.aspx", false);
                }
                else
                {
                    // Display an error message if authentication fails
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
                // Close the reader and the connection in the finally block
                reader.Close();
                con.Close();
            }
        }
    }
}