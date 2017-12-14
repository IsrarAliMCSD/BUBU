<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="UserSkillMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.UserSkillMgmt" %>

<%@ Register Src="~/Forms/UserControls/AdditionalSkillControl.ascx" TagPrefix="uc1" TagName="AdditionalSkillControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AdditionalSkillControl runat="server" ID="AdditionalSkillControl" />
</asp:Content>
