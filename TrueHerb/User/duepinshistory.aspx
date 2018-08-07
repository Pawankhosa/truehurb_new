<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="duepinshistory.aspx.cs" Inherits="User_duepinshistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12 text-center">
        <p>Total Pins Received in August for clearing Dues: <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label> </p>
        <p>Total Pins used in August for clearing Dues: <asp:Label ID="lblpending" runat="server" Text="0"></asp:Label> </p>
        <p>Total Pins balance: <asp:Label ID="lblbal" runat="server" Text="0"></asp:Label></p>
    </div>
    <div class="col-md-12">
        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Pins</th>
                <th>UsedBy</th>
                <th>Dated</th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("pin") %></td>
                    <td> <%#Eval("subregno") %></td>
                     <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

