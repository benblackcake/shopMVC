namespace MVCtest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int Order_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Order_Date { get; set; }

        public int? Customer_ID { get; set; }

        public int? Shipper_ID { get; set; }

        public int? Payment_ID { get; set; }

        //[Required(ErrorMessage ="必須輸入收件人姓名")]
        [StringLength(10)]
        public string recipient_Name { get; set; }
        //[Required(ErrorMessage = "必須輸入收件人手機")]
        [StringLength(10)]
        public string recipient_Phone { get; set; }
        //[Required(ErrorMessage = "必須輸入收件地址")]
        public string recipient_Adress { get; set; }
        public string Status { get; set; }   //new add



        public virtual Customer Customer { get; set; }
        public virtual Payment  Payment { get; set; }
        public virtual Shipper Shipper { get; set; }


       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
