using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Net;

namespace Bubu_WebApp
{
    public static class HelperFunction
    {
        #region Variable

        private static string v_LogFormat;
        private static StreamWriter v_sw;
        private static bool v_bool_ContentExist;
        private static string v_str_LogFileName = "KSCReconcile_DS_" + DateTime.Now.ToString("yyyyMMdd") + ".log"; // ASIM ALI <VSI> - 20140822
        private static DateTime v_dte_CurrentDate;
        private static int v_int_DefaultDaySpan = 7;

        #endregion

        #region Methods

        public static void Func_InfoLog(string p_InfoMsg)
        {
            try
            {
                string v_log_file_path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Log\");
                if (!Directory.Exists(v_log_file_path))
                {
                    Directory.CreateDirectory(v_log_file_path);
                    v_log_file_path = Path.Combine(v_log_file_path + v_str_LogFileName);
                    Func_Write_Log_File(p_InfoMsg, v_log_file_path);
                }
                else
                {
                    // <START> - ASIM ALI <VSI> - 20140822

                    v_dte_CurrentDate = DateTime.Now;

                    foreach (FileInfo v_obj_FileInformation in new DirectoryInfo(v_log_file_path).GetFiles())
                    {
                        TimeSpan v_obj_Difference;
                        v_obj_Difference = v_dte_CurrentDate - v_obj_FileInformation.LastWriteTime;
                        //Delete Files from Folder
                        if (v_obj_Difference.Days >= v_int_DefaultDaySpan)
                        {
                            File.Delete(v_obj_FileInformation.FullName);
                        }
                    }

                    // <END> - ASIM ALI <VSI> - 20140822

                    v_log_file_path = Path.Combine(v_log_file_path + v_str_LogFileName);

                    if (File.Exists(v_log_file_path))  //ASIM ALI <VSI> - 20140822
                    {
                        // <START> - ASIM ALI <VSI> - 20140725
                        using (StreamReader sr = new StreamReader(v_log_file_path))
                        {
                            string v_str_Contents = sr.ReadToEnd();
                            if (v_str_Contents.Length == 0)
                                v_bool_ContentExist = true;
                            else
                                v_bool_ContentExist = false;
                        }
                        // <END> - ASIM ALI <VSI> - 20140725
                    }
                    Func_Write_Log_File(p_InfoMsg, v_log_file_path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Func_Write_Log_File(string p_InfoMsg, string v_log_file_path)
        {
            v_sw = new StreamWriter(v_log_file_path, true);
            try
            {
                v_LogFormat = DateTime.Now.Date.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss").ToString() + " : ";
                // <START> - ASIM ALI <VSI> - 20140725
                if (v_bool_ContentExist)
                {
                    v_sw.WriteLine("‘**************************************************************’\r\n" + v_LogFormat + p_InfoMsg);
                }
                else
                    v_sw.WriteLine(v_LogFormat + p_InfoMsg);
                // <END> - ASIM ALI <VSI> - 20140725
            }
            catch (Exception e)
            {
                v_sw = new StreamWriter(v_log_file_path, true);
                v_sw.WriteLine(v_LogFormat + e.Message);
            }
            finally
            {
                v_sw.Flush();
                v_sw.Close();
            }
        }

        public static string Func_FormatMuntipleEmailAddresses(string p_emailAddresses)
        {
            var v_delimiters = new[] { ',', ';' };

            var v_addresses = p_emailAddresses.Split(v_delimiters, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(",", v_addresses);
        }

        public static void Func_Delete_Files(string v_dir_path)
        {
            if (Directory.Exists(v_dir_path))
            {
                string[] filePaths = Directory.GetFiles(v_dir_path);
                foreach (string filePath in filePaths)
                {
                    File.Delete(filePath);
                }
            }
        }

        public static void Func_CreateDirectory(string v_dir_path)
        {
            if (!Directory.Exists(v_dir_path))
            {
                Directory.CreateDirectory(v_dir_path);
            }
        }

        public static void Func_CompressFile(string p_directorypth)
        {
            DirectoryInfo v_di = new DirectoryInfo(p_directorypth);
            FileInfo[] v_fio = v_di.GetFiles("*.xls");

            foreach (FileInfo v_fi in v_di.GetFiles("*.xls"))
            {
                // Get the stream of the source file.
                using (FileStream v_infile = v_fi.OpenRead())
                {
                    // Prevent compressing hidden and 
                    // already compressed files.
                    if ((File.GetAttributes(v_fi.FullName)
                        & FileAttributes.Hidden)
                        != FileAttributes.Hidden & v_fi.Extension != ".zip")
                    {
                        // Create the compressed file.
                        using (FileStream v_outfile =
                                    File.Create(v_fi.FullName + ".zip"))
                        {
                            using (GZipStream Compress =
                                new GZipStream(v_outfile,
                                CompressionMode.Compress))
                            {
                                // Copy the source file into 
                                // the compression stream.
                                v_infile.CopyTo(Compress);
                            }
                        }
                    }
                }
            }
        }

        public static string Func_CompressFile(string p_directorypth, string p_fileexttocompress, string p_filename, string p_str_extract_path)
        {
            //using (ZipArchive archive = ZipFile.Open(p_directorypth.Replace("." + p_fileexttocompress, ".zip"), ZipArchiveMode.Create))
            //{
            //    archive.CreateEntryFromFile(p_directorypth, p_filename);
            //}
            return p_directorypth.Replace("." + p_fileexttocompress, ".zip");
        }

        public static void Func_CompressFile_CSV(string p_filename, string p_directorypth)
        {
            //using (ZipArchive archive = ZipFile.Open(p_directorypth.Replace(".csv", ".zip"), ZipArchiveMode.Create))
            //{
            //    archive.CreateEntryFromFile(p_directorypth, p_filename);
            //}
        }

        public static string Func_Decrypt(string p_input)
        {
            return p_input;
            byte[] v_inputarray = Convert.FromBase64String(p_input);
            string ACCESS_KEY = "1PR5AVJZ4SCYMICROS@RECON";
            TripleDESCryptoServiceProvider v_tripledes = new TripleDESCryptoServiceProvider();
            v_tripledes.Key = UTF8Encoding.UTF8.GetBytes(ACCESS_KEY);
            v_tripledes.Mode = CipherMode.ECB;
            v_tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform v_ctransform = v_tripledes.CreateDecryptor();
            byte[] resultArray = v_ctransform.TransformFinalBlock(v_inputarray, 0, v_inputarray.Length);
            v_tripledes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string Encrypt(string p_input)
        {
            return p_input;
            byte[] v_inputarray = UTF8Encoding.UTF8.GetBytes(p_input);
            string ACCESS_KEY = "1PR5AVJZ4SCYMICROS@RECON";
            TripleDESCryptoServiceProvider v_tripledes = new TripleDESCryptoServiceProvider();
            v_tripledes.Key = UTF8Encoding.UTF8.GetBytes(ACCESS_KEY);
            v_tripledes.Mode = CipherMode.ECB;
            v_tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform v_ctransform = v_tripledes.CreateEncryptor();
            byte[] resultArray = v_ctransform.TransformFinalBlock(v_inputarray, 0, v_inputarray.Length);
            v_tripledes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static void Func_SendFiletoFTPServer(string p_str_ftp_location, string v_str_filename, string v_str_poslog_file_path, string v_str_user, string v_str_password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(p_str_ftp_location + @"/" + v_str_filename); //Should come from config
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(v_str_user, v_str_password);

            // Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader(Path.Combine(v_str_poslog_file_path + v_str_filename));
            //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            byte[] fileContents = File.ReadAllBytes(v_str_poslog_file_path + v_str_filename);
            //sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();
        }

        public static string  Dateformat(string date)
        {
            return date != "" ? String.Format("{0:MM/dd/yyyy}", date) : "";
        }
        public static string Dateformat(DateTime date)
        {
            return date != null ? String.Format("{0:MM/dd/yyyy}", date) : "";
        }

        public static string EncryptData(string data)
        {
            return data;
        }
        public static string DecryptData(string data)
        {
            return data;
        }

        #endregion
    }
}