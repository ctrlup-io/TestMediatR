using AutoMapper.Configuration.Annotations;

namespace TestMediatR.Domain
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}