<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Bubu_WebApp.Forms.Test1" %>

<%@ Register Src="~/Forms/UserControls/AddBusinessClubRequest.ascx" TagPrefix="uc1" TagName="AddBusinessClubRequest" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:AddBusinessClubRequest runat="server" id="AddBusinessClubRequest" />
</asp:Content>
