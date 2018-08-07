<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Tree.aspx.cs" Inherits="User_Tree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" runat="Server">
    <link href="css/hierarchy-view.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <%-- <style>
        table {
	width:100%;
	text-align:left;
	font-size:13px !important;
}
table {
	font-size:13px !important;
	color:#222;
	font-weight:600;
}
th, td {
	padding:10px;
}
th {
	color:#fff;
	font-weight: bold;
	border-top:1px solid #222;
	background-color:#2F2F2F;
}
td {
	border:1px solid #222;

    </style>}--%>
    <h3 class="text-white">Tree</h3>
    <ul class="breadcrumb mt-10">
        <li class="breadcrumb-item"><a href="#">Home</a></li>

        <li class="breadcrumb-item active">Tree</li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
            <table width="700" class="client_table" style="display:none">
                <tr>
                    <td align="center" valign="top" colspan="5" class="client_home_hd" id="usertopbottom">Tree</td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <table width="500px">
                            <tr>
                                <td>ID</td>
                                <td>
                                    <asp:TextBox CssClass="textbox" ID="txtname" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtname" ErrorMessage="Enter ID" ValidationGroup="aa"></asp:RequiredFieldValidator></td>
                                <td>
                                    <%-- <asp:Button CssClass="lb-buttion" ID="Button1" runat="server" Text="SUBMIT" 
                  onclick="Button1_Click" ValidationGroup="aa" />--%>
                   
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tableborderform" align="center">
                        <table width="1000px" border="0" cellpadding="0" cellspacing="0" align="center">
                            <tr>
                                <td colspan="2" class="textstylecenter1" align="center">
                                    <asp:Label ID="Label23" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
                                <td width="0" class="textstylecenter1" align="center">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                                <td colspan="2" width="233" class="textstylecenter1" align="center">
                                    <asp:Label ID="Label25" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
                            </tr>
                            <tr valign="top" align="center">
                                <td width="140" class="textstylecenter1">&nbsp;</td>
                                <td width="140" class="textstylecenter1">&nbsp;</td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <br />


                                </td>
                                <td width="140" class="textstylecenter1">&nbsp;</td>
                                <td width="140" class="textstylecenter1">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="textstylecenter1" align="center">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                                <td align="center" class="textstylecenter1">&nbsp;</td>
                                <td colspan="2" class="textstylecenter1" align="center">
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                            </tr>
                            <tr valign="top" height="40">
                                <td colspan="2" class="textstylecenter1" align="center">
                                    <br />

                                    <asp:Label ID="Label17" runat="server" Font-Size="Small"></asp:Label>
                                    <br />

                                </td>
                                <td align="center" class="textstylecenter1">&nbsp;</td>
                                <td colspan="2" class="textstylecenter1" align="center">
                                    <br />

                                    <br />
                                    <asp:Label ID="Label18" runat="server" Font-Size="Small"></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="140" align="center" class="textstylecenter1">
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <asp:Image ID="Image12" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                                <td width="140" align="center" class="textstylecenter1">&nbsp;</td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <asp:Image ID="Image15" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <asp:Image ID="Image18" runat="server" ImageUrl="~/User/img/user_black.png" Width="50px" /></td>
                            </tr>

                            <tr valign="top">
                                <td width="140" align="center" class="textstylecenter1">

                                    <br />
                                    <asp:Label ID="Label19" runat="server" Font-Size="Small"></asp:Label></td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <br />

                                    <br />
                                    <asp:Label ID="Label20" runat="server" Font-Size="Small"></asp:Label></td>
                                <td width="140" align="center" class="textstylecenter1">&nbsp;</td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <br />

                                    <br />
                                    <asp:Label ID="Label21" runat="server" Font-Size="Small"></asp:Label></td>
                                <td width="140" align="center" class="textstylecenter1">
                                    <br />
                                    <asp:Label ID="Label22" runat="server" Font-Size="Small"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="20px"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="col-md-12">
            <div class="  col-md-3">
                <asp:TextBox ID="txtreg" runat="server" CssClass="form-control" placeholder="Enter Regno"></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <asp:Button ID="btnseacrh" runat="server" Text="Submit" OnClick="btnseacrh_Click" CssClass="btn btn-default" />
            </div>
        </div>
    </asp:Panel>
    <div class="col-md-12">
    <section class="management-hierarchy">
   
                <div class="hv-container">
                    <div class="hv-wrapper">

                        <!-- Key component -->
                        <div class="hv-item">

                            <div class="hv-item-parent">
                                <div class="person">
                                    <asp:Image ID="parentnode" runat="server" />
                                    <p class="name">
                                        <asp:Label ID="Label8" runat="server" Text="Label" Font-Bold="true"></asp:Label><br>
                                        <asp:LinkButton ID="lnkparent" runat="server" OnClick="lnkparent_Click"></asp:LinkButton><br />
                                        <asp:ListView ID="lvmain" runat="server">
                                            <ItemTemplate>
                                                L:<%#Eval("leftleg") %> | R:<%#Eval("rightleg") %><br />D:<%#Eval("leftdirect") %> | D: <%#Eval("rightdirect") %>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </p>
                                </div>
                            </div>

                            <div class="hv-item-children">

                                <div class="hv-item-child">
                                    <!-- Key component -->
                                    <div class="hv-item">

                                        <div class="hv-item-parent">
                                            <div class="person">
                                                <asp:Image ID="leftnode" runat="server" />
                                                <p class="name">
                                                    
                                                    <asp:LinkButton CssClass="my-table-td-center"
                                                        Font-Bold="true" Font-Size="Large" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                                                    <br /><asp:Label ID="Label10" runat="server" Font-Size="Small"></asp:Label>
                                                    <br />
                                                    <asp:ListView ID="leftone" runat="server">
                                                        <ItemTemplate>
                                                            L:<%#Eval("leftleg") %> | R:<%#Eval("rightleg") %><br />D:<%#Eval("leftdirect") %> | D: <%#Eval("rightdirect") %>
                                                        </ItemTemplate>
                                                    </asp:ListView>

                                                </p>
                                            </div>
                                        </div>

                                        <div class="hv-item-children">

                                            <div class="hv-item-child">
                                                <div class="person">
                                                    <asp:Image ID="leftnodeleft" runat="server" />
                                                    <p class="name">
                                                        <asp:LinkButton CssClass="brown"
                                                            Font-Bold="true" Font-Size="Large" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"></asp:LinkButton>
                                                        <br />
                                                        <asp:Label ID="Label12" runat="server" Font-Size="Small"></asp:Label><br />
                                                        <asp:ListView ID="lefttwo" runat="server">
                                                            <ItemTemplate>
                                                                L:<%#Eval("leftleg") %>| R:<%#Eval("rightleg") %><br />D:<%#Eval("leftdirect") %>| D: <%#Eval("rightdirect") %>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                    </p>
                                                </div>
                                            </div>


                                            <div class="hv-item-child">
                                                <div class="person">
                                                    <asp:Image ID="leftnoderight" runat="server" />
                                                    <p class="name">
                                                        <asp:LinkButton CssClass="brown"
                                                            Font-Bold="true" Font-Size="Large" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"></asp:LinkButton><br />
                                                        <asp:Label ID="Label13" runat="server" Font-Size="Small"></asp:Label><br />
                                                        <asp:ListView ID="leftthree" runat="server">
                                                            <ItemTemplate>
                                                                L:<%#Eval("leftleg") %>| R:<%#Eval("rightleg") %><br />D:<%#Eval("leftdirect") %>| D: <%#Eval("rightdirect") %>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                    </p>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>


                                <div class="hv-item-child">
                                    <!-- Key component -->
                                    <div class="hv-item">

                                        <div class="hv-item-parent">
                                            <div class="person">
                                                <asp:Image ID="rightnode" runat="server" />
                                                <p class="name">
                                                    <asp:LinkButton CssClass="my-table-td-center"
                                                        Font-Bold="true" Font-Size="Large" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"></asp:LinkButton><br />
                                                    <asp:Label ID="Label11" runat="server" Font-Size="Small"></asp:Label><br />
                                                     <asp:ListView ID="lvrightnode" runat="server">
                                                            <ItemTemplate>
                                                                L:<%#Eval("leftleg") %>| R:<%#Eval("rightleg") %><BR />D:<%#Eval("leftdirect") %>| D: <%#Eval("rightdirect") %>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                </p>
                                            </div>
                                        </div>

                                        <div class="hv-item-children">

                                            <div class="hv-item-child">
                                                <div class="person">
                                                    <asp:Image ID="rightleft" runat="server" />
                                                    <p class="name">
                                                        <asp:LinkButton CssClass="brown"
                                                            Font-Bold="true" Font-Size="Large" ID="LinkButton5" runat="server" OnClick="LinkButton5_Click"></asp:LinkButton><br />
                                                        <asp:Label ID="Label14" runat="server" Font-Size="Small"></asp:Label>
                                                        <asp:ListView ID="lvrightleft" runat="server">
                                                            <ItemTemplate>
                                                                L:<%#Eval("leftleg") %>| R:<%#Eval("rightleg") %><br />:<%#Eval("leftdirect") %>| D: <%#Eval("rightdirect") %>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                    </p>
                                                </div>
                                            </div>


                                            <div class="hv-item-child">
                                                <div class="person">
                                                    <asp:Image ID="rightright" runat="server" />
                                                    <p class="name">
                                                        <asp:LinkButton CssClass="brown"
                                                            Font-Bold="true" Font-Size="Large" ID="LinkButton6" runat="server" OnClick="LinkButton6_Click"></asp:LinkButton>
                                                        <br />
                                                        <asp:Label ID="Label15" runat="server" Font-Size="Small"></asp:Label><br />

                                                        <asp:ListView ID="lvrightright" runat="server">
                                                            <ItemTemplate>
                                                                L:<%#Eval("leftleg") %>| R:<%#Eval("rightleg") %><br />D:<%#Eval("leftdirect") %>| D: <%#Eval("rightdirect") %>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                    </p>
                                                </div>
                                            </div>

                                        </div>

                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>
                </div>
       
    </section>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

