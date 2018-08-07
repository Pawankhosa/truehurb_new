<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Auth_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <style>
        .Dash {
            padding: 20px;
            background: menu;
            margin: 10px;
        }

        .blue {
            background: #3498db;
            color: white;
        }

        .yellow {
            background: #ffc61d;
            color: white;
        }

        .green {
            background: #27ae60;
            color: white;
        }

        .contact-info h5 {
            color: white;
            font-weight: bold;
        }
        .contact-box .contact-icon {
    display: table-cell;
    padding-right: 20px;
}
        .contact-box .contact-info {
    display: table-cell;
    vertical-align: top;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12" style="margin-bottom: 20px">
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-inr"></i>
                </div>
                <div class="contact-info">
                    <h5>Daily Reward Income</h5>
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
                    <span>L:
                        <asp:Label ID="lblleft" runat="server" Text=""></asp:Label></span>
                    <span>R:
                        <asp:Label ID="lblright" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

