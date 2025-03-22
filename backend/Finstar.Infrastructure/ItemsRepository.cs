using System.Collections.Generic;
using Dapper;
using Finstar.Domain;
using Finstar.Domain.Models;
using Microsoft.Data.SqlClient;

namespace Finstar.Infrastructure
{
    public class ItemsRepository : IItemsRepository
    {
        public void SaveItems(IList<Item> items)
        {
            using var connection =
                new SqlConnection(
                    "Data Source=localhost;Initial Catalog=Finstar;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;Integrated Security=True");
            connection.Open();
            connection.Execute("CREATE TABLE [test] ([id] int, [name] int)");
        }

        public IList<Item> GetItems()
        {
            throw new System.NotImplementedException();
        }
    }
}