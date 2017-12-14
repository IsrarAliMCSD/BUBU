using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bubu_WebApp.App_Class
{
    public class vacancyDetail
    {
        public VacancyApply vacancyApply { get; set; }
        public User user { get; set; }
        public Domicile domicile { get; set; }
        public UserWorkExperience UserWorkExperienceLatest { get; set; }
        public UserQualification UserQualificationLatest { get; set; }
        public int CVMatch { get; set; }

    }
    public class userDetail
    {
        public User user { get; set; }
        public Domicile domicile { get; set; }
        public UserWorkExperience UserWorkExperienceLatest { get; set; }
        public UserQualification UserQualificationLatest { get; set; }
        public int CVMatch { get; set; }

    }
}