<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="DocumentUploadMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.DocumentUploadMgmt" %>

<%@ Register Src="UserControls/DocumentUploadControl.ascx" TagName="DocumentUploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:DocumentUploadControl ID="DocumentUploadControl1" runat="server" />
    <br />
    <asp:Button ID="btnBack" CssClass="form-btn" runat="server" Text="Back" OnClick="btnBack_Click" />

</asp:Content>
