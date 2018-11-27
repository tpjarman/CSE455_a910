<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445_A9A10.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 277px; width: 654px">
            Go to the login page, in order to change accounts, etc:<br />
            <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login Page" />
            <br />
            <br />
            Go to the member page to use the temperature conversion (RESTful) service from Project3:<br />
            <asp:Button ID="btn_Member" runat="server" OnClick="btn_Member_Click" Text="Member Page" />
            <br />
            <br />
            Go to the staff page, to view, add or remove users:<br />
            <asp:Button ID="btn_Staff" runat="server" OnClick="btn_Staff_Click" Text="Staff Page" />
            <br />
            <br />
            Log off and expire the login cookies:<br />
            <asp:Button ID="btn_Out" runat="server" OnClick="btn_Out_Click" Text="Log Off" />
            <br />
            <br />
            <asp:Label ID="lbl_Result" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="lbl_SessionCount" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
