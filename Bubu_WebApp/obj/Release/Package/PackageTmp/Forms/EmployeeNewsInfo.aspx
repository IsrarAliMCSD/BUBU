<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="EmployeeNewsInfo.aspx.cs" Inherits="Bubu_WebApp.Forms.EmployeeNewsInfo" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubNewsDisplayControl.ascx" TagPrefix="uc1" TagName="BusinessClubNewsDisplayControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:BusinessClubNewsDisplayControl runat="server" ID="BusinessClubNewsDisplayControl" />
</asp:Content>
