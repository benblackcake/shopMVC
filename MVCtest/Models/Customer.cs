namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Customer_ID { get; set; }

        [StringLength(20)]
        public string Customer_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_Email { get; set; }

        [StringLength(10)]
        public string Customer_Phone { get; set; }

        [StringLength(300)]
        public string User_Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Customer_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
