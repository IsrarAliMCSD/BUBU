<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubControl" %>
<script>
    $(document).ready(function () {
        $("#fupLogo").change(function () {
            ShowImageReadURL(this, "imgLogoUpload");
        });
    });
</script>
<div class="row">
    <div class="col-12">
        <asp:Label ID="lblBusinessClub" runat="server" CssClass="mainHeading" Text="Business Club"></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-4">
        <asp:Label ID="lblBusinessClubID" Visible="false" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Club Name: "></asp:Label>
    </div>
    <div class="col-4">
        <asp:TextBox ID="txtBusinessClubName" runat="server" CssClass="textBox"></asp:TextBox>
    </div>
    <div class="col-4">
        <asp:RequiredFieldValidator ID="rfvBusinessClubName" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGBusinessClub" runat="server" ControlToValidate="txtBusinessClubName"
            ErrorMessage="Please enter Business Club name"></asp:RequiredFieldValidator>
    </div>
</div>

<div class="row">
    <div class="col-4">
        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Purpose: "></asp:Label>
    </div>
    <div class="col-4">
        <asp:TextBox ID="txtPurpose" runat="server" CssClass="textBox"></asp:TextBox>
    </div>
    <div class="col-4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGBusinessClub" runat="server" ControlToValidate="txtPurpose"
            ErrorMessage="Please enter purpose"></asp:RequiredFieldValidator>
    </div>
</div>

<div class="row">
    <div class="col-4">
        <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="About: "></asp:Label>
    </div>
    <div class="col-4">
        <asp:TextBox ID="txtAbout" runat="server" CssClass="textBox"></asp:TextBox>

    </div>
    <div class="col-4">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" CssClass="validation"
            ValidationGroup="VGBusinessClub" runat="server" ControlToValidate="txtAbout"
            ErrorMessage="Please enter about the club"></asp:RequiredFieldValidator>
    </div>
</div>

<div class="row">
    <div class="col-4">
        <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Logo: "></asp:Label>
    </div>
    <div class="col-4">
        <asp:FileUpload ID="fupLogo" runat="server" ClientIDMode="Static" />
        <asp:Image ID="imgLogoUpload" runat="server" ClientIDMode="Static" CssClass="width100" />

    </div>
    <div class="col-4">
    </div>

</div>

<div class="row">
    <div class="col-4">
    </div>
    <div class="col-8">
        <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-12">
        <hr />
    </div>
</div>
<div class="row">
    <div class="col-2"></div>
    <div class="col-4">
        <asp:Button ID="btnSave" runat="server" ValidationGroup="VGBusinessClub" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click" />
    </div>
    <div class="col-4">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />
        <%--<asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="width200 button" OnClick="btnBack_Click"/>--%>
    </div>
</div>

<div class="row">
    <div class="col-12">
        <asp:GridView ID="gvBusinessClub" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds." OnRowCommand="gvBusinessClub_RowCommand">
            <AlternatingRowStyle BackColor="#999966" />
            <Columns>
                <asp:TemplateField ItemStyle-Width="10%">

                    <ItemTemplate>
                        <asp:Image ID="img_Club" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                            ImageUrl='<%# GetImage(Eval("CONTENTDATA"),Eval("FORMAT") ) %>' /><br />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblCOMPANYNAME" runat="server" CssClass="italicText" Text='<%# Eval("BUSINESSCLUBNAME")%>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="60%">

                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Purpose: "></asp:Label>
                        <asp:Label ID="lblPurpose" runat="server" Text='<%# Eval("PURPOSE")%>'></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="About: "></asp:Label>
                        <asp:Label ID="lblAbout" runat="server" Text='<%# Eval("ABOUT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField ItemStyle-Width="10%">

                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/view.png" CausesValidation="false"
                            CommandArgument='<%# Bind("BUSINESSCLUBID") %>' CommandName="GRIDVIEW"
                            ToolTip="View" CssClass="width20" />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                            CommandArgument='<%# Bind("BUSINESSCLUBID") %>' CommandName="GRIDEDIT" Visible='<%# Bind("ISACTIVE") %>'
                            ToolTip="Edit" CssClass="width20" />
                        <asp:ImageButton ID="IbtnJoin" runat="server" ImageUrl="~/Images/Icon/join.png" CausesValidation="false"
                            CommandArgument='<%# Bind("BUSINESSCLUBID") %>' CommandName="GRIDJOIN" OnClientClick="return confirm('Do you want to Join the Club?');"
                            Visible='<%# Convert.ToBoolean(Eval("ISACTIVE"))== false? true:false %>' ToolTip="Join Club" CssClass="width20" />
                        <br />
                        <asp:LinkButton ID="lbtnBusinessClub" runat="server" Text="Detail"
                            CommandArgument='<%# Bind("BUSINESSCLUBID") %>' CommandName="CLUBDETAIL" ToolTip="View Detail and member"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</div>
