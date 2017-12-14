<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalInformationControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.PersonalInformationControl" %>

<div>
    <div class="container">
        <div class="row">
            <%--<div class="col-12 ">

                <asp:Label ID="lblhBasicinformation" runat="server" CssClass="mainHeading" Text="Basic Information"></asp:Label>

            </div>--%>
        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label1" runat="server" Text="Name:" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label2" runat="server" Text="First Name:" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblFirstName" runat="server"
                    Text=""></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label3" runat="server" Visible="false" Text="Middle Name:" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblMiddleName" Visible="false" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="Label5" runat="server" Visible="false" Text="Last Name:" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblLastName" runat="server" Visible="false" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label4" runat="server" Text="Brith Date: " CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblBirthDate" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label7" runat="server" Text="Email: " CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label6" runat="server" Text="Telefon: " CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblContactNo" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="Label16" runat="server" Text="Domicile: " Visible="false" CssClass="boldText"></asp:Label>

            </div>
            <div class="col-3 ">
                <asp:Label ID="lblDomicile" runat="server" Visible="false" Text=""></asp:Label>
            </div>

        </div>


        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label15" runat="server" Text="country: " Visible="false" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblCountry" runat="server" Visible="false" Text=""></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:CheckBox ID="chboxMarried" runat="server" Enabled="false" Visible="false" TextAlign="Right" Text="Married" />

            </div>
        </div>

        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label13" runat="server" Text="Gender: " Visible="false" CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:Label ID="lblGender" runat="server" Visible="false" Text=""></asp:Label>
            </div>
            <div class="col-3 ">
            </div>
        </div>
        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label8" runat="server" Text="Career/ Profession: " CssClass="boldText"></asp:Label>
            </div>
            <div class="col-3 ">
                <asp:RadioButton ID="rbtnUnEmployeed" runat="server" GroupName="employmentStatus" Checked="true" Enabled="false" Text="UnEmployeed " />
            </div>

            <div class="col-3 ">
            </div>
        </div>

        <div class="row">
            <div class="col-3 ">
            </div>
            <div class="col-3 ">
                <asp:RadioButton ID="rbtnemployeed" runat="server" GroupName="employmentStatus" Enabled="false" Text="Employeed " />
            </div>

            <div class="col-6 ">
                <asp:Label ID="Label9" runat="server" Visible="false" Text="Company" CssClass="boldText"></asp:Label><br />
                <asp:Label ID="lblCompany" runat="server" Text=""></asp:Label>

                <asp:Label ID="Label10" runat="server" Visible="false" Text="Position" CssClass="boldText"></asp:Label><br />
                <asp:Label ID="lblPosition" runat="server" Text=""></asp:Label>

                <asp:Label ID="Label11" runat="server" Visible="false" Text="Function" CssClass="boldText"></asp:Label><br />
                <asp:Label ID="lblFunction" runat="server" Text=""></asp:Label>

                <asp:Label ID="Label12" runat="server" Visible="false" Text="Job Location" CssClass="boldText"></asp:Label><br />
                <asp:Label ID="lblJoblocation" runat="server" Text=""></asp:Label>
            </div>

        </div>

        <div class="row">
            <div class="col-3 ">
                <asp:Label ID="Label14" runat="server" Text="Job Start" Visible="false" CssClass="boldText"></asp:Label><br />
                <asp:Label ID="lblJobStart" runat="server" Visible="false" Text=""></asp:Label>
            </div>

        </div>


    </div>
</div>
