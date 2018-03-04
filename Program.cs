using _300960704_Rodrigo_ASS03.Data;
using _300960704_Rodrigo_ASS03.Model;
using System;
using System.Linq;

namespace _300960704_Rodrigo_ASS03
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            do
            {
                Console.Write("What do you want to do: Query (I)nventory, query (C)lients, or (Q)uit? ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "I":
                        QueryInventory();
                        break;

                    case "C":
                        QueryClients();
                        break;

                    case "Q":
                        quit = true;
                        break;

                    default:
                        Console.WriteLine($"Invalid value entered '{userInput}'. Check the possible values and please, try again!");
                        break;
                }
            }
            while (!quit);
        }

        /// <summary>
        /// Performs the requested queries in the inventory.
        /// </summary>
        private static void QueryInventory()
        {
            SortByDescription();
            SelectDescriptionQuantitySortedByQuantity();
            SelectDescriptionTotalValueSortedByTotalValue();
            MostExpensiveItem();
            ReducePriceBy10Percent();
        }

        /// <summary>
        /// Sorts all the inventory items by description.
        /// </summary>
        private static void SortByDescription()
        {
            // Queries the data.
            var sortedByDescription = from item in InventoryItemTable.InventoryItemList
                                      orderby item.ItemDescription
                                      select item;

            // Prints the data
            string title = "Sorted by Description";
            int center = (88 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine(String.Format("{0,-89}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine("| Item#           | Item Description                    | Quantity       | Unit Price    |");
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");

            foreach (var item in sortedByDescription)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,14} | {3,13} |", item.ItemNumber.ToString(), item.ItemDescription, item.Quantity.ToString(), item.UnitPrice.ToString("#.00")));
            }

            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+\n\n");
        }

        /// <summary>
        /// Selects the description and the quantity and sorts by quantity.
        /// </summary>
        private static void SelectDescriptionQuantitySortedByQuantity()
        {
            // Queries the data.
            var descriptionQuantitySortedByQuantity = from item in InventoryItemTable.InventoryItemList
                                                      orderby item.Quantity
                                                      select new { item.ItemDescription, item.Quantity };
            // Prints the data
            string title = "Description and Quantity Sorted by Quantity";
            int center = (54 + title.Length) / 2;
            Console.WriteLine("+-------------------------------------+----------------+");
            Console.WriteLine(String.Format("{0,-55}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-------------------------------------+----------------+");
            Console.WriteLine("| Item Description                    | Quantity       |");
            Console.WriteLine("+-------------------------------------+----------------+");

            foreach (var item in descriptionQuantitySortedByQuantity)
            {
                Console.WriteLine(String.Format("| {0,-35} | {1,14} |", item.ItemDescription, item.Quantity.ToString()));
            }

            Console.WriteLine("+-------------------------------------+----------------+\n\n");
        }

        /// <summary>
        /// Selects the description and the total value (quantity * unit price) and sorts by total value.
        /// </summary>
        private static void SelectDescriptionTotalValueSortedByTotalValue()
        {
            // Queries the data.
            var descriptionTotalValueSortedByTotalValue = from sorted in (
                                                              from item in InventoryItemTable.InventoryItemList
                                                              select new { item.ItemDescription, TotalValue = item.Quantity * item.UnitPrice }
                                                          )
                                                          orderby sorted.TotalValue
                                                          select sorted;
            // Prints the data
            string title = "Description and Total Value Sorted by Total Value";
            int center = (54 + title.Length) / 2;
            Console.WriteLine("+-------------------------------------+----------------+");
            Console.WriteLine(String.Format("{0,-55}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-------------------------------------+----------------+");
            Console.WriteLine("| Item Description                    | Total Value    |");
            Console.WriteLine("+-------------------------------------+----------------+");

            foreach (var item in descriptionTotalValueSortedByTotalValue)
            {
                Console.WriteLine(String.Format("| {0,-35} | {1,14} |", item.ItemDescription, item.TotalValue.ToString("#.00")));
            }

            Console.WriteLine("+-------------------------------------+----------------+\n\n");
        }

        /// <summary>
        /// Gets the most expensive item.
        /// </summary>
        private static void MostExpensiveItem()
        {
            // Queries the data.
            var mostExpensiveItem = from item in InventoryItemTable.InventoryItemList
                                    orderby item.UnitPrice descending
                                    select item;

            // Prints the data
            string title = "Most Expensive Item";
            int center = (88 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine(String.Format("{0,-89}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine("| Item#           | Item Description                    | Quantity       | Unit Price    |");
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            var first = mostExpensiveItem.First();
            Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,14} | {3,13} |", first.ItemNumber.ToString(), first.ItemDescription, first.Quantity.ToString(), first.UnitPrice.ToString("#.00")));
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+\n\n");
        }

        /// <summary>
        /// Reduces the prices of all itens by 10%.
        /// </summary>
        private static void ReducePriceBy10Percent()
        {
            // Queries the data.
            var reducedPriceBy10Percent = InventoryItemTable.InventoryItemList.Select(item => { item.UnitPrice *= 0.90M; return item; }).ToList();

            // Prints the data
            string title = "Prices Reduced by 10%";
            int center = (88 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine(String.Format("{0,-89}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");
            Console.WriteLine("| Item#           | Item Description                    | Quantity       | Unit Price    |");
            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+");

            foreach (var item in reducedPriceBy10Percent)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,14} | {3,13} |", item.ItemNumber.ToString(), item.ItemDescription, item.Quantity.ToString(), item.UnitPrice.ToString("#.00")));
            }

            Console.WriteLine("+-----------------+-------------------------------------+----------------+---------------+\n");
        }

        private static void QueryClients()
        {
            SortByClientID();
            SortByNameCity();
            SelectGovernmentSortedByRevenue();
            SelectActiveAndCalculateTotalRevenue();
            MostImportantClient();
        }

        /// <summary>
        /// Sorts all the clients by client ID.
        /// </summary>
        private static void SortByClientID()
        {
            // Queries the data.
            var sortedByClientID = from client in ClientTable.ClientList
                                   orderby client.ClientID
                                   select client;

            // Prints the data
            string title = "Sorted by Client ID";
            int center = (120 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine(String.Format("{0,-121}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine("| Client ID       | Client Name                         | Client Services | Client City   | Client Revenue | Client Type |");
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");

            foreach (var client in sortedByClientID)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,15} | {3,13} | {4,14} | {5,11} |",
                    client.ClientID.ToString(), client.Name, client.Services, client.City, client.Revenue.ToString("#,000.00"), client.Type.ToString()
                ));
            }

            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+\n\n");
        }

        /// <summary>
        /// Sorts all the clients by name and city.
        /// </summary>
        private static void SortByNameCity()
        {
            // Queries the data.
            var sortedByNameCity = from client in ClientTable.ClientList
                                   orderby client.Name, client.City
                                   select client;

            // Prints the data
            string title = "Sorted by Name and City";
            int center = (120 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine(String.Format("{0,-121}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine("| Client ID       | Client Name                         | Client Services | Client City   | Client Revenue | Client Type |");
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");

            foreach (var client in sortedByNameCity)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,15} | {3,13} | {4,14} | {5,11} |",
                    client.ClientID.ToString(), client.Name, client.Services, client.City, client.Revenue.ToString("#,000.00"), client.Type.ToString()
                ));
            }

            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+\n\n");
        }

        /// <summary>
        /// Selects all the government clients sorted by their revenue.
        /// </summary>
        private static void SelectGovernmentSortedByRevenue()
        {
            // Queries the data.
            var selectGovernmentSortedByRevenue = from client in ClientTable.ClientList
                                                  where client.Services == "Government"
                                                  orderby client.Revenue
                                                  select client;

            // Prints the data
            string title = "Government Clients Sorted by Revenue";
            int center = (120 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine(String.Format("{0,-121}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine("| Client ID       | Client Name                         | Client Services | Client City   | Client Revenue | Client Type |");
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");

            foreach (var client in selectGovernmentSortedByRevenue)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,15} | {3,13} | {4,14} | {5,11} |",
                    client.ClientID.ToString(), client.Name, client.Services, client.City, client.Revenue.ToString("#,000.00"), client.Type.ToString()
                ));
            }

            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+\n\n");
        }

        /// <summary>
        /// Gets all active clients and calculates their total revenue.
        /// </summary>
        private static void SelectActiveAndCalculateTotalRevenue()
        {
            // Queries the data.
            var selectActiveAndCalculateTotalRevenue = from client in ClientTable.ClientList
                                                       where client.Type == ClientType.ACTIVE
                                                       group client by new { client.Type } into grouped
                                                       select new {
                                                           grouped.Key.Type, TotalRevenue = grouped.Sum(client => client.Revenue)
                                                       };

            // Prints the data
            string title = "Active Clients Total Revenue ";
            int center = (31 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------+");
            Console.WriteLine(String.Format("{0,-32}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------+");
            Console.WriteLine("| Total Revenue   | Client Type |");
            Console.WriteLine("+-----------------+-------------+");

            foreach (var client in selectActiveAndCalculateTotalRevenue)
            {
                Console.WriteLine(String.Format("| {0,15} | {1,-11} |", client.TotalRevenue.ToString("#,000.00"), client.Type.ToString()));
            }

            Console.WriteLine("+-----------------+-------------+\n\n");
        }

        /// <summary>
        /// Retrieves the most important client that is the one active with the greatest revenue.
        /// </summary>
        private static void MostImportantClient()
        {
            // Queries the data.
            var mostImportantClient = from client in ClientTable.ClientList
                                      where client.Type == ClientType.ACTIVE
                                      orderby client.Revenue descending
                                      select client;

            // Prints the data
            string title = "Government Clients Sorted by Revenue";
            int center = (120 + title.Length) / 2;
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine(String.Format("{0,-121}|", String.Format("|{0," + center + "}", title.ToUpper())));
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            Console.WriteLine("| Client ID       | Client Name                         | Client Services | Client City   | Client Revenue | Client Type |");
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+");
            var first = mostImportantClient.First();
            Console.WriteLine(String.Format("| {0,15} | {1,-35} | {2,15} | {3,13} | {4,14} | {5,11} |",
                first.ClientID.ToString(), first.Name, first.Services, first.City, first.Revenue.ToString("#,000.00"), first.Type.ToString()
            ));
            Console.WriteLine("+-----------------+-------------------------------------+-----------------+---------------+----------------+-------------+\n");
        }
    }
}
