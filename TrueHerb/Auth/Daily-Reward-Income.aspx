<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Daily-Reward-Income.aspx.cs" Inherits="Auth_Daily_Reward_Income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
   <h3>Daily Reward Income</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
   
    
    <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>Invoice</th>  
                     <th>Amount</th>
                 
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td>
                           <%#Eval("regno") %></td>
                        
                        <td>
                            <%#Eval("purchaseid") %></td>
                     <td>
                            <%#Eval("amount") %></td>
                       
                       


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
      Daily Total Income  : <asp:Label ID="lblincome" runat="server" Text="0"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success" Text="Distribute Reward" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

