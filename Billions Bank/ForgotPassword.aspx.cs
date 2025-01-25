using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Billions_Bank
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        // Page Load event
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is not being loaded in response to a postback
            if (!IsPostBack)
            {
                // Load user security question when the page is first loaded
                getUsersecurityQuestion();
            }
        }

        // Method to retrieve and display user security question
        void getUsersecurityQuestion()
        {
            // Check if the "forgotpassword" session variable is set
            if (Session["forgotpassword"] != null)
            {
                // Initialize SQL connection and command
                con = new SqlConnection(Common.GetConnectionString());
                cmd = new SqlCommand(@"SELECT a.UserName, s.SecurityQuestionName, a.Answer from Account a 
                                    inner join SecurityQuestion s on a.SecurityQuestionId = s.SecurityQuestionId 
                                    where Username = @Username", con);

                // Add parameters to the SQL command
                cmd.Parameters.AddWithValue("@Username", Session["forgotpassword"]);

                // Initialize the reader to null
                reader = null;

                try
                {
                    // Open the connection
                    con.Open();

                    // Execute the command and read the user information
                    reader = cmd.ExecuteReader();
                    bool isTrue = false;

                    // Check if there is at least one matching user
                    while (reader.Read())
                    {
                        isTrue = true;
                        lblUsername.Text = reader["UserName"].ToString();
                        lblSecurityQuestion.Text = reader["SecurityQuestionName"].ToString();
                        hdnAnswer.Value = reader["Answer"].ToString();
                    }

                    // Display an error message if no matching user is found
                    if (!isTrue)
                    {
                        error.InnerText = "Invalid input.";
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
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    con.Close();
                }
            }
        }

        // Event handler for the "Forgot Password" button click
        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            // Check if the entered answer matches the stored answer
            if (txtAnswer.Text.Trim() == hdnAnswer.Value)
            {
                // Redirect to the ChangePassword.aspx page if the answer is correct
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                // Display an error message if the answer is incorrect and change the error message color to red
                error.InnerText = "Invalid Input.";
                error.Style.Add("color", "red");
            }
        }

        // Event handler for the "Cancel" button click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the Login.aspx page when the "Cancel" button is clicked
            Response.Redirect("Login.aspx");
        }
    }
}