using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public class CardStatusActionsResolver : IPartialAllowedActionsResolver
{
    public IEnumerable<Models.CardAction> Resolve(CardDetails card)
    {
        var allowedActions = new List<Models.CardAction>();

        switch (card.CardStatus)
        {
            case CardStatus.Ordered:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION8,
                    ActionName.ACTION9,
                    ActionName.ACTION10,
                    ActionName.ACTION12,
                    ActionName.ACTION13
                });

                if (card.IsPinSet)
                {
                    allowedActions.AddActionName(ActionName.ACTION6);
                }
                else
                {
                    allowedActions.AddActionName(ActionName.ACTION7);
                }

                break;
            case CardStatus.Inactive:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION2,
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION8,
                    ActionName.ACTION9,
                    ActionName.ACTION10,
                    ActionName.ACTION11,
                    ActionName.ACTION12,
                    ActionName.ACTION13
                });

                if (card.IsPinSet)
                {
                    allowedActions.AddActionName(ActionName.ACTION6);
                }
                else
                {
                    allowedActions.AddActionName(ActionName.ACTION7);
                }

                break;
            case CardStatus.Active:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION1,
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION8,
                    ActionName.ACTION9,
                    ActionName.ACTION10,
                    ActionName.ACTION11,
                    ActionName.ACTION12,
                    ActionName.ACTION13
                });

                if (card.IsPinSet)
                {
                    allowedActions.AddActionName(ActionName.ACTION6);
                }
                else
                {
                    allowedActions.AddActionName(ActionName.ACTION7);
                }

                break;
            case CardStatus.Blocked:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION8,
                    ActionName.ACTION9
                });

                if (card.IsPinSet)
                {
                    allowedActions.AddRangeOfActionNames(new[] {
                        ActionName.ACTION6,
                        ActionName.ACTION7
                    });
                }

                break;      
            case CardStatus.Expired:
            case CardStatus.Closed:
            case CardStatus.Restricted:
                allowedActions.AddRangeOfActionNames(new[] {
                    ActionName.ACTION3,
                    ActionName.ACTION4,
                    ActionName.ACTION5,
                    ActionName.ACTION9
                });
                break;
        }

        return allowedActions;
    }
}
