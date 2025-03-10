using CardAllowedActionsService.Application.Cards.Models;

namespace CardAllowedActionsService.Application.Cards.Services;

public interface ICardService
{
    public Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
}
