<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="CompanyInformationEdit.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.CompanyInformationEdit" %>

<%@ Register Src="~/Forms/UserControls/EmployeerCompanyInfo.ascx" TagPrefix="uc1" TagName="EmployeerCompanyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EmployeerCompanyInfo runat="server" ID="EmployeerCompanyInfo" />
</asp:Content>
