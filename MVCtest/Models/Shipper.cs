namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shipper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Shipper_Id { get; set; }

        [StringLength(20)]
        public string Shipper_Method_Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
    }
}
