<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacancyControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.VacancyControl" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblVacancy" runat="server" CssClass="mainHeading" Text="Vacancy"></asp:Label>
            <asp:Label ID="lblVacancyId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblCompanyId" runat="server" Visible="false"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <br />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            if you do not public  the job, No employee can see this job but you can search for them.
        </div>
        <div class="col-12">
            Do you want to public  this job.
            <asp:RadioButton ID="rbtnNo" runat="server" GroupName="PublicPrivate" Text="No" Checked="true" />
            <asp:RadioButton ID="rbtnYes" runat="server" GroupName="PublicPrivate" Text="Yes" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label2" runat="server" CssClass="boldText"
                Text="Job Title: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtJobTitle" runat="server" ValidationGroup="VGVacancy" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJobTitle" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="txtJobTitle"
                ErrorMessage="Please enter job title"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label140" runat="server" CssClass="boldText"
                Text="Sector: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtSector" runat="server" ValidationGroup="VGVacancy" Enabled="false" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rftSector" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="txtSector"
                ErrorMessage="Please enter Sector"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label3" runat="server" CssClass="boldText"
                Text="Function: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtFunction" runat="server" ValidationGroup="VGVacancy" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFunction" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="txtFunction"
                ErrorMessage="Please enter function"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label4" runat="server" CssClass="boldText"
                Text="Description: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtDescription" runat="server" ValidationGroup="VGVacancy" TextMode="MultiLine" Height="100px" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="txtDescription"
                ErrorMessage="Please enter description"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label6" runat="server" CssClass="boldText"
                Text="Region: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:DropDownList ID="ddlRegion" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator2" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="ddlRegion"
                ErrorMessage="Please select region "></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label5" runat="server" CssClass="boldText"
                Text="Job Type: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:DropDownList ID="ddlJobType" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvReference" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGVacancy" runat="server" ControlToValidate="ddlJobType"
                ErrorMessage="Please select job Type "></asp:RequiredFieldValidator>
        </div>
    </div>



    <div class="row">
        <div class="col-12">
            <br />
        </div>

    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblError" runat="server" Text="" CssClass="validation"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="VGVacancy" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click" />
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="button width260 height35" OnClick="btnBack_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-8">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search (Sector,Function, Region, JobType,  Job Title)" CssClass="form-control input-sm"></asp:TextBox>
        </div>
        <div class="col-3">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CausesValidation="false" CssClass="button width260 height35" OnClick="btnSearch_Click" />
        </div>
    </div>


    <div class="row">
        <div class="col-12">
            <asp:GridView ID="gvVacancyList" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="100%" EmptyDataText="No Vacancy exists." GridLines="Horizontal"
                OnRowCommand="gvVacancyList_RowCommand">
                 <AlternatingRowStyle BackColor="#999966" />
                <Columns>
                    <asp:TemplateField>

                        <ItemTemplate>
                            <asp:Image ID="img_document" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("CompanyInformation.COMPANYCONTENTDATA"),Eval("CompanyInformation.COMPANYFORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblCOMPANYNAME" runat="server" Text='<%# Eval("CompanyInformation.COMPANYNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Sector: "></asp:Label>
                            <asp:Label ID="lblCompanySector" runat="server" Text='<%# Bind("CompanyInformation.companySector") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
                            <asp:Label ID="lblJobFunction" runat="server" Text='<%# Bind("JobFunction") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Region: "></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Region.RegionName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Job Type: "></asp:Label>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("JobType.JobTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label112" runat="server" CssClass="boldText" Text="Job Title: "></asp:Label>
                            <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("JobTitle") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label15" runat="server" CssClass="boldText" Text="Job Detail: "></asp:Label>
                            <asp:Label ID="lblJobDetail" runat="server" Text='<%# Bind("JobDetail") %>'></asp:Label>
                            <br />
                            <asp:Label ID="lblIsPrivate" runat="server" CssClass="boldText" Text='<%# (Boolean.Parse(Eval("IsPrivate").ToString())) ? "Private" : "Not Private" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnApplicant" runat="server" CausesValidation="false" Text="Applicant"
                                CommandName="VACANTAPPLICANT" CommandArgument='<%# Bind("VacancyId") %>'
                                ToolTip="Applicant List" />
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" Text="Search For Candidate"
                                CommandName="VACANCYSEARCHFORCANDIDATE" CommandArgument='<%# Bind("VacancyId") %>'
                                ToolTip="Applicant List" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                                CommandArgument='<%# Bind("VacancyId") %>' CommandName="VACANCYEDIT"
                                ToolTip="Edit" CssClass="width20" />
                            <br />
                            <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                                CommandArgument='<%# Bind("VacancyId") %>' CommandName="VACANCYDELETE"
                                ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


        </div>
    </div>
