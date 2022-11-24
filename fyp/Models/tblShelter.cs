namespace fyp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShelter")]
    public partial class tblShelter
    {
        [Key]
        public int Shelter_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Shelter_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Shelter_Contact { get; set; }

        [Required]
        [StringLength(300)]
        public string Shelter_Address { get; set; }
    }
}
