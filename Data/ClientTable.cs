using _300960704_Rodrigo_ASS03.Model;
using System.Collections.Generic;

namespace _300960704_Rodrigo_ASS03.Data
{
    /// <summary>
    /// Class that will store the data contained on the assignment and simulate a table in the system
    /// to be queried by LINQ.
    /// </summary>
    public class ClientTable
    {
        public static List<Client> ClientList = new List<Client>
        {
            new Client
            {
                ClientID = 1,
                Name = "BK Associates",
                Services = "Commercial",
                City = "Toronto",
                Revenue = 230000.00M,
                Type = ClientType.ACTIVE
            },
            new Client
            {
                ClientID = 6,
                Name = "Bick",
                Services = "Industrial",
                City = "Dallas",
                Revenue = 679000.00M,
                Type = ClientType.INACTIVE
            },
            new Client
            {
                ClientID = 19,
                Name = "TPH",
                Services = "Government",
                City = "Atlanta",
                Revenue = 986000.00M,
                Type = ClientType.ACTIVE
            },
            new Client
            {
                ClientID = 12,
                Name = "Crow",
                Services = "Industrial",
                City = "Phoenix",
                Revenue = 126000.00M,
                Type = ClientType.INACTIVE
            },
            new Client
            {
                ClientID = 56,
                Name = "TX Electric",
                Services = "Industrial",
                City = "Portland",
                Revenue = 564000.00M,
                Type = ClientType.ACTIVE
            },
            new Client
            {
                ClientID = 42,
                Name = "GRB",
                Services = "Government",
                City = "Omaha",
                Revenue = 437000.00M,
                Type = ClientType.INACTIVE
            },
            new Client
            {
                ClientID = 98,
                Name = "LB&B",
                Services = "Commercial",
                City = "Toronto",
                Revenue = 990000.00M,
                Type = ClientType.ACTIVE
            },
            new Client
            {
                ClientID = 44,
                Name = "H&P",
                Services = "Commercial",
                City = "Denver",
                Revenue = 122000.00M,
                Type = ClientType.ACTIVE
            },
        };
    }
}
