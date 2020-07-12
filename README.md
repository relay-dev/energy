<img src="https://raw.githubusercontent.com/relay-dev/energy/master/resources/icon.png" alt="Energy" height="150" width="150">

# Energy

[![Build status](https://ci.appveyor.com/api/projects/status/rbnas7sa2tnl5adl/branch/master?svg=true)](https://ci.appveyor.com/project/sfergusonATX/energy/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/relay-dev/energy/badge.svg?branch=master&service=github)](https://coveralls.io/github/relay-dev/energy?branch=master)
[![NuGet Release](https://img.shields.io/nuget/v/Energy.svg)](https://www.nuget.org/packages/Relay.Energy/)
[![MyGet](https://img.shields.io/myget/relay-dev/v/Energy?color=red&label=myget)](https://www.myget.org/feed/relay-dev/package/nuget/Relay.Energy)
[![License](https://img.shields.io/github/license/relay-dev/energy.svg)](https://github.com/relay-dev/energy/blob/master/LICENSE)

Energy is a small library of utilities that are useful in the energy industry. 

<br />

## Installing Energy

Here's how you can install the package:

> #### *.NET Core CLI*
> 
> ```
> dotnet add package Relay.Energy
> ```
>
> #### *Package Manager Console*
> 
> ```
> Install-Package Relay.Energy
> ```

<br />

## Samples

### Data Structures

The data structures in this library represent energy dimensions. An energy dimension is an attribute pertaining to a record in a system built for the energy industry. Since these dimensions are fundamental to the business and used so frequently, it makes sense to standardize the way they are represented. Each energy dimension exposes the same set of properties which are derived from parsing an input string provided to the constructor. Some more fun facts about energy dimensions:

    1.) The dimensions are standardized, immutable, lightweight structs
    2.) String interpretation is flexible
        - Different variations of the same data are considered when parsing input strings.
        - This is valuable when a system interacts with several different vendors that represent the same attribute in different ways. For example, one vendor may represent an Electric account as 'E', while another uses 'Electric'.
    3). There are standard sets of static values exposed by each structure that represent valid values
        - For example, the Commodity structure exposes static instances that represent Electric, Gas, Solar and Unrecognized (Unrecognized is available for all energy dimensions as a representation of an input string that couldn't be parsed).
        - This allows you to use the structs similarly to the way you would use an enum
    4). Comparison amongst instances is simple
        - The equivalency operators are overloaded for each dimension to support comparing dimensions of the same type to each other, and for comparing strings to a dimension.

#### Standardized fields

Each dimension contains everything needed to parse an input string and return it's standardized constituents.

```c#
private void StandardizedFieldsAreExposedForInstances()
{
    var accountClass = new AccountClass("Residential");

    Console.WriteLine(accountClass.Name);
    Console.WriteLine(accountClass.Code);
    Console.WriteLine(accountClass.DisplayName);
}
```

#### String Interpretation

Each dimension will sensibly parse the input string to account for variations in representation from different vendors.

```c#
private void InterpretationIsFlexibleForInputStrings()
{
    var accountClass1 = new AccountClass("R");
    var accountClass2 = new AccountClass("res");
    var accountClass3 = new AccountClass("Resi");
    var accountClass4 = new AccountClass("resi.");

    Console.WriteLine(accountClass1.Name);
    Console.WriteLine(accountClass2.Name);
    Console.WriteLine(accountClass3.Name);
    Console.WriteLine(accountClass4.Name);
}
```

#### Static Values

Each dimension exposes static instances for quick comparison and assignment.

```c#
private void StaticValuesRepresentValidValues()
{
    string accountClassString = "Large Commercial";

    bool isLargeCommercial = (accountClassString == AccountClass.LargeCommercial);
    AccountClass localAccountClass = AccountClass.SmallCommercial;

    Console.WriteLine("Is Large Commercial: {0}", isLargeCommercial);
    Console.WriteLine("Local Account Class: {0}", localAccountClass.Name);
}
```

#### Equality Comparison

Each dimension can be compared for equality.

```c#
private void CompareForEquality()
{
    bool areResidentialInstancesEquivalent = (new AccountClass("Residential") == new AccountClass("Residential"));
    bool areResidentialSmallCommercialInstancesEquivalent = (new AccountClass("Residential") == new AccountClass("Small Commercial"));

    Console.WriteLine("Are Residential instances equivalent?: {0}", areResidentialInstancesEquivalent);
    Console.WriteLine("Are Residential Small Commercial instances equivalent?: {0}", areResidentialSmallCommercialInstancesEquivalent);
}
```

#### String Comparison

Each dimension can also be compared for equality using strings.

```c#
private void CompareForEqualityFromStrings()
{
    bool isResidentialResidentialEquivalent = (new AccountClass("Residential") == "Residential");
    bool isResidentialSmallCommercialEquivalent = (new AccountClass("Residential") == "Small Commercial");
    bool isSmallCommercialSmallCommercialAbbreviationEquivalent = (new AccountClass("Small Commercial") == "SC");

    Console.WriteLine("Is Residential Residential equivalent?: {0}", isResidentialResidentialEquivalent);
    Console.WriteLine("Is Residential SmallCommercial equivalent?: {0}", isResidentialSmallCommercialEquivalent);
    Console.WriteLine("Is SmallCommercial SmallCommercial equivalent?: {0}", isSmallCommercialSmallCommercialAbbreviationEquivalent);
}
```

### More

There are several other variations not documented here. You can find a Console Application with these samples [here](https://github.com/relay-dev/energy/tree/master/samples/Energy.Samples/).