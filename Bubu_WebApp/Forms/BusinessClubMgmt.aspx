﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="BusinessClubMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.BusinessClubMgmt" %>


<%@ Register Src="~/Forms/UserControls/BusinessClubUpdatedControl.ascx" TagPrefix="uc1" TagName="BusinessClubUpdatedControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <uc1:BusinessClubUpdatedControl runat="server" ID="BusinessClubUpdatedControl" />
    
</asp:Content>
