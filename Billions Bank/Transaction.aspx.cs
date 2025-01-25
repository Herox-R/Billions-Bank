using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billions_Bank
{
    public partial class Transaction : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        SqlTransaction transaction = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is not being loaded in response to a postback
            if (!IsPostBack)
            {
                // Redirect to login page if the userId session variable is not set
                if (Session["userId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }

            // Populate the TransactionAccountNumber dropdown list with account numbers
            getAccountNumber();
        }

        // Method to populate the TransactionAccountNumber dropdown list with account numbers
        void getAccountNumber()
        {
            try
            {
                con = new SqlConnection(Common.GetConnectionString());
                cmd = new SqlCommand(@"Select AccountId, AccountNumber from Account where AccountId  != @AccountId", con);
                cmd.Parameters.AddWithValue("@AccountId", Session["userId"]);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                TransactionAccountNumber.DataSource = dt;
                TransactionAccountNumber.DataTextField = "AccountNumber";
                TransactionAccountNumber.DataValueField = "AccountId";
                TransactionAccountNumber.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error -" + ex.Message + "');</script>");
            }
        }

        // Event handler for the "Send" button click
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                con = new SqlConnection(Common.GetConnectionString());
                con.Open();

                try
                {
                    int r = 0;
                    Utils utils = new Utils();
                    int balanceAmount = utils.accountBalance(Convert.ToInt32(Session["userId"]));
                    int amount = Convert.ToInt32(txtAmount.Text.Trim());

                    // Check if the entered amount is less than or equal to the account balance
                    if (amount <= balanceAmount)
                    {
                        transaction = con.BeginTransaction();

                        // Insert a transaction record
                        cmd = new SqlCommand(@"INSERT INTO [Transaction](SenderAccountId, ReceiverAccountId, RecipientName, MobileNumber, Amount, TransactionDate, Reference)
                                   VALUES (@SenderAccountId,@ReceiverAccountId, @RecipientName, @MobileNumber, @Amount, @TransactionDate, @Reference)", con, transaction);
                        cmd.Parameters.AddWithValue("@SenderAccountId", Session["userId"]);
                        cmd.Parameters.AddWithValue("@ReceiverAccountId", TransactionAccountNumber.SelectedValue);
                        cmd.Parameters.AddWithValue("@RecipientName", txtRecipientName.Text.Trim());
                        cmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim());
                        cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Reference", txtReference.Text.Trim());
                        r = cmd.ExecuteNonQuery();

                        // Update sender's account balance
                        UpdateSenderAccountBalance(Convert.ToInt32(Session["userId"]), balanceAmount, amount, con, transaction);

                        // Update receiver's account balance
                        UpdateReceiverAccountBalance(Convert.ToInt32(TransactionAccountNumber.SelectedValue), amount, con, transaction);
                        transaction.Commit();

                        // Redirect to the debits page if the transaction is successful
                        if (r > 0)
                        {
                            Response.Redirect("mydebits.aspx", false);
                        }
                        else
                        {
                            error.InnerText = "Invalid Input";
                        }
                    }
                    else
                    {
                        error.InnerText = "Insufficient Balance";
                    }
                }
                catch (Exception)
                {
                    // Rollback the transaction in case of an exception
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }

        // Method to update the sender's account balance
        void UpdateSenderAccountBalance(int _senderId, int _dbAmount, int _amount, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            try
            {
                // Check if there is sufficient balance
                if (_dbAmount >= _amount)
                {
                    _dbAmount -= _amount;
                    cmd = new SqlCommand("Update Account set Amount = @Amount where AccountId = @AccountId", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amount", _dbAmount);
                    cmd.Parameters.AddWithValue("@AccountId", _senderId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "');</script>");
            }
        }

        // Method to update the receiver's account balance
        void UpdateReceiverAccountBalance(int _receiverId, int _amount, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            SqlDataReader dr = null;
            int _dbAmount = 0;
            cmd = new SqlCommand("Select Amount from Account where AccountId=@AccountId", sqlConnection, sqlTransaction);
            cmd.Parameters.AddWithValue("@AccountId", _receiverId);

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _dbAmount = (int)dr["Amount"];
                    _dbAmount += _amount;
                }
                dr.Close();

                cmd = new SqlCommand("Update Account set Amount = @Amount where AccountId=@AccountId", sqlConnection, sqlTransaction);
                cmd.Parameters.AddWithValue("@Amount", _dbAmount);
                cmd.Parameters.AddWithValue("@AccountId", _receiverId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error - " + ex.Message + "');</script>");
            }
        }

        // Event handler for the "Cancel" button click
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the Transaction page
            Response.Redirect("Transaction.aspx");
        }
    }
}