namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Comment = new HashSet<Comment>();
            OrderDetail = new HashSet<OrderDetail>();
            Product_Detail = new HashSet<Product_Detail>();
        }

        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Product_Name { get; set; }

        public int? Category_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string UnitPrice { get; set; }

        [StringLength(50)]
        public string Product_Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Product_date { get; set; }

        [StringLength(10)]
        public string Product_Sale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Detail> Product_Detail { get; set; }

        public virtual Sub_Categroy Sub_Categroy { get; set; }
    }
}
