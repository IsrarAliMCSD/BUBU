<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bubu_WebApp.Forms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--   <link href="../Style/bubu.css" rel="stylesheet" />
    <link href="../Style/Login.css" rel="stylesheet" />--%>
    <link href="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <script src="../Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="../Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <%--  <script src="../Framework/JS/Login.js"></script>--%>
    <script src="../Framework/JS/bubu.js"></script>
    <script>
        function ShowMessage(Messagetext, Title, Image) {


            $("<div> sdfsdfdfdgdg</div>").dialog({

                title: Title.toUpperCase(),
                modal: true,
                overflow: "hidden",
                resizable: false,
                closeOnEscape: false,
                show: 'slide',
                buttons: {
                    "Close": function () {

                        $(this).dialog("close");
                    }

                }

            });

        }
        $(function () {
            ShowMessage("asdfsfsd", "sdfsfsdf", "");

        })
    </script>

</head>
<body>

    <hgroup>
        <h1>Abcd WebSite</h1>
    </hgroup>

    <form id="form1" runat="server">
        <div id="divLogin" runat="server">

            <h3>Sing In</h3>


            <%--<asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>--%>
            <div class="group">
                <asp:TextBox ID="txtEmailLogin" runat="server" MaxLength="50" CssClass="input"></asp:TextBox>
                <span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="validation"
                    ErrorMessage="Please enter email address" ControlToValidate="txtEmailLogin" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="login" CssClass="validation" Display="Dynamic" ControlToValidate="txtEmailLogin" ErrorMessage="Please enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <label class="label">Email</label>
            </div>
            <div class="group">
                <%-- <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>--%>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="25" CssClass="input"></asp:TextBox>
                <span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="validation"
                    ErrorMessage="Please enter password" ControlToValidate="txtPassword" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>

                <label class="label">Password</label>
            </div>
            <div>
                <asp:CheckBox ID="chbRememberPassword" runat="server" Text="Remember Password" />
            </div>
            <asp:Button ID="btnLogin" runat="server" ValidationGroup="login" Text="Login" CssClass="button buttonBlue" OnClick="btnLogin_Click" />

            <asp:Button ID="btnRegistration" runat="server" Text="Registration" CssClass="button buttonBlue" OnClick="btnRegistration_Click" />
            <asp:LinkButton ID="lbtnforgotPassword" runat="server" OnClick="lbtnforgotPassword_Click">Forgot Password</asp:LinkButton>
        </div>
        <div id="divSignUp" runat="server" visible="false">
            <hgroup>
                <h1>Abcd WebSite</h1>
                <h3>Sing Up</h3>
            </hgroup>

            <div class="group">
                <asp:TextBox ID="txtEmailSignUp" runat="server" MaxLength="50" CssClass="input"></asp:TextBox>
                <span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation"
                    ErrorMessage="Please enter email address " ControlToValidate="txtEmailSignUp" ValidationGroup="SignUp" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="SignUp" CssClass="validation" Display="Dynamic" ControlToValidate="txtEmailSignUp" ErrorMessage="Please enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                <label class="label">Email Address</label>
            </div>

            <div class="group">
                <asp:TextBox ID="txtPasswordSignUp" runat="server" MaxLength="50" CssClass="input"></asp:TextBox><span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validation"
                    ErrorMessage="Please enter password" ControlToValidate="txtPasswordSignUp" ValidationGroup="SignUp" Display="Dynamic"></asp:RequiredFieldValidator>

                <label class="label">Password</label>
            </div>

            <div class="group">
                <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="50" CssClass="input"></asp:TextBox><span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validation"
                    ErrorMessage="Please enter confirm password" ControlToValidate="txtConfirmPassword" ValidationGroup="SignUp" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ValidationGroup="SignUp" Display="Dynamic"
                    CssClass="validation" ControlToCompare="txtPasswordSignUp" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                <label class="label">Confirm Password</label>
            </div>
            <div class="group">
                <asp:DropDownList ID="ddlAccountType" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="btnSignUp" runat="server" ValidationGroup="SignUp" Text="Sign Up" CssClass="button buttonBlue" OnClick="btnSignUp_Click" />

            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button buttonBlue" OnClick="btnCancel_Click" />

        </div>
        <div id="divforgotPassword" runat="server" visible="false">
            <div class="group">
                <asp:TextBox ID="txtEmailForgotPassword" runat="server" MaxLength="50" CssClass="input"></asp:TextBox>
                <span class="highlight"></span><span class="bar"></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validation"
                    ErrorMessage="Please enter email address " ControlToValidate="txtEmailForgotPassword" ValidationGroup="forgotPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="forgotPassword" CssClass="validation" Display="Dynamic" ControlToValidate="txtEmailForgotPassword" ErrorMessage="Please enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                <label class="label">Email Address</label>
            </div>
            <asp:Button ID="btnfoorgotPassword" runat="server" ValidationGroup="forgotPassword" Text="Reset Password" CssClass="button buttonBlue" OnClick="btnfoorgotPassword_Click" />

            <asp:Button ID="btnCancelforgotpassword" runat="server" Text="Cancel" CssClass="button buttonBlue" OnClick="btnCancelforgotpassword_Click" />
        </div>


    </form>

</body>

</html>

