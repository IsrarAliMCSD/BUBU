<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBusinessClubRequest.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.AddBusinessClubRequest" %>
<div class="container">
    <div class="row">
        <script src="../../Framework/JS/bubu.js"></script>
        <div class="col-12">
            <asp:Label ID="lblAddBusinessRequest" runat="server" CssClass="mainHeading" Text="Business Club Joing Request"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="validation" ValidationGroup="a"
                ControlToValidate="txtFirstName" ErrorMessage="Please enter first name."></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" CssClass="validation" ValidationGroup="a"
                ControlToValidate="txtLastName" ErrorMessage="Please enter last name."></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtEmail" runat="server"  CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" CssClass="validation" ValidationGroup="a"
                ControlToValidate="txtEmail" ErrorMessage="Please enter email."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="a" 
                CssClass="validation" Display="Dynamic" ControlToValidate="txtEmail" 
                ErrorMessage="Please enter valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

        </div>
    </div>

    <%-- <div class="row">
        <div class="col-3">
            <asp:Label ID="Label3" runat="server" Text="Employee: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlEmployee" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvEmployee" Display="Dynamic" CssClass="validation" ValidationGroup="a"
                runat="server" ControlToValidate="ddlEmployee"
                ErrorMessage="Please select Employee"></asp:RequiredFieldValidator>
        </div>
    </div>--%>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label4" runat="server" Text="Message: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="100px" CssClass="textBox" MaxLength="245"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" CssClass="validation" ValidationGroup="a"
                ControlToValidate="txtMessage" ErrorMessage="Please enter message."></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <br />
            <br />
        </div>
        <div class="col-9">
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" CssClass="button width260 height35" ValidationGroup="a" Text="Send request" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="button width260 height35" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>

</div>

