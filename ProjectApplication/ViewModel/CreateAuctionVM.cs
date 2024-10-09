using System.ComponentModel.DataAnnotations;

namespace ProjectApplication.ViewModel
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(256, ErrorMessage = "Max length 128 characters")]
        public string Description { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Auctioneer { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }
        //public List<BidVM> BidVMs { get; set; } = new();
    }
}
