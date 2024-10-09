using ProjectApplication.Core.Interfaces;

namespace ProjectApplication.Core
{
    public class AuctionService: IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;
        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;

        }
        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetAllByUserName(string userName){
            return _auctionPersistence.GetAllByUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _auctionPersistence.GetById(id);  
        }

       public  void UpdateDescription(int id, string description){
            _auctionPersistence.UpdateDescription (id, description); 
        }
        public void Add(Auction auct)
        {
            //assume no bids in new auction
            if (auct == null || auct.Id != 0) throw new InvalidDataException();
            _auctionPersistence.Add(auct);
        }


        public bool AddBidToAuct(int auctionId, Bid bid)
        {
            return _auctionPersistence.AddBidToAuct(auctionId, bid);
        }

        public List<Auction> GetAuctionsByBidder(string bidderUserName)
        {
            return _auctionPersistence.GetAuctionsByBidder(bidderUserName);
        } 
        public List<Auction> GetCompletedAuctionsByWinner(string winnerUserName)
        {
            return _auctionPersistence.GetCompletedAuctionsByWinner(winnerUserName);
        }

    }
}
