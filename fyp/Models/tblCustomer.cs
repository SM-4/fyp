namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCustomer")]
    public partial class tblCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCustomer()
        {
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrders = new HashSet<tblOrder>();
            tblWishlists = new HashSet<tblWishlist>();
        }

        [Key]
        public int Customer_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Contact { get; set; }

        [Required]
        [StringLength(300)]
        public string Customer_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrder> tblOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWishlist> tblWishlists { get; set; }
    }
}
