<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurriculamVitaeControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.CurriculamVitaeControl" %>
<%@ Register Src="~/Forms/UserControls/PersonalInformationControl.ascx" TagPrefix="uc1" TagName="PersonalInformationControl" %>
<%@ Register Src="~/Forms/UserControls/UserCommencementControl.ascx" TagPrefix="uc1" TagName="UserCommencementControl" %>

<div>
    <div class="container">
        <div class="row">
            <br />
        </div>
        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label3" runat="server" CssClass="mainHeading" Text="Personal Details"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnEditPersonalDetail" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnEditPersonalDetail_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <uc1:PersonalInformationControl runat="server" ID="PersonalInformationControl" />
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-8">
                <asp:Label ID="lblSchoolEducation" runat="server" CssClass="mainHeading" Text="School Education"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnEditSchoolEducation" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnEditSchoolEducation_Click" />
            </div>
        </div>

        <asp:Repeater ID="rptrUserQualification" runat="server">
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
                </div>
                <div class="row">
                    <div class="col-12">
                        <hr />
                    </div>
                </div>

            </ItemTemplate>

        </asp:Repeater>

        <br />
        <div class="row">
            <div class="col-8">
                <asp:Label ID="lblWorkExperience" runat="server" CssClass="mainHeading" Text="Work Experience"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnEditWorkExperience" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnEditWorkExperience_Click" />
            </div>
        </div>
        <asp:Repeater ID="rptrWorkExperience" runat="server">
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
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <hr />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
       
        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label6" runat="server" CssClass="mainHeading" Text="Interests & Hobbies"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnEditInterestAndHobby" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnEditInterestAndHobby_Click" />
            </div>
        </div>
        <div class="row">
            <asp:Repeater ID="rptruserHobbies" runat="server">
                <ItemTemplate>
                    <div class="col-3 divSkill">
                        <asp:Label ID="lblUserHobby" runat="server"
                            Text='<%# Eval("Hobby.HobbyName")%>'></asp:Label>
                        <asp:Label ID="lblUserHobbyDetail" runat="server" CssClass="italicText" Text='<%# Eval("HobbyDetail")!=""?
                            "("+  Eval("HobbyDetail")+")":  Eval("HobbyDetail")%>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <hr />

        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label2" runat="server" CssClass="mainHeading" Text="Language"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnLanguageEdit" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnLanguageEdit_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvUserLanguage" runat="server" AutoGenerateColumns="false" Width="100%">
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

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label7" runat="server" CssClass="mainHeading" Text="Additional Skill"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnAdditionalSkill" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnAdditionalSkill_Click" />
            </div>
        </div>

        <div class="row">
            <asp:Repeater ID="rptruserSkills" runat="server">
                <ItemTemplate>

                    <div class="col-3 divSkill">
                        <asp:Label ID="lblUserSkill" runat="server"
                            Text='<%# Eval("Skill.SkillName")%>'></asp:Label>
                        <asp:Label ID="lblUserSkillDetail" runat="server" CssClass="italicText" Text='<%# Eval("SkillDetail")!=""?
                            "("+  Eval("SkillDetail")+")":  Eval("SkillDetail")%>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
 

        <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label5" runat="server" CssClass="mainHeading" Text="References"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnReference" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnReference_Click" />
            </div>
        </div>

        <asp:Repeater ID="rptruserreference" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="col-8">
                        <asp:Label ID="lblReferenceName" runat="server" CssClass="boldText"
                            Text='<%# Eval("ReferenceName")+" ( "+ Eval("Reference.ReferenceName")+" ) " %>'></asp:Label>
                    </div>
                    <div class="col-4"></div>
                </div>
                <div class="row">
                    <div class="col-8">
                        <asp:Label ID="lblReferencePosition" runat="server" Text='<%# Eval("ReferencePosition") %>'></asp:Label>
                        <span class="italicText">at </span>
                        <asp:Label ID="lblReferenceCompany" runat="server" Text='<%# Eval("ReferenceCompany") %>'></asp:Label>
                    </div>
                    <div class="col-4"></div>
                </div>
                <div class="row">
                    <div class="col-10">
                        <asp:Label ID="lblReferenceContactNumber" runat="server" CssClass="italicText" Text='<%# Eval("ReferenceContactNo") %>'></asp:Label>
                    </div>
                    <div class="col-2">
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <hr />
                       
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
       
        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label4" runat="server" CssClass="mainHeading" Text="Commencement Of Job"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnCommencement" runat="server" Text="Edit" CssClass="form-btn" OnClick="btnCommencement_Click" />
            </div>
        </div>
       
        <div class="row">
            <div class="col-12">
                <asp:Label ID="lblCommencement" runat="server" CssClass="italicText" Text=""></asp:Label>
            </div>
        </div>



    </div>
</div>
