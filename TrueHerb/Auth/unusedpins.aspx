<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="unusedpins.aspx.cs" Inherits="Auth_unusedpins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
       <div class="col-md-12">


         <table id="table1" class="table table-striped table-hover table-fw-widget">
                    <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pins</th>
                    <th>Amount</th>  
                     <th>Created on</th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("pin") %></td>
                        
                        <td>
                            <%#Eval("pintype") %></td>
                     
                        <td>
                      <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("datecreate")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>

           <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" Text="View Pin Transfer" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

