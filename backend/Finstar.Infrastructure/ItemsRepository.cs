using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Finstar.Domain;
using Finstar.Domain.Models;
using Finstar.Infrastructure.Helpers;
using Microsoft.Data.SqlClient;

namespace Finstar.Infrastructure
{
    public class ItemsRepository : IItemsRepository
    {
        //todo: считать из json
        private const string ConnectionString = "Data Source=localhost;Initial Catalog=Finstar;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;Integrated Security=True";
        private const string ItemsInsertSp = "p_items_insert";
        private const string GetItemsSp = "p_items_select";
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

        public IList<Item> GetItems(ItemQueryOptions options)
        {
            using var connection =
                new SqlConnection(ConnectionString);
            connection.Open();
           return connection.Query<Item>(GetItemsSp, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}