using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EFDocumentUpload
    {
        public BubuEntities bubucontext;
        bool result = false;
        public EFDocumentUpload()
        {
            bubucontext = new BubuEntities();
        }
        public List<DocumentFormatAllow> getAllDocumentFormatAllow()
        {
            using (bubucontext)
            {
                return bubucontext.DocumentFormatAllows.Where(a => a.IsActive == true).ToList();
            }

        }
        public List<DocumentFormatAllow> getAllDocumentFormatAllowByDocumentType(int documentCategoryId)
        {
            using (bubucontext)
            {
                return bubucontext.DocumentFormatAllows.Where(a => a.DocumentCategoryId == documentCategoryId
                    && a.IsActive == true).ToList();
            }

        }
        public List<DocumentUpload> getAllDocumentsByUserId(int userid, ref string returnMessage)
        {
            using (bubucontext)
            {
                return bubucontext.DocumentUploads.Include("DocumentCategory")
                    .Where(a => a.Userid == userid && a.IsActive == true).ToList();
            }
        }
        public List<DocumentCategory> getAllDocumentCategories()
        {
            using (bubucontext)
            {
                return bubucontext.DocumentCategories.Where(a => a.IsActive == true).ToList();
            }
        }
        public bool SaveDocumentUpload(DocumentUpload documentUploadObject, ref string returnMessage)
        {
            using (bubucontext = new BubuEntities())
            {

                if (documentUploadObject.UploadDocumentId > 0)
                {
                    // bubucontext.Entry(documentUploadObject).State = EntityState.Modified;
                    DocumentUpload DocUploadOBj = bubucontext.DocumentUploads.Where(a => a.UploadDocumentId == documentUploadObject.UploadDocumentId).FirstOrDefault();
                    if (DocUploadOBj != null && DocUploadOBj.UploadDocumentId > 0)
                    {
                        DocUploadOBj.Description = documentUploadObject.Description;
                        DocUploadOBj.DocumentCategoryid = documentUploadObject.DocumentCategoryid;
                        if (documentUploadObject.ContentData != null && documentUploadObject.format != "")
                        {
                            DocUploadOBj.ContentData = documentUploadObject.ContentData;
                            DocUploadOBj.ContentType = documentUploadObject.ContentType;
                            DocUploadOBj.format = documentUploadObject.format;
                            DocUploadOBj.fileName = documentUploadObject.fileName;
                        }
                    }
                }
                else
                {
                    bubucontext.Entry(documentUploadObject).State = EntityState.Added;
                    bubucontext.DocumentUploads.Add(documentUploadObject);
                }
                bubucontext.SaveChanges();
            }
            return true;
        }

        public bool DeleteDocumentUpload(int documentUploadId, ref string returnMessage)
        {
            using (bubucontext)
            {
                DocumentUpload documentUploadObj = bubucontext.DocumentUploads.Where(a => a.UploadDocumentId == documentUploadId).FirstOrDefault();
                if (documentUploadObj != null && documentUploadObj.UploadDocumentId > 0)
                {
                    documentUploadObj.IsActive = false;
                    bubucontext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public DocumentUpload GetdocumentByUploadDocumentId(int UploadDocumentId, ref string returnMessage)
        {
            using (bubucontext)
            {
                return bubucontext.DocumentUploads.Where(a => a.UploadDocumentId == UploadDocumentId).FirstOrDefault();
            }
        }

        public List<DocumentUpload> GetAllDocumentByUserIdAndDocumentType(int documentTypeId, int userid)
        {
            using (bubucontext)
            {
                return bubucontext.DocumentUploads.Where(a => a.DocumentCategoryid == documentTypeId &&
                    a.Userid == userid).ToList();
            }
        }

    }
}
