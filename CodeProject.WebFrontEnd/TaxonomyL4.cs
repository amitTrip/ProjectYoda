//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeProject.WebFrontEnd
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxonomyL4
    {
        public decimal id { get; set; }
        public Nullable<decimal> L3_Id { get; set; }
        public string Value { get; set; }
    
        public virtual TaxonomyL3 TaxonomyL3 { get; set; }
    }
}
