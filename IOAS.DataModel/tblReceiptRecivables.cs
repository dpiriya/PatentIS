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
    
    public partial class tblReceiptRecivables
    {
        public int ReceivablesId { get; set; }
        public Nullable<int> ReceiptId { get; set; }
        public Nullable<int> ReceivablesHeadId { get; set; }
        public string ReceivablesHeadName { get; set; }
        public Nullable<decimal> ReceivabesAmount { get; set; }
        public Nullable<System.DateTime> CrtdTS { get; set; }
        public Nullable<int> CrtdUserId { get; set; }
        public Nullable<System.DateTime> UpdtTS { get; set; }
        public Nullable<int> UpdtUserId { get; set; }
        public Nullable<int> AccountGroupId { get; set; }
        public string TransactionType { get; set; }
        public Nullable<bool> Tax_f { get; set; }
    }
}
