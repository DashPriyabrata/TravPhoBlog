//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog_comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public sbyte? Mark_Read { get; set; }
        public sbyte? IsEnabled { get; set; }
        public DateTime? Date { get; set; }
    
        public virtual blog_user blog_user { get; set; }
    }
}
