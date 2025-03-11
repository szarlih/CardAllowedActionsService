# Cards Allowed Actions Service

The **Cards Allowed Actions Service** is a microservice built using **C# and .NET 8** that determines the **allowed actions** a user can perform on a given card. It exposes an **API endpoint** that accepts a **user ID** and a **card number** and returns a list of permitted actions based on the card's **type** and **status**.

## Features

- Accepts **user ID** and **card number** as input.
- Determines the **allowed actions** based on:
  - **Card Type**: Debit, Credit, or Prepaid.
  - **Card Status**: Ordered, Inactive, Active, Restricted, Blocked, Expired, or Closed.
  - **PIN status**: Some actions require a PIN to be set.
- Returns a JSON response containing a list of **permitted actions**.

## Example Rules

- A **Prepaid card** in **CLOSED** status allows: `ACTION3, ACTION4, ACTION9`.
- A **Credit card** in **BLOCKED** status allows:
  - `ACTION3, ACTION4, ACTION5, ACTION6` *(if PIN is set)*,  
  - `ACTION7` *(if PIN is set)*, `ACTION8, ACTION9`.
 
## Api documentation

There is Swagger UI configured in developent mode
 
## Endpoint

GET /api/cards/{userId}/{cardNumber}

### Example query params
- userId: User1, cardNumber: Card11
- userId: User2, cardNumber: Card21

## Data Model

```csharp
public enum CardType 
{ 
    Prepaid, 
    Debit, 
    Credit 
} 

public enum CardStatus 
{ 
    Ordered, 
    Inactive, 
    Active, 
    Restricted, 
    Blocked, 
    Expired, 
    Closed 
}

public record CardDetails(
  string CardNumber,
  CardType CardType,
  CardStatus CardStatus,
  bool IsPinSet);

