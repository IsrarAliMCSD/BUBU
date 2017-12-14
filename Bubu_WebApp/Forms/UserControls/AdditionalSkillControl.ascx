<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdditionalSkillControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.AdditionalSkillControl" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblAdditionalSkill" runat="server" CssClass="mainHeading" Text="Additional Skills"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblUserSkillId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Skill: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlSkill" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCategory" Display="Dynamic" CssClass="validation"
                ValidationGroup="userhobby" runat="server" ControlToValidate="ddlSkill"
                ErrorMessage="Please select Skill"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label1" runat="server" Text="Skill Detail: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtSkillDetail" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
    </div>
    <div class="row">
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
        <div class="col-4">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="userhobby" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click" />
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="button width260 height35" OnClick="btnBack_Click" />
        </div>
          <div class="col-1"></div>
    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>

    </div>

     <asp:Repeater ID="rptruserSkill" runat="server" OnItemCommand="rptruserSkill_ItemCommand">
        <ItemTemplate>
            <div class="row">
                <div class="col-10 divSkillWithOutMargin">
                      <asp:Label ID="lblUserSkill" runat="server" CssClass="boldText"
                            Text='<%# Eval("Skill.SkillName")%>'></asp:Label>
                        <asp:Label ID="lblUserSkillDetail" runat="server" CssClass="italicText" Text='<%# Eval("SkillDetail")!=""?
                            "("+  Eval("SkillDetail")+")":  Eval("SkillDetail")%>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserSkillId") %>' CommandName="USERSKILLEDIT"
                        ToolTip="Edit" CssClass="width20" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserSkillId") %>' CommandName="USERSKILLDELETE"
                        ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>


</div>
