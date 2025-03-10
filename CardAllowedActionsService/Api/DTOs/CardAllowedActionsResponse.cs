namespace CardAllowedActionsService.Api.DTOs
{
    public class CardAllowedActionsResponse
    {
        public required string CardNumber { get; set; }
        public required string UserId { get; set; }
        public IEnumerable<string>? AllowedActions { get; set; }
    }
}
