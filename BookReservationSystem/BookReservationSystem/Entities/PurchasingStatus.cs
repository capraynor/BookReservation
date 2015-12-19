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
    
    public enum PurchasingStatus : short
    {
        /// <summary>
        /// 完成采购
        /// </summary>
        Completed = 0,
        /// <summary>
        /// 未处理该图书采购请求
        /// </summary>
        Unhandled = 1,
        /// <summary>
        /// 拒绝该图书采购请求
        /// </summary>
        Rejected = 2
    }
}
