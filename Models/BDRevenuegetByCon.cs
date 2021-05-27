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
    public class BDRevenuegetByCon
    {
        public DataTable RevenuegetByCon(RevenuegetByConModel model)
        {
            var cc = new Configs();
            try
            {

                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + cc.GetIP + ":"+cc.GetRevenue+"/XCS60/RevenuegetByCon");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string json = jsonobj;

                    streamWriter.Write(jsonobj);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                var response2 = JsonConvert.DeserializeObject<List<RevenuegetByConModelS>>(result);

                /*JObject jsonobj = (JObject)JToken.FromObject(model);
               
                var client = new RestClient("http://" + cc.GetIP + ":8084/XCS60/RevenuegetByCon");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Postman-Token", "0d7a7694-f469-49b6-b944-8bbfe790bbec");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", jsonobj.ToString(), RestSharp.ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                IRestResponse<List<RevenuegetByConModelS>> response1 = client.Execute<List<RevenuegetByConModelS>>(request);*/


                DataReport.RevenuegetByConDataTable dts = new DataReport.RevenuegetByConDataTable();
                DataReport.RevenuegetByConRow dr2;

                if (response2.ToList().Count==0)
                {
                    return null;
                }
                else
                {
                    if (response2.ToList() != null)
                    {
                        foreach (var x in response2.ToList())
                        {
                            if (x.RevenueID != 0)
                            {
                                dr2 = dts.NewRevenuegetByConRow();
                                dr2.RevenueCode = x.RevenueCode;
                                dr2.StationName = x.StationName;
                                dr2.RevenueNo = x.RevenueNo;
                                dr2.RevenueDate = x.RevenueDate.ToString("dd MMMM yyyy", new CultureInfo("th-TH"));
                                dr2.InformTo = x.InformTo;
                                dr2.ResultCount = x.ResultCount.ToString();

                                dr2.TitleNameFull20 = string.Empty;
                                dr2.TitleNameFull36 = string.Empty;
                                dr2.ReceiptNo = string.Empty;
                                double totalFine = 0;
                                string ReceiptNo = string.Empty;
                                foreach (var x1 in x.RevenueDetail)
                                {
                                    if (x1.CompareReceiptID != 0)
                                    {
                                        jsonobj = (JObject)JToken.FromObject(model);
                                        httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + cc.GetIP + ":"+cc.GetRevenue+"/XCS60/RevenueComparegetByCompareReceiptID");
                                        httpWebRequest.ContentType = "application/json";
                                        httpWebRequest.Method = "POST";

                                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                        {
                                            //string json = jsonobj;

                                            streamWriter.Write(jsonobj);
                                            streamWriter.Flush();
                                            streamWriter.Close();
                                        }

                                        httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                        result = "";
                                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                        {
                                            result = streamReader.ReadToEnd();
                                        }
                                        var responseCompare = JsonConvert.DeserializeObject<List<RevenueComparegetByCompareReceiptIDModel>>(result);
                                        //RevenueCompareDetailReceiptPara md = new RevenueCompareDetailReceiptPara();
                                        //md.CompareReceiptID = x1.CompareReceiptID;
                                        //jsonobj = (JObject)JToken.FromObject(md);
                                        //// client = new RestClient("http://103.233.193.62:8084/XCS60/RevenueComparegetByCompareReceiptID");
                                        //client = new RestClient("http://" + cc.GetIP + ":8084/XCS60/RevenueComparegetByCompareReceiptID");
                                        //request = new RestRequest(Method.POST);
                                        //request.AddHeader("Postman-Token", "0d7a7694-f469-49b6-b944-8bbfe790bbec");
                                        //request.AddHeader("Cache-Control", "no-cache");
                                        //request.AddHeader("Content-Type", "application/json");
                                        //request.AddParameter("undefined", jsonobj.ToString(), RestSharp.ParameterType.RequestBody);
                                        //response = client.Execute(request);

                                        //IRestResponse<List<RevenueComparegetByCompareReceiptIDModel>> responseCompare = client.Execute<List<RevenueComparegetByCompareReceiptIDModel>>(request);
                                        foreach (var dataMain in responseCompare.ToList())
                                        {
                                            if (dataMain.CompareID != 0)
                                            {
                                                foreach (var RCPD in dataMain.RevenueCompareDetail)

                                                {

                                                    if (RCPD.CompareDetailID != 0)
                                                    {
                                                        foreach (var RCPDReceipt in RCPD.RevenueCompareDetailReceipt)
                                                        {
                                                            totalFine += RCPDReceipt.TotalFine;
                                                            ReceiptNo += RCPDReceipt.ReceiptNo + ",";
                                                        }
                                                    }

                                                }


                                            }
                                        }


                                    }

                                }

                                foreach (var Rt in x.RevenueStaff)
                                {
                                    dr2.PositionName = string.Empty;

                                    if (Rt.ContributorID == 20)
                                    {
                                        dr2.TitleNameFull20 = string.Format("{0} {1} {2} {3} ", Rt.TitleName, Rt.FirstName, Rt.LastName, Rt.PositionName);
                                    }
                                    if (Rt.ContributorID == 36)
                                    {
                                        dr2.TitleNameFull36 = string.Format("( {0} {1} {2} )", Rt.TitleName, Rt.FirstName, Rt.LastName);
                                        dr2.PositionName = Rt.PositionName;
                                    }
                                }
                                if (ReceiptNo!="")
                                {
                                    dr2.ReceiptNo = ReceiptNo.Remove(ReceiptNo.Length - 1, 1).ToString();
                                }
                                    
                                
                                
                                    dr2.TotalFine = totalFine.ToString();
                                
                                if (totalFine > 0)
                                {
                                    dr2.TotalFine40 = (totalFine * 0.4).ToString();
                                    dr2.TotalFine60 = (totalFine * 0.6).ToString();
                                }
                                

                                   
                                    dts.Rows.Add(dr2);
                                

                                        
                                
                            }
                        }
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

        internal string getReportTempPath()

        {
            var cc = new Configs();
            return cc.GetIP;

        }
    }
}