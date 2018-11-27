<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="CSE445_A9A10.Members.Members" %>
<%@ Register TagPrefix="myControl" TagName="SiteCompareTool" Src="~/Members/SiteCompareUserTool.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Member Page:<br />
            <br />
            Simple Restful Service:<br />
            Temperature:
            <asp:TextBox ID="txtTemperature" runat="server"></asp:TextBox>
            <br />
            <asp:ListBox ID="lstConversions" runat="server">
                <asp:ListItem Value="0">F to C</asp:ListItem>
                <asp:ListItem Value="1">C to F</asp:ListItem>
                <asp:ListItem Value="2">C to K</asp:ListItem>
                <asp:ListItem Value="3">F to K</asp:ListItem>
            </asp:ListBox>
            <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="Convert" />
            <br />
            <asp:Label ID="lblConvertedTemp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <myControl:SiteCompareTool runat="server"></myControl:SiteCompareTool>
            <br />
            <br />
            Return to Main Page:
            <asp:Button ID="btn_Main" runat="server" OnClick="btn_Main_Click" Text="Main Page" />
            <br />
        </div>
    </form>
</body>
</html>
