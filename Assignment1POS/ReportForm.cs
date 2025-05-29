using System;
using System.Windows.Forms;

public class ReportForm : Form
{
    public ReportForm()
    {
        Text = "Reports";
        Width = 400;
        Height = 200;

        int customers = InventoryManager.Customers;
        decimal profit = InventoryManager.TotalProfit();

        var label = new Label
        {
            Text = $"Total Customers: {customers}\nTotal Profit: ${profit}",
            AutoSize = true,
            Top = 50,
            Left = 50
        };

        var closeButton = new Button { Text = "Main Menu", Top = 100, Left = 50 };
        closeButton.Click += (s, e) => Close();

        Controls.Add(label);
        Controls.Add(closeButton);
    }
}