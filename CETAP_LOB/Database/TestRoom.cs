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
    
    public partial class TestRoom
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public string RoomType { get; set; }
        public Nullable<decimal> HireCost { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string Comment { get; set; }
        public string RoomName { get; set; }
        public int TestRoom_TestVenue { get; set; }
    }
}