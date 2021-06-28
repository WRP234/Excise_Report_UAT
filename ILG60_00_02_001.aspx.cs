using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using Report_XCS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_XCS
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ILG60_00_02_001 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filename = "ILG60-00-02-001";
                string para = "NoticeCode";
                try
                {
                    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string requestFromPost = reader.ReadToEnd();

                    if (requestFromPost != null)
                    {
                        var js = JsonConvert.DeserializeObject<Noticegetbyconmodel>(requestFromPost);
                        if (js != null)
                        {
                            if (js.NoticeCode != "")
                            {
                                ReportDocument rpt = new ReportDocument();
                                rpt.Load(Server.MapPath("~/ReportModel/" + filename + ".rpt"));
                                rpt = new cryslogin().Getsublogin(rpt);
                                rpt.SetParameterValue(para, js.NoticeCode.ToString());
                                //this.CrystalReportViewer1.ReportSource = rpt;
                                var s = new cryslogin().exportpdf(rpt);
                                if (s != null)
                                {
                                    byte[] b = new byte[s.Length];
                                    s.Read(b, 0, Convert.ToInt32(s.Length.ToString()));
                                    Byte[] inArray = new Byte[(int)s.Length];
                                    Char[] outArray = new Char[(int)(s.Length * 1.34)];
                                    s.Read(inArray, 0, (int)s.Length);
                                    Convert.ToBase64CharArray(inArray, 0, inArray.Length, outArray, 0);
                                    DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                                    string targetFileName = Request.PhysicalApplicationPath + "Reports\\TempReports\\" + filename + "_" + (new Random()).Next() + ".pdf";
                                    rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                                    rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                                    diskOpts.DiskFileName = targetFileName;
                                    rpt.ExportOptions.DestinationOptions = diskOpts;
                                    rpt.Export();
                                    FileInfo file = new FileInfo(targetFileName);
                                    Response.ClearContent();
                                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                                    Response.AddHeader("Content-Length", file.Length.ToString());
                                    Response.ContentType = "application/pdf";
                                    Response.TransmitFile(file.FullName);
                                    Response.End();
                                }
                            }
                            else
                            {
                                Response.ClearContent();
                                Response.ContentType = "application/json";
                                Response.AddHeader("cache-control", "no-cache");
                                Response.AddHeader("Content-Type", "application/json");
                                Response.Write("{\"Status\":\"ส่งอะไรมาอ่ะ......\"}");
                                Response.End();
                            }
                        }
                    }
                    Response.ClearContent();
                    Response.ContentType = "application/json";
                    Response.AddHeader("cache-control", "no-cache");
                    Response.AddHeader("Content-Type", "application/json");
                    Response.Write("{\"Status\":\"ไม่พบข้อมูล\"}");
                    Response.End();
                }
                catch (System.Threading.ThreadAbortException)
                {

                }
                catch (Exception ex)
                {
                   //Console.WriteLine(ex.StackTrace);

                    Response.ClearContent();
                    Response.ContentType = "application/json";
                    Response.AddHeader("cache-control", "no-cache");
                    Response.AddHeader("Content-Type", "application/json");
                    //Response.Write("{\"Status\":" + ex.Message + "}");
                    Response.Write("{\"Status123\":" + ex.StackTrace + ex.Message + "}");
                    Response.End();
                }

            }
        }
    }
}