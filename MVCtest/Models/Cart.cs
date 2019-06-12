namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int Cart_ID { get; set; }

        public int Customer_ID { get; set; }

        public int? Quantity { get; set; }

        public int Product_Detail_Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product_Detail Product_Detail { get; set; }
    }
}
