using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class ReturnForm : Form
{
    private ListBox itemList;
    private Button addButton, finishButton;
    private List<decimal> refundCart = new();

    public ReturnForm()
    {
        Text = "Make a Return";
        Width = 400;
        Height = 300;

        itemList = new ListBox { Top = 10, Left = 10, Width = 360 };
        foreach (var item in InventoryManager.Inventory)
            itemList.Items.Add($"{item.Name} - ${item.Price}");

        addButton = new Button { Text = "Add Return", Top = 200, Left = 10 };
        addButton.Click += AddItem;

        finishButton = new Button { Text = "Finish", Top = 200, Left = 100 };
        finishButton.Click += FinishReturn;

        Controls.Add(itemList);
        Controls.Add(addButton);
        Controls.Add(finishButton);
    }

    void AddItem(object sender, EventArgs e)
    {
        if (itemList.SelectedIndex >= 0)
        {
            var selected = InventoryManager.Inventory[itemList.SelectedIndex];
            refundCart.Add(selected.Price);
            MessageBox.Show($"{selected.Name} added to return cart.");
        }
    }

    void FinishReturn(object sender, EventArgs e)
    {
        decimal total = refundCart.Sum();
        MessageBox.Show($"Your refund total is ${total}.\nThank you for shopping at Target!");
        Close();
    }
}