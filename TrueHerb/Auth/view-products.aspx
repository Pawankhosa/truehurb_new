<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-products.aspx.cs" Inherits="Auth_view_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Product List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
      
        <h3>View Product</h3>
    <hr />
   
    <asp:GridView ID="gvpins" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>
<%--            <asp:BoundField DataField="month" HeaderText="Month" />--%>
   
            <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="code" HeaderText="Code" />
          
            <asp:BoundField DataField="dp" HeaderText="DP" />
             <asp:BoundField DataField="pv" HeaderText="PV" />
              <asp:TemplateField HeaderText="Image" >
                <ItemTemplate>
                   
                  <img src='../uploadimage/<%#Eval("image") %>' width="80" />
                </ItemTemplate>
                
              </asp:TemplateField>
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("id") %>' OnClick="lnkedit_Click" runat="server">Edit</asp:LinkButton>
                   <asp:LinkButton ID="LinkButton1"  CommandArgument='<%#Eval("id") %>' runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                   <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("code") %>' OnClick="LinkButton2_Click" runat="server">Enter Stock</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

