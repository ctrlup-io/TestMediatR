using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMediatR.Infrastructure.Entities
{
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        public Guid? Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
