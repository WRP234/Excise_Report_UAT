using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;




namespace Report_XCS.Models
{
    public class BDInvestigateDetailgetByCon
    {
        internal string getReportTempPath()

        {
            var db = new Configs();
            return db.GetIP;

        }

        internal DataTable GetInvestigateDetailgetByCon(InvestigateDetailgetByConReq mdreq)
        {
            var cc = new Configs();
            try
            {
                JObject jsonobj = (JObject)JToken.FromObject(mdreq);
                 var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + cc.GetIP + ":"+cc.GetInvestigate+"/XCS60/InvestigateDetailgetByCon");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonobj);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                string result = "";
                using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }           
                var x = JsonConvert.DeserializeObject<MDInvestigateDetailgetByCon>(result);
                //JObject jsonobj = (JObject)JToken.FromObject(mdreq);
                //var client = new RestClient("http://" + cc.GetIP + ":8888/XCS60/InvestigateDetailgetByCon");
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("Postman-Token", "0d7a7694-f469-49b6-b944-8bbfe790bbec");
                //request.AddHeader("Cache-Control", "no-cache");
                //request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("undefined", jsonobj.ToString(), RestSharp.ParameterType.RequestBody);
                //IRestResponse response = client.Execute(request);

                //IRestResponse<List<MDInvestigateDetailgetByCon>> response1 = client.Execute<List<MDInvestigateDetailgetByCon>>(request);


                DataReport.InvestigateDetailgetByConDataTable dts = new DataReport.InvestigateDetailgetByConDataTable();
                DataReport.InvestigateDetailgetByConRow drDetail;

