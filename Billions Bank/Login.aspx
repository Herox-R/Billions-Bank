<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Billions_Bank.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center">
        <tr>
            <td colspan="4" align="center">
                <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">LOGIN:</h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
            <td style="padding-right:40px;" class="auto-style2">
            </td>
            <td>
                <asp:LinkButton ID="lblForgotPassword" runat="server" Height="28px" CausesValidation="false" OnClick="lblForgotPassword_Click" >Forgot Password</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Height="28px" Width="199px"  TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

            </td>
            <td class="auto-style2"></td>
            <td> </td>
        </tr>
        <tr>
              <td colspan="4" style="padding-left:77px;">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Height="28px" OnClick="btnLogin_Click" Width="67px" />
                  &nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;">OR</span>&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSignUp" runat="server" Text="SignUp" Height="28px" OnClick="btnSignUp_Click"
                   />
              </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="error" runat="server" style="color:red">

                </div>
            </td>
            <td>
                &nbsp;</td>
           
        </tr>
    </table>
</asp:Content>