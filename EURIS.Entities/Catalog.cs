//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EURIS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalog
    {
        public Catalog()
        {
            this.Product = new HashSet<Product>();
        }
    
        public string Code { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Product> Product { get; set; }
    }
}
