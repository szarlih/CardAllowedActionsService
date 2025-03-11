using CardAllowedActionsService.Application.Cards.Enums;

namespace CardAllowedActionsService.Application.Cards.Models;

public record CardAction
{
    public required ActionName Name { get; init; }
}
