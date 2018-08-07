<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="ManageSale.aspx.cs" Inherits="Auth_ManageSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Sale List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
        <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>Invoice</th>  
                     <th>Amount</th>
                    <th></th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("regno") %></td>
                        
                        <td>
                            <%#Eval("purchaseid") %></td>
                     <td>
                            <%#Eval("amount") %></td>
                        <td>
                      <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("purchaseid") %>' OnClick="lnkedit_Click" runat="server">Sale History</asp:LinkButton>
                           
                        </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

