using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Report_XCS.Models
{
    public class cryslogin
    {
        Configs cf = new Configs();

        public ReportDocument Getlogincrystal(ReportDocument cryRpt)
        {

            cryRpt.SetDatabaseLogon(cf.getdbuser, cf.getdbpass, cf.getip, string.Empty);
            //cryRpt.SetDatabaseLogon("illegal60", "ill123", "103.233.193.94:1521/orcl2", string.Empty);
            return cryRpt;
        }
        /*public ReportDocument Getlogin(ReportDocument cryRpt)
        {
            
            ConnectionInfo crconnectioninfo = new ConnectionInfo();
            TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;

            crconnectioninfo.ServerName = cf.getip;
            crconnectioninfo.DatabaseName = string.Empty;
            crconnectioninfo.UserID = cf.getdbuser;
            crconnectioninfo.Password = cf.getdbpass;
            //crconnectioninfo.ServerName = "103.233.193.94:1521/orcl2";
            //crconnectioninfo.DatabaseName = string.Empty;
            //crconnectioninfo.UserID = "illegal60";
            //crconnectioninfo.Password = "ill123";

            CrTables = cryRpt.Database.Tables;

            foreach (Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }
            return cryRpt;
        }*/
        public ReportDocument Getsublogin(ReportDocument crReportDocument)
        {
            Sections crSections;
            ReportDocument  crSubreportDocument;
            SubreportObject crSubreportObject;
            ReportObjects crReportObjects;
            ConnectionInfo crConnectionInfo;
            Database crDatabase;
            Tables crTables;
            TableLogOnInfo crTableLogOnInfo;
            //crReportDocument = new ReportDocument();
            //crReportDocument.Load("c:\\reports\\Homes.rpt", CrystalDecisions.Shared.
            //OpenReportMethod.OpenReportByTempCopy);
            crDatabase = crReportDocument.Database;
            crTables = crDatabase.Tables;
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = cf.getip;
            crConnectionInfo.DatabaseName = string.Empty;
            crConnectionInfo.UserID = cf.getdbuser;
            crConnectionInfo.Password = cf.getdbpass;
            foreach (CrystalDecisions.CrystalReports.Engine.Table aTable in crTables)
            {
                crTableLogOnInfo = aTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                aTable.ApplyLogOnInfo(crTableLogOnInfo);
            }
            // THIS STUFF HERE IS FOR REPORTS HAVING SUBREPORTS 
            // set the sections object to the current report's section 
            crSections = crReportDocument.ReportDefinition.Sections;
            // loop through all the sections to find all the report objects 
            foreach (Section crSection in crSections)
            {
                crReportObjects = crSection.ReportObjects;
                //loop through all the report objects in there to find all subreports 
                foreach (ReportObject crReportObject in crReportObjects)
                {
                    if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        crSubreportObject = (SubreportObject)crReportObject;
                        //open the subreport object and logon as for the general report 
                        crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
                        crDatabase = crSubreportDocument.Database;
                        crTables = crDatabase.Tables;
                        foreach (CrystalDecisions.CrystalReports.Engine.Table aTable in crTables)
                        {
                            crTableLogOnInfo = aTable.LogOnInfo;
                            crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
                            aTable.ApplyLogOnInfo(crTableLogOnInfo);
                        }
                    }
                }
            }
            return crReportDocument;
        }
        public Stream exportpdf(ReportDocument rpt)
        {           
            try
            {
                var s = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                return s;
            }
            catch(Exception ex)
            {
                throw ex;
                return null;
            }           
        }     
        public DataSet GET06_002(string receipt_no)
        {
            DataReport ds = new DataReport();
            
            var conn = new OracleConnection();
            string query = @"SELECT
    compare_detail_id,
    receipt_office_name,
    compare_sub_district,
    compare_district_name_th,
    compare_province_name_th,
    to_char(payment_date, 'YYYY-Month-DD', 'nls_calendar=''Thai Buddha'' nls_date_language = Thai') payment_date,
    compare_no,
    lawbreaker_title_name_th,
    lawbreaker_title_name_en,
    lawbreaker_first_name,
    lawbreaker_middle_name,
    lawbreaker_last_name,
    lawbreaker_other_name,
    guiltbase_name,
    to_char(occurrence_date, 'YYYY-Month-DD', 'nls_calendar=''Thai Buddha'' nls_date_language = Thai') occurrence_date,
    sub_district_name_th,
    arrest_code,
    receipt_no,
    district_name_th,
    province_name_th,
    payment_fine,
    compare_title_name_th,
    compare_title_name_en,
    compare_first_name,
    compare_last_name,
    compare_opreation_pos_name,
    compare_management_pos_name,
    compare_represent_pos_name,
    compare_operation_pos_level_name,
    compare_management_pos_level_name,
    compare_represent_pos_level_name,
    compare_operation_dept_name,
    compare_operation_under_dept_name,
    compare_operation_work_dept_name,
    compare_operation_office_name,
    compare_management_dept_name,
    compare_management_under_dept_name,
    compare_management_work_dept_name,
    compare_operation_office_short_name,
    compare_management_office_short_name,
    compare_represent_office_short_name
FROM
    ilg61_00_06_002 where receipt_no=" + receipt_no;
            try
            {               
                conn.ConnectionString = "user id="+ cf.getdbuser + ";password="+ cf.getdbpass + ";data source="+ cf.getip;
                conn.Open();
                OracleCommand cmd = new OracleCommand(query);
                cmd.Connection = conn;
               
                //if (tran != null)
                //{
                //    cmd.Transaction = tran;
                //}
               
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds, "ilg61_00_06_002");
                ds.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds;
        }

    }
}