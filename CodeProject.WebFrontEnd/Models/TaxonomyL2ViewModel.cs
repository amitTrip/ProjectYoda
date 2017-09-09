using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeProject.WebFrontEnd.Models
{
    public class TaxonomyL2ViewModel : YTransactionalInformation
    {
        public decimal id { get; set; }
        public Nullable<decimal> L1_Id { get; set; }
        public string Value { get; set; }
        public List<TaxonomyL2> TaxonomyL2s { get; set; }
    }
}