using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Finstar.Domain;
using Finstar.Domain.Models;
using Finstar.Infrastructure.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Finstar.Infrastructure
{
    public class ItemsRepository : IItemsRepository
    {
        private const string ItemsInsertSp = "p_items_insert";
        private const string GetItemsSp = "p_items_select";

        private IConfiguration _configuration;
        private readonly string ConnectionString;
        public ItemsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Finstar") ?? "";
        }

        public async Task SaveItemsAsync(IEnumerable<Item> items)
        {
            using var connection =
                new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(ItemsInsertSp, commandType: CommandType.StoredProcedure, param: new
            {
                items = ParamHelper.GetItemsParam(items)
            } );
        }

        public async Task<PagingModel<Item>> GetItemsAsync(ItemQueryOptions options)
        {
            using var connection =
                new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            var result = await connection.QueryMultipleAsync(GetItemsSp, commandType: CommandType.StoredProcedure,
                param: new
                {
                    codeFilter = options.CodeFilter,
                    valueFilter = options.ValueFilter,
                    offset = (options.Page - 1) * options.PageSize,
                    pageSize = options.PageSize,
                });
            return new PagingModel<Item>
            {
                Items = result.Read<Item>().ToList(),
                TotalCount = result.ReadSingle<int>(),
                Page = options.Page,
                PageSize = options.PageSize
            };
        }
    }
}