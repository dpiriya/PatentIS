//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IOAS.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSalaryPaymentHead
    {
        public int PaymentHeadId { get; set; }
        public Nullable<int> PaymentNo { get; set; }
        public string ProjectNo { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> TypeOfPayBill { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public string PaymentMonthYear { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
