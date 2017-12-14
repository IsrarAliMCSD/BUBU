<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobDetail.aspx.cs" Inherits="Bubu_WebApp.Forms.JobDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <link href="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <link href="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <asp:Image ID="imgCompanyLogo" runat="server" class="widthHeight100" />
                </div>

                <div class="col-6">
                    <asp:Label ID="lblCompanyName" runat="server" Text="" CssClass="boldText"></asp:Label><br />
                    <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Sector: "></asp:Label>
                    <asp:Label ID="lblCompanySector" runat="server" Text="" CssClass="boldText"></asp:Label><br />
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblJobFunction" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Region: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblRegion" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Job Type: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblJobType" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Job Title: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblJobTitle" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Job Detail: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblJobDetail" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Qualification Category: "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblQualificationCategoty" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Label ID="Label9" runat="server" CssClass="boldText" Text="Qualification "></asp:Label>
                </div>
                <div class="col-6">
                    <asp:Label ID="lblQualificationName" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
