namespace CardAllowedActionsService.Api.DTOs
{
    /// <summary>
    /// Response DTO for allowed actions for a card
    /// </summary>
    public class CardAllowedActionsResponse
    {
        public required string CardNumber { get; set; }
        public required string UserId { get; set; }

        /// <summary>
        /// added only for easier testing
        /// </summary>
        public required string CardStatus { get; set; }

        /// <summary>
        /// added only for easier testing
        /// </summary>
        public required string CardType { get; set; }

        /// <summary>
        /// True if pin was set, added only for easier testing
        /// </summary>
        public required bool IsPinSet { get; set; }

        public IEnumerable<string>? AllowedActions { get; set; }
    }
}
