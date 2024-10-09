using System.Security.Cryptography;

namespace ProjectApplication.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String UserName { get; set;}
        public string Description { get; set; }
        public string Auctioneer { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<Bid> _bids { get; } = new List<Bid>();
        public List<Bid> Bids => _bids;
        public Auction() { }

        public Auction(int id, string name, string description, string auctioneer, decimal startingPrice, DateTime endDateTime)
        {
            Id= id;
            Name = name;
            Description = description;
            Auctioneer = auctioneer;
            StartingPrice = startingPrice;
            EndDateTime = endDateTime;
        }

        public void AddBid(Bid newBid)
        {
            _bids.Add(newBid);
        }
      
    }
}
