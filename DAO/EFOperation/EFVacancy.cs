using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFVacancy
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFVacancy()
        {
            bubucontext = new BubuEntities();
        }
        public List<Vacancy> GetVacancyListByUserId(int userId, bool isPrivateInclude, ref string returnMessage)
        {
            IQueryable<Vacancy> iqVacancyList = bubucontext.Vacancies.Where(a => a.CompanyInformation.UserId == userId && a.IsActive == true);
            if (!isPrivateInclude)
            {
                iqVacancyList = iqVacancyList.Where(a => a.IsPrivate != isPrivateInclude);
            }
            return iqVacancyList.ToList();
        }
        public List<JobType> GetJobType()
        {
            return bubucontext.JobTypes.Where(a => a.IsActive == true).ToList();
        }
        public bool SaveVacancy(Vacancy vacancy, ref string returnMessage)
        {
            using (bubucontext = new BubuEntities())
            {
                if (vacancy.VacancyId > 0)
                {
                    Vacancy vacancyObj = bubucontext.Vacancies.Where(a => a.VacancyId == vacancy.VacancyId).FirstOrDefault();
                    if (vacancyObj != null && vacancyObj.VacancyId > 0)
                    {
                        vacancyObj.CompanyId = vacancy.CompanyId;
                        vacancyObj.CompanyInformation = vacancy.CompanyInformation;
                        vacancyObj.CompletedRemark = vacancy.CompletedRemark;
                        vacancyObj.IsActive = vacancy.IsActive;
                        vacancyObj.IsPrivate = vacancy.IsPrivate;
                        vacancyObj.IsVacancyCompleted = vacancy.IsVacancyCompleted;
                        vacancyObj.JobDetail = vacancy.JobDetail;
                        vacancyObj.JobFunction = vacancy.JobFunction;
                        vacancyObj.JobTitle = vacancy.JobTitle;
                        vacancyObj.JobTypeId = vacancy.JobTypeId;
                        vacancyObj.RegionId = vacancy.RegionId;
                        vacancyObj.QualificationCategory = vacancy.QualificationCategory;
                        vacancyObj.QualificationId = vacancy.QualificationId;
                    }
                }
                else
                {
                    bubucontext.Entry(vacancy).State = EntityState.Added;
                    bubucontext.Vacancies.Add(vacancy);

                }
                bubucontext.SaveChanges();
            }
            return true;
        }

        public bool DeleteVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                Vacancy vacancy = bubucontext.Vacancies.Where(a => a.VacancyId == vacancyId).FirstOrDefault();
                if (vacancy != null && vacancy.VacancyId > 0)
                {
                    vacancy.IsActive = false;
                    bubucontext.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public Vacancy GetVacancyByVacancyId(int vacancyId, ref string returnMessage)
        {
            return bubucontext.Vacancies.Include("Qualification")                
                .Where(a => a.VacancyId == vacancyId).FirstOrDefault();
        }
        public List<Vacancy> GetVacancyListSearch(int userId, bool isPrivateInclude, string textSearch, ref string returnMessage)
        {
            IQueryable<Vacancy> iqVacancyList = bubucontext.Vacancies.Where(a => a.CompanyInformation.UserId == userId && a.IsActive == true);
            if (!isPrivateInclude)
            {
                iqVacancyList = iqVacancyList.Where(a => a.IsPrivate != isPrivateInclude);
            }
            if (textSearch != "")
            {
                iqVacancyList = iqVacancyList.Where(a => a.JobFunction.Contains(textSearch) || a.Region.RegionName.Contains(textSearch) ||
                    a.JobType.JobTypeName.Contains(textSearch) || a.JobTitle.Contains(textSearch));
            }
            return iqVacancyList.ToList();
        }

        public Vacancy GetVacancyDetailByVacancyId(int vacancyId)
        {
            //return bubucontext.Vacancies
            //    .Include("Qualification")
            //    .Include("QualificationCategory")
            //    .Where(a => a.VacancyId == vacancyId).FirstOrDefault();



            IQueryable<Vacancy> searchResult = bubucontext.Vacancies
                .Include("CompanyInformation")
                .Include("Qualification")
                .Include("QualificationCategory")
                .Include("JobType")
                .Include("Region")
                .Where(a => a.IsActive == true && a.IsVacancyCompleted == false && a.VacancyId==vacancyId);
            return searchResult.OrderByDescending(a => a.CreatedDate).FirstOrDefault();
        }


    }
}
