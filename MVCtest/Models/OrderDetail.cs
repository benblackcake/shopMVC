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
        [Key]
        public int OrderDetail_Id { get; set; }

        public int Order_Id { get; set; }

        public int Product_Id { get; set; }

        [StringLength(10)]
        public string Product_Name { get; set; }

        public int? Product_Detail_Id { get; set; }

        public int? UnitPrice { get; set; }

        public int? Quantity { get; set; }
    }
}
