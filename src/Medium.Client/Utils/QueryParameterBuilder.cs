using Microsoft.AspNetCore.Http.Extensions;
using System.Collections.Generic;

namespace Medium.Client.Utils
{
    internal static class QueryParameterBuilder
    {
        public static string BuildQueryString(Dictionary<string, string> parameters)
        {
            var builder = new QueryBuilder();

            foreach (var parameter in parameters)
            {
                if(parameter.Value != null || parameter.Value != default)
                {
                    builder.Add(parameter.Key, parameter.Value);
                }
            }
            return builder.ToString();
        }
    }
}
