using _300960704_Rodrigo_ASS03.Model;
using System.Collections.Generic;

namespace _300960704_Rodrigo_ASS03.Data
{
    /// <summary>
    /// Class that will store the data contained on the assignment and simulate a table in the system
    /// to be queried by LINQ.
    /// </summary>
    public class InventoryItemTable
    {
        public static List<InventoryItem> InventoryItemList = new List<InventoryItem>
        {
            new InventoryItem()
            {
                ItemNumber = 83,
                ItemDescription = "Electric sander",
                Quantity = 7,
                UnitPrice = 59.98M
            },
            new InventoryItem()
            {
                ItemNumber = 24,
                ItemDescription = "Power saw",
                Quantity = 18,
                UnitPrice = 99.99M
            },
            new InventoryItem()
            {
                ItemNumber = 7,
                ItemDescription = "Sledge hammer",
                Quantity = 11,
                UnitPrice = 21.55M
            },
            new InventoryItem()
            {
                ItemNumber = 77,
                ItemDescription = "Hammer",
                Quantity = 76,
                UnitPrice = 11.99M
            },
            new InventoryItem()
            {
                ItemNumber = 39,
                ItemDescription = "Lawn mower",
                Quantity = 3,
                UnitPrice = 79.95M
            },
            new InventoryItem()
            {
                ItemNumber = 68,
                ItemDescription = "Screwdriver",
                Quantity = 106,
                UnitPrice = 7.99M
            },
            new InventoryItem()
            {
                ItemNumber = 56,
                ItemDescription = "Jig Saw",
                Quantity = 21,
                UnitPrice = 11.95M
            },
            new InventoryItem()
            {
                ItemNumber = 3,
                ItemDescription = "Wrench",
                Quantity = 34,
                UnitPrice = 7.95M
            }
        };
    }
}
