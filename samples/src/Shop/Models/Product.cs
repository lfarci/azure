namespace Shop.Models
{
    public record Product
    {
        public string Id { get; init; } = Guid.NewGuid().ToString("N");
        public string Name { get; init; } = string.Empty;
        public int Amount { get; init; }
        public double Price { get; init; }
    }
}
