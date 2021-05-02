﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TungShop.Model.Model
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomeName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAdress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }


    }
}
