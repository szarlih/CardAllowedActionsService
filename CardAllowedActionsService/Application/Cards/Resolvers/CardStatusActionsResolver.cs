using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class CardStatusActionsResolver : IAllowedActionsResolver
{
    public IEnumerable<CardAction> Resolve(CardDetails card)
    {
        var allowedActions = new List<CardAction>();

        switch (card.CardStatus)
        {
            case CardStatus.Ordered:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" },
                    new CardAction() { Name = "ACTION10" },
                    new CardAction() { Name = "ACTION12" },
                    new CardAction() { Name = "ACTION13" }
                    ]);

                if (card.IsPinSet)
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION6" });
                }
                else
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION7" });
                }

                break;
            case CardStatus.Inactive:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION2" },
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" },
                    new CardAction() { Name = "ACTION10" },
                    new CardAction() { Name = "ACTION11" },
                    new CardAction() { Name = "ACTION12" },
                    new CardAction() { Name = "ACTION13" }
                    ]);

                if (card.IsPinSet)
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION6" });
                }
                else
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION7" });
                }

                break;
            case CardStatus.Active:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION1" },
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" },
                    new CardAction() { Name = "ACTION10" },
                    new CardAction() { Name = "ACTION11" },
                    new CardAction() { Name = "ACTION12" },
                    new CardAction() { Name = "ACTION13" }
                    ]);

                if (card.IsPinSet)
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION6" });
                }
                else
                {
                    allowedActions.Add(new CardAction() { Name = "ACTION7" });
                }

                break;
            case CardStatus.Blocked:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION8" },
                    new CardAction() { Name = "ACTION9" }
                ]);

                if (card.IsPinSet)
                {
                    allowedActions.AddRange([
                        new CardAction() { Name = "ACTION6" },
                        new CardAction() { Name = "ACTION7" }
                    ]);
                }

                break;      
            case CardStatus.Expired:
            case CardStatus.Closed:
            case CardStatus.Restricted:
                allowedActions.AddRange([
                    new CardAction() { Name = "ACTION3" },
                    new CardAction() { Name = "ACTION4" },
                    new CardAction() { Name = "ACTION5" },
                    new CardAction() { Name = "ACTION9" }
                ]);
                break;
        }

        return allowedActions;
    }
}
