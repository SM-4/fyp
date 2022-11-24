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
        public int P_CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string P_CategoryName { get; set; }

        [StringLength(300)]
        public string P_CategoryImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPetSubcategory> tblPetSubcategories { get; set; }
    }
}
