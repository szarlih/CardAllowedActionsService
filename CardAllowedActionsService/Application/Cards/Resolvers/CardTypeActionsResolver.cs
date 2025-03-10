using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class CardTypeActionsResolver : IAllowedActionsResolver
{
    public IEnumerable<CardAction> Resolve(CardDetails card)
    {
        var allowedActions = new List<CardAction>();
        switch (card.CardType)
        {
            case CardType.Prepaid:
            case CardType.Debit:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION1" },
                    new CardAction() { Name = "ACTION2" },
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION6" },
                    new CardAction() { Name = "ACTION7" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" },
                    new CardAction() { Name = "ACTION10" },
                    new CardAction() { Name = "ACTION11" },
                    new CardAction() { Name = "ACTION12" },
                    new CardAction() { Name = "ACTION13" }
                    ]);
                break;
            case CardType.Credit:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION1" },
                    new CardAction() { Name = "ACTION2" },
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION6" },
                    new CardAction() { Name = "ACTION7" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" },
                    new CardAction() { Name = "ACTION10" },
                    new CardAction() { Name = "ACTION11" },
                    new CardAction() { Name = "ACTION12" },
                    new CardAction() { Name = "ACTION13" }
                    ]);
                break;
        }

        return allowedActions;
    }
}
