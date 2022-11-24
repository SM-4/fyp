namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblOrderDetail
    {
        [Key]
        public int OrderDetails_ID { get; set; }

        public int Order_Quantity { get; set; }

        public int Order_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string SalePrice { get; set; }

        [Required]
        [StringLength(50)]
        public string PurchasePrice { get; set; }

        public int? Pets_FID { get; set; }

        public int? Accessories_FID { get; set; }

        public virtual tblAccessory tblAccessory { get; set; }

        public virtual tblOrder tblOrder { get; set; }

        public virtual tblPet tblPet { get; set; }
    }
}
