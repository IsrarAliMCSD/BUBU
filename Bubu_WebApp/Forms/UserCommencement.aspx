<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserCommencement.aspx.cs" Inherits="Bubu_WebApp.Forms.UserCommencement" %>

<%@ Register Src="~/Forms/UserControls/UserCommencementControl.ascx" TagPrefix="uc1" TagName="UserCommencementControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserCommencementControl runat="server" ID="UserCommencementControl" />
</asp:Content>
