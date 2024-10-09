using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApplication.Core;
using ProjectApplication.Core.Interfaces;
using ProjectApplication.Migrations.AuctionDb;
using ProjectApplication.ViewModel;
using System.Security.Cryptography;

namespace ProjectApplication.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionService _auctionService;
        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        public ActionResult Index()
        {
            string userName = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAllByUserName(userName);

            List<AuctionVM> autionsVMs = new();
            foreach (var acu in auctions)
            {
                autionsVMs.Add(AuctionVM.FromAution(acu));
            }
            return View(autionsVMs);
        }

        public ActionResult ActiveAuctions()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> autionsVMs = new();
            foreach (var acu in auctions)
            {
                autionsVMs.Add(AuctionVM.FromAution(acu));
            }
            autionsVMs = autionsVMs.OrderBy(a => a.EndDateTime).ToList(); // Sort by end date

            return View(autionsVMs);
        }

        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            Auction auct = _auctionService.GetById(id);

            if (auct == null)
            {
                return NotFound();
            }

            // Check if the user is the owner of the auction or if the auction has expired
            if (!User.Identity.IsAuthenticated || (!auct.UserName.Equals(User.Identity.Name) && auct.EndDateTime > DateTime.Now))
            {
                return Unauthorized();
            }

            AuctionDetailsVM dvm = AuctionDetailsVM.FromAuction(auct);
            // Sort the bids in descending order
            dvm.BidVMs = dvm.BidVMs.OrderByDescending(b => b.Amount).ToList();

            return View(dvm);
        }

        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            Auction auction = _auctionService.GetById(id);

            // Check if the user is the owner of the auction
            if (auction == null || !auction.UserName.Equals(User.Identity.Name))
            {
                return NotFound();
            }
            return View();
        }

        // POST: AuctionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string description)
        {
            Auction auction = _auctionService.GetById(id);
            // Check if the user is the owner of the auction
            if (auction == null || !auction.UserName.Equals(User.Identity.Name))
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _auctionService.UpdateDescription(id, description);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            if (ModelState.IsValid)
            {
                Auction auct = new Auction()
                {
                    Name = vm.Title,
                    UserName = User.Identity.Name,
                    Description = vm.Description,
                    Auctioneer = vm.Auctioneer,
                    StartingPrice = vm.StartingPrice,
                    EndDateTime = vm.EndDateTime

                };
                // Ensure the user creating the auction is the owner
                if (!auct.UserName.Equals(User.Identity.Name))
                {
                    return BadRequest("Unauthorized access.");
                }


                _auctionService.Add(auct);
                return RedirectToAction("Index");
            }
            return View(vm);

        }

        public ActionResult AddBid(int id)
        {
            Auction auction = _auctionService.GetById(id);

            // Check if the user is the owner of the auction
            if (auction == null || !auction.UserName.Equals(User.Identity.Name))
            {
                return NotFound();
            }

            BidVM bidVm = new BidVM
            {
                Bidder = User.Identity.Name,
                TimePlaced = DateTime.Now
            };

            return View(bidVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid(int id, BidVM vm)
        {
            if (ModelState.IsValid)
            {
                Auction auction = _auctionService.GetById(id);
                // Check if the user is the owner of the auction
                if (auction == null || !auction.UserName.Equals(User.Identity.Name))
                {
                    return NotFound();
                }

                // Get the current highest bid or the starting price
                decimal currentHighestBid = auction.Bids.Any() ? auction.Bids.Max(b => b.Amount) : auction.StartingPrice;

                if (vm.Amount > currentHighestBid)
                {
                    Bid bid = new Bid()
                    {
                        Bidder = vm.Bidder,
                        Amount = vm.Amount,
                        TimePlaced = DateTime.Now
                    };

                    bool bidAdded = _auctionService.AddBidToAuct(id, bid);

                    // Retrieve the updated auction details after adding the bid
                    Auction updatedAuction = _auctionService.GetById(id);
                    AuctionDetailsVM updatedAuctionDetails = AuctionDetailsVM.FromAuction(updatedAuction);
                    // Sort the bids in descending order
                    updatedAuctionDetails.BidVMs = updatedAuctionDetails.BidVMs.OrderByDescending(b => b.Amount).ToList();

                    return View("Details", updatedAuctionDetails);
                }
                else
                {
                    // Bid amount is not higher than the current highest bid or starting price
                    ModelState.AddModelError("Amount", "Bid amount must be higher than the current highest bid or starting price.");
                }
            }
            return View("AddBid", vm);
        }

        // 7
        [HttpGet]
        [HttpPost]
        public ActionResult UserBids()
        {
            string userName = User.Identity.Name;

            List<Auction> auctionsWithBids = _auctionService.GetAuctionsByBidder(userName);
            List<AuctionDetailsVM> autionsVMs = new List<AuctionDetailsVM>();

            foreach (var acu in auctionsWithBids)
            {
                if (acu.UserName.Equals(userName))
                {
                    autionsVMs.Add(AuctionDetailsVM.FromAuction(acu));
                }
            }

            return View(autionsVMs);
        }

        // 8
        public ActionResult CompletedAuctions()
        {
            string userName = User.Identity.Name;
            List<Auction> completedAuctions = _auctionService.GetCompletedAuctionsByWinner(userName);

            List<AuctionDetailsVM> completedAuctionsVMs = new List<AuctionDetailsVM>();

            foreach (var auction in completedAuctions)
            {
                completedAuctionsVMs.Add(AuctionDetailsVM.FromAuction(auction));
            }

            return View(completedAuctionsVMs);
        }


    }
}
