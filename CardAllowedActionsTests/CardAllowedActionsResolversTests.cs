using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;
using CardAllowedActionsService.Application.Cards.Resolvers;
using Shouldly;

namespace CardAllowedActionsTests;

public class CardAllowedActionsResolversTests
{
    [Theory]
    [InlineData(CardType.Prepaid)]
    [InlineData(CardType.Debit)]
    [InlineData(CardType.Credit)]
    public void Resolve_WhenChecksOnlyCardType(CardType type)
    {
        var expectedActions = new List<CardAction>
        {
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
        };

        if (type == CardType.Credit)
        {
            expectedActions.Insert(4, new CardAction() { Name = "ACTION5" });
        }

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = type,
            CardStatus = CardStatus.Blocked,
            IsPinSet = true
        };

        var resolver = new CardTypeActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Theory]
    [InlineData(CardStatus.Expired)]
    [InlineData(CardStatus.Closed)]
    [InlineData(CardStatus.Restricted)]
    public void Resolve_WhenCardStatusExpiredOrRestrictedOrClosed(CardStatus type)
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION5" },
            new CardAction() { Name = "ACTION9" },
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Credit,
            CardStatus = type,
            IsPinSet = true
        };

        var resolver = new CardStatusActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsInactive_And_CardTypeIsDebit_PinSet()
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION2" },
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION6" },
            new CardAction() { Name = "ACTION8" },
            new CardAction() { Name = "ACTION9" },
            new CardAction() { Name = "ACTION10" },
            new CardAction() { Name = "ACTION11" },
            new CardAction() { Name = "ACTION12" },
            new CardAction() { Name = "ACTION13" }
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Inactive,
            IsPinSet = true
        };

        var resolver = new CompositeAllowedActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsInactive_And_CardTypeIsCredit_PinSet()
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION2" },
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION5" },
            new CardAction() { Name = "ACTION6" },
            new CardAction() { Name = "ACTION8" },
            new CardAction() { Name = "ACTION9" },
            new CardAction() { Name = "ACTION10" },
            new CardAction() { Name = "ACTION11" },
            new CardAction() { Name = "ACTION12" },
            new CardAction() { Name = "ACTION13" }
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Credit,
            CardStatus = CardStatus.Inactive,
            IsPinSet = true
        };

        var resolver = new CompositeAllowedActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsRestricted_And_CardTypeIsPrepaid()
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION9" },
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Prepaid,
            CardStatus = CardStatus.Restricted,
            IsPinSet = true
        };

        var resolver = new CompositeAllowedActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsActive_And_CardTypeIsDebit_NotPinSet()
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION1" },
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION7" },
            new CardAction() { Name = "ACTION8" },
            new CardAction() { Name = "ACTION9" },
            new CardAction() { Name = "ACTION10" },
            new CardAction() { Name = "ACTION11" },
            new CardAction() { Name = "ACTION12" },
            new CardAction() { Name = "ACTION13" }
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Active,
            IsPinSet = false
        };

        var resolver = new CompositeAllowedActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsOrdered_And_CardTypeIsDebit_NotPinSet()
    {
        var expectedActions = new List<CardAction>
        {
            new CardAction() { Name = "ACTION3" },
            new CardAction() { Name = "ACTION4" },
            new CardAction() { Name = "ACTION7" },
            new CardAction() { Name = "ACTION8" },
            new CardAction() { Name = "ACTION9" },
            new CardAction() { Name = "ACTION10" },
            new CardAction() { Name = "ACTION12" },
            new CardAction() { Name = "ACTION13" }
        };

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Ordered,
            IsPinSet = false
        };

        var resolver = new CompositeAllowedActionsResolver();

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }
}
