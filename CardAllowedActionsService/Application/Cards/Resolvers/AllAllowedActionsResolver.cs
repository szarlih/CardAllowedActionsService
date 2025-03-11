using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class AllAllowedActionsResolver : IAllowedActionsResolver
{
    private readonly IEnumerable<IPartialAllowedActionsResolver> _resolvers;

    public AllAllowedActionsResolver(IEnumerable<IPartialAllowedActionsResolver> resolvers)
    {
        _resolvers = resolvers;
    }

    public IEnumerable<CardAction> Resolve(CardDetails card)
    {
        var allResolved = _resolvers
            .Select(resolver => resolver.Resolve(card))
            .Aggregate((current, next) => current.Intersect(next));

        return allResolved;
    }
}
