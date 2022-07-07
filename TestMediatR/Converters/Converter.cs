using TestMediatR.Domain;

namespace TestMediatR.Converters
{
    public static class Converter
    {
        public static ProductContract? ToProductContract(this Product product)
        {
            if(product == null) return null;

            return new ProductContract
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public static List<ProductContract>? ToProductContracts(this List<Product>? products)
        {
            if (products == null) return null;

            if(products.Count == 0) return new List<ProductContract>();

            List < ProductContract > productsContract = new List<ProductContract>();

            foreach (var product in products)
            {
                productsContract.Add(ToProductContract(product));
            }

            return productsContract;
        }

        public static List<Product>? ToProducts(this List<ProductContract>? productContracts)
        {
            if(productContracts == null) return null;

            if (productContracts.Count == 0) return new List<Product>();

            List<Product> productsContract = new List<Product>();
            foreach(var product in productContracts)
            {
                productsContract.Add(ToProduct(product));
            }
            return productsContract;
        }

        public static Product? ToProduct(this ProductContract productContract)
        {
            if(null == productContract) return null;

            return new Product { Id = productContract.Id, Name = productContract.Name };
        }
    }
}
