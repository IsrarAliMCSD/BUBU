using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace Bubu_WebApp
{
    public class EmailUtility
    {
        #region Variable

        MailMessage v_email_msg;
        SmtpClient v_smptp_client;

        #endregion

        public bool sendEmail(string[] sendTo, string[] cc, string subject, string message)
        {

            try
            {
                string v_smtp_server = "smtp.gmail.com";// ConfigurationManager.AppSettings["KSCReconcile_DS_smtp"].ToString();
                string v_mail_from = "strangerboy499@gmail.com"; // ConfigurationManager.AppSettings["Mail_From"].ToString();
                string v_username = "strangerboy499@gmail.com";// "strangerboy499@gmail.com"; //ConfigurationManager.AppSettings["User_Name"].ToString();
                string v_password = "Karachipakistan"; //"Karachipakistan";// ConfigurationManager.AppSettings["Password"].ToString();
                v_email_msg = new MailMessage(v_mail_from, string.Join(";", sendTo));
                v_email_msg.Subject = subject;
                v_email_msg.Body = message;
                v_email_msg.IsBodyHtml = true;
                v_smptp_client = new SmtpClient(v_smtp_server);
                if (v_username.Trim() == string.Empty || v_username.Trim() == "" || v_password == string.Empty || v_password == "")
                    v_smptp_client.UseDefaultCredentials = true;
                else
                {
                    // v_password = HelperFunction.Func_Decrypt(v_password);
                    v_smptp_client.Credentials = new System.Net.NetworkCredential(v_username, v_password);
                }
                v_smptp_client.EnableSsl = true;
                v_smptp_client.Port = 587;
                v_smptp_client.Send(v_email_msg);
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
                return true;
            }
            catch (Exception e)
            {
                HelperFunction.Func_InfoLog("Exception :" + e.StackTrace.ToString() + e.Source.ToString() + e.Message.ToString());
                return false;
            }
            finally
            {
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
            }

        }
        public bool Func_SendMail(StringBuilder p_Email_Body, string p_email_list, DataRow p_dtb_control_row, DataRow p_dtr_report_detail, string p_excel_path, string p_chart_path)
        {
            try
            {
                string v_smtp_server = ConfigurationManager.AppSettings["KSCReconcile_DS_smtp"].ToString();
                string v_mail_from = ConfigurationManager.AppSettings["Mail_From"].ToString();
                string v_username = ConfigurationManager.AppSettings["User_Name"].ToString();
                string v_password = ConfigurationManager.AppSettings["Password"].ToString();
                if (p_email_list.Contains(";"))
                    p_email_list = HelperFunction.Func_FormatMuntipleEmailAddresses(p_email_list);
                v_email_msg = new MailMessage(v_mail_from, p_email_list);
                v_email_msg.Subject = p_dtr_report_detail["REPORT_SUBJECT"].ToString().Trim().Replace("{SRC}", p_dtb_control_row["SRC_SYSTEM"].ToString()).Replace("{TAR}", p_dtb_control_row["TARGET_SYSTEM"].ToString()).ToString().Replace("{CID}", p_dtb_control_row["CONTROL_ID"].ToString()).Trim();
                v_email_msg.IsBodyHtml = true;
                v_email_msg.Body = p_Email_Body.ToString();
                if ((p_chart_path != string.Empty || p_chart_path != "") && p_dtr_report_detail["INCLUDE_CHART"].ToString().Trim() == "Y")
                {
                    string v_image_path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Temp\");
                    string v_image_attachment_path = Path.Combine(v_image_path, p_chart_path);
                    Attachment v_image_inline = new Attachment(v_image_attachment_path);
                    string contentID = Path.GetFileName(v_image_attachment_path).Replace(".", "");
                    v_image_inline.ContentDisposition.Inline = true;
                    v_image_inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    v_image_inline.ContentId = contentID;
                    v_image_inline.ContentType.MediaType = "image/png";
                    v_image_inline.ContentType.Name = Path.GetFileName(v_image_attachment_path);
                    v_email_msg.Attachments.Add(v_image_inline);
                    v_email_msg.Body = v_email_msg.Body.Replace("@@IMAGE@@", "cid:" + contentID);
                }
                else
                {
                    v_email_msg.Body = v_email_msg.Body.Replace("@@IMAGE@@", "");
                    v_email_msg.Body = v_email_msg.Body.Replace("<font face=\"calibri\" size=\"3\"><p><strong>Reconciliation Statistics (Current): </strong></p></font> <p><img src=\"\" alt=\"\" width=\"780\" height=\"350\" /></p>", "");
                    v_email_msg.Body = v_email_msg.Body.Replace("<font face=\"calibri\" size=\"3\"><p><strong>Invenotry Statistics : </strong></p></font> <p><img src=\"\" alt=\"\" width=\"780\" height=\"350\" /></p>", "");
                }
                //checking if excel file created or not
                if (p_excel_path != string.Empty || p_excel_path != "")
                {
                    string[] v_arr_attach_paths = p_excel_path.Split(';');
                    foreach (string v_attach_path in v_arr_attach_paths)
                    {
                        Attachment v_excel_inline = new Attachment(v_attach_path);
                        string v_excel_contentid = Path.GetFileName(v_attach_path);
                        v_excel_inline.ContentId = v_excel_contentid;
                        v_excel_inline.ContentDisposition.DispositionType = DispositionTypeNames.Attachment;
                        v_excel_inline.ContentDisposition.Inline = false;
                        if (p_dtr_report_detail["COMPRESS_ATTACHMENT"].ToString().Trim() == "Y")
                            v_excel_inline.ContentType.MediaType = "application/zip";
                        else
                            v_excel_inline.ContentType.MediaType = "application/vnd.ms-excel";
                        v_excel_inline.ContentType.Name = Path.GetFileName(v_attach_path);
                        v_email_msg.Attachments.Add(v_excel_inline);
                    }
                }
                v_smptp_client = new SmtpClient(v_smtp_server);
                v_smptp_client.UseDefaultCredentials = false;
                if (v_username.Trim() == string.Empty || v_username.Trim() == "" || v_password == string.Empty || v_password == "")
                    v_smptp_client.UseDefaultCredentials = true;
                else
                {
                    v_password = HelperFunction.Func_Decrypt(v_password);
                    v_smptp_client.Credentials = new System.Net.NetworkCredential(v_username, v_password);
                }
                v_smptp_client.Send(v_email_msg);
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
                return true;
            }
            catch (Exception e)
            {
                HelperFunction.Func_InfoLog("Exception :" + e.StackTrace.ToString() + e.Source.ToString() + e.Message.ToString());
                return false;
            }
            finally
            {
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
            }
        }

        public bool Func_SendMail(string p_recipients, string p_subject, string p_Details)
        {
            try
            {
                string v_smtp_server = ConfigurationManager.AppSettings["KSCReconcile_DS_smtp"].ToString();
                string v_mail_from = ConfigurationManager.AppSettings["Mail_From"].ToString();
                string v_username = ConfigurationManager.AppSettings["User_Name"].ToString();
                string v_password = ConfigurationManager.AppSettings["Password"].ToString();
                v_email_msg = new MailMessage(v_mail_from, p_recipients);
                v_email_msg.Subject = p_subject;
                v_email_msg.Body = p_Details;
                v_smptp_client = new SmtpClient(v_smtp_server);
                if (v_username.Trim() == string.Empty || v_username.Trim() == "" || v_password == string.Empty || v_password == "")
                    v_smptp_client.UseDefaultCredentials = true;
                else
                {
                    // v_password = HelperFunction.Func_Decrypt(v_password);
                    v_smptp_client.Credentials = new System.Net.NetworkCredential(v_username, v_password);
                }
                v_smptp_client.Send(v_email_msg);
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
                return true;
            }
            catch (Exception e)
            {
                HelperFunction.Func_InfoLog("Exception :" + e.StackTrace.ToString() + e.Source.ToString() + e.Message.ToString());
                return false;
            }
            finally
            {
                v_email_msg.Dispose();
                v_smptp_client.Dispose();
            }
        }

    }
}