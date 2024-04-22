using System;
using ReceiptSplitterLib;

namespace ReceiptSplitterLibTest;


[TestClass]
public class SplitterTests
{
    [TestMethod]
    public void SplitAmount_EqualTotalAmountAndPeople_EqualSplitAmount()
    {
        // Arrange
        decimal totalAmount = 100.0M;
        int numPeople = 4;
        decimal expectedSplitAmount = 25.0M; // Expected split amount per person

        // Act
        decimal splitAmount = ReceiptSplitter.SplitAmount(totalAmount, numPeople);

        // Assert
        Assert.AreEqual(expectedSplitAmount, splitAmount);
    }

    [TestMethod]
    public void SplitAmount_DifferentTotalAmountAndPeople_CorrectSplitAmount()
    {
        // Arrange
        decimal totalAmount = 150.0M;
        int numPeople = 5;
        decimal expectedSplitAmount = 30.0M; // Expected split amount per person

        // Act
        decimal splitAmount = ReceiptSplitter.SplitAmount(totalAmount, numPeople);

        // Assert
        Assert.AreEqual(expectedSplitAmount, splitAmount);
    }

    [TestMethod]
    public void SplitAmount_ZeroTotalAmount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalAmount = 0.0M;
        int numPeople = 3;

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => ReceiptSplitter.SplitAmount(totalAmount, numPeople));
    }
}


[TestClass]
public class AverageTipCalculatorTests
{
    [TestMethod]
    public void CalculateTip_EqualMealCosts_EqualTipAmounts()
    {
     
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>()
        {
            {"Alice", 30.0M},
            {"Bob", 30.0M},
            {"Charlie", 30.0M}
        };

        float tipPercentage = 10.0f; // 10% tip
        decimal expectedTip = 9.0M; // Expected tip amount for each person

        Dictionary<string, decimal> tipAmounts = AverageTipCalculator.CalculateTip(mealCosts, tipPercentage);

        foreach (var tip in tipAmounts)
        {
            Assert.AreEqual(expectedTip, tip.Value);
        }
    }

    private static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public void CalculateTip_DifferentMealCosts_CorrectTipAmounts()
    {
 
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>()
        {
            {"Alice", 25.0M},
            {"Bob", 30.0M},
            {"Charlie", 20.0M}
        };

        float tipPercentage = 15.0f; // 15% tip
        decimal[] expectedTips = { 5.0M, 6.0M, 4.0M }; // Expected tip amount for each person

        Dictionary<string, decimal> tipAmounts = AverageTipCalculator.CalculateTip(mealCosts, tipPercentage);

        int i = 0;
        foreach (var tip in tipAmounts)
        {
            Assert.AreEqual(expectedTips[i], tip.Value);
            i++;
        }
    }

    [TestMethod]
    public void CalculateTip_ZeroMealCosts_ZeroTipAmounts()
    {
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>()
        {
            {"Alice", 0.0M},
            {"Bob", 0.0M},
            {"Charlie", 0.0M}
        };
        float tipPercentage = 20.0f; // 20% tip

        Dictionary<string, decimal> tipAmounts = AverageTipCalculator.CalculateTip(mealCosts, tipPercentage);

        foreach (var tip in tipAmounts)
        {
            Assert.AreEqual(0.0M, tip.Value);
        }
    }
}


[TestClass]
public class TipPerPersonTests
{
    [TestMethod]
    public void CalculateTipPerPerson_EqualPriceAndPatrons_EqualTipPerPerson()
    {
        decimal price = 100.0M;
        int numPatrons = 4;
        float tipPercentage = 10.0f; // 10% tip
        decimal expectedTipPerPerson = 2.50M; // Expected tip per person

        decimal tipPerPerson = TipPerPerson.CalculateTipPerPerson(price, numPatrons, tipPercentage);

        Assert.AreEqual(expectedTipPerPerson, tipPerPerson);
    }

    [TestMethod]
    public void CalculateTipPerPerson_DifferentPriceAndPatrons_CorrectTipPerPerson()
    {
        decimal price = 150.0M;
        int numPatrons = 5;
        float tipPercentage = 15.0f; // 15% tip
        decimal expectedTipPerPerson = 4.50M; // Expected tip per person

        decimal tipPerPerson = TipPerPerson.CalculateTipPerPerson(price, numPatrons, tipPercentage);

        Assert.AreEqual(expectedTipPerPerson, tipPerPerson);
    }

    [TestMethod]
    public void CalculateTipPerPerson_ZeroPrice_ZeroTipPerPerson()
    {
        decimal price = 0.0M;
        int numPatrons = 3;
        float tipPercentage = 20.0f; // 20% tip

        Assert.ThrowsException<ArgumentException>(() => TipPerPerson.CalculateTipPerPerson(price, numPatrons, tipPercentage));
    }
}