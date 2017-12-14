<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserHobbyMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.UserHobbyMgmt" %>

<%@ Register Src="~/Forms/UserControls/UserHobbyControl.ascx" TagPrefix="uc1" TagName="UserHobbyControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserHobbyControl runat="server" ID="UserHobbyControl" />
</asp:Content>
