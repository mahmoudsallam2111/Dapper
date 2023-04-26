using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Dtos
{
    public class UpdateProductDto
    {
        public required  int Id { get; set; }
        public required string Name { get; set; } = default!;
        public required string BarCode { get; set; } = default!;
        public required string Description { get; set; } = default!;
        public required decimal Rate { get; set; }
        public  DateTime ModifiedOn { get; set; } = DateTime.Now;   
    }
}
