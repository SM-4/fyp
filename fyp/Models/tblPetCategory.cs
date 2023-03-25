namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPetCategory")]
    public partial class tblPetCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPetCategory()
        {
            tblPetSubcategories = new HashSet<tblPetSubcategory>();
        }

        [Key]
        public int Category_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Category_Name { get; set; }

        [StringLength(300)]
        public string Category_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPetSubcategory> tblPetSubcategories { get; set; }
    }
}
