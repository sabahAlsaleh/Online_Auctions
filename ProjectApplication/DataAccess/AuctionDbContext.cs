using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectApplication.DataAccess
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) {}

        public DbSet<BidDB> BidDBs { get;set; }
        public DbSet<AuctionDB> AuctionDBs { get;set; }

        //för att tala om vilka data som finns i början i databasen
        /* protected override void OnModelCreating(ModelBuilder modelBuilder){
             modelBuilder.Entity<AuctionDB>().HasData(
             new AuctionDB
             {
                 Id= -3,
                 Name= "Learning ASP.NET Core with MVC",
                 Description= "test",
                 Auctioneer="Test2",
                 StartingPrice=0,
                 EndDateTime= DateTime.Now,
                // BidDBs= null 
             });

         }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDB acudp = new AuctionDB
            {
                Id = -1,
                Name = "Auction And Bids plasce",
                UserName= "sabahaa@kth.se",
                Description = "Description 1",
                Auctioneer = "Auctioneer 1",
                StartingPrice = 100,
                EndDateTime = DateTime.Now,
                BidDBs = new List<BidDB>()
            };
            modelBuilder.Entity<AuctionDB>().HasData(acudp);

            BidDB bdb1 = new BidDB()
            {
                Id =-1,
                Bidder = "Bidder1 ",
                Amount = 150,  // Provide a value for the Amount property
                TimePlaced = DateTime.Now,
                AuctionId = -1
            };

            BidDB bdb2 = new BidDB()
            {
                Id =-2,
                Bidder = "Bidder 2",
                Amount = 200,  // Provide a value for the Amount property
                TimePlaced = DateTime.Now,
                AuctionId = -1
            };

            modelBuilder.Entity<BidDB>().HasData(bdb1);
            modelBuilder.Entity<BidDB>().HasData(bdb2);
        }
         */
    }

}