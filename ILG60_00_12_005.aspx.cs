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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report_XCS
{
    public partial class ILG60_00_12_005 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filename = "ILG60-00-12-005";
                string para1 = "StartDate";
                string para2 = "EndDate";
                string para3 = "OfficeCode1";
                string para4 = "OfficeCode2";
                string para5 = "OfficeCode3";
                try
                {
                    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string requestFromPost = reader.ReadToEnd();

                    if (requestFromPost != null)
                    {
                        var js = JsonConvert.DeserializeObject<ILG60_00_12_005Json>(requestFromPost);
                        if (js != null)
                        {

                            ReportDocument rpt = new ReportDocument();
                            rpt.Load(Server.MapPath("~/ReportModel/" + filename + ".rpt"));
                            rpt = new cryslogin().Getsublogin(rpt);
                            rpt.SetParameterValue(para1, js.StartDate.ToString());
                            rpt.SetParameterValue(para2, js.EndDate.ToString());
                            rpt.SetParameterValue(para3, js.OfficeCode1.ToString());
                            rpt.SetParameterValue(para4, js.OfficeCode2.ToString());
                            rpt.SetParameterValue(para5, js.OfficeCode3.ToString());

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
                            Response.Write("{\"Status\":\"parameter : \"}");
                            Response.Write("StartDate : " + js.StartDate.ToString() + "  ");
                            Response.Write("EndDate : " + js.EndDate.ToString() + "  ");
                            Response.Write("OfficeCode1 : " + js.OfficeCode1.ToString() + "  ");
                            Response.Write("OfficeCode2 : " + js.OfficeCode2.ToString() + "  ");
                            Response.Write("OfficeCode3 : " + js.OfficeCode3.ToString() + "  ");
                            Response.End();
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
                    Response.ClearContent();
                    Response.ContentType = "application/json";
                    Response.AddHeader("cache-control", "no-cache");
                    Response.AddHeader("Content-Type", "application/json");
                    Response.Write("{\"Status\":\"Server Error\"}");
                    Response.End();
                }

            }
        }
    }
}