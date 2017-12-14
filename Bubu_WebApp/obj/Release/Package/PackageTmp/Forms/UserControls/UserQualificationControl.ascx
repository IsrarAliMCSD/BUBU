<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserQualificationControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.UserQualificationControl" %>
<script>

    $(document).ready(function () {
        $("#chbfIsCompleted").change(function () {
            if ($("#chbfIsCompleted").is(':checked')) {
                $("#txtfYearCompleted").attr("disabled", "disabled");
            }
            else {
                $("#txtfYearCompleted").removeAttr("disabled");
            }

        });

    });
</script>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblSchoolEducation" runat="server" CssClass="mainHeading" Text="School Education"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-4">
            <asp:Label ID="lblUserQualificationId" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Qualification:"></asp:Label>
            <asp:DropDownList ID="ddlfQualification" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvQualification" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertQualification" runat="server" ControlToValidate="ddlfQualification"
                ErrorMessage="Please select Qualification"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:Label ID="Label7" runat="server" Text="Country: "></asp:Label>
            <asp:DropDownList ID="ddlfCountry" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCountry" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGInsertQualification" runat="server" ControlToValidate="ddlfCountry"
                ErrorMessage="Please select Country"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4"></div>
        <div class="col-4">
            <br />
            <asp:CheckBox ID="chbfIsCompleted" ClientIDMode="Static" runat="server" Text="Completed" TextAlign="Left" CssClass="IsCompleted" />
        </div>
        <div class="col-4">
            <asp:Label ID="Label2" runat="server" Text="Year: "></asp:Label><br />
            <input id="txtfYearCompleted" type="number" clientidmode="Static" runat="server" class="textBox" value="2017" min="1965" max="2025" />
        </div>
        <div class="col-4">
            <asp:Label ID="Label3" runat="server" Text="Institute: "></asp:Label>
            <asp:TextBox ID="txtfInstitute" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvInstitute" runat="server" CssClass="validation"
                ErrorMessage="Please enter Institute" ControlToValidate="txtfInstitute" ValidationGroup="VGInsertQualification"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="col-4">
            <asp:Label ID="Label4" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtfDescription" runat="server" CssClass="textBox"></asp:TextBox>
        </div>
        <div class="col-4">
            <asp:Label ID="Label5" runat="server" Text="Percentage: "></asp:Label>
            <asp:TextBox ID="txtfPercentage" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RangeValidator ID="rvPercentage" runat="server" ValidationGroup="VGInsertQualification"
                ControlToValidate="txtfPercentage" Display="Dynamic" CssClass="validation" MinimumValue="0.00" MaximumValue="100.0"
                Type="Double" ErrorMessage="Only numeric and point values are allowed from 0 to 100"></asp:RangeValidator>

        </div>
        <div class="col-4">
            <asp:Label ID="Label6" runat="server" Text="CGPA: "></asp:Label>
            <asp:TextBox ID="txtfCGPA" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RangeValidator ID="rvCGPA" runat="server" ValidationGroup="VGInsertQualification"
                ControlToValidate="txtfCGPA" Display="Dynamic" CssClass="validation" MinimumValue="0.00" MaximumValue="5"
                Type="Double" ErrorMessage="Only numeric and point values are allowed from 0 to 100"></asp:RangeValidator>

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
            <asp:Button ID="btnAdd" runat="server" ValidationGroup="VGInsertQualification" Text="Add" OnClick="btnAdd_Click" ToolTip="Add" CssClass="button width260 height35" />
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="VGInsertQualification" Text="Update" OnClick="btnUpdate_Click" ToolTip="Update" CssClass="button width260 height35" Visible="false" />
        </div>
        <div class="col-4">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" CssClass="button width260 height35" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" CssClass="button width260 height35" />
        </div>
        <div class="col-2"></div>
    </div>

    <asp:Repeater ID="rptrUserQualification" runat="server" OnItemCommand="rptrUserQualification_ItemCommand">
        <ItemTemplate>
            <div class="row">
                <div class="col-10">

                    <asp:Label ID="lblQualification" runat="server" Text='<%# Eval("Qualification.QualificationName")+" - " %>'></asp:Label>
                    <asp:Label ID="lblCompletedYear" runat="server"
                        Text='<%# Eval("IsCompleted").ToString().ToUpper() == "TRUE" ?Eval("CompletedYear") :"(In Progress)" %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("country.countryName") %>'></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <asp:Label ID="lblInstitute" runat="server" Text='<%# Bind("Institution") %>'></asp:Label>
                </div>
                <div class="col-4">
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </div>

                <div class="col-1">
                    <asp:Label ID="lblPercentage" runat="server" Text='<%# Eval("percentage")!=null?
                              Eval("percentage")+"%":  Eval("percentage")%>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:Label ID="lblCGPA" runat="server" Text='<%# Eval("CGPA")!=null?
                              Eval("CGPA")+"(CGPA)":  Eval("CGPA")%>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserQualificationId") %>' CommandName="QualificationEdit"
                        ToolTip="Edit" CssClass="width20" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserQualificationId") %>' CommandName="QualificationDelete"
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
