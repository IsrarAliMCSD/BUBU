<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSignUp.aspx.cs" Inherits="Bubu_WebApp.EmployeeSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style/bubu.css" rel="stylesheet" />

    <script src="Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <link href="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <script src="Framework/JS/bubu.js"></script>
    <link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script>
    <link href="Style/bubu.css" rel="stylesheet" />
    <%--    <script src="Framework/JS/Login.js"></script>--%>

    <script>

        $(document).ready(function () {
            DatePicker(".calendar");
            $(".divemployeement").show(10);
            $("input[type='radio']").click(function () {
                if ($(this).attr("value") == "rbtnUnEmployeed") {
                    $(".divemployeement").hide(500);
                }
                else {
                    $(".divemployeement").show(500);
                }
                //alert('s');
            });
            $("#chbfIsCompleted").change(function () {
                if ($("#chbfIsCompleted").is(':checked')) {
                    $("#txtfYearCompleted").removeAttr("disabled");
                }
                else {
                    $("#txtfYearCompleted").attr("disabled", "disabled");

                }

            });
        });
        function PersonalInformationCall() {
            var returnResult = true;

            if ($("#rbtnemployeed").is(':checked')) {
                var EmpUmEmpEventControl = $(".EmpUmEmpEvent");

                for (var item = 0; item < EmpUmEmpEventControl.length; item++) {
                    if ($(EmpUmEmpEventControl[item]).val() == undefined || $(EmpUmEmpEventControl[item]).val() == "" || $(EmpUmEmpEventControl[item]).val().trim() == "") {
                        $(EmpUmEmpEventControl[item]).next("span").removeClass("hide");
                        returnResult = false;
                    }
                    else {
                        $(EmpUmEmpEventControl[item]).next("span").attr('class', 'hide');
                    }
                }
            }
            if (returnResult) {
                var flag = Page_ClientValidate('VPersonalInformation');
                if (flag) {
                    returnResult = true;
                }
                else {
                    returnResult = false;
                }
            }
            return returnResult;
        }

    </script>
    <style>
        body {
            font-family: Helvetica;
            background: #eee;
            -webkit-font-smoothing: antialiased;
        }

        h1, h3 {
            font-weight: 300;
        }

        .backgroundwhite {
            background: #FFFFFF;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <center><h1>Sign In </h1> </center>
        <br />
        <div class="backgroundwhite">
            <div class="container">
                <div class="container">
                    <div class="row">
                        <%--<div class="col-12 ">

                <asp:Label ID="lblhBasicinformation" runat="server" CssClass="mainHeading" Text="Basic Information"></asp:Label>

            </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label1" runat="server" Text="User Name:" CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" CssClass="validation"
                                ErrorMessage="Please enter UserName" ControlToValidate="txtUserName" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label3" runat="server" Text="Password:" CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textBox" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation"
                                ErrorMessage="Please enter Password" ControlToValidate="txtPassword" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label2" runat="server" Text="First Name:" CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"
                                Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" CssClass="validation"
                                ErrorMessage="Please enter first name" ControlToValidate="txtFirstName" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label4" runat="server" Text="Brith Date: " CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="textBox calendar" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" CssClass="validation"
                                ErrorMessage="Please enter Date of birth" ControlToValidate="txtBirthDate" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label7" runat="server" Text="Email: " CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="validation"
                                ErrorMessage="Please enter email address" ControlToValidate="txtEmail" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="VPersonalInformation" CssClass="validation"
                                Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email address"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label6" runat="server" Text="Telefon: " CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" CssClass="validation"
                                ErrorMessage="Please enter contact number" ControlToValidate="txtContactNo" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-3 ">
                            <asp:Label ID="Label8" runat="server" Text="Career/ Profession: " CssClass="boldText"></asp:Label>
                        </div>
                        <div class="col-3 ">
                            <asp:RadioButton ID="rbtnUnEmployeed" runat="server" ClientIDMode="Static"
                                GroupName="employmentStatus" Enabled="true" Text="UnEmployeed " />
                        </div>

                        <div class="col-3 ">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-3 ">
                        </div>
                        <div class="col-3 ">
                            <asp:RadioButton ID="rbtnemployeed" ClientIDMode="Static" runat="server"
                                GroupName="employmentStatus" Checked="true" Enabled="true" Text="Employeed " />
                        </div>

                        <div class="col-6 divemployeement" runat="server" id="divemployeement">

                            <asp:Label ID="Label9" runat="server" Text="Company" CssClass="boldText"></asp:Label><br />
                            <asp:TextBox ID="txtCompany" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                            <span id="spanCompany" class="validation hide">Please enter company</span>

                            <br />
                            <asp:Label ID="Label10" runat="server" Text="Position" CssClass="boldText"></asp:Label><br />
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                            <span id="spanPosition" class="validation hide">Please enter position </span>

                            <br />
                            <asp:Label ID="Label11" runat="server" Text="Function" CssClass="boldText"></asp:Label><br />
                            <asp:TextBox ID="txtFunction" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                            <span id="spanFunction" class="validation hide">Please enter function</span>

                            <br />
                            <asp:Label ID="Label12" runat="server" Text="Job Location" CssClass="boldText"></asp:Label><br />
                            <asp:TextBox ID="txtJoblocation" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                            <span id="spanJoblocation" class="validation hide">Please enter job location</span>

                        </div>

                    </div>
                    <%-----------------------------------------------------------%>

                    <div class="row">
                        <div class="col-12">
                            <asp:Label ID="lblSchoolEducation" runat="server" CssClass="mainHeading" Text="School Education"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <asp:Label ID="Label19" runat="server" Text="Qualification  Category:"></asp:Label>
                            <asp:DropDownList ID="ddlfQualificationCategory" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
                                ValidationGroup="VPersonalInformation" runat="server" ControlToValidate="ddlfQualificationCategory"
                                ErrorMessage="Please select Qualification Category"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="lblUserQualificationId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Education:"></asp:Label><br />
                            <asp:DropDownList ID="ddlfQualification" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvQualification" Display="Dynamic" CssClass="validation"
                                ValidationGroup="VPersonalInformation" runat="server" ControlToValidate="ddlfQualification"
                                ErrorMessage="Please select Qualification"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="Label13" runat="server" CssClass="boldText" Text="Country: "></asp:Label><br />
                            <asp:DropDownList ID="ddlfCountry" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCountry" Display="Dynamic" CssClass="validation"
                                ValidationGroup="VPersonalInformation" runat="server" ControlToValidate="ddlfCountry"
                                ErrorMessage="Please select Country"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3"></div>
                        <div class="col-3">
                            <br />
                            <asp:CheckBox ID="chbfIsCompleted" ClientIDMode="Static" runat="server" Text="Completed" TextAlign="Left" CssClass="IsCompleted boldText" />
                        </div>
                        <div class="col-3">
                            <asp:Label ID="Label14" runat="server" CssClass="boldText" Text="Year: "></asp:Label><br />
                            <input id="txtfYearCompleted" type="number" clientidmode="Static" runat="server" class="textBox" value="2017" min="1965" max="2025" />
                        </div>
                        <div class="col-3">
                            <asp:Label ID="Label15" runat="server" CssClass="boldText" Text="Institute: "></asp:Label>
                            <asp:TextBox ID="txtfInstitute" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" CssClass="validation"
                                ErrorMessage="Please enter Institute" ControlToValidate="txtfInstitute" ValidationGroup="VPersonalInformation"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-3"></div>
                        <div class="col-3">
                            <asp:Label ID="Label16" runat="server" CssClass="boldText" Text="Description: "></asp:Label>
                            <asp:TextBox ID="txtfDescription" runat="server" CssClass="textBox"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <asp:Label ID="Label17" runat="server" CssClass="boldText" Text="Percentage: "></asp:Label>
                            <asp:TextBox ID="txtfPercentage" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RangeValidator ID="rvPercentage" runat="server" ValidationGroup="VPersonalInformation"
                                ControlToValidate="txtfPercentage" Display="Dynamic" CssClass="validation" MinimumValue="0.00" MaximumValue="100.0"
                                Type="Double" ErrorMessage="Only numeric and point values are allowed from 0 to 100"></asp:RangeValidator>

                        </div>
                        <div class="col-3">
                            <asp:Label ID="Label18" runat="server" CssClass="boldText" Text="CGPA: "></asp:Label>
                            <asp:TextBox ID="txtfCGPA" runat="server" CssClass="textBox"></asp:TextBox>
                            <asp:RangeValidator ID="rvCGPA" runat="server" ValidationGroup="VPersonalInformation"
                                ControlToValidate="txtfCGPA" Display="Dynamic" CssClass="validation" MinimumValue="0.00" MaximumValue="5"
                                Type="Double" ErrorMessage="Only numeric and point values are allowed from 0 to 5"></asp:RangeValidator>

                        </div>
                        <div class="col-3"></div>
                    </div>



                    <%-----------------------------------------------------------%>
                    <div class="row">
                        <div class="col-12">
                            <hr />

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="button width260 height35" Text="Go" OnClientClick="return PersonalInformationCall();" ValidationGroup="VPersonalInformation" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnLogin" runat="server" CssClass="button width260 height35" Text="Login" Visible="false" CausesValidation="false" OnClick="btnLogin_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="button width260 height35" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12"> <br /></div>
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>
</html>
