namespace Delivery_Final_Function
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deliverytable")]
    public partial class Deliverytable
    {
        [Key]
        public int DeliveryID { get; set; }


        //--Validating Customer ID
        [Required(ErrorMessage = "Enter a valid Customer ID")]
        public int? CustomerID { get; set; }


        //--Validating Delivery Person
        [Required(ErrorMessage = "Delivery Person is required")]
        [StringLength(50)]
        public string DeliveryPerson { get; set; }


        //--Validating Amount
        [Required(ErrorMessage = "Amount is required")]
        public double? Amount { get; set; }


        [StringLength(250)]
        public string Feedback { get; set; }


        //--Validating Delivery Address
        [Required(ErrorMessage = "Delivery Address is required")]
        [StringLength(250)]
        public string DeliveryAddress { get; set; }

        //--Validating Product ID
        [Required(ErrorMessage = "Enter a valid Product ID")]
        public int? ProductID { get; set; }


        //--Validating Delivered Produucts
        [Required(ErrorMessage = "Delivered Product is required")]
        [StringLength(50)]
        public string DeliveredProducts { get; set; }
    }
}
