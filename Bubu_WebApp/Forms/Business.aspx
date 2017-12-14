<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="Bubu_WebApp.Forms.Business" %>

<%@ Register Src="~/Forms/UserControls/CurriculamVitaeControl.ascx" TagPrefix="uc1" TagName="CurriculamVitaeControl" %>
<%@ Register Src="~/Forms/UserControls/DocumentListDisplayControl.ascx" TagPrefix="uc1" TagName="DocumentListDisplayControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        $(document).ready(function () {

            $("#img_document").click(function () {
                ShowImages("Document", $(this).clone());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tabs" class="tab">
        <ul>
            <li><a href="#tabs-1">Curriculam Vitae</a></li>
            <li><a href="#tabs-2">Diplomas and certificates</a></li>
        </ul>
        <div id="tabs-1" style="background-color: #ded5d5;">
            <uc1:CurriculamVitaeControl runat="server" ID="CurriculamVitaeControl" />
        </div>
        <div id="tabs-2" style="background-color: #ded5d5">
            <div class="row">
            <div class="col-8">
                
            </div>
            <div class="col-4">
                  <asp:Button ID="btnEditDocuments" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnEditDocuments_Click" />
            </div>
        </div>
            <uc1:DocumentListDisplayControl runat="server" ID="DLSCertificate" />
            <uc1:DocumentListDisplayControl runat="server" ID="DLSDiploma" />
            <uc1:DocumentListDisplayControl runat="server" ID="DLSOtherDocument" />
        </div>
    </div>
    <br />
    <br />
</asp:Content>
