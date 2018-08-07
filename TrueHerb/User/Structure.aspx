<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Structure.aspx.cs" Inherits="User_Structure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
   
     <div class="col-md-12">


        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Regno</th>
                    <th>AddInst</th>
                     <th>Name</th>
                    <th>joining</th>
                    <th>installments</th>
                    <th>LastPaid</th>
                </tr>
            </thead>
            <asp:ListView ID="gvpins" runat="server" OnItemDataBound="gvpins_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItemIndex+1 %></td>

                        <td><%#Eval("regno") %></td>
                        <td>
                            <asp:TextBox ID="txtpaid" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                        <td><%#Eval("fname") %></td>
                        <td>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("joined")).ToString("dd/MM/yyyy") %>'></asp:Label>

                        </td>
                        <td>
                            <asp:HiddenField ID="hfid" Value='<%#Eval("regno") %>' runat="server" />
                            <asp:Label ID="lbltotalinst" runat="server" Text="Label"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbllastpaid" runat="server" Text="Label"></asp:Label>
                            
                        </td>


                </ItemTemplate>
            </asp:ListView>
        </table>


    </div>

     <div class="col-md-12">
          
           
          <div class="form-group col-md-3">
                   <asp:Button CssClass="btn-default btn" ID="btnpay" runat="server" 
                       Text="Pay Now" onclick="btnpay_Click"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

