namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int Order_Id { get; set; }

        public int Product_Id { get; set; }

        [StringLength(10)]
        public string Product_Name { get; set; }

        [StringLength(10)]
        public string Product_Detail { get; set; }

        [StringLength(10)]
        public string UnitPrice { get; set; }

        [StringLength(10)]
        public string Quantity { get; set; }

        [Key]
        public int OrderDetail_Id { get; set; }
    }
}
