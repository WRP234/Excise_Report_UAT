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
    public partial class ILG60_00_06_002 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string filename = "ILG60-00-06-002";
            //    try
            //    {
            //        StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
            //        string requestFromPost = reader.ReadToEnd();
            //        OperModels oper = new OperModels();

            //        if (requestFromPost != null)
            //        {
            //            var js = JsonConvert.DeserializeObject<P031models>(requestFromPost);

            //            if (js.IndictmentID > 0 & js.CompareID > 0)
            //            {
            //                var m1 = new CompareArrestgetByIndictmentIDJcon();
            //                m1.IndictmentID = js.IndictmentID;
            //                var m2 = new ComparegetByConJson();
            //                m2.CompareID = js.CompareID;
            //                DataSet dtt1 = oper.CompareArrestgetByIndictmentID(m1);
            //                DataSet dtt2 = oper.ComparegetByCon(m2);
            //                DataSet dtt3 = oper.ViewImageSignature();
            //                if (dtt1 != null & dtt2 != null)
            //                {
            //                    dtt1.Tables.Add(dtt2.Tables["ComparegetByCon"].Copy());
            //                    ReportDocument rpt = new ReportDocument();
            //                    rpt.Load(Server.MapPath("~/ReportModel/"+ filename + ".rpt"));
            //                    rpt.SetDataSource(dtt1);

            //                    var s = new cryslogin().exportpdf(rpt);
            //                    if (s != null)
            //                    {
            //                        byte[] b = new byte[s.Length];
            //                        s.Read(b, 0, Convert.ToInt32(s.Length.ToString()));
            //                        //   s.Close();
            //                        //--------------------------------------------
            //                        Byte[] inArray = new Byte[(int)s.Length];
            //                        Char[] outArray = new Char[(int)(s.Length * 1.34)];
            //                        s.Read(inArray, 0, (int)s.Length);
            //                        Convert.ToBase64CharArray(inArray, 0, inArray.Length, outArray, 0);
            //                        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            //                        string targetFileName = Request.PhysicalApplicationPath + "Reports\\TempReports\\" + filename + "_" + (new Random()).Next() + ".pdf";

            //                        rpt.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            //                        rpt.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            //                        diskOpts.DiskFileName = targetFileName;
            //                        rpt.ExportOptions.DestinationOptions = diskOpts;
            //                        // Export report ... Server-Side.
            //                        rpt.Export();
            //                        FileInfo file = new FileInfo(targetFileName);
            //                        Response.ClearContent();
            //                        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            //                        Response.AddHeader("Content-Length", file.Length.ToString());
            //                        Response.ContentType = "application/pdf";
            //                        Response.TransmitFile(file.FullName);
            //                        Response.End();
            //                    }
            //                }
            //                else
            //                {
            //                    Response.ClearContent();
            //                    Response.ContentType = "application/json";
            //                    Response.AddHeader("Authorization", "Basic ");
            //                    Response.Write("{\"Status\":\"ไม่พบข้อมูล\"}");
            //                    Response.End();
            //                }
            //            }

            //            Response.ClearContent();
            //            Response.ContentType = "application/json";
            //            Response.AddHeader("cache-control", "no-cache");
            //            Response.AddHeader("Content-Type", "application/json");
            //            Response.Write("{\"Status\":\"ส่งอะไรมาหรอจ๊ะ\"}");
            //            Response.End();


            //        }
            //    }
            //    catch (System.Threading.ThreadAbortException)
            //    {

            //    }
            //    catch (Exception ex)
            //    {
            //        Response.ClearContent();
            //        Response.ContentType = "application/json";
            //        Response.AddHeader("cache-control", "no-cache");
            //        Response.AddHeader("Content-Type", "application/json");
            //        Response.Write("{\"Status\":" + ex.Message + "}");
            //        Response.End();
            //    }
            //}
            if (!IsPostBack)
            {
                string filename = "ILG60-00-06-002";
                string para = "receipt_no";
                try
                {
                    StreamReader reader = new StreamReader(HttpContext.Current.Request.InputStream);
                    string requestFromPost = reader.ReadToEnd();

                    if (requestFromPost != null)
                    {
                        var js = JsonConvert.DeserializeObject<ILG60_00_06_002Json>(requestFromPost);
                        var js2 = JsonConvert.DeserializeObject<RequestViewImageSignature>(requestFromPost);
                        if (js != null)
                        {
                            if (js.receipt_no.Length > 0)
                            {
                                DataSet dt = new DataSet();
                               var dt1 = new cryslogin().GET06_002(js.receipt_no);
                                var dt2 = new OperModels().ViewImageSignature(js2);
                                dt.Tables.Add(dt1.Tables["ilg61_00_06_002"].Copy());
                                dt.Tables.Add(dt2.Tables["ViewImageSignature"].Copy());
                                ReportDocument rpt = new ReportDocument();
                                rpt.Load(Server.MapPath("~/ReportModel/" + filename + ".rpt"));
                                //rpt = new cryslogin().Getsublogin(rpt);
                                rpt.SetDataSource(dt);
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
                                Response.Write("{\"Status\":\"ส่งอะไรมาหรอจ๊ะ\"}");
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
                    Response.ClearContent();
                    Response.ContentType = "application/json";
                    Response.AddHeader("cache-control", "no-cache");
                    Response.AddHeader("Content-Type", "application/json");
                    Response.Write("{\"Status\":" + ex.Message + "}");
                    Response.End();
                }

            }
        }
    }
}