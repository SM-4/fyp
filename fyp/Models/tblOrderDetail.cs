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

        public int Order_PetQuantity { get; set; }

        public int Order_FID { get; set; }

        [Column(TypeName ="numeric")]
        public decimal SalePricePet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PurchasePricePet { get; set; }

        public int? Pets_FID { get; set; }

        public virtual tblOrder tblOrder { get; set; }

        public virtual tblPet tblPet { get; set; }
    }
}
