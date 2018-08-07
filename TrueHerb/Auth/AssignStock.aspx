<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="AssignStock.aspx.cs" Inherits="Auth_AssignStock" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
          <h3>Assign Stock</h3>
    <hr />
    <div class="col-md-8">
          <div class="form-group">
            <label>User Name</label>
            <asp:TextBox ID="txtuser" runat="server" class="form-control" OnTextChanged="txtuser_TextChanged" AutoPostBack="true" ></asp:TextBox>
              <asp:Label ID="lbluser" runat="server" Text="Label"></asp:Label>
            

        </div>
        <div class="form-group">
            <label>Product Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control" ></asp:TextBox>
            <asp:Label ID="lblproduct" runat="server" Text="Label"  Visible="false"></asp:Label>
            <ajaxToolkit:AutoCompleteExtender ID="txtname_AutoCompleteExtender" runat="server" BehaviorID="txtname_AutoCompleteExtender" MinimumPrefixLength="2"  CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" ServiceMethod="SearchProduct" TargetControlID="txtname" FirstRowSelected="false">
            </ajaxToolkit:AutoCompleteExtender>

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

