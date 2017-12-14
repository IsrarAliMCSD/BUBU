<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserLanguageMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.UserLanguageMgmt" %>

<%@ Register Src="~/Forms/UserControls/UserLanguageControl.ascx" TagPrefix="uc1" TagName="UserLanguageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserLanguageControl runat="server" ID="UserLanguageControl" />
</asp:Content>
