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
    
    public partial class tblHonororiumDetails
    {
        public int HonororiumDetailsId { get; set; }
        public Nullable<int> HonororiumId { get; set; }
        public Nullable<int> PayeeType { get; set; }
        public string PayeeName { get; set; }
        public Nullable<int> PayeeID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> TDS { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public string ModeOfPayment { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string Status { get; set; }
        public string TDSPercentage { get; set; }
    }
}
