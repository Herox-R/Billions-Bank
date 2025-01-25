<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Billions_Bank.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    &nbsp;<table align="center">
    <tr>
        <td colspan="2" align="center">
            <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">&nbsp;</h4>
            <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">Transaction</h4>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Account Number"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="TransactionAccountNumber" runat="server" Height="28px" Width="208px" AppendDataBoundItems="True">
                <asp:ListItem Value="0">Please select Account Number</asp:ListItem>
            </asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TransactionAccountNumber" SetFocusOnError="true" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            <asp:Label ID="Label3" runat="server" Text="Recipient Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtRecipientName" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtRecipientName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Minimum recipient name length must be 6 characters(alphanumeric)" ForeColor="Red"
                    ControlToValidate="txtRecipientName" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[a-zA-Z0-9\s]{6,15}$"></asp:RegularExpressionValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            <asp:Label ID="Label2" runat="server" Text="Mobile Number"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMobileNumber" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtMobileNumber" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must be of 10 digits" ForeColor="Red"
                    ControlToValidate="txtMobileNumber" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td style="height: 25px">
            <asp:Label ID="Label11" runat="server" Text="Amount"></asp:Label>
        </td>
        <td style="height: 25px">
            <asp:TextBox ID="txtAmount" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtAmount" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            <div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtAmount" Display="Dynamic" ErrorMessage="Invaild Amount" ForeColor="Red" SetFocusOnError="true" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td style="height: 16px">
            <asp:Label ID="Label12" runat="server" Text="Transaction Date"></asp:Label>
        </td>
        <td style="height: 16px">
            <asp:TextBox ID="txtTransactionDate" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtTransactionDate" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                ErrorMessage="Invalid date format. Please enter in YY/MM/DD format." ForeColor="Red"
                ControlToValidate="txtTransactionDate" ValidationExpression="\d{4}/\d{2}/\d{2}"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 50%">
            <asp:Label ID="Label10" runat="server" Text="Reference"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtReference" runat="server" Height="28px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtReference" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnSend" runat="server" Text="Send" Height="28px" OnClick="btnSend_Click" />
        </td>
        <td>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div id="error" runat="server" style="color:red"></div>
        </td>
    </tr>
</table>
</asp:Content>