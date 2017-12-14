<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubViewControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubViewControl" %>
<div class="row">
    <div class="col-12">
        <asp:Label ID="lblBusinessClubId" runat="server" Visible="false" CssClass="mainHeading" Text=""></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-6 businessClubColor1" style="border-right: 2px solid #ccc;">
        <asp:Image ID="imgLogo" runat="server" ClientIDMode="Static" CssClass="width100" />
    </div>
    <div class="col-6  businessClubColor2 divCenter store-box">
        <asp:Label ID="lblBusinessClubName" runat="server" CssClass="boldText" Text="Club Name: "></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="About Us: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:Label ID="lblAbout" runat="server" CssClass="italicText" Text=" "></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Purposes: "></asp:Label>
    </div>
    <div class="col-10">
        <asp:Label ID="lblPurpose" runat="server" CssClass="italicText" Text=" "></asp:Label>
    </div>
</div>
<div class="row">
    <div class="col-2">
        <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Members: "></asp:Label>
    </div>
    <div class="col-2">
        <asp:Label ID="lblMemberCount" runat="server" CssClass="boldText circle" Text="0 "></asp:Label>
    </div>
    <div class="col-6">
        <asp:LinkButton ID="lbtnAddMember" runat="server" Visible="false" Text="Add Member" OnClick="lbtnAddMember_Click"></asp:LinkButton>
    </div>
</div>
<div class="row">
    <div class="col-12">
        <hr />

    </div>
</div>
<div class="row">
    <div class="col-12  text-right">
        <asp:Button ID="btnAddNewMember" Visible="true"  CssClass="form-btn " runat="server" Text="+ Add New Member" OnClick="btnAddNewMember_Click" />

    </div>
</div>
<div class="row">
    <div class="col-12">
        <asp:GridView ID="gvBusinessMember" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds.">
            <Columns>
                <asp:TemplateField ItemStyle-Width="20%">

                    <ItemTemplate>
                        <asp:Image ID="img_ProfilePicture" runat="server" ClientIDMode="Static" CssClass="width50"
                            ImageUrl='<%# GetImage(Eval("User.CONTENTDATA"),Eval("User.FORMAT") ) %>' /><br />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Name: "></asp:Label>
                        <asp:Label ID="lblEmployeeName" runat="server"
                            Text='<%# Eval("User.UserName") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Birth Date: "></asp:Label>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Eval("User.DateOfBirth", "{0:MM/dd/yy}") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Domicile: "></asp:Label>
                        <asp:Label ID="lblDomicile" runat="server" Text='<%# Eval("User.Domicile.DomicileName") %>'></asp:Label>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Company: "></asp:Label>
                        <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("UserWorkExperienceLatest.Company") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label6" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
                        <asp:Label ID="lblFunction" runat="server" Text='<%# Eval("UserWorkExperienceLatest.JobFunction") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label8" runat="server" CssClass="boldText" Text="Position: "></asp:Label>
                        <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("UserWorkExperienceLatest.Position") %>'></asp:Label>
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Education: "></asp:Label>
                        <asp:Label ID="lblEducation" runat="server" Text='<%# Eval("UserQualificationLatest.Qualification.QualificationName") %>'></asp:Label>
                        <%-- <br />
                        <asp:Label ID="Label9" runat="server" CssClass="boldText" Text="Year Completed: "></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text='<%#
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "true" ? 
                             Eval("UserQualificationLatest.CompletedYear") :
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "false" ? 
                              "In Progress":"" %>'></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</div>


