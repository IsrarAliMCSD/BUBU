<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Bubu_WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" Font-Size="Large" runat="server"
                Text="<%$Resources:Resource,Name%>"></asp:Label>
        </div>
    </form>

    <table width="90%" border="1">
        <thead>
            <tr>
                <th>SstoreID</th>
                <th>Store Name</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td></td>
                <td></td>
            </tr>

        </tbody>

    </table>
</body>
</html>
