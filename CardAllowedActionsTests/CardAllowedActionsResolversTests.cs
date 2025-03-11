using CardAllowedActionsService.Application.Cards.Enums;
using CardAllowedActionsService.Application.Cards.Models;
using CardAllowedActionsService.Application.Cards.Resolvers;
using Shouldly;

namespace CardAllowedActionsTests;

public class CardAllowedActionsResolversTests
{
    private static IEnumerable<IPartialAllowedActionsResolver> GetResolvers()
    {
        return new List<IPartialAllowedActionsResolver>
        {
            new CardTypeActionsResolver(),
            new CardStatusActionsResolver()
        };
    }

    [Theory]
    [InlineData(CardType.Prepaid)]
    [InlineData(CardType.Debit)]
    [InlineData(CardType.Credit)]
    public void Resolve_WhenChecksOnlyCardType(CardType type)
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] {
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

        if (type == CardType.Credit)
        {
            expectedActions.Insert(4, new CardAction() { Name = ActionName.ACTION5 });
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
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] {
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION5,
            ActionName.ACTION9
        });

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
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] {
            ActionName.ACTION2,
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION6,
            ActionName.ACTION8,
            ActionName.ACTION9,
            ActionName.ACTION10,
            ActionName.ACTION11,
            ActionName.ACTION12,
            ActionName.ACTION13
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Inactive,
            IsPinSet = true
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsInactive_And_CardTypeIsCredit_PinSet()
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] {
            ActionName.ACTION2,
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION5,
            ActionName.ACTION6,
            ActionName.ACTION8,
            ActionName.ACTION9,
            ActionName.ACTION10,
            ActionName.ACTION11,
            ActionName.ACTION12,
            ActionName.ACTION13
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Credit,
            CardStatus = CardStatus.Inactive,
            IsPinSet = true
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsRestricted_And_CardTypeIsPrepaid()
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] {
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION9
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Prepaid,
            CardStatus = CardStatus.Restricted,
            IsPinSet = true
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsActive_And_CardTypeIsDebit_NotPinSet()
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[] { 
            ActionName.ACTION1,
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION7,
            ActionName.ACTION8,
            ActionName.ACTION9,
            ActionName.ACTION10,
            ActionName.ACTION11,
            ActionName.ACTION12,
            ActionName.ACTION13
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Active,
            IsPinSet = false
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsOrdered_And_CardTypeIsDebit_NotPinSet()
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[]
        {
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION7,
            ActionName.ACTION8,
            ActionName.ACTION9,
            ActionName.ACTION10,
            ActionName.ACTION12,
            ActionName.ACTION13
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Debit,
            CardStatus = CardStatus.Ordered,
            IsPinSet = false
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }

    [Fact]
    public void Resolve_When_CardStatusIsInactive_And_CardTypeIsPrepaid_PinNotSet()
    {
        var expectedActions = new List<CardAction>();
        expectedActions.AddRangeOfActionNames(new[]
        {
            ActionName.ACTION2,
            ActionName.ACTION3,
            ActionName.ACTION4,
            ActionName.ACTION7,
            ActionName.ACTION8,
            ActionName.ACTION9,
            ActionName.ACTION10,
            ActionName.ACTION11,
            ActionName.ACTION12,
            ActionName.ACTION13
        });

        var card = new CardDetails
        {
            CardNumber = "1234567890123456",
            CardType = CardType.Prepaid,
            CardStatus = CardStatus.Inactive,
            IsPinSet = false
        };

        var resolver = new AllAllowedActionsResolver(GetResolvers());

        var actions = resolver.Resolve(card);

        actions.ShouldBe(expectedActions);
    }
}
