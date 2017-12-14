<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="CertificateMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.CertificateMgmt" %>

<%@ Register Src="~/Forms/UserControls/DocumentListDisplayControl.ascx" TagPrefix="uc1" TagName="DocumentListDisplayControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 ">
            <uc1:DocumentListDisplayControl runat="server" ID="DLSCertificate" />
            <uc1:DocumentListDisplayControl runat="server" ID="DLSDiploma" />
            <uc1:DocumentListDisplayControl runat="server" ID="DLSOtherDocument" />
        </div>
    </div>
</asp:Content>
