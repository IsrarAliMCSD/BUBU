<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CandidateSearchControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.CandidateSearchControl" %>

<div class="row">
    <div class="col-12 ">
        <asp:Label ID="lblSearch" CssClass="mainHeading" runat="server" Text="Search"></asp:Label>
    </div>
</div>

<div class="row">
    <div class="col-12 "><asp:Label ID="lblVacancyID" CssClass="mainHeading" runat="server" Visible="false"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Country Title Function Category" CssClass="form-control input-sm"></asp:TextBox>
    </div>
</div>

<div class="row">
    <div class="col-3">
        <asp:Label ID="Label2" CssClass="boldText" runat="server" Text="Gender: "></asp:Label>
    </div>
    <div class="col-9">
        <asp:DropDownList ID="ddlGender" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-3">
        <asp:Label ID="Label1" CssClass="boldText" runat="server" Text="Domicile: "></asp:Label>
    </div>
    <div class="col-9">
        <asp:DropDownList ID="ddlDomicile" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-3">
        <asp:Label ID="Label3" CssClass="boldText" runat="server" Text="Education: "></asp:Label>
    </div>
    <div class="col-9">
        <asp:DropDownList ID="ddlEducation" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-3">
        <asp:Label ID="Label4" CssClass="boldText" runat="server" Text="Work Experience: "></asp:Label>
    </div>
    <div class="col-9">
        <asp:DropDownList ID="ddlWorkExperience" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-3">
        <asp:Label ID="Label5" CssClass="boldText" runat="server" Text="Job Type: "></asp:Label>
    </div>
    <div class="col-9">
        <asp:DropDownList ID="ddlJobType" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="row">
    <div class="col-3">
        <asp:LinkButton ID="lbtnMoreOption" runat="server" Text="more Option" OnClick="lbtnMoreOption_Click"></asp:LinkButton>
    </div>
    <div class="col-9">
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button width260 height35" OnClick="btnSearch_Click" />
    </div>
</div>



<div class="row">
    <div class="col-12">
        <asp:GridView ID="gvCandidateSearch" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds." OnRowCommand="gvCandidateSearch_RowCommand">
             <AlternatingRowStyle BackColor="#999966" />
            <Columns>
                <asp:TemplateField ItemStyle-Width="20%">

                    <ItemTemplate>
                        <asp:Image ID="img_ProfilePicture" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                            ImageUrl='<%# GetImage(Eval("User.CONTENTDATA"),Eval("User.FORMAT") ) %>' /><br />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Name: "></asp:Label>
                        <asp:Label ID="lblEmployeeName" runat="server"
                            Text='<%# Eval("User.FirstName")+" "+Eval("User.LastName") %>'></asp:Label>
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
                        <br />
                        <asp:Label ID="Label9" runat="server" CssClass="boldText" Text="Year Completed: "></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text='<%#
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "true" ? 
                             Eval("UserQualificationLatest.CompletedYear") :
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "false" ? 
                              "In Progress":"" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnContact" runat="server" CommandName="SENDMESSAGE" CausesValidation="false" Text="ContactCandidate" ToolTip="ContactCandidate" />

                        <br />
                        <asp:LinkButton ID="lbtnDownloadFile" runat="server"
                            CommandArgument='<%# Bind("User.UserId") %>' CommandName="CVDOWNLOAD" CausesValidation="false" Text="Download" ToolTip="Download Profile" />
                        <%--  <br />
                            <asp:LinkButton ID="lbtnletterOfrefuse" runat="server" CausesValidation="false" Text="Letter of Refuse" ToolTip="Letter of Refuse" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Panel ID="pnlContact" runat="server" Visible="false">
                            <tr>
                                <td colspan="100%">
                                    <asp:Label ID="Label75" runat="server" CssClass="boldText" Text="Message: "></asp:Label>
                                    <asp:TextBox ID="txtEmployeeContact" Width="100%" MaxLength="250" TextMode="MultiLine"
                                        CssClass="motivationletter width100Pc" runat="server"></asp:TextBox>
                                    <br />
                                    <div class="col-12">
                                        <asp:RequiredFieldValidator ID="rfvEmployeeContact" runat="server" CssClass="validation"
                                            ErrorMessage="Please enter Content" ControlToValidate="txtEmployeeContact" ValidationGroup="VGEmployeeContact"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
                                    </div>
                                    <br />
                                    <center>
                                            <asp:Button ID="btnSend" runat="server"  ValidationGroup="VGEmployeeContact"
                                                  CommandName="SEND" CommandArgument='<%# Bind("User.Userid") %>'  CssClass="width200" Text="SEND"  />
                                              <asp:Button ID="btnCancel" runat="server" 
                                                  CommandName="SENDCANCEL" CommandArgument='<%# Bind("User.Userid") %>' CssClass="width200" Text="Cancel"  />
                                    </center>
                        </asp:Panel>
                        </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>


