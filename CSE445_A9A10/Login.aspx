<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CSE445_A9A10._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CSE445-A9</h1>
        <p class="lead">Login Page</p>
    </div>

    <div class="row">
        Username:
        <asp:TextBox ID="txt_loginUser" runat="server"></asp:TextBox>
        <br __designer:mapid="12" />Password:&nbsp;
        <asp:TextBox ID="txt_loginPass" runat="server"></asp:TextBox>
        <br __designer:mapid="14" />
        <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login" />
        <asp:Label ID="lbl_result" runat="server" Text="Label"></asp:Label>
        <br />
        <br __designer:mapid="17" />
        <br __designer:mapid="18" />Register User Account:<br __designer:mapid="19" />First Name:
        <asp:TextBox ID="txt_regFirst" runat="server"></asp:TextBox>
        <br __designer:mapid="1b" />Last Name:
        <asp:TextBox ID="txt_regLast" runat="server"></asp:TextBox>
        <br __designer:mapid="1d" />Username:&nbsp;
        <asp:TextBox ID="txt_regUser" runat="server"></asp:TextBox>
        <br __designer:mapid="1f" />Password:&nbsp;&nbsp;
        <asp:TextBox ID="txt_regPass" runat="server"></asp:TextBox>
        <br __designer:mapid="21" />
        <asp:Button ID="btn_Register" runat="server" OnClick="btn_Register_Click" Text="Register" />
        <asp:Label ID="lbl_result2" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
