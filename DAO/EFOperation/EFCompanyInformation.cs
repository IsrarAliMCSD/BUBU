using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.EFOperation
{
    public class EFCompanyInformation
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFCompanyInformation()
        {
            bubucontext = new BubuEntities();
            bubucontext.Configuration.ProxyCreationEnabled = true;
            bubucontext.Configuration.LazyLoadingEnabled = true;
        }
        public CompanyInformation GetCompanyInformationByUserId(int userId)
        {
            return bubucontext.CompanyInformations.Where(a => a.UserId == userId && a.IsActive == true).FirstOrDefault();
        }
        public bool SaveCompanyInformation(CompanyInformation companyInformation, ref string returnMessage)
        {
            using (bubucontext = new BubuEntities())
            {
                if (companyInformation.CompanyId > 0)
                {
                    CompanyInformation companyInformationObj = bubucontext.CompanyInformations.Where(a => a.CompanyId == companyInformation.CompanyId).FirstOrDefault();
                    if (companyInformation != null && companyInformation.CompanyId > 0)
                    {
                        companyInformationObj.CompanyAddress = companyInformation.CompanyAddress;
                        companyInformationObj.CompanyContactNumber = companyInformation.CompanyContactNumber;
                        companyInformationObj.CompanyName = companyInformation.CompanyName;
                        companyInformationObj.UserId = companyInformation.UserId;
                        companyInformationObj.IsActive = companyInformation.IsActive;
                        companyInformationObj.CompanySector = companyInformation.CompanySector;
                        if (companyInformation.CompanyContentData != null && companyInformation.Companyformat != "")
                        {
                            companyInformationObj.CompanyContentData = companyInformation.CompanyContentData;
                            companyInformationObj.CompanyContentType = companyInformation.CompanyContentType;
                            companyInformationObj.Companyformat = companyInformation.Companyformat;
                            companyInformationObj.fileName = companyInformation.fileName;
                        }
                    }
                }
                else
                {
                    bubucontext.Entry(companyInformation).State = EntityState.Added;
                    bubucontext.CompanyInformations.Add(companyInformation);

                }
                bubucontext.SaveChanges();
            }
            return true;
        }
        public List<CompanyAbout> GetCompanyAboutUsList(int userId)
        {
            return bubucontext.CompanyAbouts.Where(a => a.CompanyInformation.UserId == userId && a.IsActive == true).ToList();
        }
        public bool DeleteCompanyAboutUsByCompanyAboutUsId(int companyAboutUsId)
        {
            using (bubucontext)
            {
                CompanyAbout companyAboutObj = bubucontext.CompanyAbouts.Where(a => a.CompanyAboutUsId == companyAboutUsId).FirstOrDefault();
                if (companyAboutObj != null && companyAboutObj.CompanyAboutUsId > 0)
                {
                    companyAboutObj.IsActive = false;

                    bubucontext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public CompanyAbout GetCompanyAboutUsByCompanyAboutId(int companyAboutUsId)
        {
            return bubucontext.CompanyAbouts.Where(a => a.CompanyAboutUsId == companyAboutUsId).FirstOrDefault();
        }
        public bool SaveCompanyAbout(CompanyAbout companyAbout, ref string returnMessage)
        {
            result = false;
            using (bubucontext)
            {
                if (companyAbout != null && companyAbout.CompanyAboutUsId > 0)
                {
                    var companyAboutObj = bubucontext.CompanyAbouts.Where(a => a.CompanyAboutUsId == companyAbout.CompanyAboutUsId).FirstOrDefault();
                    if (companyAboutObj != null && companyAboutObj.CompanyAboutUsId > 0)
                    {
                        companyAboutObj.Heading = companyAbout.Heading;
                        companyAboutObj.Detail = companyAbout.Detail;
                    }
                }
                else
                {
                    bubucontext.CompanyAbouts.Add(companyAbout);
                }
                bubucontext.SaveChanges();
                result = true;
            }
            return result;
        }

        public CompanyInformation GetCompanyInformationByCompanyId(int companyId)
        {
            return bubucontext.CompanyInformations.Where(a => a.CompanyId == companyId && a.IsActive == true).FirstOrDefault();
        }
    }
}
