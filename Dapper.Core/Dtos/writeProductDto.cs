using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Dtos
{
   public class writeProductDto
    {
         public int Id { get; set; }    
        public required string Name { get; set; } = string.Empty;
        public required string BarCode { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Range(0 , 5)]
        public decimal Rate { get; set; }
        public required DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
