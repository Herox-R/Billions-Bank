<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="mycredits.aspx.cs" Inherits="Billions_Bank.mycredits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div align="center">
        <div>
             <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">My Credits</h4>
        </div>
       
       <asp:GridView ID="gvMyCredits" runat="server" Height="16px" Width="903px" AutoGenerateColumns="false">
           <Columns>
               <asp:TemplateField HeaderText ="Sender AccountNumber">
                   <ItemTemplate>
                       <asp:Label ID="SenderAccountNumber" runat="server" Text='<%# Eval("SenderAccountNumber") %>'></asp:Label>
                   </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText ="Sender Name">
                   <ItemTemplate>
                       <asp:Label ID="SenderName" runat="server" Text='<%# Eval("SenderName") %>'></asp:Label>
                   </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText ="Transaction Date">
            <ItemTemplate>
              <asp:Label ID="TransactionDate" runat="server" Text='<%# Eval("TransactionDate") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" />
           </asp:TemplateField>
               <asp:TemplateField HeaderText ="Amount">
                <ItemTemplate>
                <asp:Label ID="Amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>
                <asp:TemplateField HeaderText ="Reference">
              <ItemTemplate>
           <asp:Label ID="Reference" runat="server" Text='<%# Eval("Reference") %>'></asp:Label>
        </ItemTemplate>
       <ItemStyle HorizontalAlign="Center" />
     </asp:TemplateField>

           </Columns>
       </asp:GridView>

    <div id="error" runat="server" style="color:red"></div>

</div>
</asp:Content>
