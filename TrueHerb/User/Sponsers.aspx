<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Sponsers.aspx.cs" Inherits="User_Sponsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
       <h3 class="text-white">Sponsers</h3>
                            <ul class="breadcrumb mt-10">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                             
                                <li class="breadcrumb-item active">Sponsers</li>
                            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">

  <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">SPONSORED IN LEFT</h4>

        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Reg.Id</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Date</th>
                <th>Installments</th>
              
            </tr>
        </thead>
        <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                   
                    <td><%#Eval("regno") %></td>
                    <td><%#Eval("fname") %></td>
                    <td><%#Eval("mobile") %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <asp:LinkButton ID="lnkleft" CommandArgument='<%#Eval("regno") %>' OnClick="lnkleft_Click" runat="server">Installments</asp:LinkButton></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>
    
  <div class="col-md-12">
      <h4 style="margin-bottom: 20px;">SPONSORED IN RIGHT</h4>
      
        <table id="example2" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Reg.Id</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Date</th>
                <th>Installments</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><%#Eval("regno") %></td>
                    <td><%#Eval("fname") %></td>
                    <td><%#Eval("mobile") %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>

                    <td>
                       <asp:LinkButton ID="lnkright" CommandArgument='<%#Eval("regno") %>' OnClick="lnkright_Click" runat="server">Installments</asp:LinkButton></td>

                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        
   </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

