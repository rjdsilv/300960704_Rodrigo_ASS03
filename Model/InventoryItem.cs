namespace _300960704_Rodrigo_ASS03.Model
{
    /// <summary>
    /// Class responsible for storing an item from database.
    /// </summary>
    public class InventoryItem
    {
        // The item number (unique ID).
        public int ItemNumber { get; set; }

        // The item description.
        public string ItemDescription { get; set; }

        // The quantity in the inventory.
        public int Quantity { get; set; }

        // The item unitary price.
        public decimal UnitPrice { get; set; }
    }
}
