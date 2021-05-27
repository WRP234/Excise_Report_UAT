using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_XCS.Models
{
    public class Configs
    {
        string ip = Properties.Settings.Default.IPserver;
        //string ip = "103.233.193.94";
        string pAdjust = Properties.Settings.Default.Adjust;
        string pInvestigate = Properties.Settings.Default.Investigate;
        string pLawsuit = Properties.Settings.Default.Lawsuit;
        string pArrest = Properties.Settings.Default.Arrest;
        string pRevenue = Properties.Settings.Default.Revenue;
        string pNotice = Properties.Settings.Default.Notice;
        string pProve = Properties.Settings.Default.Prove;
        string pCompare = Properties.Settings.Default.Compare;
        string DBip = Properties.Settings.Default.DBip;
        string DBname = Properties.Settings.Default.DBname;
        string DBuser = Properties.Settings.Default.DBuser;
        string DBpass = Properties.Settings.Default.DBpass;


        public string getip
        {
            get
            {
                return DBip;
            }
            
        }
        public string getdbname
        {
            get
            {
                return DBname;
            }
            
        }
        public string getdbuser
        {
            get
                {
                return DBuser;
            }
            
        }
        public string getdbpass
        {
            get
            {
                return DBpass;
            }
            
        }

        public string IPserver()
        {
            return ip;
        }

        public string GetIP
        {
            get
            {
                return ip;
            }
            
        }
        public string GetAdjust
        {
            get
            {
                return pAdjust;
            }

        }
        public string GetInvestigate
        {
            get
            {
                return pInvestigate;
            }

        }
        public string GetLawsuit
        {
            get
            {
                return pLawsuit;
            }

        }
        public string GetArrest
        {
            get
            {
                return pArrest;
            }

        }
        public string GetRevenue
        {
            get
            {
                return pRevenue;
            }

        }
        public string GetNotice
        {
            get
            {
                return pNotice;
            }

        }
        public string GetProve
        {
            get
            {
                return pProve;
            }

        }
        public string GetCompare
        {
            get
            {
                return pCompare;
            }

        }
    }
}
//Excise_illegal_UAT2