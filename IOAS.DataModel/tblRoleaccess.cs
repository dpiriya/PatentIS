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
    
    public partial class tblRoleaccess
    {
        public int RoleaccessId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> FunctionId { get; set; }
        public Nullable<bool> Read_f { get; set; }
        public Nullable<bool> Add_f { get; set; }
        public Nullable<bool> Delete_f { get; set; }
        public Nullable<bool> Approve_f { get; set; }
        public Nullable<bool> Update_f { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string Status { get; set; }
    }
}
