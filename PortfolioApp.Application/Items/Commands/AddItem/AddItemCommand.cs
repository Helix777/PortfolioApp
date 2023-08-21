namespace PortfolioApp.Application.Items.Commands.AddItem
{
    public record AddItemCommand
        (string Code, string Name, string Comments,
        int ColorId)
    {
    }
}
