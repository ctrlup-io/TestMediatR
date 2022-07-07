using AutoMapper;
using System.Data;
using TestMediatR.Domain;
using TestMediatR.Domain.Interfaces;
using TestMediatR.Infrastructure.Entities;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TestMediatR.Infrastructure.Context;

namespace TestMediatR.Infrastructure
{
    public class DataStoreRepository : IDataStoreRepository
    {
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        private readonly DataStoreContext _dbContext;

        public DataStoreRepository(IMapper mapper, IDbConnection dbConnection, DataStoreContext dbContext) { _mapper = mapper; _dbConnection = dbConnection; _dbContext = dbContext; }

        public async Task<Guid> AddProduct(Product product)
        {
            var param = new
            {
                product.Name,
                product.CreationDate,
                product.UpdateDate
            };

           return await _dbConnection.ExecuteScalarAsync<Guid>(Consts.INSERT_PRODUCT, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> CheckIfProductExists(Guid? id)
        {
            return await _dbContext.Product.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task DeleteProduct(Guid id)
        {
            var param = new
            {
                Id = id
            };
            await _dbConnection.ExecuteAsync(Consts.DELETE_PRODUCT_BY_ID, param, commandType: CommandType.StoredProcedure);
        }

        public async Task EventOccured(Product product, string evt)
        {
            SetEvent(product, evt);
            await UpdateProduct(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var results = await _dbConnection.QueryAsync<ProductEntity>(Consts.SELECT_ALL_PRODUCTS, commandType: CommandType.StoredProcedure);

            return _mapper.Map<IEnumerable<Product>>(results);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var param = new
            {
                Id = id
            };
            ProductEntity result = await _dbConnection.QueryFirstAsync<ProductEntity>(Consts.SELECT_PRODUCT_BY_ID, param, commandType: CommandType.StoredProcedure);

            return _mapper.Map<Product>(result);
        }

        public async Task UpdateProduct(Product product)
        {
            var param = new
            {
                product.Id,
                product.Name,
                product.CreationDate,
                product.UpdateDate
            };
            await _dbConnection.ExecuteAsync(Consts.UPDATE_PRODUCT_BY_ID, param, commandType: CommandType.StoredProcedure);
        }

        private static void SetEvent(Product product, string evt)
        {
            if (product == null || string.IsNullOrWhiteSpace(evt))
            {
                return;
            }

            switch (evt.ToUpperInvariant())
            {
                case Consts.EVENT_CREATE:
                    product.CreationDate = DateTime.Now;
                    break;
                case Consts.EVENT_UPDATE:
                    product.UpdateDate = DateTime.Now;
                    break;
                default:
                    product.Name = $"{product.Name} evt: {evt}";
                    break;
            }
        }
    }
}

