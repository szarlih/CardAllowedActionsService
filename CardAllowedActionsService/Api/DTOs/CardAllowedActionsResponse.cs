namespace CardAllowedActionsService.Api.DTOs
{
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
        /// added only for easier testing
        /// </summary>
        public required bool IsPinSet { get; set; }

        public IEnumerable<string>? AllowedActions { get; set; }
    }
}
