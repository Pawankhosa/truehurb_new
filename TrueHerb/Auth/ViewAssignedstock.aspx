<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="ViewAssignedstock.aspx.cs" Inherits="Auth_ViewAssignedstock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Assigned List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <h3>Assigned Stock</h3>
    <hr />
   
    <asp:GridView ID="gvpins" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" >
        <Columns>

   
             <asp:BoundField DataField="name" HeaderText="Product Name" />
            <asp:BoundField DataField="code" HeaderText="Code" />
            <asp:BoundField DataField="fname" HeaderText="User Name" />
            <asp:BoundField DataField="regno" HeaderText="RegNo." />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Date" >
                <ItemTemplate>
            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
             <%--<asp:BoundField DataField="date" HeaderText="date" />--%>
           
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

