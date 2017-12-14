<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="AddBusinessClubDetail.aspx.cs" Inherits="Bubu_WebApp.Forms.AddBusinessClubDetail" %>


<%@ Register Src="~/Forms/UserControls/AddBusinessClubRequest.ascx" TagPrefix="uc1" TagName="AddBusinessClubRequest" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddBusinessClubRequest runat="server" ID="AddBusinessClubRequest" />
</asp:Content>
