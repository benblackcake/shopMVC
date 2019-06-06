namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Master")]
    public partial class Master
    {
        [Key]
        public int master_id { get; set; }

        [StringLength(50)]
        public string master_account { get; set; }

        [StringLength(50)]
        public string master_password { get; set; }
    }
}
