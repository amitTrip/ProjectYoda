using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeProject.WebFrontEnd.Models
{
    public class TaxonomyL1ViewModel : YTransactionalInformation
    {
        public decimal id { get; set; }
        public string Value { get; set; }
        public List<TaxonomyL1> TaxonomyL1s { get; set; }
    }
}