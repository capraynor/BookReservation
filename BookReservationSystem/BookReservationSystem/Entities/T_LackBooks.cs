//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookReservationSystem.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_LackBooks
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<System.DateTime> VerifiedTime { get; set; }
        public string VerifiedNote { get; set; }
        public Nullable<LackBooksStatus> Status { get; set; }
        public string RelatedOrderId { get; set; }
    }
}
