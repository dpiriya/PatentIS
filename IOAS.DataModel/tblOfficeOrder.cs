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
    
    public partial class tblOfficeOrder
    {
        public int OrderId { get; set; }
        public string OrderTypeId { get; set; }
        public string OrderType { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OrderFor { get; set; }
        public string EmployeeId { get; set; }
        public string EmpNo { get; set; }
        public string Attachment { get; set; }
        public string Remarks { get; set; }
        public string StaffName { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string OrderNumber { get; set; }
        public string BankAccount { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        public Nullable<System.DateTime> RelievingDate { get; set; }
        public Nullable<decimal> PayableAmount { get; set; }
        public Nullable<int> StaffID { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
