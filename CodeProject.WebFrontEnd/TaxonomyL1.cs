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
    
    public partial class TaxonomyL1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaxonomyL1()
        {
            this.TaxonomyL2 = new HashSet<TaxonomyL2>();
        }
    
        public decimal id { get; set; }
        public string Value { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaxonomyL2> TaxonomyL2 { get; set; }
    }
}