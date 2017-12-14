<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="Bubu_WebApp.Forms.CompanyInfo" %>

<%@ Register Src="~/Forms/UserControls/EmployeerHomeController.ascx" TagPrefix="uc1" TagName="EmployeerHomeController" %>
<%@ Register Src="~/Forms/UserControls/EmployeerJobSearch.ascx" TagPrefix="uc1" TagName="EmployeerJobSearch" %>
<%@ Register Src="~/Forms/UserControls/JobSearchControl.ascx" TagPrefix="uc1" TagName="JobSearchControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EmployeerHomeController runat="server" ID="EmployeerHomeController1" />
    <hr />
    <uc1:JobSearchControl runat="server" ID="JobSearchControl1" />
    
</asp:Content>
