using ProjectApplication.Core;

namespace ProjectApplication.ViewModel
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Auctioneer { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<BidVM> BidVMs { get; set; } = new(); // Updated initialization
     

        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                Auctioneer = auction.Auctioneer,
                StartingPrice = auction.StartingPrice,
                EndDateTime = auction.EndDateTime
            };

            foreach (var bid in auction.Bids)
            {
                detailsVM.BidVMs.Add(BidVM.FromBid(bid));
            }
            return detailsVM;
        }
    }
}
