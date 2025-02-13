namespace PortfolioApp.Application.Items.Queries.GetItemById
{
    public record GetItemByIdQuery(int ItemId)
    {
        public static GetItemByIdQuery With(int itemId)
        {
            return new(itemId);
        }
    }
}
