<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Expiredpins.aspx.cs" Inherits="User_Expiredpins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
       <h3 class="text-white">Expired Pins</h3>
                            <ul class="breadcrumb mt-10">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                             
                                <li class="breadcrumb-item active">Expired Pins</li>
                            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">

  

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Pins</th>
                <th>Used For</th>
                <th>Name</th>
                <th>Dated</th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("pin") %></td>
                    <td> <%#Eval("subregno") %></td>
                    <td><%#Eval("lname") %></td>
                     <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

