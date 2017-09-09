using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeProject.WebFrontEnd.Models
{
    public class CPEReviewViewModel : YTransactionalInformation
    {
        public System.Guid Id { get; set; }
        public System.Guid CPEDetailsId { get; set; }
        public Nullable<decimal> SRNumber { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string L3 { get; set; }
        public string L4 { get; set; }
        public string QAAssesment { get; set; }
        public string PODManagerComment { get; set; }
        public string PODLeadAction { get; set; }
        public string ActionStatus { get; set; }

        public List<CPEReview> CPEReviews { get; set; }
    }
}