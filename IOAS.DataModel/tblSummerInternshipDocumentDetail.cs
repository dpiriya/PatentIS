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
    
    public partial class tblSummerInternshipDocumentDetail
    {
        public int SummerInternshipDocumentDetailId { get; set; }
        public Nullable<int> DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentActualName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> UPDT_By { get; set; }
        public Nullable<System.DateTime> CRTD_TS { get; set; }
        public Nullable<System.DateTime> UPDT_TS { get; set; }
        public Nullable<int> CRTD_By { get; set; }
        public Nullable<int> Delete_By { get; set; }
        public string Status { get; set; }
        public Nullable<int> SummerInternshipStudentId { get; set; }
        public Nullable<bool> IsStudentDocument_f { get; set; }
        public Nullable<bool> IsInternshipPayment_f { get; set; }
    }
}
