<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountActivate.aspx.cs" Inherits="Bubu_WebApp.Forms.AccountActivate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnGotoHome" runat="server" Visible="false" Text="Go To Home" OnClick="btnGotoHome_Click" />

        </div>
    </form>
    
</body>
</html>
