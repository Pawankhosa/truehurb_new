﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="Auth_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Product
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-8">



        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <%--<div class="form-group">
            <label>Product code</label>
                <asp:TextBox ID="txtcode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>--%>

        <div class="form-group">
            <label>DP </label>
            <asp:TextBox ID="txtdp" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Pv </label>
            <asp:TextBox ID="txtpv" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label>Upload Image</label>
            <asp:FileUpload ID="sliderimage" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server"
                Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
    <div class="col-md-4">
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

