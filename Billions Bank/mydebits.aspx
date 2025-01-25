<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="mydebits.aspx.cs" Inherits="Billions_Bank.mydebits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div align="center">
            <div>
                 <h4 style="font-size: 24px; font-weight: bold; text-transform: uppercase;">My Debits</h4>
            </div>
           
           <asp:GridView ID="gvMyDebits" runat="server" Height="16px" Width="903px" AutoGenerateColumns="false">
               <Columns>
                   <asp:TemplateField HeaderText ="AccountNumber">
                       <ItemTemplate>
                           <asp:Label ID="accNum" runat="server" Text='<%# Eval("AccountNumber") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText ="Recipient Name">
                       <ItemTemplate>
                           <asp:Label ID="recipientName" runat="server" Text='<%# Eval("RecipientName") %>'></asp:Label>
                       </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText ="Amount">
                    <ItemTemplate>
                    <asp:Label ID="amount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText ="Transaction Date">
                   <ItemTemplate>
                   <asp:Label ID="transactionDate" runat="server" Text='<%# Eval("TransactionDate") %>'></asp:Label>
                   </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    <asp:TemplateField HeaderText ="Reference">
                  <ItemTemplate>
               <asp:Label ID="reference" runat="server" Text='<%# Eval("Reference") %>'></asp:Label>
            </ItemTemplate>
           <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>

               </Columns>
           </asp:GridView>

        <div id="error" runat="server" style="color:red"></div>

    </div>
</asp:Content>
