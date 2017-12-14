<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="CurriculumVitae.aspx.cs" Inherits="Bubu_WebApp.Forms.CurriculumVitae" %>

<%@ Register Src="~/Forms/UserControls/CurriculamVitaeControl.ascx" TagPrefix="uc1" TagName="CurriculamVitaeControl" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CurriculamVitaeControl runat="server" ID="CurriculamVitaeControl" />
</asp:Content>
