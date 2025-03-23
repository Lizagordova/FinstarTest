using System;
using System.Collections.Generic;
using System.Data;
using Finstar.Domain.Models;

namespace Finstar.Infrastructure.Helpers
{
    public static class ParamHelper
    {
        public static DataTable GetItemsParam(IEnumerable<Item> items)
        {
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("value", typeof(string));
            foreach (var item in items)
                dt.Rows.Add(item.Id, item.Code, item.Value);
            return dt;
        }
    }
}