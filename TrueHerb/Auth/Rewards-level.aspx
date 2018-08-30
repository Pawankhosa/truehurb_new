<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Rewards-level.aspx.cs" Inherits="Auth_Rewards_level" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Pay Rewards Amount
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">

  <div class="form-group">
               <label> Enter Registration Id. </label>
               <asp:TextBox ID="txtregid" AutoPostBack="true" OnTextChanged="txtregid_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
               
          </div>
       <div class="col-md-12">
        <div class="col-md-3">
            Left Pair : <asp:Label ID="lblleft" runat="server" Text=""></asp:Label>
        </div>
        <div class="col-md-3">
            Right Pair : <asp:Label ID="lblright" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="col-md-12">

        <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Pair</th>
                    <th>Rewards</th> 
                    <th>Reward Income</th> 
                    <th>Sale</th> 
                    <th>Level</th>
                <%--    <th>Reward Level</th>--%>
                    
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %>
                        </td>

                        <td>
                            <asp:Label ID="lblpins" runat="server" Text='<%#Eval("pair") %>' Enabled="false"><%#Eval("pair") %></asp:Label></td>
                        <asp:HiddenField ID="hfid" Value='<%#Eval("id") %>' runat="server" />
                        <td>
                             <%#Eval("rewardsname") %></td>
                       <td>
                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>' CssClass="danger" ></asp:Label>
                             </td>
                      <td>
                            Rs.<asp:Label ID="lblsale" runat="server" Text='<%#Eval("sale") %>' CssClass="danger" ></asp:Label></td>
                         
                       <td>

                           <asp:LinkButton ID="lnklevel" runat="server" Enabled="false">Pending</asp:LinkButton>
                       </td>
                      <%--  <td>
                               
                             <asp:LinkButton ID="lnkreward"  CssClass="btn btn-danger" runat="server" >Reward Pending</asp:LinkButton>
                        </td>--%>
                       


                </ItemTemplate>
            </asp:ListView>
        </table>

    </div>
        <div class="col-md-12">
            <h4 style="margin-bottom: 20px;">Paid</h4>
            <table id="example2" class="table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Date</th>
                <th>Amount</th>
               <%-- <th>Balance</th>--%>
                <th>Mode</th>
              <%--  <th>Action</th>--%>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("date")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblamt" runat="server" Text='<%#Eval("Paid") %>'></asp:Label></td>
                   <%-- <td><asp:Label ID="lblbal" runat="server" Text='<%#Eval("Balance") %>'></asp:Label></td>--%>
                    <td><%#Eval("mode") %></td>
                    <%--<td>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CommandArgument='<%#Eval("id") %>' CssClass="label label-info">Edit</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click"  CommandArgument='<%#Eval("id") %>' CssClass="label label-danger" runat="server">Delete</asp:LinkButton>
                    </td>--%>
                    
                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
        <%--    <div class="col-md-12 text-center">
               <strong> Balance : <%=bal %> </strong>
            </div>--%>
        </div>
        <div class="col-md-12">
            <h4 >Pay</h4>
                <hr />
            <div class="form-group col-md-2">

                Amount<asp:TextBox ID="txtmnt" runat="server" class="form-control" placeholder="Amt. Paid "></asp:TextBox>
            </div>

         
            <div class="form-group col-md-2">
                Payment Mode 
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" >Cash</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                    <asp:ListItem>Pins</asp:ListItem>
                </asp:RadioButtonList>


                  <asp:TextBox ID="txtcheque" runat="server" class="form-control" Visible="false" placeholder="Cheque No."></asp:TextBox>
            </div>
        
            <div class="form-group col-md-2">
                <asp:Button CssClass="btn-primary btn" ID="btnpaid" runat="server"
                    Text="Pay Amount" OnClick="btnpaid_Click" />
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

