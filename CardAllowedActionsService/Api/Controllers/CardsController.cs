using CardAllowedActionsService.Api.DTOs;
using CardAllowedActionsService.Application.Cards.Resolvers;
using CardAllowedActionsService.Application.Cards.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardAllowedActionsService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    ICardService _cardService;
    IAllowedActionsResolver _allowedActionsResolver;

    public CardsController(ICardService cardService, IAllowedActionsResolver allowedActionsResolver)
    {
        _cardService = cardService;
        _allowedActionsResolver = allowedActionsResolver;
    }

    [HttpGet("{userId}/{cardNumber}",Name = "GetAllowedActions")]
    public async Task<ActionResult<CardAllowedActionsResponse>> GetAllowedActionsResponses(string userId, string cardNumber)
    {
        var cardDetails = await _cardService.GetCardDetails(userId, cardNumber);

        if (cardDetails is null)
        {
            return NotFound($"No card found for UserId: {userId}, CardNumber: {cardNumber}");
        }

        var allowedActions = _allowedActionsResolver.Resolve(cardDetails).Select(a => a.Name);

        return
            Ok (new CardAllowedActionsResponse
            {
                CardNumber = cardDetails!.CardNumber,
                UserId = userId,
                AllowedActions = allowedActions.Select(aa => aa.ToString()),
                CardStatus = cardDetails!.CardStatus.ToString(),
                CardType = cardDetails!.CardType.ToString(),
                IsPinSet = cardDetails!.IsPinSet
            });
    }
}
