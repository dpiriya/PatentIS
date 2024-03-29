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
    
    public partial class tblProjectInvoiceDraft
    {
        public int InvoiceDraftId { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> InvoiceType { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> PIId { get; set; }
        public string TaxCode { get; set; }
        public Nullable<int> AgencyId { get; set; }
        public Nullable<int> ServiceType { get; set; }
        public string DescriptionofServices { get; set; }
        public Nullable<decimal> TaxableValue { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<decimal> TotalInvoiceValue { get; set; }
        public string TotalInvoiceValueinWords { get; set; }
        public Nullable<int> Bank { get; set; }
        public string BankAccountNumber { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CrtdTS { get; set; }
        public Nullable<int> CrtdUserId { get; set; }
        public Nullable<System.DateTime> UpdtTS { get; set; }
        public Nullable<int> UpdtUserId { get; set; }
        public Nullable<int> InstalmentYear { get; set; }
        public Nullable<int> InstalmentNumber { get; set; }
        public string PONumber { get; set; }
        public string CommunicationAddress { get; set; }
    }
}
