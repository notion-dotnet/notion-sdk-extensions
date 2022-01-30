namespace Notion.Client.Extensions
{
    public static class CreateCopyExtensions
    {
        /// <summary> Creates copy of DatabasesQueryParameters </summary>
        public static DatabasesQueryParameters CreateCopy(this DatabasesQueryParameters source) =>
            new DatabasesQueryParameters()
            {
                Filter = source.Filter,
                Sorts = source.Sorts,
                PageSize = source.PageSize,
                StartCursor = source.StartCursor
            };
    }
}