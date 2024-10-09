using System.ComponentModel.DataAnnotations;

namespace ProjectApplication.DataAccess
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public String UserName { get; set;}

        [Required] // Not null
        [MaxLength(256)]
        public string Description { get; set; }
        [Required]
        public string Auctioneer { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

       public List<BidDB> BidDBs { get; set; } = new List<BidDB>();
      
    }
}
