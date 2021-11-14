using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhprobalkozas.ZH.Entities
{
    [Table("Planes")]
    public class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Mass { get; set; }
        [Required]
        public bool Civil { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Order> Orders { get; set; }
        public Plane()
        {
            Orders = new HashSet<Order>();
        }
        
    }
}
