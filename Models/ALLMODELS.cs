using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Report_XCS.Models
{
    public class ALLMODELS
    {
    }

    public class testjson
    {
        public int id { set; get; }
    }

    public class testjson1
    {
        public int id { set; get; }
    }

    public class RequestViewImageSignature
    {
        public string SystemId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string Operation { get; set; }
        public RequestViewImageSignatureDetail RequestData { get; set; }
    }

    public class RequestViewImageSignatureDetail
    {
        public string UserName { get; set; }
        public string OffCode { get; set; }
    }

    public class ResponseViewImageSignature
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public ResponseViewImageSignatureDetail ResponseData { get; set; }
    }

    public class ResponseViewImageSignatureDetail
    {
        public string UserName { get; set; }
        public string OffCode { get; set; }
        public string FileType { get; set; }
        public string FileBody { get; set; }
    }

    public class ILG60_00_06_001Json
    {
        public int IndictmentID { get; set; }
        public int CompareID { get; set; }
    }
    public class ILG60_00_06_002Json
    {
        public string receipt_no { get; set; }
        public string SystemId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string Operation { get; set; }
        public RequestViewImageSignatureDetail RequestData { get; set; }
    }
    public class ILG60_00_06_003Json
    {
        public int IndictmentID { get; set; }
        public int CompareID { get; set; }
        public string ArrestCode { get; set; }
    }
    public class ILG60_00_06_004Json
    {
        public int LawsuitID { get; set; }
    }
    public class ILG60_00_08_001Json
    {
        public int RequestBribeID { get; set; }
    }
    public class ILG60_00_09_004Json
    {
        public int BRIBE_REWARD_ID { get; set; }
    }

    public class ILG60_00_09_002Json
    {
        public int LawsuitID { get; set; }
    }

    public class ILG60_00_05_001Json
    {
        public int ProveID { get; set; }
    }
    public class ILG60_00_06_006Json
    {
        public int CompareDetailID { get; set; }
    }
    public class ILG60_00_06_005Json
    {
        public int CompareID { get; set; }
    }
    public class ILG60_00_09_001Json
    {
        public int CompareID { get; set; }
    }

    public class ILG60_00_09_003Json
    {
        public int BribeRewardID { get; set; }
    }
    #region P031
    public class P031models
    {
        public int IndictmentID { set; get; }
        public int CompareID { set; get; }
        
    }
    #endregion
    public class ILG60_00_11_001Json
    {
        public int EvidenceInID { get; set; }
    }

    public class ILG60_00_12_001Json
    {
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string OfficeCode1 { get; set; }
        public string OfficeCode2 { get; set; }
        public string OfficeCode3 { get; set; }
    }
    public class ILG60_00_12_002Json
    {
        public string enddate { get; set; }
        public string startdate { get; set; }
        public string officecode { get; set; }
    }
    public class ILG60_00_12_002_1Json
    {
        public string enddate { get; set; }
        public string startdate { get; set; }
        public string officecode { get; set; }
    }
    public class ILG60_00_12_003Json
    {
        public string getDatefrom { get; set; }
        public string getDateto { get; set; }
        public string getOffcode1 { get; set; }
        public string getOffcode2 { get; set; }
        public string getOffcode3 { get; set; }
    }
    public class ILG60_00_12_004Json
    {
        public string getMonthfrom1 { get; set; }
        public string getMonthfrom2 { get; set; }
        public string getMonthfrom3 { get; set; }
        public string getMonthto1 { get; set; }
        public string getMonthto2 { get; set; }
        public string getMonthto3 { get; set; }
        public string getOffcode1 { get; set; }
        public string getOffcode2 { get; set; }
        public string getOffcode3 { get; set; }
    }
    public class ILG60_00_12_005Json
    {
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string OfficeCode1 { get; set; }
        public string OfficeCode2 { get; set; }
        public string OfficeCode3 { get; set; }
    }
    #region lawsuitgetbycon
    public class LawsuitArrestgetByConModels
    {
        public int IndictmentID { get; set; }
    }
    public class LawsuitArrestgetByConJson
    {
        public string ArrestCode { get; set; }
        public List<LawsuitArrestIndicment> LawsuitArrestIndicment { get; set; }
        public List<LawsuitArrestStaff> LawsuitArrestStaff { get; set; }
    }
    public class LawsuitArrestIndicment
    {
        public List<LawsuitArrestIndicmentDetail> LawsuitArrestIndicmentDetail { get; set; }


        public List<Lawsuit> Lawsuit { get; set; }
        public List<LawsuitLawGuiltbase> LawsuitLawGuiltbase { get; set; }
    }
    public class Lawsuit
    {
        public string LawsuitNo { get; set; }
        public string LawsuitDate { get; set; }
        public string LawsuitTime { get; set; }
        public int IsLawsuit { get; set; }
        public string ReasonDontLawsuit { get; set; }
        public string LawsuitStation { get; set; }
        public List<LawsuiteStaff> LawsuiteStaff { get; set; }

    }
    public class LawsuitLawGuiltbase
    {
        public string GuiltBaseName { get; set; }
    }
    public class LawsuitArrestProductDetail
    {
        public string ProductDesc { get; set; }
        public string ProductSize { get; set; }
        public string ProductSizeUnitName { get; set; }
        public string ProductQty { get; set; }
        public string ProductNetVolume { get; set; }
        public string ProductNetVolumeUnit { get; set; }
    }
    public class LawsuitArrestIndicmentDetail
    {
        public List<LawsuitArrestProductDetail> LawsuitArrestProductDetail { get; set; }
        public List<LawsuitArrestLawbreaker> LawsuitArrestLawbreaker { get; set; }
    }
    public class LawsuitArrestLawbreaker
    {
        //public int EntityType { get; set; }
        public string LawbreakerTitleName { get; set; }
        public string LawbreakerFirstName { get; set; }
        public string LawbreakerMiddleName { get; set; }
        public string LawbreakerLastName { get; set; }
        public string LawbreakerOtherName { get; set; }
        //public string CompanyTitle { get; set; }
        //public string CompanyName { get; set; }
        //public string CompanyOtherName { get; set; }
    }
    public class LawsuiteStaff
    {
        //public string TitleName { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string PositionName { get; set; }
        //public string DepartmentName { get; set; }
        public string OfficeName { get; set; }
        public string OfficeShortName { get; set; }
    }
    public class LawsuitArrestStaff
    {
        public string DepartmentName { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }
        public int ContributorID { get; set; }

        public string OfficeShortName { get; set; }
    }
    #endregion

    #region ArrestgetByCon
    public class ArrestgetByConmodel
    {
        public string ArrestCode { get; set; }
    }
    public class ArrestgetByCon
    {
        public string ArrestCode { get; set; }
        public string ArrestStation { get; set; }
        public string ArrestDate { get; set; }
        public string ArrestTime { get; set; }
        public string OccurrenceDate { get; set; }
        public string OccurrenceTime { get; set; }
        public string Behaviour { get; set; }
        public string Prompt { get; set; }
        public string Testimony { get; set; }
        public List<ArrestLocale> ArrestLocale { get; set; }
        public List<ArrestStaff> ArrestStaff { get; set; }
        public List<ArrestProduct> ArrestProduct { get; set; }
        public List<ArrestIndictment> ArrestIndictment { get; set; }
    }
    public class ArrestLocale
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Alley { get; set; }
        public string Road { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
    public class ArrestStaff
    {
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }
        public int ContributorCode { get; set; }
    }
    public class ArrestIndictment
    {
        public List<ArrestIndictmentDetail> ArrestIndictmentDetail { get; set; }
        public List<ArrestLawGuitbase> ArrestLawGuitbase { get; set; }

    }
    public class ArrestIndictmentDetail
    {
        public List<ArrestLawbreaker> ArrestLawbreaker { set; get; }

    }
    public class ArrestLawbreaker
    {
        public int EntityType { get; set; }
        public string LawbreakerTitleName { get; set; }
        public string LawbreakerFirstName { get; set; }
        public string LawbreakerMiddleName { get; set; }
        public string LawbreakerLastName { get; set; }
        public string LawbreakerOtherName { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyOtherName { get; set; }
    }
    public class ArrestProduct
    {
        public string ProductDesc { get; set; }
        public double Qty { get; set; }
        public string QtyUnit { get; set; }
        public double NetVolume { get; set; }
        public string NetVolumeUnit { get; set; }
    }
    public class ArrestLawGuitbase
    {
        public string GuiltBaseName { get; set; }
    }
    #endregion


    #region Noticegetbycon
    public class Noticegetbyconmodel
    {
        public string NoticeCode { get; set; }
    }
    public class Noticegetbyconjson
    {
        public string NoticeCode { get; set; }
        public string NoticeStation { get; set; }
        public string NoticeDate { get; set; }
        public string NoticeDue { get; set; }
        public string NoticeTime
        { get; set; }
        public List<NoticeInformer> NoticeInformer { get; set; }
        public List<NoticeStaff> NoticeStaff { get; set; }
        public List<NoticeProduct> NoticeProduct { get; set; }
        public List<NoticeLocale> NoticeLocale { get; set; }

    }
    public class NoticeInformer
    {

        public int InformerType { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string InformerInfo { get; set; }
    }
    public class NoticeStaff
    {
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }
        public string OfficeName { get; set; }

    }
    public class NoticeProduct
    {
        public string ProductDesc { get; set; }
    }
    public class NoticeLocale
    {
        public string Address { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
    #endregion


    #region ProvegetByCon
    public class ProvegetByConModel
    {
        public string ProveID { get; set; }
    }
    public class ProvegetByConJson
    {
        public string ProveReportNo { get; set; }
        public string Command { get; set; }
        public List<ProveProduct> ProveProduct { get; set; }

    }
    public class ProveProduct
    {
        public string ProveResult { get; set; }
    }
    #endregion

    #region ArrestIndictmentProductgetByIndictmentID
    public class ArrestIndictmentProductgetByIndictmentIDModel
    {
        public int IndictmentID { get; set; }

    }
    public class ArrestIndictmentProductgetByIndictmentIJson
    {
        public string ProductDesc { get; set; }
        public string IndictmentProductQty { get; set; }
        public string IndictmentProductQtyUnit { get; set; }
        public string IndictmentProductSize { get; set; }
        public string IndictmentProductSizeUnit { get; set; }
        public string IndictmentProductVolume { get; set; }
        public string IndictmentProductVolumeUnit { get; set; }

    }


    #endregion

    #region P038
    public class P038MODEL
    {
        public string ArrestCode { get; set; }
        public string ProveID { get; set; }
        public int IndictmentID { get; set; }
    }

    #endregion

    #region RevenuegetReport

    #region RevenuegetByCon

    public class RevenueDetail
    {
        public int RevenueDetailID { get; set; }
        public string ReceiptBookNo { get; set; }
        public string ReceiptNo { get; set; }
        public int RevenueStatus { get; set; }
        public int RevenueID { get; set; }
        public int CompareReceiptID { get; set; }
        public int IsActive { get; set; }
    }

    public class RevenueStaff
    {
        public int StaffID { get; set; }
        public string ProgramCode { get; set; }
        public string ProcessCode { get; set; }
        public int RevenueID { get; set; }
        public string StaffCode { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string PosLevel { get; set; }
        public string PosLevelName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public object DepartmentLevel { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string OfficeShortName { get; set; }
        public int ContributorID { get; set; }
        public int IsActive { get; set; }
    }


    public class RevenuegetByConModel
    {
        public int RevenueID { get; set; }
    }
    public class RevenuegetByConModelS
    {
        public int RevenueID { get; set; }
        public string RevenueCode { get; set; }
        public string RevenueNo { get; set; }
        public DateTime RevenueDate { get; set; }
        public string RevenueTime { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string InformTo { get; set; }
        public int IsActive { get; set; }
        public int RevenueStatus { get; set; }
        public int ResultCount { get; set; }
        public List<RevenueDetail> RevenueDetail { get; set; }
        public List<RevenueStaff> RevenueStaff { get; set; }
    }


    #endregion

    #region RevenueComparegetByCompareReceiptID

    public class RevenueCompareStaff
    {
        public int StaffID { get; set; }
        public string ProgramCode { get; set; }
        public string ProcessCode { get; set; }
        public int CompareID { get; set; }
        public string StaffCode { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string PosLevel { get; set; }
        public string PosLevelName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLevel { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string OfficeShortName { get; set; }
        public int ContributorID { get; set; }
        public int IsActive { get; set; }
    }

    public class RevenueCompareDetailReceipt
    {
        public int CompareReceiptID { get; set; }
        public string ReceiptType { get; set; }
        public string ReceiptBookNo { get; set; }
        public string ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string StationCode { get; set; }
        public string Station { get; set; }
        public int CompareDetailID { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TotalFine { get; set; }
        public int RevenueStatus { get; set; }
        public object RevenueDate { get; set; }
        public int IsActive { get; set; }
        public int ReceiptChanel { get; set; }
        public string ReferenceNo { get; set; }
        public int CompareAuthority { get; set; }
        public int FineType { get; set; }
    }

    public class RevenueCompareDetail
    {
        public int CompareDetailID { get; set; }
        public int CompareID { get; set; }
        public int IndictmentDetailID { get; set; }
        public string CompareAction { get; set; }
        public string LawbrakerTestimony { get; set; }
        public string Fact { get; set; }
        public int IsRequest { get; set; }
        public object RequestForAction { get; set; }
        public string CompareReason { get; set; }
        public int IsProvisionalAcquittal { get; set; }
        public string Bail { get; set; }
        public string Guaruntee { get; set; }
        public int CompareFine { get; set; }
        public object PaymentFineDate { get; set; }
        public DateTime PaymentFineAppointDate { get; set; }
        public DateTime PaymentVatDate { get; set; }
        public int TreasuryMoney { get; set; }
        public int BribeMoney { get; set; }
        public int RewardMoney { get; set; }
        public int CompareDetailIsActive { get; set; }
        public string ApproveStationCode { get; set; }
        public string ApproveStation { get; set; }
        public DateTime ApproveReportDate { get; set; }
        public string CommandNo { get; set; }
        public DateTime CommandDate { get; set; }
        public int CompareAuthority { get; set; }
        public int ApproveReportType { get; set; }
        public int MistreatNo { get; set; }
        public int FineType { get; set; }
        public string AdjustReason { get; set; }
        public int IndictmentID { get; set; }
        public int LawbreakerID { get; set; }
        public int LawsuitType { get; set; }
        public int IndicmentDetailIsActive { get; set; }
        public string ArrestCode { get; set; }
        public int LawbreakerRefID { get; set; }
        public int EntityType { get; set; }
        public object CompanyTitleCode { get; set; }
        public object CompanyTitle { get; set; }
        public object CompanyName { get; set; }
        public object CompanyOtherName { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public string CompanyLicenseNo { get; set; }
        public object FoundedDate { get; set; }
        public object LicenseDateForm { get; set; }
        public object LicenseDateTo { get; set; }
        public object TaxID { get; set; }
        public object ExciseRegNo { get; set; }
        public int LawbreakerType { get; set; }
        public string LawbreakerTitleCode { get; set; }
        public string LawbreakerTitleName { get; set; }
        public string LawbreakerFirstName { get; set; }
        public object LawbreakerMiddleName { get; set; }
        public string LawbreakerLastName { get; set; }
        public object LawbreakerOtherName { get; set; }
        public object LawbreakerDesc { get; set; }
        public string IDCard { get; set; }
        public string PassportNo { get; set; }
        public int VISAType { get; set; }
        public object PassportCountryCode { get; set; }
        public object PassportCountryName { get; set; }
        public object PassportDateIn { get; set; }
        public object PassportDateOut { get; set; }
        public object BirthDate { get; set; }
        public string GenderType { get; set; }
        public object BloodType { get; set; }
        public string NationalityCode { get; set; }
        public string NationalityNameTH { get; set; }
        public string RaceCode { get; set; }
        public string RaceName { get; set; }
        public object ReligionCode { get; set; }
        public object ReligionName { get; set; }
        public object MaritalStatus { get; set; }
        public string Career { get; set; }
        public object GPS { get; set; }
        public object Location { get; set; }
        public object Address { get; set; }
        public object Village { get; set; }
        public object Building { get; set; }
        public object Floor { get; set; }
        public object Room { get; set; }
        public object Alley { get; set; }
        public object Road { get; set; }
        public object SubDistrictCode { get; set; }
        public object SubDistrict { get; set; }
        public object DistrictCode { get; set; }
        public object District { get; set; }
        public object ProvinceCode { get; set; }
        public object Province { get; set; }
        public object ZipCode { get; set; }
        public object TelephoneNo { get; set; }
        public object Email { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public object Remarks { get; set; }
        public object LinkPhoto { get; set; }
        public object PhotoDesc { get; set; }
        public int IsActive { get; set; }
        public List<RevenueCompareDetailReceipt> RevenueCompareDetailReceipt { get; set; }
    }

    public class RevenueCompareDetailReceiptPara
    {
        public int CompareReceiptID { get; set; }
    }
    public class RevenueComparegetByCompareReceiptIDModel
    {
        public int CompareID { get; set; }
        public string CompareCode { get; set; }
        public DateTime CompareDate { get; set; }
        public object CompareStationCode { get; set; }
        public string CompareStation { get; set; }
        public string CompareSubdistrictCode { get; set; }
        public string CompareSubdistrict { get; set; }
        public string CompareDistrictCode { get; set; }
        public string CompareDistrict { get; set; }
        public string CompareProvinceCode { get; set; }
        public string CompareProvince { get; set; }
        public string AccuserSubdistrictCode { get; set; }
        public string AccuserSubdistrict { get; set; }
        public string AccuserDistrictCode { get; set; }
        public string AccuserDistrict { get; set; }
        public string AccuserProvinceCode { get; set; }
        public string AccuserProvince { get; set; }
        public int IsOutside { get; set; }
        public int LawsuitID { get; set; }
        public int IsActive { get; set; }
        public List<RevenueCompareStaff> RevenueCompareStaff { get; set; }
        public List<RevenueCompareDetail> RevenueCompareDetail { get; set; }

    }
    #endregion

    #endregion

    #region InvestigategetByConReport

    #region InvestigategetByConMD

    public class InvestigategetByConReq
    {
        public string InvestigateCode { get; set; }
    }

    public class InvestigateDetailStaff
    {
        public int StaffID { get; set; }
        public int ProgramCode { get; set; }
        public string ProcessCode { get; set; }
        public string InvestigateDetailID { get; set; }
        public string StaffCode { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string PosLevel { get; set; }
        public string PosLevelName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public object DepartmentLevel { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string OfficeShortName { get; set; }
        public int ContributorID { get; set; }
        public int IsActive { get; set; }
    }

    public class InvestigateDetailSuspect
    {
        public int SuspectID { get; set; }
        public int SuspectReferenceID { get; set; }
        public int EntityType { get; set; }
        public object CompanyTitleCode { get; set; }
        public object CompanyTitle { get; set; }
        public object CompanyName { get; set; }
        public object CompanyOtherName { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public object TaxID { get; set; }
        public object ExciseRegNo { get; set; }
        public int SuspectType { get; set; }
        public object SuspectTitleName { get; set; }
        public string SuspectFirstName { get; set; }
        public object SuspectMiddleName { get; set; }
        public string SuspectLastName { get; set; }
        public object SuspectOtherName { get; set; }
        public string IDCard { get; set; }
        public object PassportNo { get; set; }
        public int IsActive { get; set; }
        public int InvestigateDetailID { get; set; }
    }

    public class InvestigateDetailLocal
    {
        public int LocalID { get; set; }
        public string InvestigateDetailID { get; set; }
        public object GPS { get; set; }
        public object Location { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public string Building { get; set; }
        public object Room { get; set; }
        public string Alley { get; set; }
        public string Road { get; set; }
        public string SubDistrictCode { get; set; }
        public string SubDistrict { get; set; }
        public string DistrictCode { get; set; }
        public string District { get; set; }
        public string ProvinceCode { get; set; }
        public string Province { get; set; }
        public object ZipCode { get; set; }
        public int IsActive { get; set; }
    }

    public class InvestigateDetailProduct
    {
        public int ProductID { get; set; }
        public int InvestigateDetailID { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public int IsDomestic { get; set; }
        public string ProductCode { get; set; }
        public string BrandCode { get; set; }
        public string BrandNameTH { get; set; }
        public object BrandNameEN { get; set; }
        public string SubBrandCode { get; set; }
        public object SubBrandNameTH { get; set; }
        public object SubBrandNameEN { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public int FixNo1 { get; set; }
        public string DegreeCode { get; set; }
        public int Degree { get; set; }
        public string SizeCode { get; set; }
        public string Size { get; set; }
        public string SizeUnitCode { get; set; }
        public string SizeUnitName { get; set; }
        public int FixNo2 { get; set; }
        public string SequenceNo { get; set; }
        public string ProductDesc { get; set; }
        public object CarNo { get; set; }
        public string Qty { get; set; }
        public string QtyUnit { get; set; }
        public string NetVolume { get; set; }
        public object NetVolumeUnit { get; set; }
        public int IsActive { get; set; }
    }

    public class InvestigateDetails
    {
        public int InvestigateDetailID { get; set; }
        public string InvestigateCode { get; set; }
        public string InvestigateSeq { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public DateTime InvestigateDateStart { get; set; }
        public DateTime InvestigateDateEnd { get; set; }

        public string InvestigateDetail { get; set; }
        public string ConfidenceOfNews { get; set; }
        public string ValueOfNews { get; set; }
        public int IsActive { get; set; }
        public List<InvestigateDetailStaff> InvestigateDetailStaff { get; set; }
        public List<InvestigateDetailSuspect> InvestigateDetailSuspect { get; set; }
        public List<InvestigateDetailLocal> InvestigateDetailLocal { get; set; }
        public List<InvestigateDetailProduct> InvestigateDetailProduct { get; set; }
    }

    public class MDInvestigategetByCon
    {
        public string InvestigateCode { get; set; }
        public string InvestigateNo { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Subject { get; set; }
        public int IsActive { get; set; }
        public List<InvestigateDetails> InvestigateDetail { get; set; }
    }


    #endregion

    #region InvestigateDetailgetByCon
    public class InvestigateCodeJson
    {
        public string InvestigateCode { get; set; }
    }
    public class InvestigateDetailgetByConReq
    {
        public int InvestigateDetailID { get; set; }
    }
    public class MDInvestigateDetailgetByCon
    {
        public int InvestigateDetailID { get; set; }
        public string InvestigateCode { get; set; }
        public string InvestigateSeq { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public DateTime InvestigateDateStart { get; set; }
        public DateTime InvestigateDateEnd { get; set; }
        public string InvestigateDetail { get; set; }
        public string ConfidenceOfNews { get; set; }
        public string ValueOfNews { get; set; }
        public int IsActive { get; set; }
        public List<InvestigateDetailStaff> InvestigateDetailStaff { get; set; }
        public List<InvestigateDetailSuspect> InvestigateDetailSuspect { get; set; }
        public List<InvestigateDetailLocal> InvestigateDetailLocal { get; set; }
        public List<InvestigateDetailProduct> InvestigateDetailProduct { get; set; }
    }


    #endregion


    #endregion


    #region CompareArrestgetByIndictmentID
    public class CompareArrestgetByIndictmentIDJcon
    {
        public int IndictmentID { get; set; }
    }
    public class CompareArrestgetByIndictmentIDModels
    {
        public string ArrestCode { get; set; }
        public List<CompareArrestIndictmentDetail> CompareArrestIndictmentDetail { get; set; }
        public string GuiltbaseName { get; set; }
        public string LawsuitDate { get; set; }
        public string SectionNo { get; set; }
        public string SubSectionType { get; set; }
    }
    public class CompareArrestIndictmentDetail
    {
        public List<CompareArrestLawbreaker> CompareArrestLawbreaker { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }

    }

    public class CompareArrestLawbreaker
    {
        public string LawbreakerTitleName { get; set; }
        public string LawbreakerFirstName { get; set; }
        public string LawbreakerMiddleName { get; set; }
        public string LawbreakerLastName { get; set; }
        public string LawbreakerOtherName { get; set; }
    }

    #endregion

    #region ComparegetByCon
    public class ComparegetByConJson
    {
        public int CompareID { get; set; }
    }
    public class ComparegetByConModel
    {
        public string CompareCode { get; set; }
        public List<CompareDetail> CompareDetail { get; set; }
        public List<CompareStaff> CompareStaff { get; set; }
    }
    public class CompareDetail
    {
        public List<CompareDetailReceipt> CompareDetailReceipt { get; set; }
    }
    public class CompareDetailReceipt
    {
        public string ReceiptNo { get; set; }
        public string Station { get; set; }
        public string PaymentDate { get; set; }
        public Double TotalFine { get; set; }
    }
    public class CompareStaff
    {
        public string PositionName { get; set; }
    }
    #endregion
}