<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="UsedpinDate.aspx.cs" Inherits="Auth_UsedpinDate" %>

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
                    <th>Name</th>
                    <th>Id</th>  
                     <th>Date</th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("fname") %></td>
                        
                        <td>
                            <%#Eval("regno") %></td>
                     
                        <td>
                      <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

