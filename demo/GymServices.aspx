<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GymServices.aspx.cs" Inherits="Sarah10415WebApp.demo.myDdlCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    

    <br /> 
        <asp:Label ID="LblOutput" runat="server" Text=""></asp:Label> <br /> <br />
        Enter your Id
        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>  <br /> <br />
        please select your Membership :  <br /> 
        <asp:RadioButtonList ID="rblMembership" runat="server"></asp:RadioButtonList>
       <br /><br />
        please select your services  :<br /> 
        <asp:CheckBoxList ID="cblGymServices" runat="server">  </asp:CheckBoxList> <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit " OnClick="btnSubmit_Click" />
       
    <br /> <hr />

</asp:Content>
