using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Nevitium.Domain.Entities.Inventory;

namespace Nevitium.Domain.Entities.Inventory
{
    public class Inventory 
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(16)")]
        [MaxLength(16)]
        public string UPCA { get; set; }

        [Column(TypeName = "NVARCHAR(16)")]
        [MaxLength(16)]
        public string EAN13 { get; set; }

        [Column(TypeName = "NVARCHAR(16)")]
        [MaxLength(16)]
        public string AmazonASIN { get; set; }

        [Column(TypeName = "NVARCHAR(16)")]
        [MaxLength(16)]
        public string ISBN { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string CustomCode { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [Column(TypeName = "NVARCHAR(4000)")]
        [MaxLength(4000)]
        public string LongDescription { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Manufacturer { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Brand { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Model { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        [MaxLength(20)]
        public string Color { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Size { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Dimensions { get; set; }

        [Column(TypeName = "NVARCHAR(40)")]
        [MaxLength(40)]
        public string Weight { get; set; }

        [Column(TypeName = "DECIMAL(19,4)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "DECIMAL(19,4)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "DECIMAL(19,4)")]
        public decimal MinPrice { get; set; }
        [Column(TypeName = "DECIMAL(19,4)")]
        public decimal MaxDiscountPercent { get; set; }
        [Column(TypeName = "DECIMAL(19,4)")]
        public decimal MaxPrice { get; set; }
        public bool Tax1 { get; set; }
        public bool Tax2 { get; set; }        
        public bool Service { get; set; }
        public bool AllowPartial { get; set; }
        public int ReorderCutoff { get; set; }

        public InventoryMeta InventoryMeta { get; set; }
    }
}
