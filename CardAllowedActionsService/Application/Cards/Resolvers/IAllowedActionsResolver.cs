﻿using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Resolvers;

public interface IPartialAllowedActionsResolver
{
    IEnumerable<CardAction> Resolve(CardDetails card);
}
