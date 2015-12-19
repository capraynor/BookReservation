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
    
    public enum OrderStatus : short
    {
        /// <summary>
        /// 已完成订单 已出库
        /// </summary>
        Completed = 0,
        /// <summary>
        /// 由于缺书 订单无法完成
        /// </summary>
        OutOfStock = 1,
        /// <summary>
        /// 未处理该图书订单
        /// </summary>
        Unhandled = 2,
        /// <summary>
        /// 该订单被拒绝
        /// </summary>
        Rejected = 3
    }
}
