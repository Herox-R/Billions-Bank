using System;
using System.Data.SqlClient;

namespace Billions_Bank
{
    public partial class SignUp : System.Web.UI.Page
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
                // Display the generated account number when the page is first loaded
                lblAccountNumber.Text = displayAccountNumber();
            }
        }

        // Method to generate a new account number
        string displayAccountNumber()
        {
            // Initialize SQL connection
            con = new SqlConnection(Common.GetConnectionString());

            // SQL command to generate a new account number based on the maximum existing account number
            cmd = new SqlCommand(@"Select 'BSB202400001' + + CAST( MAX( CAST( SUBSTRING( AccountNumber, 12, 50 ) AS INT)) +1 AS VARCHAR) 
                                AS AccountNumber from Account", con);

            // Open the connection
            con.Open();

            // Execute the command and read the generated account number
            reader = cmd.ExecuteReader();
            string accountNumber = string.Empty;
            while (reader.Read())
            {
                accountNumber = reader["AccountNumber"].ToString();
            }

            // Close the reader and the connection
            reader.Close();
            con.Close();

            // Return the generated account number
            return accountNumber;
        }

        // Event handler for the "Sign Up" button click
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // Initialize SQL connection
            con = new SqlConnection(Common.GetConnectionString());

            // SQL command to insert a new account into the Account table
            cmd = new SqlCommand(@"Insert into Account(AccountNumber,AccountType,UserName,Gender,Email,Address,SecurityQuestionId,Answer,
                                  Amount,Password) values(@AccountNumber,@AccountType,@UserName,@Gender,@Email,@Address,@SecurityQuestionId,
                                  @Answer,@Amount,@Password)", con);

            // Add parameters to the SQL command
            cmd.Parameters.AddWithValue("@AccountNumber", lblAccountNumber.Text);
            cmd.Parameters.AddWithValue("@AccountType", ddlAccountType.SelectedValue);
            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@SecurityQuestionId", ddlSecurityQuestion.SelectedValue);
            cmd.Parameters.AddWithValue("@Answer", txtAnswer.Text.Trim());
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

            try
            {
                // Open the connection
                con.Open();

                // Execute the command and get the number of affected rows
                int r = cmd.ExecuteNonQuery();

                // Redirect to the login page if the account is successfully created
                if (r > 0)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    // Display an error message if the input is invalid
                    error.InnerText = "Invalid input.";
                }
            }
            catch (Exception ex)
            {
                // Check if the exception is due to a unique key violation (duplicate username)
                if (ex.Message.Contains("Violation of UNIQUE KEY constraints"))
                {
                    error.InnerText = "User name already exists.";
                }
                else
                {
                    // Display an error message for other exceptions
                    Response.Write("<script>alert('Error -" + ex.Message + " ');</script>");
                }
            }
            finally
            {
                // Close the connection in the finally block
                con.Close();
            }
        }

        // Event handler for the "Cancel" button click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the login page
            Response.Redirect("Login.aspx");
        }
    }
}