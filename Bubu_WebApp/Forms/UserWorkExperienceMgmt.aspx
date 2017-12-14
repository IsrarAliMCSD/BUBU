<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserWorkExperienceMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.UserWorkExperienceMgmt" %>

<%@ Register Src="~/Forms/UserControls/WorkExperienceControl.ascx" TagPrefix="uc1" TagName="WorkExperienceControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WorkExperienceControl runat="server" ID="WorkExperienceControl" />
</asp:Content>
