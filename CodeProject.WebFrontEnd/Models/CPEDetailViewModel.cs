using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeProject.WebFrontEnd.Models
{
    public class CPEDetailViewModel : YTransactionalInformation
    {
        public System.Guid Id { get; set; }
        public decimal SRNumber { get; set; }
        public string ReviewMonth { get; set; }
        public System.DateTime SurveyDate { get; set; }
        public string EngineerName { get; set; }
        public string EngManager { get; set; }
        public string PODName { get; set; }
        public Nullable<System.DateTime> SRCreatedDate { get; set; }
        public Nullable<decimal> SRDTS { get; set; }
        public string QoS { get; set; }
        public Nullable<decimal> SRDTC { get; set; }
        public string IRMissed { get; set; }
        public string SupportOffering { get; set; }
        public string SupportServiceLevel { get; set; }
        public string CurrentOwnerGroup { get; set; }
        public string SurveyMonth { get; set; }
        public string QualityAnalystName { get; set; }
        public string SRClosedMonth { get; set; }
        public string DeliveryRegion { get; set; }
        public string AreaName { get; set; }
        public string SurveyVerbatim { get; set; }

        public List<CPEDetail> CPEDetails { get; set; }

        public virtual ICollection<CPEReview> CPEReviews { get; set; }
    }
}