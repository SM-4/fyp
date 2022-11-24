namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblWishlist")]
    public partial class tblWishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Wishlist_ID { get; set; }

        public int Customer_FID { get; set; }

        public int? Pet_FID { get; set; }

        public int? Accessories_FID { get; set; }

        public virtual tblAccessory tblAccessory { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblPet tblPet { get; set; }
    }
}
