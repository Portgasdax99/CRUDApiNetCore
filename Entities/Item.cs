using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Entities
{
    public record Item
    {
        [Key]
        public Guid Id { get; init; }
        [Required]
        [MaxLength(250)]
        public String Name { get; init; }
        [Required]
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
