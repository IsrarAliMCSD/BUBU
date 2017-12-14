<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="QualificationMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.QualificationMgmt" %>

<%@ Register Src="~/Forms/UserControls/UserQualificationControl.ascx" TagPrefix="uc1" TagName="UserQualificationControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UserQualificationControl runat="server" ID="UserQualificationControl" />
</asp:Content>
