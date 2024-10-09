using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectApplication.Core;
using ProjectApplication.Core.Interfaces;

namespace ProjectApplication.DataAccess
{
    // implement interface IAuctionPersistence
    public class AuctionSqlPresistence: IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPresistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            var auctionDBs = _dbContext.AuctionDBs.Where(p => p.UserName.Equals(userName)).ToList();// update the Identity

            List<Auction> auctionsRes = new List<Auction>();
            foreach (AuctionDB adb in auctionDBs)
            {
              
                Auction auct = _mapper.Map<Auction>(adb);
                auctionsRes.Add(auct);
            }
            return auctionsRes;

        }

        public List<Auction> GetAll()
        {
            var auctionDBs = _dbContext.AuctionDBs.ToList();
            List<Auction> auctionsRes = new List<Auction>();
            foreach (AuctionDB adb in auctionDBs)
            {
                Auction auct = _mapper.Map<Auction>(adb);
                auctionsRes.Add(auct);
            }
            return auctionsRes;
        }

        public Auction GetById(int id)
        {
            // Eager loading
            var auctionsDB = _dbContext.AuctionDBs
                .Include(a => a.BidDBs)
                .Where(a => a.Id == id)
                .SingleOrDefault();

            Auction auct = _mapper.Map<Auction>(auctionsDB);
            foreach (BidDB bdb in auctionsDB.BidDBs)
            {
                auct.AddBid(_mapper.Map<Bid>(bdb));
            }
            return auct;
        }

       public void UpdateDescription(int id, string description)
        {
            var auction = _dbContext.AuctionDBs.Find(id);
            if (auction != null)
            {
                auction.Description = description;
                _dbContext.SaveChanges();
            }
        }
        public void Add(Auction auct)
        {
            AuctionDB adb = _mapper.Map<AuctionDB>(auct);
            _dbContext.AuctionDBs.Add(adb);
            _dbContext.SaveChanges();
        }

        public bool AddBidToAuct(int auctionId, Bid bid)
        {
            var auctionsDB = _dbContext.AuctionDBs.Find(auctionId);
            BidDB bidDB = _mapper.Map<BidDB>(bid);

            auctionsDB.BidDBs.Add(bidDB);
            _dbContext.SaveChanges();

            return true; 
         
        }
        public List<Auction> GetAuctionsByBidder(string bidderUserName)
        {
            var auctionDBs = _dbContext.AuctionDBs
                .Include(a => a.BidDBs)
                .Where(a => a.BidDBs.Any(b => b.Bidder == bidderUserName))
                .ToList();

            List<Auction> auctionsRes = new List<Auction>();
            foreach (AuctionDB adb in auctionDBs)
            {
                Auction auct = _mapper.Map<Auction>(adb);
                foreach (BidDB bdb in adb.BidDBs)
                {
                    auct.AddBid(_mapper.Map<Bid>(bdb));
                }
                auctionsRes.Add(auct);
            }
            return auctionsRes;
        }

        public List<Auction> GetCompletedAuctionsByWinner(string winnerUserName)
        {
            var completedAuctionsDB = _dbContext.AuctionDBs
                .Include(a => a.BidDBs)
                .Where(a => a.EndDateTime <= DateTime.Now)  // Check if the auction has ended
                .ToList();

            List<Auction> completedAuctionsRes = new List<Auction>();

            foreach (AuctionDB adb in completedAuctionsDB)
            {
                BidDB highestBid = adb.BidDBs.OrderByDescending(b => b.Amount).FirstOrDefault(); // Find the highest bid

                if (highestBid != null && highestBid.Bidder == winnerUserName)
                {
                    Auction auct = _mapper.Map<Auction>(adb);
                    foreach (BidDB bdb in adb.BidDBs)
                    {
                        auct.AddBid(_mapper.Map<Bid>(bdb));
                    }
                    completedAuctionsRes.Add(auct);
                }
            }

            return completedAuctionsRes;
        }


    }

}
