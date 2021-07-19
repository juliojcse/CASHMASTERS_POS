# CASHMASTERS POINT OF SALE

## Introduction

This library is intended for calculating the optimal change for standardized currency systems.
It was designed using OOP and design patterns (Builder) for future extension.
About the Calculate_Change algorithm, it was decided to use the greedy method as it finds the optimal
solution for most standard currency systems.


## Configuration

To configure the library properly, you need to define some keys in the appSettings section of App.config.
Define the currencies you want to include for example MXN. Then for the value, define the different denominations
avalaible for your currency, separated by |.
Example:
```xml
<add key="MXN" value="0.05|0.10|0.20|0.50|1.00|2.00|5.00|10.00|20.00|50.00|100.00"/>
```

Also define the DefaultCurrencyValue key and set a default value for it.

```xml
<add key="DefaultCurrencyValue" value="MXN"/>
```

## Implementation
Once imported, it is important to use the ChangeBuilder class to create the Change object and use the Calculate_Change method.
Before creating a Change instance, you need to set the currency to be used (BuildCurrency method) by the builder or use the default value (BuildDefaultCurrency method).
The last step would be to call the GetResult method to get the Change instance.

If necessary, define the proper DefaultThreadCurrentCulture to match your denomination representations (decimals).

```csharp
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-US");
// Create Change instance
Change change = (new ChangeBuilder()).BuildDefaultCurrency().GetResult();

decimal itemPrice = Convert.ToDecimal(450);
Dictionary<decimal, int> inputCoins = new Dictionary<decimal, int>();
inputCoins.Add(100, 5); //500

// Calculate change
Dictionary<decimal, int> changeOut = change.Calculate_Change(itemPrice, inputCoins);
```

The Calculate_Change method expects two parameters the item price as decimal and a Dictionary representing the given amount by the customer.
The Dictionary keys represent the denominations and values the quantity of that denomination. Dictionary{Denomination, Quantity}.
Calculate_Change returns a similar dictionary structure which is the optimal change.



 

