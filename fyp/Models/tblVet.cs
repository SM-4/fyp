namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblVet")]
    public partial class tblVet
    {
        [Key]
        public int Veterinarian_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Veterinarian_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Veterinarian_Contact { get; set; }

        [Required]
        public string Veterinarian_Address { get; set; }
    }
}
