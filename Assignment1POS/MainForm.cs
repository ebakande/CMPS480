using System;
using System.Windows.Forms;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "Target POS System";
        Width = 400;
        Height = 300;

        var purchaseBtn = new Button { Text = "Make a Purchase", Top = 30, Width = 300, Left = 40 };
        purchaseBtn.Click += (s, e) => new PurchaseForm().ShowDialog();

        var returnBtn = new Button { Text = "Make a Return", Top = 70, Width = 300, Left = 40 };
        returnBtn.Click += (s, e) => new ReturnForm().ShowDialog();

        var inventoryBtn = new Button { Text = "Manage Inventory", Top = 110, Width = 300, Left = 40 };
        inventoryBtn.Click += (s, e) => new InventoryForm().ShowDialog();

        var reportBtn = new Button { Text = "View Report", Top = 150, Width = 300, Left = 40 };
        reportBtn.Click += (s, e) => new ReportForm().ShowDialog();

        Controls.Add(purchaseBtn);
        Controls.Add(returnBtn);
        Controls.Add(inventoryBtn);
        Controls.Add(reportBtn);
    }
}