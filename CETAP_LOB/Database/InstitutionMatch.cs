//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CETAP_LOB.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class InstitutionMatch
    {
        public long RequestNumber { get; set; }
        public int InstID { get; set; }
        public long Barcode { get; set; }
        public string StudentID { get; set; }
        public string Programme { get; set; }
        public string Faculty { get; set; }
        public System.DateTime RequestDate { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Composit Composit { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
