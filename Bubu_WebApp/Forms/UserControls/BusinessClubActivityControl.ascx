<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubActivityControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubActivityControl" %>

<div class="row">
    <div class="col-12">
        <asp:Label ID="lblEvent" runat="server" CssClass="mainHeading" Text="Business Club Event"></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label1" runat="server" CssClass="boldText" Visible="false" Text="Busienss Club: "></asp:Label>
        <asp:Label ID="lblBusinessClubActivityId" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="col-10">
        <asp:DropDownList ID="ddlClubName" CssClass="ddlWidth260 ddl" Visible="false" runat="server"></asp:DropDownList>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Event Type: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:DropDownList ID="ddlActivityType" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="ddlActivityType"
            ErrorMessage="Please select activity type "></asp:RequiredFieldValidator>

    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Event Name: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtSubject" runat="server" ClientIDMode="Static"
            CssClass="textBox" MaxLength="150"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="txtSubject"
            ErrorMessage="Please enter Event Name"></asp:RequiredFieldValidator>

    </div>
</div>

<div class="row">
    <div class="col-2">
        <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Location: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtLocation" runat="server" ClientIDMode="Static"
            CssClass="textBox " MaxLength="500"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGACTIVITY" runat="server" ControlToValidate="txtLocation"
            ErrorMessage="Please enter Location"></asp:RequiredFieldValidator>

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
        <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Dead Line: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:TextBox ID="txtDeadLine" runat="server" ClientIDMode="Static" CssClass="EmpUmEmpEvent calendar textBox" Text=""></asp:TextBox>

    </div>
</div>



<%--<div class="row">
    <div class="col-2"></div>
    <div style="background-color: blue;" class="col-4">
        <asp:Button ID="btnSave" runat="server" Text="Save123" ValidationGroup="VGACTIVITY" OnClick="btnSave_Click" />
    </div>
    <div style="background-color: brown;" class="col-4">
      
    </div>
    <div class="col-2"></div>
</div>--%>
<div class="row">
    <div class="col-2"></div>
    <div class="col-10">
        <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
       
 
    </div>
</div>

<div class="row">
    <div class="col-2"></div>
    <div class="col-5"> 
         <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button width260 height35" ValidationGroup="VGACTIVITY" OnClick="btnSave_Click" />
          </div>
    <div class="col-5">
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" CssClass="button width260 height35"   OnClick="btnCancel_Click" />
    </div>
</div>



