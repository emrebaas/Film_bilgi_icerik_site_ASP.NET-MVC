namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vizyon")]
    public partial class Vizyon
    {
        [Key]
        public int vizyon_id { get; set; }

        [Required]
        [StringLength(100)]
        public string vizyon_adi { get; set; }

        [Required]
        [StringLength(500)]
        public string vizyon_resim { get; set; }

        [Required]
        [StringLength(10)]
        public string vizyon_tarih { get; set; }

        [Required]
        [StringLength(250)]
        public string vizyon_fragman { get; set; }

        [Required]
        public string vizyon_konu { get; set; }

        public int vizyon_film_kategori { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
