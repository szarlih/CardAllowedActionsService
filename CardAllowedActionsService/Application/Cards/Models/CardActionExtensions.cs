using CardAllowedActionsService.Application.Cards.Enums;

namespace CardAllowedActionsService.Application.Cards.Models;

public static class CardActionExtensions
{
    public static void AddRangeOfActionNames(this List<CardAction>? cardActions, ActionName[] actionNames)
    {
        if (cardActions == null)
        {
            cardActions = new List<CardAction>();
        }

        foreach (var actionName in actionNames)
        {
            cardActions.Add(new CardAction { Name = actionName });
        }
    }

    public static void AddActionName(this List<CardAction>? cardActions, ActionName actionName)
    {
        if (cardActions == null)
        {
            cardActions = new List<CardAction>();
        }

        cardActions.Add(new CardAction { Name = actionName });
    }
}
