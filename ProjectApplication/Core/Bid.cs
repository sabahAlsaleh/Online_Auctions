namespace ProjectApplication.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public string Bidder { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        // Constructor
        public Bid() { }    
        public Bid( string bidder, decimal amount)
        {
            Bidder = bidder;
            Amount = amount;
            TimePlaced = DateTime.Now;
        }
         public Bid(int id, string bidder, decimal amount)
        {
            Id = id;
            Bidder = bidder;
            Amount = amount;
            TimePlaced = DateTime.Now;
        }
        public Bid(int id, string bidder, decimal amount, DateTime timePlaced)
        {
            Id = id;
            Bidder = bidder;
            Amount = amount;
            TimePlaced = timePlaced;
        }



    }

}
