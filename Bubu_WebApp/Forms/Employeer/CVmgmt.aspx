<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="CVmgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.CVmgmt" %>

<%@ Register Src="~/Forms/UserControls/CurriculamVitaeControl.ascx" TagPrefix="uc1" TagName="CurriculamVitaeControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:CurriculamVitaeControl runat="server" ID="CurriculamVitaeControl" />
</asp:Content>
