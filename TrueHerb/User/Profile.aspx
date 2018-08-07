<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="User_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
    <h3 class="text-white">Profile</h3>
    <ul class="breadcrumb mt-10">
        <li class="breadcrumb-item"><a href="#">Home</a></li>

        <li class="breadcrumb-item active">Profile</li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-8 col-md-offset-2">
        <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td>Sponser Id:</td>
                <td>
                    <asp:Label ID="lblspon" runat="server" Text=""></asp:Label></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>RegId</td>
                <td>
                    <asp:Label ID="lblreg" runat="server" Text="Label"></asp:Label></td>
                <td>Pan</td>
                <td>
                    <asp:Label ID="lblpan" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
                <td>Of</td>
                <td>
                    <asp:Label ID="lblfather" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:Label ID="lblads" runat="server" Text=""></asp:Label></td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:Label ID="lblcity" runat="server" Text=""></asp:Label></td>
                <td>PIN</td>
                <td>
                    <asp:Label ID="lblpin" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>State</td>
                <td>
                    <asp:Label ID="lblstate" runat="server" Text=""></asp:Label></td>
                <td>Country</td>
                <td>
                    <asp:Label ID="lblcountry" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Phone(Office)</td>
                <td>
                    <asp:Label ID="lblphone" runat="server" Text=""></asp:Label></td>
                <td>Phone(Resi)</td>
                <td>
                    <asp:Label ID="lblphpone2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Mobile</td>
                <td>
                    <asp:Label ID="lblmon" runat="server" Text=""></asp:Label></td>
                <td>Email</td>
                <td>
                    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Bank Account</td>
                <td>
                    <asp:Label ID="lblbankac" runat="server" Text=""></asp:Label></td>
                <td>Bank Name</td>
                <td>
                    <asp:Label ID="lblbank" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Nominee</td>
                <td>
                    <asp:Label ID="lblnomiee" runat="server" Text=""></asp:Label></td>
                <td>Relation</td>
                <td>
                    <asp:Label ID="lblrelation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Nomiee Address</td>
                <td>
                    <asp:Label ID="lblnomads" runat="server" Text=""></asp:Label></td>
                <td>Nominee Phone</td>
                <td>
                    <asp:Label ID="lblnomieephone" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

