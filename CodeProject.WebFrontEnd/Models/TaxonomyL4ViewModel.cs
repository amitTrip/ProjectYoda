using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeProject.WebFrontEnd.Models
{
    public class TaxonomyL4ViewModel : YTransactionalInformation
    {
        public decimal id { get; set; }
        public Nullable<decimal> L3_Id { get; set; }
        public string Value { get; set; }
        public List<TaxonomyL4> TaxonomyL4s { get; set; }
    }
}