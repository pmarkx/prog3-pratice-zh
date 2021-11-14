﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhprobalkozas.ZH.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Planes))]
        public int PlaneId { get; set; }
        [NotMapped]
        public virtual Plane Planes { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
