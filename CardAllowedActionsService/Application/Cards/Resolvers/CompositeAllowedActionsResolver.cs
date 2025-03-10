using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class CompositeAllowedActionsResolver : IAllowedActionsResolver
{
    private readonly IAllowedActionsResolver _typeResolver;
    private readonly IAllowedActionsResolver _statusResolver;

    public CompositeAllowedActionsResolver()
    {
        _typeResolver = new CardTypeActionsResolver();
        _statusResolver = new CardStatusActionsResolver();
    }

    public IEnumerable<CardAction> Resolve(CardDetails card)
    {
        var typeActions = _typeResolver.Resolve(card);
        var statusActions = _statusResolver.Resolve(card);

        var commonActions = typeActions.Intersect(statusActions);

        return commonActions;
    }
}
