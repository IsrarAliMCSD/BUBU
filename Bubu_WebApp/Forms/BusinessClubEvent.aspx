<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="BusinessClubEvent.aspx.cs" Inherits="Bubu_WebApp.Forms.BusinessClubEvent" %>

<%--<%@ Register Src="~/Forms/UserControls/BusinessClubActivityControl.ascx" TagPrefix="uc1" TagName="BusinessClubActivityControl" %>--%>
<%--<%@ Register Src="~/Forms/UserControls/BusinessClubActivityListControl.ascx" TagPrefix="uc1" TagName="BusinessClubActivityListControl" %>--%>
<%@ Register Src="~/Forms/UserControls/BusinessClubActivityListUpdate.ascx" TagPrefix="uc1" TagName="BusinessClubActivityListUpdate" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblBusinessClubId" runat="server" Visible="false" CssClass="mainHeading" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-6 businessClubColor1" style="border-right: 2px solid #ccc;">
            <asp:Image ID="imgLogo" runat="server" ClientIDMode="Static" CssClass="width100" />
        </div>
        <div class="col-6  businessClubColor2 divCenter store-box">
            <asp:Label ID="lblBusinessClubName" runat="server" CssClass="boldText" Text="Club Name: "></asp:Label>
        </div>
    </div>


    <%--<uc1:BusinessClubActivityControl runat="server" ID="BusinessClubActivityControl" />--%>
    <%--<hr />--%>
    <uc1:BusinessClubActivityListUpdate runat="server" id="BusinessClubActivityListUpdate" />
 <%--    <hr />
   <uc1:BusinessClubActivityListControl runat="server" ID="BusinessClubActivityListControl" />--%>
</asp:Content>
