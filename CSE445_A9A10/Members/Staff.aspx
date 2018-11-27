<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="CSE445_A9A10.Members.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Staff Page:<br />
            <asp:HyperLink ID="LinkMember" runat="server" NavigateUrl="~/Members/Members.aspx">Member Page</asp:HyperLink>
            <br />
            <br />
            <asp:Button ID="btn_ShowMembers" runat="server" OnClick="btn_ShowMembers_Click" Text="Show Members" />
            <br />
            <asp:Label ID="lbl_Members" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            First:
            <asp:TextBox ID="txt_AddFirst" runat="server"></asp:TextBox>
&nbsp;Last:
            <asp:TextBox ID="txt_AddLast" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btn_AddUser" runat="server" OnClick="btn_AddUser_Click" Text="AddUser" />
&nbsp;<asp:Button ID="btn_RemoveUser" runat="server" OnClick="btn_RemoveUser_Click" Text="Remove User" />
            <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            Return to Main Page: <asp:Button ID="btn_Main" runat="server" OnClick="btn_Main_Click" Text="Main Page" />
        </div>
    </form>
</body>
</html>
