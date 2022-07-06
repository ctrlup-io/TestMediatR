using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Infrastructure.Entities;
using Dapper;

namespace TestMediatR.Infrastructure
{
    public class DataStoreRepository : IDataStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;

        public DataStoreRepository(IMapper mapper, IDbConnection dbConnection) { _mapper = mapper; _dbConnection = dbConnection; }

        public async Task<Guid> AddProduct(Product product)
        {
            var request = new
            {
                Name = product.Name,
                CreationDate = product.CreationDate,
                UpdateDate = product.UpdateDate
            };

           return await _dbConnection.ExecuteScalarAsync<Guid>("Insert_Product", request, commandType: CommandType.StoredProcedure);
        }

        public Task<bool> CheckIfProductExists(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EventOccured(Product product, string evt)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
