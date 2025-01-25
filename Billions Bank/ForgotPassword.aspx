<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Billions_Bank.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 160px;
            height: 40px;
        }
        .auto-style3 {
            height: 40px;
            width: 208px;
        }
        .auto-style4 {
            height: 21px;
        }
        .auto-style5 {
            width: 208px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center" >
          <tr>
               <td colspan="2" align="centre" class="auto-style4">
                  <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">FORGOT PASSWORD</h4>
              </td>  
          </tr>          
          <tr>
                 <td style="width:160px;">
                     <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>                    
                 </td>
                 <td class="auto-style5">
                     <asp:Label ID="lblUsername" runat="server"></asp:Label>
                 </td>
          </tr>
          <tr>
                  <td class="auto-style2">
                      <asp:Label ID="Label2" runat="server" Text="Security"></asp:Label>
                  </td>
                  <td class="auto-style3">
                      <asp:Label ID="lblSecurityQuestion" runat="server"></asp:Label>
                  </td>
          </tr>
         <tr>
             <td style="width:160px;">
                 <asp:Label ID="Label3" runat="server" Text="Answer"></asp:Label>
                 <asp:HiddenField ID="hdnAnswer" runat="server" />
             </td>
             <td class="auto-style5">
                  <asp:TextBox ID="txtAnswer" runat="server" Height="25px" Width="192px"  ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" 
                  ControlToValidate="txtAnswer" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
             </td>

         </tr> 
        <tr>
            <td align="center">
               <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" Height="28px" OnClick="btnForgotPassword_Click" />
           </td>
           <td class="auto-style5">
              <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false" />
          </td>
     </tr>
     <tr>
         <td colspan="2">
              <div id="error" runat="server" sytle="color:red">
       
             </div>
       </td>
</tr>


    </table>

</asp:Content>
