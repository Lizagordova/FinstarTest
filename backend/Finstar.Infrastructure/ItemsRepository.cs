using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        // todo: добавить асинхронность и обработку исключений
        public void SaveItems(IEnumerable<Item> items)
        {
            using var connection =
                new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(ItemsInsertSp, commandType: CommandType.StoredProcedure, param: new
            {
                items = ParamHelper.GetItemsParam(items)
            } );
        }

        public PagingModel<Item> GetItems(ItemQueryOptions options)
        {
            using var connection =
                new SqlConnection(ConnectionString);
            connection.Open();
           var result = connection.QueryMultiple(GetItemsSp, commandType: CommandType.StoredProcedure,
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