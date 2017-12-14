<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs" Inherits="Bubu_WebApp.Forms.PersonalInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        $(document).ready(function () {
            $("input[type='radio']").click(function () {
                if ($(this).attr("value") == "rbtnUnEmployeed") {
                    $(".divemployeement").hide(500);
                }
                else {
                    $(".divemployeement").show(500);
                }
                //alert('s');
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
            else {
                returnResult = true;
            }
            return returnResult;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-12 ">

                    <asp:Label ID="lblhBasicinformation" runat="server" CssClass="mainHeading" Text="Basic Information"></asp:Label>

                </div>

            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label1" runat="server" Text="Name:" CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" CssClass="validation"
                        ErrorMessage="Please enter UserName" ControlToValidate="txtUserName" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="VPersonalInformation" CssClass="validation"
                        Display="Dynamic" ControlToValidate="txtUserName" ErrorMessage="Please enter  email address"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </div>
                <div class="col-2">
                    <asp:Label ID="Label2" runat="server" Text="First Name:" CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" CssClass="validation"
                        ErrorMessage="Please enter first name" ControlToValidate="txtFirstName" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-2 ">
                    <asp:Label ID="Label3" runat="server" Text="Middle Name:" CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4 ">
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label5" runat="server" Text="Last Name:" CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4 ">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" CssClass="validation"
                        ErrorMessage="Please enter last name" ControlToValidate="txtLastName" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label4" runat="server" Text="Brith Date: " CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4 ">
                    <asp:TextBox ID="txtBirthDate" ClientIDMode="Static" runat="server" CssClass="textBox calendar" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" CssClass="validation"
                        ErrorMessage="Please enter Date of birth" ControlToValidate="txtBirthDate" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label7" runat="server" Text="Email: " CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" CssClass="validation"
                        ErrorMessage="Please enter email address" ControlToValidate="txtEmail" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="VPersonalInformation" CssClass="validation"
                        Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Please enter valid email address"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label6" runat="server" Text="Contact No: " CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" CssClass="validation"
                        ErrorMessage="Please enter contact number" ControlToValidate="txtContactNo" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-2">
                    <asp:Label ID="Label14" runat="server" Text="Domicle: " CssClass="boldText"></asp:Label>

                </div>
                <div class="col-4">
                    <%-- <asp:TextBox ID="txtDomicile" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDomicile" runat="server" CssClass="validation"
                        ErrorMessage="Please enter Domicile" ControlToValidate="txtDomicile" ValidationGroup="VPersonalInformation" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                    <asp:DropDownList ID="ddlDomicile" CssClass="ddlWidth260 ddl" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="rfvDomicile" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VPersonalInformation" runat="server" ControlToValidate="ddlDomicile"
                        ErrorMessage="Please select domicile"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label15" runat="server" Text="Country: " CssClass="boldText"></asp:Label>

                </div>
                <div class="col-4">
                    <asp:DropDownList ID="ddlCountry" CssClass="ddlWidth260 ddl" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCountry" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VPersonalInformation" runat="server" ControlToValidate="ddlCountry"
                        ErrorMessage="Please select country"></asp:RequiredFieldValidator>
                </div>
                <div class="col-2">
                    <asp:CheckBox ID="chboxMarried" runat="server" TextAlign="Right" Text="Married" />

                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label16" runat="server" Text="Gender: " CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:RadioButton ID="rbtnMale" runat="server" GroupName="Gender" Checked="true" Text="Male :" />
                </div>
                <div class="col-2">
                    <asp:RadioButton ID="rbtnFeMale" runat="server" GroupName="Gender" Text="FeMale :" />
                </div>
            </div>

            <div class="row">
                <div class="col-2">
                    <asp:Label ID="Label8" runat="server" Text="Career/ Profession: " CssClass="boldText"></asp:Label>
                </div>
                <div class="col-4">
                    <asp:RadioButton ID="rbtnUnEmployeed" ClientIDMode="Static" runat="server"
                        GroupName="employmentStatus" Checked="true" Text="UnEmployeed :" />
                </div>
                <div class="col-2">
                    <asp:RadioButton ID="rbtnemployeed" ClientIDMode="Static" runat="server"
                        GroupName="employmentStatus" Text="Employeed :" />
                </div>
                <div class="col-4">
                </div>
            </div>
            <div class="row divemployeement" runat="server" id="divemployeement">
                <div class="col-4">
                    <asp:Label ID="Label9" runat="server" Text="Company" CssClass="boldText"></asp:Label><br />
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                    <span id="spanCompany" class="validation hide">Please enter company</span>
                </div>
                <div class="col-4">
                    <asp:Label ID="Label10" runat="server" Text="Position" CssClass="boldText"></asp:Label><br />
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                    <span id="spanPosition" class="validation hide">Please enter position </span>
                </div>
                <div class="col-4">
                    <asp:Label ID="Label11" runat="server" Text="Function" CssClass="boldText"></asp:Label><br />
                    <asp:TextBox ID="txtFunction" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                    <span id="spanFunction" class="validation hide">Please enter function</span>
                </div>
                <div class="col-4">
                    <asp:Label ID="Label12" runat="server" Text="Job Location" CssClass="boldText"></asp:Label><br />
                    <asp:TextBox ID="txtJoblocation" runat="server" CssClass="EmpUmEmpEvent textBox" Text=""></asp:TextBox>
                    <span id="spanJoblocation" class="validation hide">Please enter job location</span>
                </div>
                <div class="col-4">
                    <asp:Label ID="Label13" runat="server" Text="Job Start" CssClass="boldText"></asp:Label><br />
                    <asp:TextBox ID="txtJobFrom" runat="server" ClientIDMode="Static" CssClass="EmpUmEmpEvent textBox calendar" Text=""></asp:TextBox>
                    <span id="spanJobFrom" class="validation hide">Please enter job Starting</span>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <hr />

                </div>

            </div>
            <div class="row">
                <div class="col-2"></div>
                <div class="col-4">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="button width260 height35" Text="Update" OnClientClick="return PersonalInformationCall();" ValidationGroup="VPersonalInformation" OnClick="btnUpdate_Click" />
                </div>
                <div class="col-4">
                    <asp:Button ID="btnCancel" runat="server" CssClass="button width260 height35" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
                <div class="col-2"></div>

            </div>

        </div>

    </div>

</asp:Content>
