<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="EmployerNEWSMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.EmployerNEWSMgmt" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubNEWSControl.ascx" TagPrefix="uc1" TagName="BusinessClubNEWSControl" %>
<%@ Register Src="~/Forms/UserControls/BusinessClubNewsDisplayControl.ascx" TagPrefix="uc1" TagName="BusinessClubNewsDisplayControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BusinessClubNEWSControl runat="server" id="BusinessClubNEWSControl" />
    <hr />
    <uc1:BusinessClubNewsDisplayControl runat="server" ID="BusinessClubNewsDisplayControl" />
</asp:Content>
