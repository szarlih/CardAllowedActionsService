using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public interface IAllowedActionsResolver
{
    IEnumerable<CardAction> Resolve(CardDetails card);
}
