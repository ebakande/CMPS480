using System.Collections.Generic;

public static class InventoryManager
{
    public static List<(string Name, decimal Price)> Inventory = new()
    {
        ("Lego Star Wars", 25m),
        ("Cookie", 5m)
    };

    public static List<decimal> Sales = new();
    public static int Customers => Sales.Count;

    public static decimal TotalProfit()
    {
        decimal total = 0;
        foreach (var sale in Sales)
            total += sale;
        return total;
    }
}