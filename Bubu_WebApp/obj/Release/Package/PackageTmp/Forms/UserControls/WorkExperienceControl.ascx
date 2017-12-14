<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkExperienceControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.WorkExperienceControl" %>
<script>

    $(document).ready(function () {
        $("#chbfIscurrentjob").change(function () {
            EnabledisableControlOnCheckBoxWorkExperience("chbfIscurrentjob", "txtJobTo");
        });

    });
</script>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblWorkExperience" runat="server" CssClass="mainHeading" Text="Work Experience"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="lblUserWorkExperienceId" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Company: "></asp:Label>
            <asp:TextBox ID="txtCompany" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCompany" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtCompany"
                ErrorMessage="Please enter company"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:Label ID="Label3" runat="server" Text="Job Function: "></asp:Label>
            <asp:TextBox ID="txtJobFunction" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJobFunction" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtJobFunction"
                ErrorMessage="Please enter job function"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:Label ID="Label2" runat="server" Text="Position: "></asp:Label>
            <asp:TextBox ID="txtPosition" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPosition" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtPosition"
                ErrorMessage="Please enter position"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label5" runat="server" Text="Job Location: "></asp:Label>
            <asp:TextBox ID="txtJobLocation" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJobLocation" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtJobLocation"
                ErrorMessage="Please enter Job location"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:Label ID="Label6" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="textBox"></asp:TextBox>

        </div>
        <div class="col-4">
            <asp:Label ID="Label7" runat="server" Text="Institution: "></asp:Label>
            <asp:TextBox ID="txtInstitution" runat="server" Text="" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvInstitution" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtInstitution"
                ErrorMessage="Please enter institution"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label8" runat="server" Text="Job from: "></asp:Label>
            <asp:TextBox ID="txtJobFrom" runat="server" ClientIDMode="Static" CssClass="EmpUmEmpEvent textBox calendar" Text=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJobFrom" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertWorkExperience" runat="server" ControlToValidate="txtJobFrom"
                ErrorMessage="Please enter Job from"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:CheckBox ID="chbfIscurrentjob" ClientIDMode="Static" runat="server" Text="Is Present Job" TextAlign="Left" CssClass="IsCompleted" />
        </div>
        <div class="col-4">
            <asp:Label ID="Label4" runat="server" Text=" Job to: "></asp:Label>
            <asp:TextBox ID="txtJobTo" runat="server" ClientIDMode="Static" CssClass="width250 textBox calendar"></asp:TextBox>
            <asp:Label ID="lblError" runat="server" Text="" CssClass="validation"></asp:Label>
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
            <asp:Button ID="btnAdd" runat="server" ValidationGroup="VGInsertWorkExperience" Text="Add" ToolTip="Add" CssClass="button width260 height35" OnClick="btnAdd_Click" />
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

    <asp:Repeater ID="rptrWorkExperience" runat="server" OnItemCommand="rptrWorkExperience_ItemCommand">
        <ItemTemplate>
            <div class="row">
                <div class="col-8">

                    <asp:Label ID="lblPosition" runat="server" CssClass="boldText" Text='<%# Eval("Position") %>'></asp:Label>
                    at
                     <asp:Label ID="lblCompany" runat="server" CssClass="boldText" Text='<%# Eval("Company") %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblJobFrom" runat="server" Text='<%# Eval("JobFrom", "{0:MM/dd/yy}") %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblJobTo" runat="server"
                        Text='<%# Eval("IsCurrentJob").ToString().ToUpper() == "FALSE" ?Eval("JobTo", "{0:MM/dd/yy}") :"(Present)" %>'></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Label ID="lblInstitute" runat="server" CssClass="italicText" Text='<%# Eval("Institution") %>'></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblJobFunction" runat="server" Text='<%# Eval("JobFunction") %>'></asp:Label>
                </div>
                <div class="col-3">
                    <asp:Label ID="lblJobLocation" runat="server" Text='<%# Eval("JobLocation") %>'></asp:Label>
                </div>
                <div class="col-4">
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserWorkExperienceId") %>' CommandName="UserWorkExperienceEdit"
                        ToolTip="Edit" CssClass="width20" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserWorkExperienceId") %>' CommandName="UserWorkExperienceDelete"
                        ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />


                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <hr />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>
