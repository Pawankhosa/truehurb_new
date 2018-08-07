<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="AvailablePins.aspx.cs" Inherits="User_AvailablePins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
    <h3 class="text-white">Available Pins</h3>
                            <ul class="breadcrumb mt-10">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                             
                                <li class="breadcrumb-item active">Available Pins</li>
                            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
   
    <div class="alert alert-success" role="alert">
        <strong>Total Pins:</strong> <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
    </div>

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Pins</th>
                <th>Date</th>
                <th>Amt</th>
                <th>Join</th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("pin") %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("datecreate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td> <%#Eval("pintype") %></td>
                    <td><asp:LinkButton ID="lnkjoin" runat="server" CommandArgument='<%#Eval("pin") %>' OnClick="lnkjoin_Click" CssClass="label label-primary">Join Now</asp:LinkButton></td>
                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

