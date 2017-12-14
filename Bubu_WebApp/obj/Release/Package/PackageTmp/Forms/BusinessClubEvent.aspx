<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="BusinessClubEvent.aspx.cs" Inherits="Bubu_WebApp.Forms.BusinessClubEvent" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubActivityControl.ascx" TagPrefix="uc1" TagName="BusinessClubActivityControl" %>
<%@ Register Src="~/Forms/UserControls/BusinessClubActivityListControl.ascx" TagPrefix="uc1" TagName="BusinessClubActivityListControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BusinessClubActivityControl runat="server" ID="BusinessClubActivityControl" />
    <hr />
    <uc1:BusinessClubActivityListControl runat="server" ID="BusinessClubActivityListControl" />
</asp:Content>
