namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Haber")]
    public partial class Haber
    {
        [Key]
        public int haber_id { get; set; }

        [Required]
        [StringLength(250)]
        public string haber_baslik { get; set; }

        [Required]
        [StringLength(500)]
        public string haber_resim { get; set; }

        [Required]
        public string haber_aciklama { get; set; }
    }
}
