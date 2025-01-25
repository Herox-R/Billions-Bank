<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Billions_Bank.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 454px;
        }
        .auto-style3 {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center">
         <tr>  
               <td colspan="2" align="centre" class="auto-style4">
                   <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">CHANGE PASSWORD</h4>
               </td> 
         </tr>
         <tr>
             <td class="auto-style3">
                 <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
                 <asp:HiddenField ID="hdnAnswer" runat="server" />
             </td>
             <td class="auto-style2">
                 <asp:TextBox ID="txtNewPassword" runat="server" Height="28px" Width="200px" TextMode="Password" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
                     ControlToValidate="txtNewPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                  <div>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                       ErrorMessage="Minimum password length must be 6 characters" ControlToValidate="txtNewPassword" ForeColor="Red"
                       SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$" ></asp:RegularExpressionValidator>
                  </div>
             </td>
         </tr>
        <tr>
             <td class="auto-style3">
                  <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
             </td>
            <td class="auto-style2">
                 <asp:TextBox ID="txtConfirmPassword" runat="server" Height="28px" Width="200px" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                ControlToValidate="txtConfirmPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
             <div>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                   ErrorMessage="Minimum password length must be 6 characters" ControlToValidate="txtConfirmPassword" ForeColor="Red"
                    SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$" ></asp:RegularExpressionValidator>
                 <asp:CompareValidator ID ="CompareValidator1" runat="server" ErrorMessage="Password not matched" ForeColor="Red"
                     SetFocusOnError ="true" Display="Dynamic" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>
             </div>
            </td>
        </tr>
        <tr>
            <td alin="center" class="auto-style3">
                 <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Height="28px" OnClick="btnChangePassword_Click" />
            </td>
            <td class="auto-style2">
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel"  Height="28px" OnClick="btnCancel_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
             <td colspan="2">
                  <div id="error" runat="server" style="color:red">

                 </div>
             </td>
        </tr>

    </table>

</asp:Content>
