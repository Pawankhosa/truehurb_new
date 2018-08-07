<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Auth_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    <h3>Profile</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
            
             <h4 class="mb-30">Personal Details</h4>
         <div class="form-group col-sm-4">
                <label for="First Name">Joined Date *</label>
               
                <asp:TextBox ID="txtdate" class="form-control" placeholder="Date" runat="server"></asp:TextBox>
            </div>
              <div class="form-group col-sm-4">
                <label for="First Name">Applicant Name *</label>
               
                <asp:TextBox ID="txtname" class="form-control" placeholder="Applicant Name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
               
              <label for="First Name">Relation</label>
                <asp:TextBox ID="txtrel" class="form-control" placeholder="Relation" runat="server"></asp:TextBox>
            </div>
        <div class="row">
            <div class="form-group col-sm-6">
                <div class="row">
                    <label class="col-sm-12" for="phone">Your birthday *</label>
                    <div class="form-group col-sm-4">
                        <div class="selected-box auto-hight">
                            <asp:DropDownList ID="ddlday" runat="server" class="form-control">

                                <asp:ListItem Value="Day">Day</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                                <asp:ListItem Value="13">13</asp:ListItem>
                                <asp:ListItem Value="14">14</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="16">16</asp:ListItem>
                                <asp:ListItem Value="17">17</asp:ListItem>
                                <asp:ListItem Value="18">18</asp:ListItem>
                                <asp:ListItem Value="19">19</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="21">21</asp:ListItem>
                                <asp:ListItem Value="22">22</asp:ListItem>
                                <asp:ListItem Value="23">23</asp:ListItem>
                                <asp:ListItem Value="24">24</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="26">26</asp:ListItem>
                                <asp:ListItem Value="27">27</asp:ListItem>
                                <asp:ListItem Value="28">28</asp:ListItem>
                                <asp:ListItem Value="29">29</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="31">31</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group col-sm-4">
                        <div class="selected-box auto-hight">
                            <asp:DropDownList ID="ddlmonth" runat="server" class="form-control">
                                <asp:ListItem Value="Month">Month</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group col-sm-4">
                        <div class="selected-box auto-hight">
                            <asp:DropDownList ID="ddlyear" runat="server" class="form-control">
                                <asp:ListItem Value="Year">Year</asp:ListItem>
                                <asp:ListItem Value="1990">1990</asp:ListItem>
                                <asp:ListItem Value="1991">1991</asp:ListItem>
                                <asp:ListItem Value="1992">1992</asp:ListItem>
                                <asp:ListItem Value="1993">1993</asp:ListItem>
                                <asp:ListItem Value="1994">1994</asp:ListItem>
                                <asp:ListItem Value="1995">1995</asp:ListItem>
                                <asp:ListItem Value="1996">1996</asp:ListItem>
                                <asp:ListItem Value="1997">1997</asp:ListItem>
                                <asp:ListItem Value="1998">1998</asp:ListItem>
                                <asp:ListItem Value="1999">1999</asp:ListItem>
                                <asp:ListItem Value="2001">2001</asp:ListItem>
                                <asp:ListItem Value="2002">2002</asp:ListItem>
                                <asp:ListItem Value="2003">2003</asp:ListItem>
                                <asp:ListItem Value="2004">2004</asp:ListItem>
                                <asp:ListItem Value="2005">2005</asp:ListItem>
                                <asp:ListItem Value="2006">2006</asp:ListItem>
                                <asp:ListItem Value="2007">2007</asp:ListItem>
                                <asp:ListItem Value="2008">2008</asp:ListItem>
                                <asp:ListItem Value="2009">2009</asp:ListItem>
                                <asp:ListItem Value="2010">2010</asp:ListItem>
                                <asp:ListItem Value="2011">2011</asp:ListItem>
                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                <asp:ListItem Value="2014">2014</asp:ListItem>
                                <asp:ListItem Value="2015">2015</asp:ListItem>
                                <asp:ListItem Value="2016">2016</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group col-sm-6">
                <label for="First Name">Phone *</label>
               
                <asp:TextBox ID="txtphn" class="form-control" placeholder="Phone" runat="server"></asp:TextBox>
            </div>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">Country *</label>
               
                <asp:TextBox ID="txtcountry" class="form-control" Text="India" placeholder="Country" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">State *</label>
               
                <asp:TextBox ID="txtstate" class="form-control"  placeholder="State" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">City *</label>
               
                <asp:TextBox ID="txtcity" class="form-control"  placeholder="City" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-12">
                <label for="First Name">Address *</label>
               
                <asp:TextBox ID="txtadd"  class="form-control" placeholder="Address" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">PinCode *</label>
               
                <asp:TextBox ID="txtpincode" class="form-control" Text="India" placeholder="Country" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">Aadhar Card No *</label>
               
                <asp:TextBox ID="txtaadhar" class="form-control"  placeholder="Aadhar Card" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">PAN Card No *</label>
               
                <asp:TextBox ID="txtpan" class="form-control"  placeholder="Pan Card" runat="server"></asp:TextBox>
            </div>
            <%--Bank Details--%>
              <h4 class="mb-30 col-md-12">Bank Details</h4>
            <div class="form-group col-sm-4">
                <label for="First Name">Bank Account No *</label>
               
                <asp:TextBox ID="txtbankno" class="form-control" placeholder="Bank Account No" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">Bank Name *</label>
               
                <asp:TextBox ID="txtbankname" class="form-control"  placeholder="Bank Name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-4">
                <label for="First Name">IFSC Code *</label>
               
                <asp:TextBox ID="txtifsc" class="form-control"  placeholder="IFSC Code" runat="server"></asp:TextBox>
            </div>
             <%--Nominee Details--%>
           
             <h4 class="mb-30 col-md-12">NOMINEE Details</h4>
            <div class="form-group col-sm-6">
                <label for="First Name">Nominee Name *</label>
               
                <asp:TextBox ID="txtnominee" class="form-control"  placeholder="Nominee Name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-6">
                <label for="First Name">Relation *</label>

                <asp:DropDownList ID="ddlrelation" runat="server" class="form-control">

                    <asp:ListItem Value="" Selected="True">Select Nominee Relation</asp:ListItem>
                    <asp:ListItem Value="Husband">Husband</asp:ListItem>
                    <asp:ListItem Value="Wife">Wife</asp:ListItem>
                    <asp:ListItem Value="Mother">Mother</asp:ListItem>
                    <asp:ListItem Value="Father">Father</asp:ListItem>
                    <asp:ListItem Value="Brother">Brother</asp:ListItem>
                    <asp:ListItem Value="Sister">Sister</asp:ListItem>
                    <asp:ListItem Value="Son">Son</asp:ListItem>
                    <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                    <asp:ListItem Value="Mother-in-Law">Mother-in-Law</asp:ListItem>
                    <asp:ListItem Value="Father-in-Law">Father-in-Law</asp:ListItem>
                    <asp:ListItem Value="Grandson">Grand Son</asp:ListItem>
                    <asp:ListItem Value="Granddaughter">Grand Daughter</asp:ListItem>
                    <asp:ListItem Value="Daughter-in-Law">Daughter-in-Law</asp:ListItem>
                    <asp:ListItem Value="Son-in-Law">Son-in-Law</asp:ListItem>
                    <asp:ListItem Value="Nephew">Nephew</asp:ListItem>
                    <asp:ListItem Value="Friend">Friend</asp:ListItem>
                </asp:DropDownList>
            </div>
           <div class="form-group col-sm-6">
                <label for="First Name">User Id</label>
               
                <asp:TextBox ID="txtid" class="form-control"  placeholder="User" runat="server"></asp:TextBox>
            </div>
        <div class="form-group col-sm-6">
                <label for="First Name">Password</label>
               
                <asp:TextBox ID="txtpassword" class="form-control"  placeholder="Nominee Name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-sm-12">
                <asp:Button ID="btnjoin" class="btn btn-default" OnClick="btnjoin_Click"  runat="server" Text="Join Now" />
                </div>
        </div>
    
    <%--<table style="width: 100%;">
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="txtregid" runat="server" class="form-control"></asp:TextBox>
            </td>
          
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
    
        </tr>
        <tr>
            <td>Nominee's Name</td>
            <td><asp:TextBox ID="txtnomi" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Nominee's Address</td>
            <td><asp:TextBox ID="txtnomiadd" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Relation with Applicant</td>
            <td><asp:TextBox ID="txtrelation" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Gender</td>
            <td><asp:TextBox ID="txtgender" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td> Marital Status</td>
            <td><asp:TextBox ID="txtmarital" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Nominee's Name</td>
            <td><asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Nominee's Name</td>
            <td><asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
        <tr>
            <td>Nominee's Name</td>
            <td><asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox></td>
         
        </tr>
    </table>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

