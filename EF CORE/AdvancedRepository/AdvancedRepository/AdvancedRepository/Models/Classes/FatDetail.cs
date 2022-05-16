using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class FatDetail   // Base den almammızın nedeni composite key olması 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //  None olursa otomatik artmayacak.
        public int Id { get; set; }

        public int ProductId { get; set; }
        public decimal  UnitPrice { get; set; }
        public int Amount { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string WhoUpdated { get; set; }

        [ForeignKey("Id")]
        public FatMaster FatMaster { get; set; }

        public Products Product { get; set; } //Sonradan ekledik, ProductName , ProductImage ı  Tabloda gösterebilmek için.



    }
}
