<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Managestock.aspx.cs" Inherits="Auth_Managestock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
      <h3>Product Detail</h3>
    <hr />
    <div class="col-md-8">
        <div class="form-group">
            <label>Product Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Stock</label>
            <asp:TextBox ID="txtqty" runat="server" class="form-control" placeholder="qty"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click"/>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

