using Nevitium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nevitium.Domain.Entities
{
    public class BaseMeta 
    {
        
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        [MaxLength(16)]
        public string User { get; set; }
    }
}
