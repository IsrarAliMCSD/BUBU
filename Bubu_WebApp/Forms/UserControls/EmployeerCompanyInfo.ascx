<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeerCompanyInfo.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.EmployeerCompanyInfo" %>
<script>
    $(document).ready(function () {
        $("#fuplLogo").change(function () {
            ShowImageReadURL(this, "imgFileUpload");
        });
    });

</script>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblCompanyInformation" runat="server" CssClass="mainHeading" Text="Company Information"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-8">
            <div class="row">

                <div class="col-4">
                    <asp:Label ID="lblCompanyId" Visible="false" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name: "></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtCompany" runat="server" TextMode="MultiLine" CssClass="textBox" Height="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCompany" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VGInsertCompany" runat="server" ControlToValidate="txtCompany"
                        ErrorMessage="Please enter company Name"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="col-4">
                    <asp:Label ID="lblCompanyAddress" runat="server" TextMode="MultiLine" Text="Company Address: "></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VGInsertCompany" runat="server" ControlToValidate="txtCompanyAddress"
                        ErrorMessage="Please enter company address"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:Label ID="Label1" runat="server" Text="Contact No: "></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VGInsertCompany" runat="server" ControlToValidate="txtContactNo"
                        ErrorMessage="Please enter contact number"></asp:RequiredFieldValidator>

                </div>
            </div>

              <div class="row">
                <div class="col-4">
                    <asp:Label ID="Label2" runat="server" Text="Sector: "></asp:Label>
                </div>
                <div class="col-8">
                    <asp:TextBox ID="txtSector" runat="server" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSector" Display="Dynamic" CssClass="validation"
                        ValidationGroup="VGInsertCompany" runat="server" ControlToValidate="txtSector"
                        ErrorMessage="Please enter sector"></asp:RequiredFieldValidator>

                </div>
            </div>

        </div>

        <div class="col-4">
            <div class="row">
                <div class="col-12">
                    <asp:FileUpload ID="fuplLogo" runat="server" ClientIDMode="Static" />
                </div>
                <div class="col-12">
                    <asp:Image ID="imgFileUpload" runat="server" ClientIDMode="Static" CssClass="width200 borderRadious" />
                </div>

            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <br />
        </div>
    </div>

    <div class="row">
        <div class="col-6">

            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="VGInsertCompany" CssClass="button width260 height35" OnClick="btnSave_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="validation" Text=""></asp:Label>
        </div>
        <div class="col-6">
            <asp:Button ID="btnBack" runat="server" Text="Back"  CssClass="button width260 height35" OnClick="btnBack_Click"  />
        </div>
    </div>

</div>
