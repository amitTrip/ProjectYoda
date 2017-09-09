using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeProject.WebFrontEnd.Models
{
    public class TaxonomyL3ViewModel : YTransactionalInformation
    {
        public decimal id { get; set; }
        public Nullable<decimal> L2_Id { get; set; }
        public string Value { get; set; }
        public List<TaxonomyL3> TaxonomyL3s { get; set; }
    }
}