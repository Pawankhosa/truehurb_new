<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="memberlist.aspx.cs" Inherits="Auth_memberlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    <h3>Member List</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Date</th>
                    <th>Regno</th>
                    <th>Password</th>
                    <th>Name</th>
                    <th>Mobile</th>  
                     <th>Sponser</th>
                    
                    <th></th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>
                        <td>
                           <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                         <td>
                           <%#Eval("regno") %></td>
                        
                        <td>
                            <%#Eval("pass") %></td>
                        <td>
                           <%#Eval("fname") %></td>
                        
                        <td>
                            <%#Eval("mobile") %></td>
                     <td>
                            <%#Eval("spillsregno") %></td>
                        <td>
                            <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("regno") %>' OnClick="lnkedit_Click" runat="server">Click</asp:LinkButton>
                            <%--   <asp:LinkButton ID="LinkButton1"  CommandArgument='<%#Eval("id") %>' runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>--%>
                        </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

