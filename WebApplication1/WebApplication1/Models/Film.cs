namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [Key]
        public int film_id { get; set; }

        [Required]
        [StringLength(100)]
        public string film_adi { get; set; }

        [Required]
        [StringLength(250)]
        public string film_resim { get; set; }

        [Required]
        [StringLength(250)]
        public string film_fragman { get; set; }

        [Required]
        [StringLength(10)]
        public string film_puan { get; set; }

        public int film_kategori_id { get; set; }

        [Required]
        [StringLength(25)]
        public string film_yil { get; set; }

        [Required]
        public string film_konu { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
