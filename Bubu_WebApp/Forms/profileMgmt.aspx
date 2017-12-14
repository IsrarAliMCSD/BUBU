<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="profileMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.profileMgmt" %>

<%@ Register Src="~/Forms/UserControls/DocumentListDisplayControl.ascx" TagPrefix="uc1" TagName="DocumentListDisplayControl" %>
<%@ Register Src="~/Forms/UserControls/PersonalInformationControl.ascx" TagPrefix="uc1" TagName="PersonalInformationControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".expandCollapse").click(function () {
                $(this).toggleClass("collapseImg").toggleClass("expandImg");
                var div = $(this).attr("referencediv");
                $("#" + div).toggleClass('hide').toggleClass("show").toggle("slow");
            });

            //$("#img_document").click(function () {
            //    ShowImages("Document", $(this).clone());
            //});
        });



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="container">
            <uc1:PersonalInformationControl runat="server" ID="PersonalInformationControl" />

            <div class="row">
                <div class="col-12 text-right">

                    <asp:Button ID="btnEditPersonalInformation" runat="server" CssClass="form-btn" Text="Edit" OnClick="btnEditPersonalInformation_Click" />
                </div>

            </div>
            <div class="row">
                <div class="container">
                    <div class="col-12 ">
                        <hr />
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-4">
                    <asp:Label ID="lblhcurriculumvitae" runat="server" CssClass="mainHeading" Text="Curriculum Vitae"></asp:Label>
                </div>
                <div class="col-8 text-right">
                    <asp:Button ID="btnEditCurriculumVitae" CssClass="form-btn " runat="server" Text="Edit" OnClick="btnEditCurriculumVitae_Click" />
                </div>

            </div>
            <div class="row">
                <div class="container">
                    <div class="col-12 ">
                        <hr />
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-4">

                    <asp:Label ID="lblhUploadDocument" runat="server"  CssClass="mainHeading" Text="Upload Documents"></asp:Label>
                </div>
                <div class="col-8 text-right">
                    <asp:Button ID="btnUploadDocumentEdit" runat="server" CssClass="form-btn" Text="Edit" OnClick="btnUploadDocumentEdit_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-12 ">
                    <img id="aCertificate" referencediv="divCertificate" class="width20 pointer collapseImg  expandCollapse" />
                    <asp:Label ID="lblCertificate" runat="server" Text="Certificates"></asp:Label>
                </div>
            </div>
            <div class="row hide" id="divCertificate">
                <div class="col-12">
                    <uc1:DocumentListDisplayControl runat="server" ID="DLSCertificate" />
                </div>
            </div>
            <div class="row">
                <div class="col-12 ">
                    <img id="aDiploma" referencediv="divDiploma" src="../Images/plus.png" class="width20 pointer collapseImg expandCollapse" />
                    <asp:Label ID="lblDiploma" runat="server" Text="Diploma"></asp:Label>
                </div>
            </div>
            <div class="row hide" id="divDiploma">
                <div class="col-12">
                    <uc1:DocumentListDisplayControl runat="server" ID="DLSDiploma" />
                </div>
            </div>
            <div class="row ">
                <div class="col-12 ">
                    <img id="aOtherDoc" referencediv="divotherDoc" src="../Images/plus.png" class="width20 pointer collapseImg expandCollapse" />
                    <asp:Label ID="lblOtherDocs" runat="server" Text="Other Documents"></asp:Label>
                </div>
            </div>
            <div class="row hide" id="divotherDoc">
                <div class="col-12">
                    <uc1:DocumentListDisplayControl runat="server" ID="DLSOtherDocument" />
                </div>
            </div>
            <div class="row">
                <div class="container">
                    <div class="col-12 ">
                        <hr />
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-4">

                    <asp:Label ID="Label13" runat="server"  CssClass="mainHeading" Text="Upload Profile Picture"></asp:Label>
                </div>
                <div class="col-8 text-right">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="form-btn" OnClick="btnUpload_Click" />
                </div>
            </div>


        </div>
    </div>


</asp:Content>
