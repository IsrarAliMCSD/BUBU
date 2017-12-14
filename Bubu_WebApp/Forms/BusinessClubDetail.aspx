<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="BusinessClubDetail.aspx.cs" Inherits="Bubu_WebApp.Forms.BusinessClubDetail" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubViewControl.ascx" TagPrefix="uc1" TagName="BusinessClubViewControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BusinessClubViewControl runat="server" ID="BusinessClubViewControl" />
</asp:Content>
