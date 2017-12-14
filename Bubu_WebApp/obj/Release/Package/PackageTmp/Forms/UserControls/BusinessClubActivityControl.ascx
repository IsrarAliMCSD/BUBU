<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubActivityControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubActivityControl" %>

<div class="row">
    <div class="col-12">
        <asp:Label ID="lblEvent" runat="server" CssClass="mainHeading" Text="Business Club Activity"></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Busienss Club: "></asp:Label>
        <asp:Label ID="lblBusinessClubActivityId" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="col-10">
        <asp:DropDownList ID="ddlClubName"  CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator InitialValue="-1" ID="rfvClubName" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="ddlClubName"
            ErrorMessage="Please select Club "></asp:RequiredFieldValidator>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Activity Type: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:DropDownList ID="ddlActivityType"  CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="ddlActivityType"
            ErrorMessage="Please select activity type "></asp:RequiredFieldValidator>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Subject: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtSubject" runat="server" ClientIDMode="Static"
            CssClass="textBox" MaxLength="150"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="txtSubject"
            ErrorMessage="Please enter subject"></asp:RequiredFieldValidator>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label6" runat="server" CssClass="boldText" Text="Date: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtActivityDate" runat="server" ClientIDMode="Static" CssClass="EmpUmEmpEvent calendar textBox" Text=""></asp:TextBox>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Description: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" Columns="80" ClientIDMode="Static"
            CssClass="width100pc  " MaxLength="500"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="txtDescription"
            ErrorMessage="Please enter Description"></asp:RequiredFieldValidator>

    </div>
</div>

<div class="row">
    <div class="col-2"></div>
    <div class="col-10">
        <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
    </div>
</div>

<div class="row">
    <div class="col-2"></div>
    <div class="col-4">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="VGACTIVITY" CssClass="button width260 height35" OnClick="btnSave_Click" />
    </div>
    <div class="col-4">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="VGACTIVITY" CssClass="button width260 height35" OnClick="btnCancel_Click" />
    </div>
    <div class="col-2"></div>
</div>


