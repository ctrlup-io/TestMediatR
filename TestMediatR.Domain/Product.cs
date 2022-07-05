using AutoMapper.Configuration.Annotations;

namespace TestMediatR.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Ignore]
        public DateTime? CreationDate { get; set; }
        [Ignore]
        public DateTime? UpdateDate { get; set; }

    }
}