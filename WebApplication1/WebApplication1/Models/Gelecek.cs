namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gelecek")]
    public partial class Gelecek
    {
        [Key]
        public int gelecek_id { get; set; }

        [Required]
        [StringLength(100)]
        public string gelecek_adi { get; set; }

        [Required]
        [StringLength(500)]
        public string gelecek_resim { get; set; }

        [Required]
        [StringLength(25)]
        public string gelecek_tarih { get; set; }

        [Required]
        [StringLength(250)]
        public string gelecek_fragman { get; set; }

        [Required]
        public string gelecek_konu { get; set; }
    }
}
