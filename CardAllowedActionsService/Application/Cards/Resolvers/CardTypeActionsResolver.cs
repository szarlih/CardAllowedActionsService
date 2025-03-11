using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class CardTypeActionsResolver : IPartialAllowedActionsResolver
{
    public IEnumerable<Models.CardAction> Resolve(CardDetails card)
    {
        var allowedActions = new List<Models.CardAction>();
        switch (card.CardType)
        {
            case CardType.Prepaid:
            case CardType.Debit:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION1,
                    ActionName.ACTION2,
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION6,
                    ActionName.ACTION7,
                    ActionName.ACTION8,
                    ActionName.ACTION9,
                    ActionName.ACTION10,
                    ActionName.ACTION11,
                    ActionName.ACTION12,
                    ActionName.ACTION13
                });
                break;
            case CardType.Credit:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION1,
                    ActionName.ACTION2,
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION6,
                    ActionName.ACTION7,
                    ActionName.ACTION8,
                    ActionName.ACTION9,
                    ActionName.ACTION10,
                    ActionName.ACTION11,
                    ActionName.ACTION12,
                    ActionName.ACTION13
                });
                break;
        }

        return allowedActions;
    }
}
