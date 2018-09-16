using System;
using static Dommel.DommelMapper;

namespace MySqlSample.Api.Data.Configuration
{
    public class SameTableNameResolver : ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
            return type.Name;
        }
    }
}