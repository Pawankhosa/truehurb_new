<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="PurchaseReport.aspx.cs" Inherits="Auth_PurchaseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
           Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <h3>  Purchase Report</h3>
    <hr />
    <div class="col-md-12">
        <table id="example" class="table table-striped table-bordered" cellspacing="0" style="width: 100%;">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Date</th>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Dp</th>
                    <th>Pv</th>
                    <th>Seller</th>
                    <th>Buyer</th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>  <%#Eval("date") %>
                            <%--<asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>--%>
                        </td>

                        <td>
                            <%#Eval("name") %></td>
                        <td>
                            <%#Eval("qty") %></td>
                        <td>
                            <%#Eval("dp") %></td>
                        <td>
                            <%#Eval("pv") %></td>
                        <td>
                            <%#Eval("sellerregno") %></td>
                        <td>
                            <%#Eval("regno") %></td>
                </ItemTemplate>
            </asp:ListView>
        </table>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

