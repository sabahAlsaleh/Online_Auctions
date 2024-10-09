using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectApplication.DataAccess
{
    public class BidDB
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        public string Bidder { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimePlaced { get; set; }

        // FKey
        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }
        public int AuctionId { get; set; }
    }
}
