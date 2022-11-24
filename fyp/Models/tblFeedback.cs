namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFeedback")]
    public partial class tblFeedback
    {
        [Key]
        public int Feedback_ID { get; set; }

        [StringLength(50)]
        public string Feedback_Description { get; set; }

        [StringLength(300)]
        public string Feedback_Image { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Feedback_Rating { get; set; }

        public int Customer_FID { get; set; }

        public int? Pets_FID { get; set; }

        public int? Accessories_FID { get; set; }

        public virtual tblAccessory tblAccessory { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        public virtual tblPet tblPet { get; set; }
    }
}
