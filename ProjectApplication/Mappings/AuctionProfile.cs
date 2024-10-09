using AutoMapper;
using ProjectApplication.Core;
using ProjectApplication.DataAccess;

namespace ProjectApplication.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            //Default mapping when property names are same
            CreateMap<AuctionDB, Auction>().ReverseMap();
        }
    }
}
