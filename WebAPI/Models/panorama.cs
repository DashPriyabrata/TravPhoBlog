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
    
    public partial class panorama
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public panorama()
        //{
        //    this.postcontents = new HashSet<postcontent1>();
        //}
    
        public int Id { get; set; }
        public string ImageSrc { get; set; }
        public string Caption { get; set; }
        public int? FullWidth { get; set; }
        public int? FullHeight { get; set; }
        public int? CroppedWidth { get; set; }
        public int? CroppedHeight { get; set; }
        public int? CroppedX { get; set; }
        public int? CroppedY { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<postcontent1> postcontents { get; set; }
    }
}
