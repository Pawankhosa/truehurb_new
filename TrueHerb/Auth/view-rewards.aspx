<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-rewards.aspx.cs" Inherits="Auth_view_rewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Name</th>
                    <th>Pair</th>  
                     <th>Amount</th>
                    <th></th>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("rewardsname") %></td>
                        
                        <td>
                            <%#Eval("Pair") %></td>
                     <td>
                            <%#Eval("Amount") %></td>
                        <td>
                      <asp:LinkButton ID="lnkedit" CommandArgument='<%#Eval("id") %>' OnClick="lnkedit_Click" runat="server">Edit</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1"  CommandArgument='<%#Eval("id") %>' runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
                        </td>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

