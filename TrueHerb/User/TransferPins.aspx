<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="TransferPins.aspx.cs" Inherits="User_TransferPins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
        Transfer Pins
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <div class="col-md-12">
        <div class="alert alert-danger" role="alert">
            <strong>Note: </strong><asp:Label ID="lblpins" runat="server" Text=""></asp:Label>
           Pins Has Been Transfer To 
            <asp:Label ID="lblto" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
        </asp:Panel>
    <div class="form-group col-sm-12">
                <label for="First Name">Enter Id*</label>
               
                <asp:TextBox ID="txtid"  class="form-control" OnTextChanged="txtid_TextChanged" AutoPostBack="true" placeholder="Sponserid" runat="server"></asp:TextBox>
                <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group col-sm-12">
                <label for="First Name">Enter Pins No.</label>
                <asp:TextBox ID="txtpins"   class="form-control"  placeholder="ProposerId" runat="server"></asp:TextBox>
                
            </div>
            <div class="form-group col-sm-12">
                <asp:Button ID="btnsubmit" CssClass="btn btn-default" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </div>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

