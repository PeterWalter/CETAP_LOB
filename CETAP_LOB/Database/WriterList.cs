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
    
    public partial class WriterList
    {
        public int Id { get; set; }
        public long NBT { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public Nullable<long> SAID { get; set; }
        public string ForeignID { get; set; }
        public string Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Classification { get; set; }
        public string TestLanguage { get; set; }
        public string TestType { get; set; }
        public int VenueID { get; set; }
        public System.DateTime DOT { get; set; }
        public string Mobile { get; set; }
        public string HomeTelephone { get; set; }
        public string EMail { get; set; }
        public decimal Paid { get; set; }
        public System.DateTime AccountCreation { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public bool Wrote { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime DateModified { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual TestVenue TestVenue { get; set; }
    }
}