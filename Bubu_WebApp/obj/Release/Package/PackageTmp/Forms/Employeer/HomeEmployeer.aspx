<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="HomeEmployeer.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.HomeEmployeer" %>

<%@ Register Src="~/Forms/UserControls/EmployeerHomeController.ascx" TagPrefix="uc1" TagName="EmployeerHomeController" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EmployeerHomeController runat="server" id="EmployeerHomeController" />
</asp:Content>
