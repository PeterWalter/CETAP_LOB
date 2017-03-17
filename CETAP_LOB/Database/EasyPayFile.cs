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
    
    public partial class EasyPayFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EasyPayFile()
        {
            EasyPayRecords = new HashSet<EasyPayRecord>();
        }
    
        public int FileGenerationNumber { get; set; }
        public string FileName { get; set; }
        public string DateWritten { get; set; }
        public string Time { get; set; }
        public Nullable<int> NumberOfPayments { get; set; }
        public Nullable<int> NumberOfTenders { get; set; }
        public Nullable<decimal> TotalFees { get; set; }
        public Nullable<decimal> TotalBankFees { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal CalculatedAmountCollected { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EasyPayRecord> EasyPayRecords { get; set; }
    }
}
