namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAccessory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccessory()
        {
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrderDetails = new HashSet<tblOrderDetail>();
            tblWishlists = new HashSet<tblWishlist>();
        }

        [Key]
        public int Accessories_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_Name { get; set; }

        //[Required]
        [StringLength(300)]
        public string Accessories_Image { get; set; }

        [Required]
        public string Accessories_Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_PurchasePrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_SalePrice { get; set; }

        public int Shop_FID { get; set; }

        public int A_SubcategoryFID { get; set; }

        public virtual tblAccSubcategory tblAccSubcategory { get; set; }

        public virtual tblShop tblShop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderDetail> tblOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWishlist> tblWishlists { get; set; }
    }
}
