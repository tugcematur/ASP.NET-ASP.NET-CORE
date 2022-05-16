using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class BasketDetail  // Base den almammızın nedeni composite key olması 
    {

       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }

        [ForeignKey( "ProductId")]
        public Products Products { get; set; }
    }
}
