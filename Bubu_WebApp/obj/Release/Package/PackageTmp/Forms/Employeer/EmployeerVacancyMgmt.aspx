<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="EmployeerVacancyMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.EmployeerVacancyMgmt" %>

<%@ Register Src="~/Forms/UserControls/VacancyControl.ascx" TagPrefix="uc1" TagName="VacancyControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:VacancyControl runat="server" ID="VacancyControl" />

</asp:Content>
