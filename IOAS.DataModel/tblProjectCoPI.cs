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
    
    public partial class tblProjectCoPI
    {
        public int CoPIId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Crtd_TS { get; set; }
        public Nullable<int> CrtdUserId { get; set; }
        public Nullable<System.DateTime> Updt_TS { get; set; }
        public Nullable<int> UpdtUserId { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<int> DeletedUserid { get; set; }
        public Nullable<decimal> PCF { get; set; }
        public Nullable<decimal> RMF { get; set; }
        public string Status { get; set; }
    }
}
