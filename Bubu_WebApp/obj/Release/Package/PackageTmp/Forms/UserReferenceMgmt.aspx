<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserReferenceMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.UserReferenceMgmt" %>

<%@ Register Src="~/Forms/UserControls/UserReferenceControl.ascx" TagPrefix="uc1" TagName="UserReferenceControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserReferenceControl runat="server" ID="UserReferenceControl" />
</asp:Content>