                if (x == null)
                {
                    return null;
                }
                else
                {
                    if (x != null)
                    {
                                drDetail = dts.NewInvestigateDetailgetByConRow();
                                drDetail.InvestigateCode = x.InvestigateCode;
                                drDetail.InvestigateSeq = x.InvestigateSeq;
                                drDetail.StationName = x.StationName;
                                drDetail.InvestigateDateStartEnd = string.Format("{0} ถึง {1}", x.InvestigateDateStart.ToString("dd MMMM yyyy", new CultureInfo("th-TH")), x.InvestigateDateEnd.ToString("dd MMMM yyyy", new CultureInfo("th-TH")));
                                drDetail.InvestigateDetail = x.InvestigateDetail;
                        string ConfidenceOfNews = "";
                        string ValueOfNews = "";
                        if (x.ConfidenceOfNews == "1")
                        {
                            ConfidenceOfNews = "ที่ผ่านมาเชื่อมั่นได้อย่างสมบูรณ์";
                        }
                        if (x.ConfidenceOfNews == "2")
                        {
                            ConfidenceOfNews = "ที่ผ่านมาเชื่อถือได้เป็นส่วนใหญ่";
                        }
                        if (x.ConfidenceOfNews == "3")
                        {
                            ConfidenceOfNews = "ที่ผ่านมาเชื่อถือไม่ได้เป็นส่วนใหญ่";
                        }
                        if (x.ConfidenceOfNews == "4")
                        {
                            ConfidenceOfNews = "ไม่สามารถตัดสินได้";
                        }
                        if (x.ValueOfNews=="A")
                        {
                            ValueOfNews = "รู้ว่าเป็นความจริงโดยปราศจากข้อสงสัย";
                        }
                        if (x.ValueOfNews == "B")
                        {
                            ValueOfNews = "ข่าวเป็นที่รู้จากแหล่งแต่ยังไม่ได้รายงานให้เจ้าหน้าที่";
                        }
                        if (x.ValueOfNews == "C")
                        {
                            ValueOfNews = "ข่าวไม่ได้เป็นที่รู้จากแหล่งแต่รู้มาจากผู้อื่นและได้มีการบันทึกไว้แล้ว";
                        }
                        if (x.ValueOfNews == "X")
                        {
                            ValueOfNews = "ไม่สามารถตัดสินได้";
                        }
                        drDetail.ConfidenceOfNews = string.Format("{0} / {1}", ConfidenceOfNews, ValueOfNews);
                                foreach (var Local in x.InvestigateDetailLocal)
                                {
                                    drDetail.InvestigateDetailLocal = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", Local.Location, Local.Address, Local.Village, Local.Building, Local.Room, Local.Alley, Local.Road, Local.SubDistrict, Local.District, Local.Province);
                                }

                                foreach (var st in x.InvestigateDetailStaff)
                                {
                                    if (st.ContributorID == 2)
                                    {
                                drDetail.InvestigateDetailStaff2 = string.Format("{0} {1} {2}", st.TitleName, st.FirstName, st.LastName);
                                drDetail.PositionName2 = st.PositionName;
                            }
                                    if (st.ContributorID == 1)
                                    {
                                drDetail.InvestigateDetailStaff1 = string.Format("{0} {1} {2}", st.TitleName, st.FirstName, st.LastName);
                                drDetail.PositionName1 = st.PositionName;
                            }
                            if (st.ContributorID == 3)
                            {
               
                                drDetail.InvestigateDetailStaff3 = string.Format("{0} {1} {2}", st.TitleName, st.FirstName, st.LastName);
                                drDetail.PositionName3 = st.PositionName;
                            }
                        }

                                if (!string.IsNullOrEmpty(x.InvestigateCode))
                                {
                                    InvestigategetByConReq md = new InvestigategetByConReq();
                            md.InvestigateCode = x.InvestigateCode;
                            //jsonobj = (JObject)JToken.FromObject(md);
                            //client = new RestClient("http://" + cc.GetIP + ":8888/XCS60/InvestigategetByCon");
                            //request = new RestRequest(Method.POST);
                            //request.AddHeader("Postman-Token", "0d7a7694-f469-49b6-b944-8bbfe790bbec");
                            //request.AddHeader("Cache-Control", "no-cache");
                            //request.AddHeader("Content-Type", "application/json");
                            //request.AddParameter("undefined", jsonobj.ToString(), RestSharp.ParameterType.RequestBody);

                            //response = client.Execute(request);

                            //IRestResponse<List<MDInvestigategetByCon>> responseCompare = client.Execute<List<MDInvestigategetByCon>>(request);
                            jsonobj = (JObject)JToken.FromObject(md);
                                    httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + cc.GetIP + ":"+cc.GetInvestigate + "/XCS60/InvestigategetByCon");
                                    httpWebRequest.ContentType = "application/json";
                                    httpWebRequest.Method = "POST";

                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                    {
                                        //string json = jsonobj;

                                        streamWriter.Write(jsonobj);
                                        streamWriter.Flush();
                                        streamWriter.Close();
                                    }
                            result = "";
                            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                            {
                                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                {
                                    result = streamReader.ReadToEnd();
                                }
                            }
                               
                                    
                                    var responseCompare = JsonConvert.DeserializeObject<List<MDInvestigategetByCon>>(result);
                                    foreach (var dataMain in responseCompare.ToList())
                                    {
                                        if (!string.IsNullOrEmpty(dataMain.InvestigateCode))
                                        {
                                            drDetail.InvestigateNo = dataMain.InvestigateNo;
                                            drDetail.Subject = dataMain.Subject;
                                            drDetail.DateStartDate = dataMain.DateStart.Day.ToString();
                                            drDetail.DateStartMonth = dataMain.DateStart.ToString("MMMM", new CultureInfo("th-TH"));
                                            drDetail.DateStartYear = dataMain.DateStart.ToString("yyyy", new CultureInfo("th-TH"));

                                        }
                                        foreach (var datadetail in dataMain.InvestigateDetail)
                                        {
                                            if (datadetail.InvestigateDetailID != 0)
                                            {
                                                drDetail.InvestigateDetail = datadetail.InvestigateDetail;
                                            }

                                        }

                                    }


                                }


                                dts.Rows.Add(drDetail);
                            }
                        
                    
                }

                return dts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}