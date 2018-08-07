<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Tranferlogs.aspx.cs" Inherits="User_Tranferlogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
       <h3 class="text-white">Transfer Logs</h3>
                            <ul class="breadcrumb mt-10">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                             
                                <li class="breadcrumb-item active">Transfer Logs</li>
                            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">

  <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">Pins Received</h4>
  
        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Pins</th>
                <th>RegNo</th>
                <th>Name</th>
                <th>Date</th>
              
            </tr>
        </thead>
            <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("pin") %></td>
                    <td> <%#Eval("oldregno") %></td>
                    <td><%#Eval("fname") %></td>
                     <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
    
  <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">Pins Sent</h4>
      
        <table id="example2" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Pins</th>
                <th>RegNo</th>
                <th>Name</th>
                <th>Date</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <tr>
                   <td><%# Container.DataItemIndex+1 %></td>
                    <td><%#Eval("pin") %></td>
                    <td> <%#Eval("newregno") %></td>
                    <td><%#Eval("fname") %></td>
                     <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>


