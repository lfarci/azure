namespace Shop.Models
{
    public record Profile
    {
        public string? Id { get; init; }
        public string? Name { get; init; }
        public string? EmailAddress { get; init; }
    }
}
