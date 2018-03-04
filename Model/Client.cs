namespace _300960704_Rodrigo_ASS03.Model
{
    /// <summary>
    /// Class responsible for storing a client from database.
    /// </summary>
    public class Client
    {
        // The client identification.
        public int ClientID { get; set; }

        // The client name.
        public string Name { get; set; }

        // The type of services the client does.
        public string Services { get; set; }

        // The city where the client lives.
        public string City { get; set; }

        // The client's income.
        public decimal Revenue { get; set; }

        // The client's type (active, inactive).
        public ClientType Type { get; set; }
    }
}
