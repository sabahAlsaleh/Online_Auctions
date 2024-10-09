using ProjectApplication.Core;

namespace ProjectApplication.ViewModel
{
    public class BidVM
    {
        public int Id { get; set; }
        public string Bidder { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimePlaced { get; set; }

        public static BidVM FromBid (Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Bidder = bid.Bidder,
                Amount = bid.Amount,
                TimePlaced = bid.TimePlaced
            };
          

        }
    }
}
