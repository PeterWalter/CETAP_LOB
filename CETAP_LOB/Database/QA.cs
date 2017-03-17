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
    
    public partial class QA
    {
        public long ID { get; set; }
        public int CSX_Number { get; set; }
        public string CSX { get; set; }
        public long NBT { get; set; }
        public long Barcode { get; set; }
        public Nullable<long> SAID { get; set; }
        public string ForeignID { get; set; }
        public Nullable<int> IDType { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Citizenship { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int VenueCode { get; set; }
        public System.DateTime TestDate { get; set; }
        public Nullable<int> HLanguage { get; set; }
        public Nullable<int> SchoolLanguage { get; set; }
        public Nullable<int> Classification { get; set; }
        public string AQL_Language { get; set; }
        public string AQL_Code { get; set; }
        public string Section1 { get; set; }
        public string Section2 { get; set; }
        public string Section3 { get; set; }
        public string Section4 { get; set; }
        public string Section5 { get; set; }
        public string Section6 { get; set; }
        public string Section7 { get; set; }
        public string MAT_Language { get; set; }
        public string MathCode { get; set; }
        public string MatSection { get; set; }
        public string Faculty1 { get; set; }
        public string Faculty2 { get; set; }
        public string Faculty3 { get; set; }
        public string EndOfFile { get; set; }
        public int BatchID { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Batch Batch { get; set; }
    }
}