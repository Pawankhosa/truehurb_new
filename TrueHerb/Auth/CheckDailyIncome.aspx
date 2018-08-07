<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="CheckDailyIncome.aspx.cs" Inherits="Auth_CheckDailyIncome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    <h4>Check Daily Income</h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
        <div class="form-group col-md-4">

            <asp:TextBox ID="txtregno" runat="server" class="form-control" placeholder="Enter Id"></asp:TextBox>


        </div>

        <div class="form-group">
            <asp:Button CssClass="btn-success btn" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-12">
        <asp:Label ID="lblname" runat="server" Text="Label">: </asp:Label><asp:Label ID="lblincome" CssClass="label label-danger" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

