<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="VacancyApplicant.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.VacancyApplicant" %>

<%@ Register Src="~/Forms/UserControls/VacancyApplicantList.ascx" TagPrefix="uc1" TagName="VacancyApplicantList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VacancyApplicantList runat="server" ID="VacancyApplicantList1" />
</asp:Content>
