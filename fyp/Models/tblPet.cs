namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblPet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPet()
        {
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrderDetails = new HashSet<tblOrderDetail>();
            tblWishlists = new HashSet<tblWishlist>();
        }

        [Key]
        public int Pets_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Pets_Name { get; set; }

     
        [StringLength(300)]
        public string Pets_Image { get; set; }

        [Required]
        public string Pets_Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Pets_PurchasePrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Pets_SalePrice { get; set; }

        public int P_SubcategoryFID { get; set; }

        public int Shop_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }

        public virtual tblShop tblShop { get; set; }

        public virtual tblPetSubcategory tblPetSubcategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWishlist> tblWishlists { get; set; }
    }
}
