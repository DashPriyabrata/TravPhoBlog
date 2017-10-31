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
    
    public partial class bloginfo
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string TitleImage { get; set; }
        public System.DateTime PostDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public int BloggerId { get; set; }
        public string Category { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsCommentsEnabled { get; set; }
        public int? Views { get; set; }
        public int? ContentId { get; set; }
        public int BlogTagId { get; set; }
        public string NavUrlString { get; set; }
        //Custom properties
        public string RelatedTagName { get; set; }
        public string Introduction { get; set; }
        public int TotalBlogCount { get; set; }

        public virtual blogger blogger { get; set; }
    }
}
