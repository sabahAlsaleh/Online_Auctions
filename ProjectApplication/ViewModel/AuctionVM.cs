using ProjectApplication.Core;

namespace ProjectApplication.ViewModel
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Auctioneer { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime EndDateTime { get; set; }

        public static AuctionVM FromAution(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                UserName = auction.UserName,
                Description = auction.Description,
                Auctioneer = auction.Auctioneer,
                StartingPrice = auction.StartingPrice,
                EndDateTime = auction.EndDateTime
            };
        }
    }
}
