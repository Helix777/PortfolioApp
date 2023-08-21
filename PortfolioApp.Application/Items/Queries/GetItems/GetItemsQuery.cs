namespace PortfolioApp.Application.Items.Queries.GetItems
{
    public record GetItemsQuery(int Page,
    int PageSize)
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        public static GetItemsQuery With(int? page, int? pageSize)
        {
            page ??= DefaultPage;
            pageSize ??= DefaultPageSize;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            return new(page.Value, pageSize.Value);
        }
    }
}
