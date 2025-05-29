using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class PurchaseForm : Form
{
    private ListBox itemList;
    private Button addButton, finishButton;
    private List<decimal> cart = new();

    public PurchaseForm()
    {
        Text = "Make a Purchase";
        Width = 400;
        Height = 300;

        itemList = new ListBox { Top = 10, Left = 10, Width = 360 };
        foreach (var item in InventoryManager.Inventory)
            itemList.Items.Add($"{item.Name} - ${item.Price}");

        addButton = new Button { Text = "Add Item", Top = 200, Left = 10 };
        addButton.Click += AddItem;

        finishButton = new Button { Text = "Finish", Top = 200, Left = 100 };
        finishButton.Click += FinishPurchase;

        Controls.Add(itemList);
        Controls.Add(addButton);
        Controls.Add(finishButton);
    }

    void AddItem(object sender, EventArgs e)
    {
        if (itemList.SelectedIndex >= 0)
        {
            var selected = InventoryManager.Inventory[itemList.SelectedIndex];
            cart.Add(selected.Price);
            MessageBox.Show($"{selected.Name} added to cart.");
        }
    }

    void FinishPurchase(object sender, EventArgs e)
    {
        decimal total = cart.Sum();
        InventoryManager.Sales.Add(total);
        MessageBox.Show($"Your total is ${total}.\nThank you for shopping at Target!");
        Close();
    }
}