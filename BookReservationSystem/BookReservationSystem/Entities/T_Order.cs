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
    
    public partial class T_Order
    {
        public int Id { get; set; }
        public string OrderOwner { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<OrderStatus> Status { get; set; }
    }
}
