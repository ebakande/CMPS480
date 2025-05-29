using System;
using System.Linq;
using System.Windows.Forms;

public class InventoryForm : Form
{
    private ListBox inventoryList;
    private Button addButton, removeButton, refreshButton;

    public InventoryForm()
    {
        Text = "Manage Inventory";
        Width = 400;
        Height = 350;

        inventoryList = new ListBox { Top = 10, Left = 10, Width = 360, Height = 200 };
        RefreshList();

        addButton = new Button { Text = "Add Item", Top = 220, Left = 10 };
        addButton.Click += AddItem;

        removeButton = new Button { Text = "Remove Item", Top = 220, Left = 100 };
        removeButton.Click += RemoveItem;

        refreshButton = new Button { Text = "Refresh", Top = 220, Left = 200 };
        refreshButton.Click += (s, e) => RefreshList();

        Controls.Add(inventoryList);
        Controls.Add(addButton);
        Controls.Add(removeButton);
        Controls.Add(refreshButton);
    }

    void RefreshList()
    {
        inventoryList.Items.Clear();
        foreach (var item in InventoryManager.Inventory)
            inventoryList.Items.Add($"{item.Name} - ${item.Price}");
    }

    void AddItem(object sender, EventArgs e)
    {
        string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Item Name:", "Add Item");
        string priceStr = Microsoft.VisualBasic.Interaction.InputBox("Enter Item Price:", "Add Item");
        if (decimal.TryParse(priceStr, out decimal price))
        {
            InventoryManager.Inventory.Add((name, price));
            MessageBox.Show("Item added successfully!");
            RefreshList();
        }
        else
        {
            MessageBox.Show("Invalid price.");
        }
    }

    void RemoveItem(object sender, EventArgs e)
    {
        string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Item Name to Remove:", "Remove Item");
        var item = InventoryManager.Inventory.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(item.Name))
        {
            InventoryManager.Inventory.Remove(item);
            MessageBox.Show("Item removed successfully!");
            RefreshList();
        }
        else
        {
            MessageBox.Show("Item Not Found! Please Try Again!");
        }
    }
}