using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
namespace Report_XCS.Models
{
    public class OperModels
    { 
        public DataSet TESTReport(testjson1 model)
        {
            DataSet dts = new DataSet();
            DataReport.TESTDataTable ts = new DataReport.TESTDataTable();
            DataReport.TESTRow tr;

          
           
            tr = ts.NewTESTRow();
            tr.Name = "TEST"+model.id;
            ts.Rows.Add(tr);
            dts.Tables.Add(ts);

            return dts;

        }
        public DataTable Lawsuitgetbycon(LawsuitArrestgetByConModels model)
        {
            
            try
            {
            
            var db = new Configs();
            JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetLawsuit + "/XCS60/LawsuitArrestgetByCon");
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
                var response2 = JsonConvert.DeserializeObject<List<LawsuitArrestgetByConJson>>(result);
                
            DataReport.LawsuitArrestgetByConDataTable dts = new DataReport.LawsuitArrestgetByConDataTable();
                DataReport.LawsuitArrestgetByConRow dr2;

                

                if (response2.ToList()==null)
            {
                return null;
            }
                else
                {
                    if (response2.ToList().Count > 0)
                    {
                        foreach (var x in response2.ToList())
                        {
                            if (x.ArrestCode!=null)
                            {
                                dr2 = dts.NewLawsuitArrestgetByConRow();
                                dr2.ArrestCode = x.ArrestCode;
                                
                                //Console.WriteLine(x.ArrestCode);
                                dr2.LawbreakerName = "";
                                foreach (var x1 in x.LawsuitArrestIndicment)
                                {
                                    foreach (var x2 in x1.Lawsuit)
                                    {
                                        if (x2.LawsuiteStaff != null)
                                        {
                                            foreach (var x3 in x2.LawsuiteStaff)
                                            {

                                                dr2._ls_OfficeName = x3.OfficeName;

                                            }
                                        }

                                        dr2.LawsuitStation = x2.LawsuitStation;
                                        dr2.LawsuitNo = x2.LawsuitNo;
                                        
                                        if (x2.LawsuitDate!=null)
                                        {
                                            dr2.LawsuitDate = DateTime.Parse(x2.LawsuitDate);
                                            dr2.Lawsuitday = DateTime.Parse(x2.LawsuitDate).ToString("dd");
                                            string[] mounth = { "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                                            string dayint = DateTime.Parse(x2.LawsuitDate).ToString("MM");
                                            dr2.Lawsuitmonth = mounth[int.Parse(dayint)];
                                            string sdadasd = DateTime.Parse(x2.LawsuitDate).ToString("yyyy");
                                            int fff = int.Parse(sdadasd) + 543;
                                            dr2.Lawsuityear = fff.ToString();
                                        }
                                        

                                        dr2.IsLawsuit = x2.IsLawsuit;
                                        dr2.ReasonDontLawsuit = x2.ReasonDontLawsuit;
                                    }
                                    foreach (var x4 in x1.LawsuitArrestIndicmentDetail)
                                    {
                                        //dr2.LawbreakerName = "";
                                        if (x4.LawsuitArrestLawbreaker != null)
                                        {                                            
                                            foreach (var x5 in x4.LawsuitArrestLawbreaker)
                                            {
                                                dr2.LawbreakerName += x5.LawbreakerTitleName + " " + x5.LawbreakerFirstName + " " + x5.LawbreakerMiddleName + " " + x5.LawbreakerLastName + " " + x5.LawbreakerOtherName+" ";
                                            }
                                        }
                                        if (x4.LawsuitArrestProductDetail != null)
                                        {
                                            dr2.ProductDesc = "";
                                            foreach (var x6 in x4.LawsuitArrestProductDetail)
                                            {
                                                dr2.ProductDesc += x6.ProductDesc + " " + x6.ProductSize + " " + x6.ProductSizeUnitName + " " + x6.ProductQty + " " + x6.ProductNetVolume + " " + x6.ProductNetVolumeUnit+"\n";
                                            }
                                        }

                                    }
                                    if (x1.LawsuitLawGuiltbase != null)
                                    {
                                        dr2.GuiltBaseName = "";
                                        foreach (var x7 in x1.LawsuitLawGuiltbase)
                                        {
                                            dr2.GuiltBaseName += x7.GuiltBaseName +" ";

                                        }
                                    }

                                }
                                foreach (var x1 in x.LawsuitArrestStaff)
                                {
                                    if (x1.ContributorID == 6)
                                    {
                                        dr2._las_Name = x1.TitleName + " " + x1.FirstName + " " + x1.LastName;
                                        dr2._las_PositionName = x1.PositionName;
                                        dr2._las_OfficeShortName = x1.OfficeShortName;
                                    }
                                    
                                    
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

        public DataSet ArrestgetByCon(ArrestgetByConmodel model)
        {
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetArrest + "/XCS60/ArrestgetByCon");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
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
                var response2 = JsonConvert.DeserializeObject<List<ArrestgetByCon>>(result);
                DataSet dtsr = new DataSet();
                DataReport.ArrestgetByConDataTable dts1 = new DataReport.ArrestgetByConDataTable();
                DataReport.ArrestgetByConRow dr1;
                DataReport.ArrestgetByCon2DataTable dts2 = new DataReport.ArrestgetByCon2DataTable();
                DataReport.ArrestgetByCon2Row dr2;
                if (response2 == null)
                {
                    return null;
                }
                else
                {
                    foreach (var x in response2.ToList())
                    {
                        dr1 = dts1.NewArrestgetByConRow();
                        dr1.ArrestCode = x.ArrestCode;
                        dr1.ArrestStation = x.ArrestStation;
                        dr1.ArrestDay = DateTime.Parse(x.ArrestDate).ToString("dd");                        
                        string[] mounth = { "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                        string dayint = DateTime.Parse(x.ArrestDate).ToString("MM");
                        dr1.ArrestMonth = mounth[int.Parse(dayint)];
                        string sdadasd = DateTime.Parse(x.ArrestDate).ToString("yyyy");
                        int fff = int.Parse(sdadasd) + 543;
                        dr1.ArrestYear = fff.ToString();
                        dr1.ArrestTime = x.ArrestTime;
                        dr1.Behaviour = x.Behaviour;
                        dr1.Testimony = x.Testimony;
                        if (x.ArrestStaff!=null)
                        {
                            dr1._AS_Nameup6 = "";
                            int u = 0;
                            foreach (var y in x.ArrestStaff)
                            {
                                
                                if (y.ContributorCode == 6)
                                {
                                    dr1._AS_Name6 = y.TitleName + " " + y.FirstName + " " + y.LastName;
                                    dr1._AS_PositionName = y.PositionName;
                                }
                                else if (y.ContributorCode != 6)
                                {
                                    if (u>0)
                                    {
                                        dr1._AS_Nameup6 += "และ ";
                                    }
                                    dr1._AS_Nameup6 += y.TitleName + " " + y.FirstName + " " + y.LastName +" ";
                                    u++;
                                }

                            }
                        }
                        if (x.ArrestIndictment!=null)
                        {
                            foreach (var y in x.ArrestIndictment)
                            {
                                if (y.ArrestIndictmentDetail != null)
                                {
                                    foreach (var z in y.ArrestIndictmentDetail)
                                    {
                                        if (z.ArrestLawbreaker != null)
                                        {
                                            dr1._AL_Name = "";
                                            dr1.LScount = z.ArrestLawbreaker.Count.ToString();
                                            int a = 0;
                                            foreach (var o in z.ArrestLawbreaker)
                                            {
                                                if (a>0)
                                                {
                                                    dr1._AL_Name += ", ";
                                                }
                                                if (o.EntityType == 1)
                                                {
                                                    dr1._AL_Name += o.LawbreakerTitleName + " " + o.LawbreakerFirstName + " " + o.LawbreakerLastName+" ";
                                                }
                                                else if (o.EntityType == 2)
                                                {
                                                    dr1._AL_Name += o.CompanyTitle + " " + o.CompanyName + " " + o.CompanyOtherName + " ";
                                                }
                                                a++;
                                            }
                                        }                                        
                                    }
                                }
                                if (y.ArrestLawGuitbase!=null)
                                {
                                    dr1.GuiltBaseName = "";
                                    foreach (var z in y.ArrestLawGuitbase)
                                    {
                                        dr1.GuiltBaseName += z.GuiltBaseName + " ";
                                    }
                                }
                            }
                        }
                        if (x.ArrestProduct!=null)
                        {
                            dr1._AP_ProductDesc = "";
                            dr1._AL_count = x.ArrestProduct.Count.ToString();
                            int prow = 1;
                            foreach (var y in x.ArrestProduct)
                            {
                                dr1._AP_ProductDesc += prow.ToString() + ". ";
                                dr1._AP_ProductDesc += y.ProductDesc+" ";                                
                                dr2 = dts2.NewArrestgetByCon2Row();
                                dr2.ArrestCode = x.ArrestCode;
                                dr2._ap_ProductDesc = y.ProductDesc;
                                dr2.Qty = Convert.ToInt32(y.Qty);
                                dr2.QtyUnit = y.QtyUnit;
                                dr1._AP_ProductDesc += "\n";
                                dr2.NetVolume = y.NetVolume;
                                dr2.NetVolumeUnit = y.NetVolumeUnit;
                                dts2.Rows.Add(dr2);
                                prow++;
                            }
                            
                        }
                        if (x.ArrestLocale !=null)
                        {
                            foreach (var z in x.ArrestLocale)
                            {
                                dr1._ai_Location = "";
                                if (z.Location != "N/A")
                                {
                                    dr1._ai_Location = z.Location+ " ";
                                }
                                dr1._ai_Location +=  z.Address + " " + z.Village + " " + z.Building + " " + z.Floor + " " + z.Room + " " + z.SubDistrict + " " + z.District + " " + z.Province;
                                dr1._al_Address = z.Address;
                                dr1._al_Alley = z.Alley;
                                dr1._al_Road = z.Road;
                                dr1.SubDistrict = z.SubDistrict;
                                dr1.District = z.District;
                                dr1.Province = z.Province;
                            }
                        }
                        dr1.OccurrenceDay = DateTime.Parse(x.OccurrenceDate).ToString("dd");
                        string odayint = DateTime.Parse(x.ArrestDate).ToString("MM");
                        dr1.OccurrenceMonth = mounth[int.Parse(odayint)];
                        string sadsasas = DateTime.Parse(x.OccurrenceDate).ToString("yyyy");
                        int offf = int.Parse(sadsasas) + 543;
                        dr1.OccurrenceYear = offf.ToString();
                        dr1.OccurrenceTime =x.OccurrenceTime;
                        dr1.Prompt = x.Prompt;
                        dts1.Rows.Add(dr1);
                       
                    }

                    dtsr.Tables.Add(dts1);
                    dtsr.Tables.Add(dts2);
                    return dtsr;
                }
                
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet Noticegetbycon(Noticegetbyconmodel model)
        {
            
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":"+ db.GetNotice + "/XCS60/NoticegetByCon");
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
                var response2 = JsonConvert.DeserializeObject<List<Noticegetbyconjson>>(result);
                DataSet dtsr = new DataSet();
                DataReport.NoticegetByConDataTable dts1 = new DataReport.NoticegetByConDataTable();
                DataReport.NoticegetByConRow dr1;
                
                if (response2.ToList() == null)
                {
                    return null;
                }
                else
                {
                    foreach (var x in response2.ToList())
                    {
                        dr1 = dts1.NewNoticegetByConRow();
                        dr1.NoticeCode = x.NoticeCode;
                        dr1.NoticeStation = x.NoticeStation;
                        dr1.NoticeTime = x.NoticeTime;
                        dr1.NoticeDue = x.NoticeDue;
                        dr1.NoticeDate = x.NoticeDate;
                        dr1.NoticeDay = DateTime.Parse(x.NoticeDate).ToString("dd");
                        string[] mounth = { "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                        string dayint = DateTime.Parse(x.NoticeDate).ToString("MM");
                        dr1.NoticeMonth = mounth[int.Parse(dayint)];
                        string sdadasd = DateTime.Parse(x.NoticeDate).ToString("yyyy");
                        int fff = int.Parse(sdadasd) + 543;
                        dr1.NoticeYear = fff.ToString();
                       
                        if (x.NoticeInformer != null)
                        {
                            dr1.NI_NAME = "";
                            foreach (var y in x.NoticeInformer)
                            {
                                dr1.NI_NAME = y.TitleName + " " + y.FirstName + " " + y.LastName;
                                if (int.Parse(y.Age)> 0)
                                {
                                    dr1.NI_AGE = y.Age;
                                }
                                
                                
                                dr1.NI_Address = y.Address;
                                dr1.NI_District = y.District;
                                dr1.NI_SubDistrict = y.SubDistrict;
                                dr1.NI_Province = y.Province;
                                dr1.NI_InformerInfo = y.InformerInfo;
                            }
                        }
                        if (x.NoticeStaff != null)
                        {
                            foreach (var y in x.NoticeStaff)
                            {
                                dr1.NS_PositionName = y.PositionName;
                                dr1.NS_Name = y.TitleName + " " + y.FirstName + " " + y.LastName + " ";
                            }
                        }
                        dts1.Rows.Add(dr1);
                        dtsr.Tables.Add(dts1);
                    }
                    return dtsr;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet ArrestIndictmentProductgetByIndictmentID(LawsuitArrestgetByConModels model)
        {
           
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetArrest + "/XCS60/ArrestIndictmentProductgetByIndictmentID");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
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
                var response2 = JsonConvert.DeserializeObject<List<ArrestIndictmentProductgetByIndictmentIJson>>(result);
                DataSet dtsr = new DataSet();
                DataReport.ArrestIndictmentProductgetByIndictmentIDDataTable dts1 = new DataReport.ArrestIndictmentProductgetByIndictmentIDDataTable();
                DataReport.ArrestIndictmentProductgetByIndictmentIDRow dr1;

                if (response2.ToList() == null)
                {
                    return null;
                }
                else
                {
                    foreach (var x in response2.ToList())
                    {
                       
                        dr1 = dts1.NewArrestIndictmentProductgetByIndictmentIDRow();
                        dr1.ProductDesc = x.ProductDesc;
                        dr1.IndictmentProductQty = x.IndictmentProductQty;
                        dr1.IndictmentProductQtyUnit = x.IndictmentProductQtyUnit;
                        dr1.IndictmentProductSize = x.IndictmentProductSize;
                        dr1.IndictmentProductSizeUnit = x.IndictmentProductSizeUnit;
                        dr1.IndictmentProductVolume = x.IndictmentProductVolume;
                        dr1.IndictmentProductVolumeUnit = x.IndictmentProductVolumeUnit;
                        dts1.Rows.Add(dr1);
                        dtsr.Tables.Add(dts1);
                    }
                    return dtsr;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet ProvegetByCon(ProvegetByConModel model)
        {
           
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetProve + "/XCS60/ProvegetByCon");
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
                var response2 = JsonConvert.DeserializeObject<ProvegetByConJson>(result);
                DataSet dtsr = new DataSet();
                DataReport.ProvegetByConDataTable dts1 = new DataReport.ProvegetByConDataTable();
                DataReport.ProvegetByConRow dr1;

                if (response2 == null)
                {
                    return null;
                }
                else
                {
                    
                        dr1 = dts1.NewProvegetByConRow();
                        dr1.ProveReportNo = response2.ProveReportNo;                        
                        dr1.Command = response2.Command;
                        if (response2.ProveProduct.Count > 0  )
                        {
                            foreach (var y in response2.ProveProduct)
                            {
                                dr1.ProveResult = y.ProveResult;
                            }
                        }
                        dts1.Rows.Add(dr1);
                        dtsr.Tables.Add(dts1);
                    
                    return dtsr;
                }

            }
            catch
            {
                return null;
            }
        }

        public DataSet CompareArrestgetByIndictmentID(CompareArrestgetByIndictmentIDJcon model)
        {
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetCompare + "/XCS60/CompareArrestgetByIndictmentID");
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
                var response2 = JsonConvert.DeserializeObject<List<CompareArrestgetByIndictmentIDModels>>(result);
                DataSet dtsr = new DataSet();
                DataReport.CompareArrestgetByIndictmentIDDataTable dts1 = new DataReport.CompareArrestgetByIndictmentIDDataTable();
                DataReport.CompareArrestgetByIndictmentIDRow dr1;

                if (response2.ToList().Count == 0)
                {
                    return null;
                }
                else
                {

                    foreach (var x in response2.ToList())
                    {
                        dr1 = dts1.NewCompareArrestgetByIndictmentIDRow();
                        dr1.ArrestCode = x.ArrestCode;
                        dr1.GuiltbaseName = x.GuiltbaseName;
                        dr1.LawsuitDate = x.LawsuitDate;
                        dr1.SectionNo = x.SectionNo;
                        dr1.SubSectionType = x.SubSectionType;
                        if (x.LawsuitDate!=null)
                        {
                            dr1.LawsuitDay = DateTime.Parse(x.LawsuitDate).ToString("dd");
                            string[] mounth = { "", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                            string dayint = DateTime.Parse(x.LawsuitDate).ToString("MM");
                            dr1.LawsuitMonth = mounth[int.Parse(dayint)];
                            string sdadasd = DateTime.Parse(x.LawsuitDate).ToString("yyyy");
                            int fff = int.Parse(sdadasd) + 543;
                            dr1.LawsuitYear = fff.ToString();
                        }
                        
                        foreach (var y in x.CompareArrestIndictmentDetail)
                        {
                            dr1.SubDistrict = y.SubDistrict;
                            dr1.District = y.District;
                            dr1.Province = y.Province;
                            foreach (var z in y.CompareArrestLawbreaker)
                            {
                                dr1.LawbreakerTitleName = z.LawbreakerTitleName;
                                dr1.LawbreakerFirstName = z.LawbreakerFirstName;
                                dr1.LawbreakerMiddleName = z.LawbreakerMiddleName;
                                dr1.LawbreakerLastName = z.LawbreakerLastName;
                                dr1.LawbreakerOtherName = z.LawbreakerOtherName;
                            }
                        }
                        dts1.Rows.Add(dr1);
                        dtsr.Tables.Add(dts1);
                    }
                }
                return dtsr;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet ComparegetByCon(ComparegetByConJson model)
        {
            try
            {
                var db = new Configs();
                JObject jsonobj = (JObject)JToken.FromObject(model);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + db.GetIP + ":" + db.GetCompare + "/XCS60/ComparegetByCon");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
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
                var response2 = JsonConvert.DeserializeObject<ComparegetByConModel>(result);

                DataSet dtsr = new DataSet();
                DataReport.ComparegetByConDataTable dts1 = new DataReport.ComparegetByConDataTable();
                DataReport.ComparegetByConRow dr1;

                if (response2 == null)
                {
                    return null;
                }
                else
                {

                    dr1 = dts1.NewComparegetByConRow();
                    dr1.CompareCode = response2.CompareCode;
                    foreach (var x in response2.CompareDetail)
                    {
                        foreach (var y in x.CompareDetailReceipt)
                        {
                            dr1.ReceiptNo = y.ReceiptNo;
                            dr1.Station = y.Station;
                            dr1.PaymentDate = y.PaymentDate;
                            dr1.TotalFine = y.TotalFine;
                        }
                    }
                    foreach (var x in response2.CompareStaff)
                    {
                        dr1.PositionName = x.PositionName;
                    }

                    dts1.Rows.Add(dr1);
                    dtsr.Tables.Add(dts1);

                    return dtsr;
                }

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataSet ViewImageSignature(RequestViewImageSignature model)
        {
            try
            {
                string service = Properties.Settings.Default.Service;          
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(service);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var jsonobj = JsonConvert.SerializeObject(model);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
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
                var response = JsonConvert.DeserializeObject<ResponseViewImageSignature>(result);

                DataSet dtsr = new DataSet();
                DataReport.ViewImageSignatureDataTable dts1 = new DataReport.ViewImageSignatureDataTable();
                DataReport.ViewImageSignatureRow dr1;

                if (response == null)
                {
                    return null;
                }
                else
                {
                    dr1 = dts1.NewViewImageSignatureRow();
                    dr1.UserName = response.ResponseData.UserName;
                    dr1.OffCode = response.ResponseData.OffCode;
                    dr1.FileType = response.ResponseData.FileType;                    
                    dr1.FileBody = Convert.FromBase64String(response.ResponseData.FileBody);
                    dts1.Rows.Add(dr1);
                    dtsr.Tables.Add(dts1);
                    return dtsr;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}