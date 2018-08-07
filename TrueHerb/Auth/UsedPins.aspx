<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="UsedPins.aspx.cs" Inherits="Auth_UsedPins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Used Pins
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
                    <th></th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("total") %></td>
                        
                        <td>
                            <%#Eval("Regno") %></td>
                     
                        <td>
                      <%#Eval("fname") %>

                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("regno") %>' runat="server">Click to view list</asp:LinkButton>
                        </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

