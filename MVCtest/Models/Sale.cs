namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [Key]
        public int Sale_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Sale_Product { get; set; }

        [StringLength(10)]
        public string Sale_UnPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime Sale_FristDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Sale_LastDate { get; set; }
    }
}
