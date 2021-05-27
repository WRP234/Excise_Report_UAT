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
    public partial class ILG60_00_12_004 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filename = "ILG60-00-12-004";
                string para1 = "getMonthfrom1";
                string para2 = "getMonthfrom2";
                string para3 = "getMonthfrom3";
                string para4 = "getMonthto1";
                string para5 = "getMonthto2";
                string para6 = "getMonthto3";
                string para7 = "getOffcode1";
                string para8 = "getOffcode2";
                string para9 = "getOffcode3";
                try
                {
                    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string requestFromPost = reader.ReadToEnd();

                    if (requestFromPost != null)
                    {
                        var js = JsonConvert.DeserializeObject<ILG60_00_12_004Json>(requestFromPost);
                        if (js != null)
                        {

                            ReportDocument rpt = new ReportDocument();
                            rpt.Load(Server.MapPath("~/ReportModel/" + filename + ".rpt"));
                            rpt = new cryslogin().Getsublogin(rpt);
                            rpt.SetParameterValue(para1, js.getMonthfrom1.ToString());
                            rpt.SetParameterValue(para2, js.getMonthfrom2.ToString());
                            rpt.SetParameterValue(para3, js.getMonthfrom3.ToString());
                            rpt.SetParameterValue(para4, js.getMonthto1.ToString());
                            rpt.SetParameterValue(para5, js.getMonthto2.ToString());
                            rpt.SetParameterValue(para6, js.getMonthto3.ToString());
                            rpt.SetParameterValue(para7, js.getOffcode1.ToString());
                            rpt.SetParameterValue(para8, js.getOffcode2.ToString());
                            rpt.SetParameterValue(para9, js.getOffcode3.ToString());

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
                            Response.Write("getMonthfrom1 : "+ js.getMonthfrom1.ToString());
                            Response.Write("getMonthfrom2 : " + js.getMonthfrom2.ToString());
                            Response.Write("getMonthfrom3 : " + js.getMonthfrom3.ToString());
                            Response.Write("getMonthto1 : " + js.getMonthto1.ToString());
                            Response.Write("getMonthto2 : " + js.getMonthto2.ToString());
                            Response.Write("getMonthto3 : " + js.getMonthto3.ToString());
                            Response.Write("getOffcode1 : " + js.getOffcode1.ToString());
                            Response.Write("getOffcode2 : " + js.getOffcode2.ToString());
                            Response.Write("getOffcode3 : " + js.getOffcode3.ToString());
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