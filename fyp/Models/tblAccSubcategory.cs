namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccSubcategory")]
    public partial class tblAccSubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccSubcategory()
        {
            tblAccessories = new HashSet<tblAccessory>();
        }

        [Key]
        public int A_SubcategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string A_SubcategoryName { get; set; }

        //[Required]
        [StringLength(300)]
        public string A_SubcategoryImage { get; set; }

        public int A_CategoryFID { get; set; }

        public virtual tblAccCategory tblAccCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccessory> tblAccessories { get; set; }
    }
}
