<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Bubu_WebApp.Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <script src="../Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <link href="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script> 
     <script src="../Framework/JS/Login.js"></script>
     <script src="../Framework/JS/bubu.js"></script>
    <style>
        div {
            border-style: solid;
            border-color: #ff0000 #0000ff;
        }

        .nicecolor {
            color: red;
            width: 200px;
            height: 200px;
            
        }

            .nicecolor:hover {
                color: blue;
                background-color:gray;
            }
    </style>
    <script>

      
        $(function(){
            ShowMessage("asdssdfsdffsfsd", "sdfsdfsdfssfsdf", "");
        
        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-3 nicecolor" style="height: 200px; overflow: auto">
                        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum
                         has been the industry's standard dummy text ever since the 1500s, when an unknown printer
                         took a galley of type and scrambled it to make a type specimen book.
                        <%-- It has survived not only
                         five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.
                         It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, 
                        and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.--%>
                    </div>
                    <div class="col-3">
                        <br />
                        <br />
                        1-2<br />
                        <br />
                    </div>
                    <div class="col-3">
                        <br />
                        <br />
                        1-3<br />
                        <br />
                    </div>
                    <div class="col-3">
                        <br />
                        <br />
                        1-4<br />
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <div class="row">
                            <div class="col-12">2-1</div>
                            <div class="col-12">3-1</div>
                            <div class="col-12">4-1</div>

                        </div>

                    </div>

                    <div class="col-9">
                        <br />
                        <br />
                        <br />
                        <br />
                        2-2
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>

                </div>

            </div>

        </div>
    </form>
</body>
</html>
