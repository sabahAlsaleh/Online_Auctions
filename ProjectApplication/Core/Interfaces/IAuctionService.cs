using System.Security.Cryptography;

namespace ProjectApplication.Core.Interfaces
{

    public interface IAuctionService
    {
        List<Auction> GetAll();
        List<Auction> GetAllByUserName(string userName);

        Auction GetById(int id);

        void Add(Auction auct);

       void UpdateDescription(int id, string description);
        public bool AddBidToAuct(int auctionId, Bid bid);
        public List<Auction> GetAuctionsByBidder(string bidderUserName);

        public List<Auction> GetCompletedAuctionsByWinner(string winnerUserName);



    }
}
