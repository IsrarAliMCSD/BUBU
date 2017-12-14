<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Bubu_WebApp.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/bubu.css" rel="stylesheet" />
    <link href="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <script src="Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script>
    <script src="Framework/JS/bubu.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-2">
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">
                    </div>

                    <div class="col-3   text-center pointer backgroundYellow" style="height: 200px;" onclick="Redirect('Login.aspx')">
                        <br />
                        <br />  <br />  <br />
                        Arbeitnehmer
                        <br />  <br />  <br />
                        <br />
                    </div>
                    <div class="col-2"></div>
                    <div class="col-3 text-center pointer  backgroundYellow" style="height: 200px;" onclick="Redirect('Login.aspx')">
                        <br />  <br />  <br />
                        <br />
                        Untemehmen<br />
                       <br />  <br />  <br />
                        <br />
                    </div>
                    <div class="col-2"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
