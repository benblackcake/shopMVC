namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Detail
    {
        [Key]
        public int Product_Detail_Id { get; set; }

        public int Product_Id { get; set; }

        [StringLength(10)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        public int? Stock { get; set; }

        public virtual Product Product { get; set; }
    }
}
