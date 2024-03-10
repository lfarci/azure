namespace Shop.Models
{
    public record Profile
    {
        public string? IdToken { get; init; }
        public string? AccessToken { get; init; }
        public string? ExpiresOn { get; init; }
        public string? RefreshToken { get; init; }
        public string? Name { get; internal set; }
    }
}
