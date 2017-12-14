<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="AddBusinessClubEvent.aspx.cs" Inherits="Bubu_WebApp.Forms.AddBusinessClubEvent" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubActivityControl.ascx" TagPrefix="uc1" TagName="BusinessClubActivityControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BusinessClubActivityControl runat="server" ID="BusinessClubActivityControl" />
</asp:Content>
