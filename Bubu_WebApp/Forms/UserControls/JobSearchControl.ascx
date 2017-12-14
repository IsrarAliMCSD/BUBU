<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobSearchControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.JobSearchControl" %>
<div class="container">
    <asp:Label ID="lblMessage" ClientIDMode="Static"  runat="server" CssClass="hide" Text=""></asp:Label>
    <div class="row">
        <div class="col-12 ">
            <asp:Label ID="lblSearch" CssClass="mainHeading" runat="server" Text="Search"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-12 ">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search (any terms keyword)" CssClass="form-control  textBox"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label2" CssClass="boldText" runat="server" Text="Sector: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlSector" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label1" CssClass="boldText" runat="server" Text="Function: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlFunction" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label3" CssClass="boldText" runat="server" Text="Region: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlRegion" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label4" CssClass="boldText" runat="server" Text="Job Type: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlJobType" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-8">
            <asp:LinkButton ID="lbtnMoreOption" runat="server" Text="more Option" OnClick="lbtnMoreOption_Click"></asp:LinkButton>
        </div>
        <div class="col-4">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button width260 height35" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>

    <asp:GridView ID="gvVacancyList" runat="server" ShowHeader="false" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Vacancy exists." OnRowCommand="gvVacancyList_RowCommand">
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
                    <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("CompanyInformation.companySector") %>'></asp:Label>
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
                    <asp:LinkButton ID="lbtnMoreInfos" runat="server" Text="More Infos" CausesValidation="false" ClientIDMode="Static"
                        ToolTip='<%# Bind("VacancyId")%>' OnClientClick="return OpenPageInDialogue('JobDetail.aspx',this);"
                        CommandName="MOREINFO" CommandArgument='<%# Bind("CompanyInformation.CompanyId") %>'></asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="lbtnApply" runat="server" Text="Apply" CausesValidation="false"
                        CommandArgument='<%# Bind("VacancyId") %>' CommandName="APPLY"
                        ToolTip="Delete" CssClass="width20"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Panel ID="pnlApply" runat="server" Visible="false">
                        <tr>
                            <td colspan="100%">
                                <asp:Panel ID="pnlOrders" runat="server">
                                    <asp:TextBox ID="txtMotivationLetter" Width="100%" MaxLength="125" TextMode="MultiLine" CssClass="motivationletter width100Pc" runat="server"></asp:TextBox>
                                   
                                    <br />
                                    <div class="col-12">
                                        <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
                                    </div>
                                    <br />
                                    <center>
                                            <asp:Button ID="btnNotNow" runat="server"    CommandName="NOTNOW"  CssClass="button width260 height35" Text="No, Apply now" />
                                            <asp:Button ID="btnYes" runat="server"   CommandName="APPLYYES" CommandArgument='<%# Bind("VacancyId") %>'  CssClass="button width260 height35" Text="Yes, Apply"  />
                                           <asp:Button ID="btnClose" runat="server"   CommandName="NOTNOW"  CssClass="button width260 height35" Text="Close"   />
                                    </center>
                                </asp:Panel>
                            </td>
                        </tr>

                    </asp:Panel>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<script>

    $(document).ready(function () {

        var motivationtext = $("#lblMessage").text();
        $(".motivationletter").text(motivationtext);
    });

</script>
