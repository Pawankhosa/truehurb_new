<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Offers.aspx.cs" Inherits="Auth_Offers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
      <div class="col-md-8">



        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>pair </label>
            <asp:TextBox ID="txtpair" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Amount </label>
            <asp:TextBox ID="txtamount" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Percentage </label>
            <asp:TextBox ID="txtper" runat="server" class="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

