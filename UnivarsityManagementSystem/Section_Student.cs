//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnivarsityManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section_Student
    {
        public int sec_student_id { get; set; }
        public int section_id { get; set; }
        public int mid { get; set; }
        public int final { get; set; }
        public int grand { get; set; }
        public int teacher_id { get; set; }
    
        public virtual Section Section { get; set; }
    }
}
