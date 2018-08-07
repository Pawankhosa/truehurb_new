<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Change-Password.aspx.cs" Inherits="User_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
 
    <div class="form-group col-sm-12">
                <label for="First Name">Old Password</label>
               
                <asp:TextBox ID="txtold"  class="form-control" placeholder="Old Password" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-12">
                <label for="First Name">New Password</label>
                <asp:TextBox ID="txtnew"   class="form-control"  placeholder="New Password" runat="server"></asp:TextBox>
                
            </div>
            <div class="form-group col-sm-12">
                <asp:Button ID="btnsubmit" CssClass="btn btn-default" runat="server" Text="Change Password" OnClick="btnsubmit_Click"/>
            </div>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

