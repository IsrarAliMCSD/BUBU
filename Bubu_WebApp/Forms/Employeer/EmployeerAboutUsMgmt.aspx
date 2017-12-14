<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="EmployeerAboutUsMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.EmployeerAboutUsMgmt" %>

<%@ Register Src="~/Forms/UserControls/CompanyAboutUsControl.ascx" TagPrefix="uc1" TagName="CompanyAboutUsControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CompanyAboutUsControl runat="server" ID="CompanyAboutUsControl" />
</asp:Content>
