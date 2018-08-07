<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="installments.aspx.cs" Inherits="User_installments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
           <h3 class="text-white">INSTALLMENTS STATUS</h3>
                            <ul class="breadcrumb mt-10">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                             
                                <li class="breadcrumb-item active">INSTALLMENTS STATUS</li>
                            </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
     <div class="col-md-12 count">
        <div class="col-md-4">
            <strong>Total Installments</strong> : <asp:Label ID="lbltotal" runat="server" Text="16" CssClass="btn btn-primary "></asp:Label>
        </div>
        <div class="col-md-4">
            <strong>Paid Installments</strong> : <asp:Label ID="lblpaid" runat="server" Text="0" CssClass="btn btn-success"></asp:Label>
        </div>
        <div class="col-md-4">
            <strong>Pending Installments</strong> : <asp:Label ID="lblpending" runat="server" Text="0" CssClass="btn btn-danger"></asp:Label>
        </div>
        
    </div>
     <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Installment Detail</th>
                <th>Date</th>
                
              
            </tr>
        </thead>
        <asp:ListView ID="gvpins" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                   
                    <td><%# Container.DataItemIndex+1 %></td>
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    
              
            </ItemTemplate>
        </asp:ListView>
        </table>

        
   </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

