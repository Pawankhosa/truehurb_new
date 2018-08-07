<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="User_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
    <style>
        .Dash {
            padding: 20px;
            background: menu;
            margin:10px
        }
        .blue{    background: #3498db;
    color: white;}
        .yellow{ background:#ffc61d;
                 color:white;
        }
        .green{ background:#27ae60;color:white}
        .contact-info h5{
            color:white;
                font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12" style="margin-bottom: 20px">
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-inr"></i>
                </div>
                <div class="contact-info">
                    <h5>Income</h5>
                    <span>
                        <asp:Label ID="lblincome" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash yellow">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-anchor"></i>
                </div>
                <div class="contact-info">
                    <h5>Capping</h5>
                    <span>
                        <asp:Label ID="lblcapping" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-link"></i>
                </div>
                <div class="contact-info">
                    <h5>Pairing</h5>
                    <span>
                       L: <asp:Label ID="lblleft" runat="server" Text=""></asp:Label></span>
                    <span>
                       R: <asp:Label ID="lblright" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        
        <%--<div class="col-md-12">
            Welcome <%=name %>
        </div>--%>
        <%--<div class="col-md-12 ">
            <table style="width: 100%;" class="table table-bordered">
                <tr>
                    <td colspan="2">
                        <b>Member Details</b>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Registration Id</td>
                    <td><%=regno %></td>
                </tr>
                <tr>
                    <td class="auto-style1">First Name</td>
                    <td><%=name %></td>
                </tr>
                <tr>
                    <td class="auto-style1">S/o,W/o,D/o</td>
                    <td><%=father %>;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Joining Date</td>
                    <td><%=date %></td>
                </tr>
                <tr>
                    <td class="auto-style1">Address</td>
                    <td><%=address %></td>
                </tr>
                <tr>
                    <td class="auto-style1">Gender</td>
                    <td><%=gender %></td>
                </tr>
                <tr>
                    <td class="auto-style1">Mobileno.</td>
                    <td><%=phn %></td>
                </tr>
                <tr>
                    <td class="auto-style1">Marital Status</td>
                    <td><%=marital %></td>
                </tr>
            </table>
        </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

