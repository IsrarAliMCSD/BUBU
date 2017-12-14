<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLanguageControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.UserLanguageControl" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblUserLanguageHeading" runat="server" CssClass="mainHeading" Text="Language"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblUserLanguageId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Language"></asp:Label>
        </div>
        <div class="col-9">

            <asp:DropDownList ID="ddlLanguage" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvLanguage" Display="Dynamic" CssClass="validation"
                ValidationGroup="userLanguage" runat="server" ControlToValidate="ddlLanguage"
                ErrorMessage="Please select Language "></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label2" runat="server" Text="Level: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlLevel" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvLevel" Display="Dynamic" CssClass="validation"
                ValidationGroup="userLanguage" runat="server" ControlToValidate="ddlLanguage"
                ErrorMessage="Please select Level"></asp:RequiredFieldValidator>
        </div>
        <div class="col-12">
            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>

    </div>
    <div class="row">
        <div class="col-1"></div>
        <div class="col-3">
            <asp:Button ID="btnAdd" runat="server" ValidationGroup="userLanguage" Text="Add" ToolTip="Save" CssClass="button width260 height35" OnClick="btnAdd_Click" />
        </div>
        <div class="col-2"></div>
        <div class="col-3">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="button width260 height35" OnClick="btnBack_Click" />
        </div>
        <div class="col-2">
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="gvUserLanguage" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvUserLanguage_RowCommand">
                 <AlternatingRowStyle BackColor="#999966" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Language"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLanguage" runat="server" Text='<%# Bind("Language.LanguageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Level"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLevel" runat="server" Text='<%# Bind("Level.LevelName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnedit" runat="server" Text="Edit" CommandName="GRIDEDIT" CommandArgument='<%# Eval("UserLanguageId")%>'></asp:LinkButton>
                            |
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" CommandName="GRIDDELETE" CommandArgument='<%# Eval("UserLanguageId")%>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</div>
