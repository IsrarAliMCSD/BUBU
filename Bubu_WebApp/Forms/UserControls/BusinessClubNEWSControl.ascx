<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubNEWSControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubNEWSControl" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblEvent" runat="server" CssClass="mainHeading" Text="NEWS"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Busienss Club: "></asp:Label>
        </div>
        <div class="col-10">
            <asp:DropDownList ID="ddlClubName"  CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCategory" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGNEWS" runat="server" ControlToValidate="ddlClubName"
                ErrorMessage="Please select Club "></asp:RequiredFieldValidator>

        </div>
    </div>

    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="News: "></asp:Label>
        </div>
        <div class="col-10">
            <asp:TextBox ID="txtNewsDetail" runat="server" TextMode="MultiLine" Rows="5" Columns="80" ClientIDMode="Static"
                CssClass="width100pc height200" MaxLength="500"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGNEWS" runat="server" ControlToValidate="txtNewsDetail"
                ErrorMessage="Please enter News"></asp:RequiredFieldValidator>

        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="VGNEWS" Text="Save" ToolTip="Save"
                  CssClass="button width260 height35" OnClick="btnSave_Click" />
        </div>
    </div>
</div>
