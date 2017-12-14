<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeerJobSearch.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.EmployeerJobSearch" %>
<div class="container">
    <div class="row">
        <div class="col-12 ">
            <asp:Label ID="lblSearch" CssClass="mainHeading" runat="server" Text="Search"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-12 ">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Country Title Function Category" CssClass="form-control input-sm"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label2" CssClass="boldText" runat="server" Text="Gender: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlGender" CssClass="btn width100pc ddl " runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label1" CssClass="boldText" runat="server" Text="Domicile: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlDomicile" CssClass="btn width100pc ddl " runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label3" CssClass="boldText" runat="server" Text="Education: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlEducation" CssClass="btn width100pc ddl " runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label4" CssClass="boldText" runat="server" Text="Work Experience: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlWorkExperience" CssClass="btn width100pc ddl " runat="server"></asp:DropDownList>
        </div>
    </div>
     <div class="row">
        <div class="col-3">
            <asp:Label ID="Label5" CssClass="boldText" runat="server" Text="Job Type: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlJobType" CssClass="btn width100pc ddl " runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:LinkButton ID="lbtnMoreOption" runat="server" Text="more Option" OnClick="lbtnMoreOption_Click"></asp:LinkButton>
        </div>
        <div class="col-9">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="width200" OnClick="btnSearch_Click" />
        </div>
    </div>
     <div class="row">
        <div class="col-12">
            <asp:GridView ID="gvVacancyList" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Vacancy exists.">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Job Title"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("JobTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Job Function"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblJobFunction" runat="server" Text='<%# Bind("JobFunction") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Job Function"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblJobDetail" runat="server" Text='<%# Bind("JobDetail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Is Private"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblIsPrivate" runat="server" Text='<%# Bind("IsPrivate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Job Type"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblJobType" runat="server" Text='<%# Bind("JobType.JobTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                                CommandArgument='<%# Bind("VacancyId") %>' CommandName="VACANCYEDIT"
                                ToolTip="Edit" CssClass="width20" />
                            <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                                CommandArgument='<%# Bind("VacancyId") %>' CommandName="VACANCYDELETE"
                                ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


        </div>
</div>

