<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Auth_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">


        <table id="example1" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th></th>
                    <th>Sr.No</th>
                    <th>Name</th>

                    <th>Amount</th>
                    <th>CHG</th>
                    <th>Net</th>
                    <th>Paid</th>
                    <th>To Pay</th>

                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="lnkclick" CommandArgument='<%#Eval("regno") %>' OnClick="lnkclick_Click" runat="server">Click</asp:LinkButton></td>
                        <td><%#Eval("regno") %>
                            <asp:HiddenField ID="hfleft" Value='<%#Eval("leftleg") %>' runat="server" />
                            <asp:HiddenField ID="hfright" runat="server" Value='<%#Eval("rightleg") %>' />
                            <asp:HiddenField ID="hfregno" runat="server" Value='<%#Eval("regno") %>' />
                        </td>

                        <td>
                            <%#Eval("fname") %> </td>


                        <td>
                            <asp:Label ID="lblamt" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblchg" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblnet" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblpaid" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbltopay" runat="server" Text="0"></asp:Label>
                        </td>



                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

