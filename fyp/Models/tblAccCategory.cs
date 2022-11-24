namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccCategory")]
    public partial class tblAccCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccCategory()
        {
            tblAccSubcategories = new HashSet<tblAccSubcategory>();
        }

        [Key]
        public int A_CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string A_CategoryName { get; set; }

        //[Required]
        [StringLength(300)]
        public string A_CategoryImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccSubcategory> tblAccSubcategories { get; set; }
    }
}
