using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevitium.Domain.Entities.Inventory
{
    public class InventoryImage 
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int ZOrder { get; set; }
        [Column(TypeName = "NVARCHAR(120)")]
        [MaxLength(120)]
        public string Description { get; set; }
        public byte[] Image { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string MimeType { get; set; }
    }
}
