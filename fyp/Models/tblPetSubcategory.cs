namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPetSubcategory")]
    public partial class tblPetSubcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPetSubcategory()
        {
            tblPets = new HashSet<tblPet>();
        }

        [Key]
        public int Subcategory_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Subcategory_Name { get; set; }

        //[Required]
        [StringLength(300)]

        public string Subcategory_Image { get; set; }

        public int Category_FID { get; set; }

        public virtual tblPetCategory tblPetCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPet> tblPets { get; set; }
    }
}
