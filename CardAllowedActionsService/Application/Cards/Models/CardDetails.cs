using CardAllowedActionsService.Application.Cards.Enums;

namespace CardAllowedActionsService.Application.Cards.Models;

public record CardDetails
{
    public required string CardNumber { get; init; }
    public required CardType CardType { get; init; }
    public required CardStatus CardStatus { get; init; }
    public required bool IsPinSet { get; init; } = false;
}
