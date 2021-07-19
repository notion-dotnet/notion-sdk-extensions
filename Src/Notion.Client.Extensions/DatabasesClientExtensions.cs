using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notion.Client.Extensions
{
    public static class DatabasesClientExtensions
    {
        public static async Task QueryToEndAsync(this IDatabasesClient databasesClient,
            string databaseId, DatabasesQueryParameters databasesQueryParameters, Action<List<Page>> onPartReceived)
        {
            databasesQueryParameters = databasesQueryParameters.CreateCopy();

            while (true)
            {
                var paginatedList = await databasesClient.QueryAsync(databaseId, databasesQueryParameters);
                onPartReceived.Invoke(paginatedList.Results);

                if (!paginatedList.HasMore) break;

                databasesQueryParameters.StartCursor = paginatedList.NextCursor;
            }
        }
    }
}