<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Createpins.aspx.cs" Inherits="Auth_Createpins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Create Pins
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-8">
        <div class="form-group">
               <label>Select Pin Type</label>
            <asp:DropDownList ID="ddlpintype" runat="server" class="form-control">
                <asp:ListItem value="1950" Selected="True">1950</asp:ListItem>
                 <asp:ListItem value="750">750</asp:ListItem>
               
              <%--<asp:ListItem value="2000">2000</asp:ListItem>
              <asp:ListItem value="3000">3000</asp:ListItem>
              <asp:ListItem value="4000">4000</asp:ListItem>
              <asp:ListItem value="5000">5000</asp:ListItem>
              <asp:ListItem value="6000">6000</asp:ListItem>
              <asp:ListItem value="7000">7000</asp:ListItem>
              <asp:ListItem value="8000">8000</asp:ListItem>
              <asp:ListItem value="9000">9000</asp:ListItem>
              <asp:ListItem value="10000">10000</asp:ListItem>
              <asp:ListItem value="11000">11000</asp:ListItem>
              <asp:ListItem value="12000">12000</asp:ListItem>
              <asp:ListItem value="13000">13000</asp:ListItem>
              <asp:ListItem value="14000">14000</asp:ListItem>
              <asp:ListItem value="15000">15000</asp:ListItem>
              <asp:ListItem value="16000">16000</asp:ListItem>--%>
            </asp:DropDownList>
          </div>
        
        <div class="form-group">
                        <label>Select no. of pins to create</label>
              <asp:DropDownList ID="ddlpin" runat="server" class="form-control">
                 
                  <asp:ListItem value="1" selected="True">1</asp:ListItem>
            <asp:ListItem value="2">2</asp:ListItem>
            <asp:ListItem value="3">3</asp:ListItem>
            <asp:ListItem value="4">4</asp:ListItem>
            <asp:ListItem value="5">5</asp:ListItem>
            <asp:ListItem value="6">6</asp:ListItem>
            <asp:ListItem value="7">7</asp:ListItem>
            <asp:ListItem value="8">8</asp:ListItem>
            <asp:ListItem value="9">9</asp:ListItem>
            <asp:ListItem value="10">10</asp:ListItem>
            <asp:ListItem value="15">15</asp:ListItem>
            <asp:ListItem value="20">20</asp:ListItem>
            <asp:ListItem value="25">25</asp:ListItem>
            <asp:ListItem value="30">30</asp:ListItem>
            <asp:ListItem value="35">35</asp:ListItem>
            <asp:ListItem value="40">40</asp:ListItem>
            <asp:ListItem value="45">45</asp:ListItem>
            <asp:ListItem value="50">50</asp:ListItem>
            <asp:ListItem value="55">55</asp:ListItem>
            <asp:ListItem value="60">60</asp:ListItem>
            <asp:ListItem value="65">65</asp:ListItem>
            <asp:ListItem value="70">70</asp:ListItem>
            <asp:ListItem value="75">75</asp:ListItem>
            <asp:ListItem value="80">80</asp:ListItem>
            <asp:ListItem value="85">85</asp:ListItem>
            <asp:ListItem value="90">90</asp:ListItem>
            <asp:ListItem value="95">95</asp:ListItem>
            <asp:ListItem value="100">100</asp:ListItem>
              </asp:DropDownList>
          </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="form-group">
               <label> Enter Reg Id. to allot pins</label>
               <asp:TextBox ID="txtpin" AutoPostBack="true" OnTextChanged="txtpin_TextChanged" runat="server" class="form-control" ></asp:TextBox>
               <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
          </div>
          </ContentTemplate>
        </asp:UpdatePanel>
           
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />

        </div>
    </div>
    <div class="col-md-4">
                    <%=pins2 %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

