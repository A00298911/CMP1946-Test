namespace ReceiptSplitterLib;

using System;


public class ReceiptSplitter
{
    public static decimal SplitAmount(decimal totalAmount, int numPeople)
    {
        if (numPeople <= 0)
        {
            throw new ArgumentException("Number of people must be greater than zero.");
        }

        if (totalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be greater than zero.");
        }

        decimal splitAmountPerPerson = totalAmount / numPeople;
        return splitAmountPerPerson;
    }
}

public class AverageTipCalculator
{
    public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();

        // Calculate total meal cost
        decimal totalMealCost = 0;
        foreach (var cost in mealCosts.Values)
        {
            totalMealCost += cost;
        }

        // Calculate total tip
        decimal totalTip = totalMealCost * (decimal)(tipPercentage / 100);

        // Calculate tip per person based on their meal cost
        foreach (var tip in mealCosts)
        {
            decimal tipForPerson = tip.Value / totalMealCost * totalTip;
            tipAmounts.Add(tip.Key, tipForPerson);
        }

        return tipAmounts;
    }
}

public class TipPerPerson
{
    public static decimal CalculateTipPerPerson(decimal price, int numPerson, float tipPercentage)
    {
        if (numPerson <= 0)
        {
            throw new ArgumentException("Number of persons must be greater than zero.");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        decimal tipAmount = price * (decimal)(tipPercentage / 100);
        decimal tipPerPerson = tipAmount / numPerson;
        return tipPerPerson;
    }
}