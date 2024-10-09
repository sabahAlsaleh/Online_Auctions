using System.ComponentModel.DataAnnotations;

namespace ProjectApplication.ViewModel
{
    public class AuctionDesEditVM
    {
        [Required]
        [StringLength(256, ErrorMessage = "Max length 128 characters")]
        public string Description { get; set; }
    }
}
