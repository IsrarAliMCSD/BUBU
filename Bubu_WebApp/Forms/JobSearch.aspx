<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="JobSearch.aspx.cs" Inherits="Bubu_WebApp.Forms.JobSearch" %>

<%@ Register Src="~/Forms/UserControls/JobSearchControl.ascx" TagPrefix="uc1" TagName="JobSearchControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <div class="container">
        <div class="row">
            <div class="col-12 ">
                <asp:Label ID="lblSearch" CssClass="mainHeading" runat="server" Text="Search"></asp:Label>
            </div>
        </div>
    </div>--%>
    <uc1:JobSearchControl runat="server" ID="JobSearchControl" />
</asp:Content>
