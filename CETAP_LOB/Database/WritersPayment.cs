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
    
    public partial class WritersPayment
    {
        public long EasyPayPayNumber { get; set; }
        public long CurrentNBT { get; set; }
        public Nullable<long> OldNBT { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual EasyPayRecord EasyPayRecord { get; set; }
    }
}
