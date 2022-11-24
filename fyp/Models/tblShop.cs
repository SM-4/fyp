namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShop")]
    public partial class tblShop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblShop()
        {
            tblAccessories = new HashSet<tblAccessory>();
            tblPets = new HashSet<tblPet>();
        }

        [Key]
        public int Shop_ID { get; set; }

        [Required]
        public string Shop_Name { get; set; }

        [Required]
        public string Shop_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccessory> tblAccessories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPet> tblPets { get; set; }
    }
}
